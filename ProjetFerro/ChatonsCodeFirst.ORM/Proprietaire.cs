using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatonsCodeFirst.ORM
{
    public class Proprietaire
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }

        [StringLength(50)]
        public string Prenom { get; set; }

        public  DateTime DateDeNaissance { get; set; }

        public virtual ICollection<Chaton> Chatons { get; set; }

        public Proprietaire()
        {
            Chatons = new List<Chaton>();
        }
    }
}
