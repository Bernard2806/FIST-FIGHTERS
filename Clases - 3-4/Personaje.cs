using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases___3_4
{
    public class Personaje
    {

        public string Nombre { get; set; }
        public string Color { get; set; }
        public int Vida { get; set; }
        public int Defensa { get; set; }
        public int Fuerza { get; set; }
        public int Mana { get; set; }
        public int VidaMax { get; set; }
        public int ManaMax { get; set; }

        public PocionBase Pocion { get; set; }

        public Personaje(string nombre) {
            Nombre = nombre;
        }

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
                if (Vida < 0)
                {
                    Vida = 0;
                }
                return true;
            }
            else {
                return false;
            }
        }

        public void CambiarColor(string NuevoColor) {
            if(Mana > 1) {
                Mana--;
                Color = NuevoColor;
                Defensa++;
            }
        }

        public void RecargarMana() {
            if (Mana >= ManaMax)
            {
                Mana = ManaMax;
            }
            else Mana += 10;
        }

        public void AumentarEstadisticas()
        {
            if(Mana >= 70){
                Mana -= 70;
                Defensa += 10;
                Fuerza += 10;
            }
        }
    }
}
