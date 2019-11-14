using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCodeFirst.ORM
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public int Credits { get; set; }

        public virtual ICollection<StudentGrade> StudentGrades { get; set; }

        public virtual ICollection<Person> Persons { get; set; }

        public Course()
        {
            StudentGrades = new List<StudentGrade>();
            Persons = new List<Person>();
        }
    }
}
