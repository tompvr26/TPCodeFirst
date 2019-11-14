using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCodeFirst.ORM
{
    public class StudentGrade
    {
        [Key]
        public int EnrollmentID { get; set; }

        public Decimal Grade { get; set; }
    }
}
