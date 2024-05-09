﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases___3_4
{
    public class Inventario
    {
        public List<Item> items { get; set; }
        public Personaje personaje { get; set; }

        public void AgregarItem(Item item) {
            items.Add(item);
        }
        public void QuitarItem(Item item) {
            items.Remove(item);
        }
    }
}
