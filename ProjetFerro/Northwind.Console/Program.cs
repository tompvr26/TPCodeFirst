using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Northwind.ORM;

namespace Northwind.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {
                //LINQ Language Integrated Query

                //select *
                var r1 = from c in db.Customers
                         select c;
                var r1bis = db.Customers;

                //where
                var r2 = from c in db.Customers
                         where c.Country == "France"
                         select c;
                var r2bis = db.Customers.Where(c => c.Country == "France");

                /*foreach (var item in r2)
                {
                    WriteLine(item.CompanyName);
                }*/

                //select de colonne vers un objet anonyme
                //une seule colonne, c'est facile
                var r3 = from c in db.Customers
                         where c.Country == "France"
                         select c.CompanyName; //du coup j'obtiens un IQueryable<string>
                var r3bis = db.Customers.Where(c => c.Country == "France")
                    .Select(c => c.CompanyName);

                //plusieur colonnes, je suis obligé de
                var r4 = from c in db.Customers
                         where c.Country == "France"
                         select new { c.CompanyName, c.Country };
                var r4bis = db.Customers.Where(c => c.Country == "France")
                    .Select(c => new { c.CompanyName, c.Country });

                /*foreach(var item in r4)
                {
                    WriteLine($"{item.CompanyName} {item.Country}");
                }*/

                var r5 = from c in db.Customers
                         where c.Country == "France"
                         select new Client()
                         {
                             NomSociete = c.CompanyName,
                             VilleEtPays = $"{c.City} {c.Country}"
                         };
                var r5bis = db.Customers.Where(c => c.Country == "France")
                                    .Select(c => new Client()
                                    {
                                        NomSociete = c.CompanyName,
                                        VilleEtPays = $"{c.City} {c.Country}"
                                    });

                //jointures
                //version à ne pas utiliser quand on a des propirétés de navigation
                var r6 = from c in db.Customers
                         join o in db.Orders on c.CustomerID equals o.CustomerID
                         select new { o.OrderID, c.CompanyName };
                var r6bis = db.Customers.Join(db.Orders
                                            , c => c.CustomerID
                                            , o => o.CustomerID
                                            , (c, o) => new { o.OrderID, c.CompanyName });

                //la bonne version
                var r7 = from o in db.Orders
                         select new { o.OrderID, o.Customer.CompanyName };
                var r7bis = db.Orders.Select(o => new { o.OrderID, o.Customer.CompanyName });

                /*foreach (var item in r6)
                {
                    WriteLine(item.OrderID);
                    WriteLine(item.COmpanyName);
                }*/


                //A NE PAS FAIRE : utiliser les propriétés de navigation APRES la requete
                //A NE PAS FAIRE

                foreach (var item in db.Orders)
                {
                    WriteLine(item.OrderID);
                    WriteLine(item.Customer.CompanyName);
                }

                //A NE PAS FAIRE 
                //A NE PAS FAIRE (au-dessus)


                //Group by
                var r8 = from c in db.Customers
                         group c by c.Country into g
                         select new { Country = g.Key, NombreDeCustomers = g.Count() };
                var r8bis = db.Customers.GroupBy(c => c.Country)
                                        .Select(g => new { Country = g.Key, NombreDeCustomers = g.Count() });

                /*foreach (var item in r8)
                {
                    WriteLine("################################################################");
                    WriteLine($"{item.Country} {item.NombreDeCustomers}");
                    foreach (var c in item.mesCustomers)
                    {
                        WriteLine(c.CompanyName);
                    }
                }*/


                ReadKey();

                //insert
                var cat = new Category()
                {
                    CategoryName = "Nouvelle",
                    Description = "Une nouvelle catégorie"
                };
                db.Categories.Add(cat);
                db.SaveChanges();//déclenche l'insert

                //update

                //1 -> récupérer l'objet à modifier
                //ici avec Find(cléPrimaire)
                var cus = db.Customers.Find("ALFKI");

                //2 -> je modifie ce que je veux
                cus.ContactName = "Mathias Braux";
                db.SaveChanges();

                //delete
                //1 -> récupérer l'objet à modifier
                //ici avec First(condition)
                var catASupprimer = db.Categories.First(c => c.CategoryName == "Nouvelle");

                //2 -> je supprime
                db.Categories.Remove(catASupprimer);
                db.SaveChanges();
            }
        }
    }
}
