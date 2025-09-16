using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatronObserver.Models;

namespace PatronObserver.Observadores
{
    public class AuditoriaPedidos
    {
        public void Suscribir(PedidoService s) => s.EstadoCambiado += OnEstadoCambiado;
        public void Desuscribir(PedidoService s) => s.EstadoCambiado -= OnEstadoCambiado;
        private void OnEstadoCambiado(object sender, PedidoChangedEventArgs e)
        {
            Console.WriteLine($"[AUDITORIA {e.Cuando:yyyy-MM-dd HH:mm:ss}]: Tu pedido {e.PedidoID} ahora esta en: {e.NuevoEstado}");
        }
    }
}
