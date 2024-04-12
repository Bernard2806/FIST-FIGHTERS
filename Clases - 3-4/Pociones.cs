using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases___3_4
{
    public abstract class PocionBase { //Genere un clase abstracta.
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

    public class PocionVida : PocionBase{
        public PocionVida(int min, int max) : base(min, max) { }
        public override bool Usar(Personaje personaje) //El parametro override se utiliza para indicar que el metodo que definimos va a tener un comportamiento distinto al de la clase base
        {
            if (personaje.Vida >= personaje.VidaMax) return false;
            int Cura = new Random().Next(Min, Max++);
            if (personaje.VidaMax < Cura + personaje.Vida)
            {
                personaje.Vida = personaje.VidaMax;
                Console.WriteLine("Se ha Curado Toda la Vida del Personaje.");
                return true;
            }
            personaje.Vida += Cura;
            Console.WriteLine($"Se ha Curado {Cura} Puntos de Vida. Vida actual: {personaje.Vida}");
            return true;
        }
    }

    public class PocionMana : PocionBase {
        public PocionMana(int min, int max) : base(min, max) { }

        public override bool Usar(Personaje personaje)
        {
            if (personaje.Mana >= personaje.ManaMax) return false;
            int Cura = new Random().Next(Min, Max++);
            if (personaje.ManaMax < Cura + personaje.Mana)
            {
                personaje.Mana = personaje.ManaMax;
                Console.WriteLine("Se ha Recuperado Todo el Mana del Personaje.");
                return true;
            }
            personaje.Vida += Cura;
            Console.WriteLine($"Se ha Recuperado {Cura} Puntos de Mana. Mana actual: {personaje.Vida}");
            return true;
        }
    }
}
