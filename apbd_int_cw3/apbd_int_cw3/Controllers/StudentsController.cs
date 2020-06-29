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

            using (var con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=APBD;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                Student st = new Student();
                com.Connection = con;
                com.CommandText = "select * from Student where IndexNumber='"+ id + "'";
                //com.Parameters.AddWithValue("id", id);
                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["IndexNumber"].ToString() == id)
                    {
                        st.IdEnrollment = Int32.Parse(dr["IdEnrollment"].ToString());
                        st.FirstName = dr["FirstName"].ToString();
                        st.LastName = dr["LastName"].ToString();

                        st.IndexNumber = dr["IndexNumber"].ToString();
                        st.BirthDate = dr["BirthDate"].ToString();
                    }
                }
            }





            /*   List<Studies> studies = new List<Studies>();
               using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=APBD;Integrated Security=True"))
               {

                   Student st = new Student();
                   Enrollment en = new Enrollment();
                   con.Open();
                   using (SqlCommand com = new SqlCommand("SELECT * FROM Student", con))
                   {
                      // com.Connection = con;

                       var dr = com.ExecuteReader();
                       while (dr.Read())
                       {
                           if (dr["IndexNumber"].ToString() == id)
                           {
                               st.IdEnrollment = Int32.Parse(dr["IdEnrollment"].ToString());
                               st.FirstName = dr["FirstName"].ToString();
                               st.LastName = dr["LastName"].ToString();

                               st.IndexNumber = dr["IndexNumber"].ToString();
                               st.BirthDate = dr["BirthDate"].ToString();
                           }
                       }
                       dr.Close();
                       com.ExecuteNonQuery();
                   }

                   using (SqlCommand com = new SqlCommand("SELECT * FROM Enrollment", con))
                   {
                       com.Connection = con;
                       var dr = com.ExecuteReader();
                       while (dr.Read())
                       {
                           if (Int32.Parse(dr["IdEnrollment"].ToString()) == st.IdEnrollment)
                           {
                               en.IdEnrollment = Int32.Parse(dr["IdEnrollment"].ToString());
                               en.Semester = Int32.Parse(dr["Semester"].ToString());
                               en.IdStudy = Int32.Parse(dr["IdStudy"].ToString());
                               en.StartDate = dr["StartDate"].ToString();
                           }
                       }
                       dr.Close();
                       com.ExecuteNonQuery();
                   }
                   using (SqlCommand com = new SqlCommand("SELECT * FROM Studies", con))
                   {
                       com.Connection = con;
                       var dr = com.ExecuteReader();
                       while (dr.Read())
                       {
                           Studies study = new Studies();
                           if (Int32.Parse(dr["IdStudy"].ToString()) == en.IdStudy)
                           {
                               study.IdStudy = Int32.Parse(dr["IdStudy"].ToString());
                               study.Name = dr["Name"].ToString();
                               studies.Add(study);
                           }

                       }
                   }

               }  
               */
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