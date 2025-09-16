using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatronObserver.Models;

namespace PatronObserver.Models
{
    public class PedidoChangedEventArgs : EventArgs
    {
        public int PedidoID { get; }
        public EstadoPedido NuevoEstado { get; }
        public DateTime Cuando { get; }

        public PedidoChangedEventArgs(int PedidoID, EstadoPedido NuevoEstado, DateTime Cuando)
        {
            this.PedidoID = PedidoID;
            this.NuevoEstado = NuevoEstado;
            this.Cuando = Cuando;
        }
    }
}
