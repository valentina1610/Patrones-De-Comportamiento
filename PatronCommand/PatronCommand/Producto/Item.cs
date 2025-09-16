using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronCommand
{
    public class Item
    {
        public string Sku { get; set; } //Es un identificador para cada producto en especifico
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }

        public Item(string sku, string nombre, double precio, int cantidad)
        {
            this.Sku = sku;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Cantidad = cantidad;
        }
    }
}
