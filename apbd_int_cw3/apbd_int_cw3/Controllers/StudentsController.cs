using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apbd_int_cw3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult GetStudent(int id)
        {
            if (id == 1)
                return Ok("Jan Kowalski");
            else if (id == 2)
                return Ok("Jurand Galazka");
            return NotFound("brak studenta");

        }
    }
}