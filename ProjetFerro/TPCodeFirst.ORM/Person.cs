using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCodeFirst.ORM
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        public DateTime? HireDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
        public Person()
        {
            Courses = new List<Course>();
            StudentGrades = new List<StudentGrade>();
        }
    }
}
