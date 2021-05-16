using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;

using Entities.Dtos;


namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IKullaniciService _kullaniciService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IKullaniciService kullaniciService, ITokenHelper tokenHelper)
        {
            _kullaniciService = kullaniciService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<Kullanici> Register(KullaniciKayitDto kullaniciKayitDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new Kullanici
            {
                Email = kullaniciKayitDto.Email,
                TC=kullaniciKayitDto.TC,
                Adi = kullaniciKayitDto.Adi,
                Soyadi = kullaniciKayitDto.Soyadi,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                Adres=kullaniciKayitDto.Adres,

            };
            _kullaniciService.Add(user);
            return new SuccessDataResult<Kullanici>(user, "Kayıt oldu");
        }

        public IDataResult<Kullanici> Login(KullaniciGirisDto kullaniciGirisDto)
        {
            var userToCheck = _kullaniciService.GetByMail(kullaniciGirisDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<Kullanici>("Kullanıcı bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(kullaniciGirisDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Kullanici>("Parola hatası");
            }

            return new SuccessDataResult<Kullanici>(userToCheck, "Başarılı giriş");
        }

        public IResult UserExists(string email)
        {
            if (_kullaniciService.GetByMail(email) != null)
            {
                return new ErrorResult("Kullanıcı mevcut");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(Kullanici user)
        {
            var claims = _kullaniciService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");
        }
    }
}