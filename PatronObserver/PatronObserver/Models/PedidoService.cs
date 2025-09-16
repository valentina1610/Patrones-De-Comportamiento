using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronObserver.Models
{
    public class PedidoService
    {
        // Indice de estados, guarda el estado de cada pedido
        private Dictionary<int, EstadoPedido> _pedidos = new();

        // Evento que notificará cambios de estado
        public event EventHandler<PedidoChangedEventArgs> EstadoCambiado;

        private List<PedidoChangedEventArgs> _historial = new();

        public void AgregarPedido(int pedidoId) 
        {
            if (!_pedidos.ContainsKey(pedidoId))
                _pedidos[pedidoId] = EstadoPedido.Recibido;
        }

        // Método que cambia el estado de un pedido y dispara el evento
        public void CambiarEstado(int pedidoId, EstadoPedido nuevoEstado)
        {
            if (!_pedidos.ContainsKey(pedidoId))
            {
                throw new InvalidOperationException("[ERROR]: Pedido no existe,");

            }
            EstadoPedido estadoActual = _pedidos[pedidoId];

            if (!EsValido(estadoActual, nuevoEstado))
            {
                throw new InvalidOperationException($"[ERROR]: No se puede cambiar de {estadoActual} a {nuevoEstado}.");

            }

            _pedidos[pedidoId] = nuevoEstado;

            var evento = new PedidoChangedEventArgs(pedidoId, nuevoEstado, DateTime.Now);

            _historial.Add(evento);
            if (_historial.Count > 5) 
                _historial.RemoveAt(0);

            EstadoCambiado?.Invoke(this, evento);
        }

        public List<PedidoChangedEventArgs> ObtenerHistorial() => new List<PedidoChangedEventArgs>(_historial);

        private bool EsValido(EstadoPedido actual, EstadoPedido nuevo)
        {
            return (actual == EstadoPedido.Recibido && nuevo == EstadoPedido.Recibido) ||
                   (actual == EstadoPedido.Recibido && nuevo == EstadoPedido.Preparado) ||
                   (actual == EstadoPedido.Preparado && nuevo == EstadoPedido.Enviado) ||
                   (actual == EstadoPedido.Enviado && nuevo == EstadoPedido.Entregado);
        }
    }
}