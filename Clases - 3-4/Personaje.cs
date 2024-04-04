using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases___3_4
{
    internal class Personaje
    {
        public string Color { get; set; }
        public int Altura { get; set; }
        public int Vida { get; set; }
        public int Defensa { get; set; }
        public int Fuerza { get; set; }
        public int Mana { get; set; }

        public bool Atacar(Personaje personaje) {
            if (Mana >= 10) {
                Mana -= 10;
                return personaje.RecibirDaño(Fuerza);
            }
            else
            {
                return false;
            }
        }

        public bool RecibirDaño(int Fuerza) {
            int Daño = Fuerza - Defensa;
            if (Daño > 0)
            {
                Vida = Vida - Daño;
                return true;
            }
            else {
                return false;
            }
        }

        public void CambiarColor(string NuevoColor) {
            Color = NuevoColor;
        }
    }
}
