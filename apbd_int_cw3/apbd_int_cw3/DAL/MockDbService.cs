using apbd_int_cw3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_int_cw3.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;


        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student{IdStudent = 1, FirstName="Karol", LastName="Kowalski" },
                new Student{IdStudent = 2, FirstName="Karol2", LastName="Kowalski4" },
                new Student{IdStudent = 3, FirstName="Karol3", LastName="Kowalski5" },
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

    }

}
