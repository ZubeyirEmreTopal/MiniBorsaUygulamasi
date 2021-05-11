using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IKullaniciService _kullaniciService;
        public UsersController(IKullaniciService kullaniciService )
        {
            _kullaniciService = kullaniciService;


        }
        [HttpPost("add")]
        public IActionResult Add(Kullanici kullanici)
        {



        }
    }
}
