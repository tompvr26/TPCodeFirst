using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTPT
{
    [Table("Oiseaux")]
    class Oiseau : Animal
    {
        public bool SaitVoler { get; set; }

        public DateTime DateDeNaissance { get; set; }
    }
}
