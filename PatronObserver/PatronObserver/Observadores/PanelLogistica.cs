using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatronObserver.Models;

namespace PatronObserver.Observadores
{
    public class PanelLogistica
    {
        public void Suscribir(PedidoService s) => s.EstadoCambiado += OnEstadoCambiado;
        public void Desuscribir(PedidoService s) => s.EstadoCambiado -= OnEstadoCambiado;
        private void OnEstadoCambiado(object sender, PedidoChangedEventArgs e)
        {
            Console.WriteLine($"[PANEL LOGISTICA]: Pedido {e.PedidoID} => {e.NuevoEstado} {e.Cuando:HH:mm:ss}");
        }
    }
}
