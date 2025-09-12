using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatronStrategy.Interfaces;

namespace PatronStrategy
{
    public class Carrito
    {
        public IDescuentoStrategy _estrategia;

        public Carrito(IDescuentoStrategy Estrategia)
        {
            this._estrategia = Estrategia;
        }

        public void SetDescuento(IDescuentoStrategy s)
        {
            _estrategia = s;
        }

        public decimal Total(decimal subtotal)
        {
            return _estrategia.Aplicar(subtotal);
        }
    }
}
