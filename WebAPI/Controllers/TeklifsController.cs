using Business.Abstract;
using Entities.Concrete;
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
    public class TeklifsController : ControllerBase
    {
        ITeklifService _teklifService;

        public TeklifsController(ITeklifService teklifService)
        {
            _teklifService = teklifService;

        }

        [HttpPost("add")]
        public IActionResult Add(Teklif teklif)
        {
            var result = _teklifService.Add(teklif);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
