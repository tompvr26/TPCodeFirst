using System;

namespace ProjetFerro
{
    internal class Chaton
    {
        public string Nom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public string Couleur { get; set; }


        public void Dormir()
        {
            Console.WriteLine($"{Nom} dort...");
            System.Threading.Thread.Sleep(2000); //endors le thread pendant 2s
        }

        /*public Chaton()    Le constructeur par defaut ne sert a rien ici
        {

        }*/
    }
}