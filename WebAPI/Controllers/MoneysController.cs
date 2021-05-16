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
    public class MoneysController : ControllerBase
    {
        IParaService _paraService;
        public MoneysController(IParaService paraService)
        {
            _paraService = paraService;
        }

        [HttpPost("add")]
        public IActionResult Add(Para para)
        {
            var result = _paraService.Add(para);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
