using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatronStrategy.Interfaces;

namespace PatronStrategy.Strategys
{
    public class Porcentaje : IDescuentoStrategy
    {
        private readonly decimal porcent;

        public Porcentaje(decimal porcent)
        {
            this.porcent = porcent;
        }
        public string Nombre => $"Descuento del {porcent * 100}%";

        public decimal Aplicar(decimal subtotal)
        {
            return subtotal - (subtotal * porcent);
        }
    }
}
