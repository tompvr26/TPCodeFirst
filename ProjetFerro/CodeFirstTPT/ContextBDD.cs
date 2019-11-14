using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTPT
{
    class ContextBDD : DbContext
    {
        public ContextBDD()
            : base("chaineDeConnexion")
        {

        }

        public DbSet<Animal> Animaux { get; set; }

        public DbSet<Oiseau> Oiseaux { get; set; }

        public DbSet<Mammifere> Mammiferes { get; set; }
    }
}
