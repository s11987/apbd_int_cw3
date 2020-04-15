using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apbd_int_cw3.DAL;
using apbd_int_cw3.Models;
using Microsoft.AspNetCore.Mvc;

namespace apbd_int_cw3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_dbService.GetStudents());
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