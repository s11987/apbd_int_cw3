using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apbd_int_cw3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apbd_int_cw3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public string GetStudent(string orderBy)
        {
            return $"Jurandowski, Galakowski, Zygmuntowski sortowanie = {orderBy}";
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 60000)}";
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {           
            return Ok("Student o " + id + " zostal usuniety");
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, Student student)
        {            
            return Ok("student zostal zaktualizowany");
        }
    }
}