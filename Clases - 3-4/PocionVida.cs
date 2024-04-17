using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases___3_4
{
    public class PocionVida : PocionBase
    {
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
}
