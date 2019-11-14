using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjetFerro
{
    internal class Liste<T>:IEnumerable<T>
    {

        private ArrayList elements;

        public T this[int index]
        {
            get { return (T)elements[index]; }
            set { elements[index] = value; }
        }

        /// <summary>
        /// Nombre d'éléments de la liste
        /// </summary>
        public int Count { get { return elements.Count; } }
        public Liste()
        {
            elements = new ArrayList();
        }

        public void Ajouter(T trucAAjouter)
        {
            elements.Add(trucAAjouter);
        }

        public IEnumerator<T> GetEnumerator()
        {
            //Construction d'un Enumérateur
            foreach (var item in elements)
            {
                yield return (T)item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //void Trier()
        //{
        //    for (int i = 0; i < Count-1; i++)
        //    {
        //        for (int j = i + 1; j < Count; j++)
        //        {
        //            if (this[i] > this[j])
        //            {
        //                var aux = this[i];
        //                this[i] = this[j];
        //                this[j] = aux;
        //            }
        //        }   
        //    }
        //}
    }
}