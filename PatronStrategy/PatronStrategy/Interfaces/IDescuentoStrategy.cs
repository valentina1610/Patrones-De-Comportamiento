using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronStrategy.Interfaces
{
    public interface IDescuentoStrategy
    {
        public decimal Aplicar(decimal subtotal);
        string Nombre { get; }
    }
}
