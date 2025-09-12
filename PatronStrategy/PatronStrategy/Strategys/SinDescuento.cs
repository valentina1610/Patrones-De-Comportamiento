using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatronStrategy.Interfaces;

namespace PatronStrategy.Strategys
{
    public class SinDescuento : IDescuentoStrategy
    {
        public string Nombre => "Sin Descuento";

        public decimal Aplicar(decimal subtotal)
        {
            return subtotal;
        }
    }
}