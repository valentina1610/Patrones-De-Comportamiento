using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatronStrategy.Interfaces;

namespace PatronStrategy.Strategys
{
    public class TopeBanco : IDescuentoStrategy
    {
        private readonly decimal monto;
        private readonly decimal tope;

        public TopeBanco(decimal monto, decimal tope)
        {
            this.monto = monto;
            this.tope = tope;
        }
        public string Nombre => $"Promo banco (tope {tope}$)";

        public decimal Aplicar(decimal subtotal)
        {
            decimal descuento = subtotal >= monto ? monto : subtotal;
            if (descuento > tope) descuento = tope;
            return subtotal - descuento;
        }
    }
}
