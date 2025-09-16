using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatronObserver.Models;

namespace PatronObserver.Observadores
{
    public class NotificadorCliente
    {
        //+= significa “cuando ocurra el evento EstadoCambiado, llamá a este método(OnEstadoCambiado)”.
        //Y -= significa “ya no quiero que este método se llame cuando ocurra el evento”.
        public void Suscribir(PedidoService s) => s.EstadoCambiado += OnEstadoCambiado;
        public void Desuscribir(PedidoService s) => s.EstadoCambiado -= OnEstadoCambiado;
        private void OnEstadoCambiado(object sender, PedidoChangedEventArgs e)
        {
            //sender es el objeto que disparó el evento, siempre es PedidoService.
            Console.WriteLine($"[NOTIFICADOR CLIENTE]: Tu pedido {e.PedidoID} ahora esta en: {e.NuevoEstado}");
        }

    }
}
