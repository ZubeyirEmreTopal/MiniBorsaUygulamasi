using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Business.Constants;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IKullaniciService _kullaniciService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IKullaniciService kullaniciService, ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
            _kullaniciService = kullaniciService;

        }

        public IDataResult<AccessToken> CreateAccessToken(Kullanici kullanici)
        {
            var claims = _kullaniciService.GetClaims(kullanici);
            var accessToken = _tokenHelper.CreateToken(kullanici, claims);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.TokenOlusturuldu);
        }

        public IDataResult<Kullanici> Giris(KullaniciGirisDto kullaniciGirisDto)
        {
            var userToCheck = _kullaniciService.GetByEmail(kullaniciGirisDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<Kullanici>(Messages.BulunamayanKullanici);
            }

            if (!HashingHelper.VerifyPasswordHash(kullaniciGirisDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Kullanici>(Messages.ParolaHatasi);
            }

            return new SuccessDataResult<Kullanici>(userToCheck, Messages.BasariliGiris);
        }

        public IDataResult<Kullanici> Kayit(KullaniciKayitDto kullaniciKayitDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var kullanici = new Kullanici
            {
                Email = kullaniciKayitDto.Email,
                Adi = kullaniciKayitDto.Adi,
                Soyadi = kullaniciKayitDto.Soyadi,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _kullaniciService.Add(kullanici);
            return new SuccessDataResult<Kullanici>(kullanici, Messages.KayitOlundu);
        }

        public IResult KullaniciExists(string email)
        {
            if (_kullaniciService.GetByEmail(email) != null)
            {
                return new ErrorResult(Messages.MevcutKullanici);
            }
            return new SuccessResult();
        }
    }
}
