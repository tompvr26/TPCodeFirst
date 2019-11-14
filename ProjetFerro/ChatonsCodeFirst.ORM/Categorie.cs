using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatonsCodeFirst.ORM
{
    public class Categorie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        public ICollection<Chaton> Chatons { get; set; }

        public Categorie()
        {
            Chatons = new List<Chaton>();
        }
    }
}
