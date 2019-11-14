using ChatonsCodeFirst.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatonsCodeFirst.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ContextBDD())
            {
                var categories = db.Categories.Where(categorie => categorie.Nom.StartsWith("M"));
                foreach (var item in categories)
                {
                    System.Console.WriteLine(item.Nom);
                }

                var chaton = new Chaton()
                {
                    Categorie = db.Categories.Find(1),
                    Nom = "Minou",
                    Sterilise = false,
                    DateDeNaissance = DateTime.Now,
                };

                var henry = new Proprietaire()
                {
                    Nom = "Bartonnier",
                    Prenom = "Henry"
                };

                db.Chatons.Add(chaton);

                System.Console.ReadKey();
            }
        }
    }
}
