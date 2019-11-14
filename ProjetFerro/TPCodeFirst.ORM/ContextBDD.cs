using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCodeFirst.ORM
{
    class ContextBDD : DbContext
    {
        public ContextBDD()
            : base("chaineDeConnexion")
        {

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Departement> Departements { get; set; }

        public DbSet<StudentGrade> StudentGrades { get; set; }

        public DbSet<Person> Persons { get; set; }
    }
}
