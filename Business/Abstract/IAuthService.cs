using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;

using Entities.Dtos;

using System;
using System.Text;

namespace Business.Abstract
{
   public interface IAuthService
    {
        IDataResult<Kullanici> Register(KullaniciKayitDto kullaniciKayitDto, string password);
        IDataResult<Kullanici> Login(KullaniciGirisDto kullaniciGirisDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Kullanici kullanici);
    }
}
