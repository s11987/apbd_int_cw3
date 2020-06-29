using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_int_cw3.Models
{
    public class Enrollment
    {
        [Key]
        public int IdEnrollment { get; set; }
        public int Semester { get; set; }
        public int IdStudy { get; set; }
        public string StartDate { get; set; }
    }
}
