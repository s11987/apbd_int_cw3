using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        [HttpGet("{id}")]
        public IActionResult GetStudentsById(string id)
        {
            Enrollment en = new Enrollment();
            using (var con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=APBD;Integrated Security=True"))
            using (var com = new SqlCommand())
            {

                com.Connection = con;
                com.CommandText = @"select * from Student
INNER JOIN Enrollment ON Student.IdEnrollment = Enrollment.IdEnrollment
INNER JOIN Studies ON Enrollment.IdStudy = Studies.IdStudy
where Student.IndexNumber = '" + id + "'";

                
                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["IndexNumber"].ToString() == id)
                    {
                        en.IdEnrollment = Int32.Parse(dr["IdEnrollment"].ToString());
                        en.Semester = Int32.Parse(dr["Semester"].ToString());
                        en.IdStudy = Int32.Parse(dr["IdStudy"].ToString());
                        en.StartDate = dr["StartDate"].ToString();
                    }
                }
            }

            return Ok(en);
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