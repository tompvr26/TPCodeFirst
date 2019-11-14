using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatonsCodeFirst.ORM
{
    public class Chaton
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        public DateTime DateDeNaissance { get; set; }

        public bool Sterilise { get; set; }

        public virtual Categorie Categorie { get; set; }

        public virtual ICollection<Proprietaire> Proprietaires { get; set; }

        public Chaton()
        {
            Proprietaires = new List<Proprietaire>();
        }
    }
}
