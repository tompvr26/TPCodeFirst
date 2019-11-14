using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetFerro
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Petite syntaxe

            // inférence type (pas du tout le meme var que javascript) (il transforme seul le var en int)
            //var entier = 5;

            var ex = new InvalidOperationException(); // est quivalent " var InvalidOperationException = new InvalidOperationException(); "

            //types anonymes
            var voiture = new { immatriculation = "EF 33 DD",
                                marque ="renault",
                                modele ="Talisman"
                                };
            Console.WriteLine(voiture.immatriculation);
            Console.WriteLine(voiture.marque);
            Console.WriteLine(voiture.modele);

            //initialisateur d'objets

            //chaton.Nom="dfshgfdshglks"   Comment on ferait normalement
            var chaton = new Chaton() // CTRL + ;  pour generer la classe // cliquer sur Chaton puis F12 pour aller directement sur Chaton
            {
                Nom="Plume",
                Couleur="Blanc",
                DateDeNaissance=new DateTime(2009,7,15)
            };


            // Initialisateur de listes et tableaux
            var liste = new List<int>() { 5, -3, 6, -4, 2 };
            var tab=new int[] { 5, -3, 6, -4, 2 };





            #endregion

            #region Méthodes d'extension

            var s = " une chaine de caractères....";
            // A maListe'ancienne on aurait fait une méthode 'static' 

            // var code = Extensions.Crypter(s, "unMotDePasse");
            // var sDecrytee = Extensions.Decrypter(code, "UnMotDePasse");
            // Le probleme de ca c'est qu'on doit connaitre les methodes dans Extensions
            var code = s.Crypter("motDePasse");
            var sDecryptee = code.Decrypter("motDePasse");
            #endregion

            #region Generique et delegues
            var maListe = new Liste<int>();
            maListe.Ajouter(5);
            maListe.Ajouter(6);
            maListe.Ajouter(7);
            maListe.Ajouter(8);
            maListe.Ajouter(9);



            for (int i = 0; i < maListe.Count; i++)
            {
                Console.WriteLine(maListe[i]);
            }
            Console.ReadKey();


            foreach (var item in maListe)
            {
                Console.WriteLine(item);
            }

            #endregion

            Console.ReadKey();

            #region INTRO LINQ

            //maintenant que les méthodes d'extension sont comprises, les IEnumarable et els expression lambda, voici LINQ : Language INtegrated Query
            //Des méthodes d'extension sur les IEnumerable qui prennent en paramètres des expressions lambda

            var entiers = new int[] { 5, 6, -4, 8, -2 };

            var listeNegatifs = entiers.Where(item => item < 0).ToList();

            var mesChatons = new List<Chaton>()
            {
                new Chaton()
                {
                    Nom="truc", Couleur="bleu", DateDeNaissance=DateTime.Now
                },
                new Chaton()
                {
                    Nom="raie", Couleur="marron", DateDeNaissance=DateTime.Now
                },
                new Chaton()
                {
                    Nom="flav", Couleur="rose", DateDeNaissance=DateTime.Now
                },
                new Chaton()
                {
                    Nom="rayan", Couleur="jaune", DateDeNaissance=DateTime.Now
                },
                new Chaton()
                {
                    Nom="flo", Couleur="gris", DateDeNaissance=DateTime.Now
                },
                new Chaton()
                {
                    Nom="roubignolle", Couleur="rouge", DateDeNaissance=DateTime.Now
                },
                new Chaton()
                {
                    Nom="bidule", Couleur="orange", DateDeNaissance=DateTime.Now
                },
            };

            var mesChatonsEnR = mesChatons.Where(c => c.Nom.StartsWith("r"));

            foreach (var c in mesChatons.AsParallel())
            {
                c.Dormir();
            }

            #endregion

        }
    }
}

















