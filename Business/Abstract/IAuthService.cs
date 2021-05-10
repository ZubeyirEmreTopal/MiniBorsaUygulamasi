using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IAuthService
    {
        IDataResult<Kullanici> Kayit(KullaniciKayitDto kullaniciKayitDto, string password);
        IDataResult<Kullanici> Giris(KullaniciGirisDto kullaniciGirisDto);
        IDataResult<AccessToken> CreateAccessToken(Kullanici kullanici);
        IResult KullaniciExists(string email);
    }
}
