using apbd_int_cw3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_int_cw3.DAL
{
    public interface IDbService
    {
        IEnumerable<Student> GetStudents();
    }
}
