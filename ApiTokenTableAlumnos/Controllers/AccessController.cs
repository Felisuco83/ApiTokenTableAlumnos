using ApiTokenTableAlumnos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTokenTableAlumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        ServiceTableAlumnos ServiceTable;
        public AccessController(ServiceTableAlumnos servicetable)
        {
            this.ServiceTable = servicetable;
        }

        [HttpGet]
        [Route("[action]/{curso}")]
        public ActionResult<string> Token (string curso)
        {
            return Ok(new { token = this.ServiceTable.GetKeySas(curso) });
        }
    }
}
