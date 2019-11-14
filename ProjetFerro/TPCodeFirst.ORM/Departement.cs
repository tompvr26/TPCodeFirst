using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCodeFirst.ORM
{
    public class Departement
    {
        [Key]
        public int DepartementID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public class Budgets
        {
            [Column(TypeName = "Money")]
            public int Budget { get; set; }

            public decimal Amount { get; set; }
        }

        public DateTime StartDate { get; set; }

        public int? Administrator { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public Departement()
        {
            Courses = new List<Course>();
        }
    }
}
