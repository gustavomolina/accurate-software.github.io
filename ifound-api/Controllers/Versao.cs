using System;
using Core.AspNetIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ifound_api
{
    [ApiController]
    [Route("api/[controller]")]
    public class VersaoController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public object Get([FromServices] IConfiguration configuration)
        {
            return new
            {
                Local = Environment.MachineName,
                Versao = configuration["Versao"],
                Production = configuration["Production"],
                Date = DateTime.Now.Date,
                DateTime = DateTime.Now
            };
        }
    }
}