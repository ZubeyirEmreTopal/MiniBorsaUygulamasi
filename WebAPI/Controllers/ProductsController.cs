using Business.Abstract;
using Entities.Concert;
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
    public class ProductsController : ControllerBase
    {
        IUrunService _urunService;
        public ProductsController(IUrunService urunService)
        {
             _urunService=urunService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _urunService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Urun urun)
        {
            var result = _urunService.Add(urun);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
