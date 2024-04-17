using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases___3_4
{
    public class PocionMana : PocionBase
    {
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
