using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTPT
{
    [Table("Mammiferes")]
    class Mammifere : Animal
    {
        public bool AquatiqueStrict { get; set; }
        public bool ADesDents { get; set; }
    }
}
