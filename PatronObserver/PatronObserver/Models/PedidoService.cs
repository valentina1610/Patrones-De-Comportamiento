using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver.Models
{
    public class PedidoService
    {
        // Diccionario que guarda el estado de cada pedido
        private Dictionary<int, EstadoPedido> _pedidos = new();

        // Evento que notificará cambios de estado
        public event EventHandler<PedidoChangedEventArgs>? EstadoCambiado;

        // Método que cambia el estado de un pedido y dispara el evento
        public void CambiarEstado(int pedidoId, EstadoPedido nuevoEstado)
        {
            if (!_pedidos.ContainsKey(pedidoId))
            {
                throw new ArgumentException("Pedido no existe.");
            }

            _pedidos[pedidoId] = nuevoEstado;

            // Dispara el evento a todos los suscriptores
            EstadoCambiado?.Invoke(
                this,
                new PedidoChangedEventArgs(
                    pedidoId,
                    nuevoEstado,
                    DateTime.Now
                )
            );
        }
    }
}
