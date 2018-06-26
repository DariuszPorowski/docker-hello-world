using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace docker_hello_world.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Dictionary<string, string>> Get()
        {
            return new Dictionary<string, string>
            {
                { "name", Environment.GetEnvironmentVariable("NAME") },
                { "hostname", Environment.GetEnvironmentVariable("HOSTNAME") }
            };
        }
    }
}