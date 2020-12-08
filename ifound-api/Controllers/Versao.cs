using System;
using Core.AspNetIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ifound_api
{
    [ApiController]
    [Route("api/[controller]")]
    public class VersaoController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Get()
        {
            return View();
        }
    }
}