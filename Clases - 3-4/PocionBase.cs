using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases___3_4
{
    public abstract class PocionBase
    { //Genere un clase abstracta.
        public int Min { get; set; }
        public int Max { get; set; }
        // Este es el constructor de PocionBase
        protected PocionBase(int min, int max) // el protected permite que las clases derivadas accedan a ciertos miembros de la clase base, como si fueran parte de su propia clase. 
        {
            Min = min;
            Max = max;
        }

        public abstract bool Usar(Personaje personaje); //Esto es un metodo abstracto. Toda clase que lo herede, esta obligada a tener este metodo
    }
}
