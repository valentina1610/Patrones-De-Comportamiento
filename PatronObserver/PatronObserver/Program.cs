using System;
using PatronObserver.Models;
using PatronObserver.Observadores;

namespace PatronObserver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PedidoService pedidoServ = new PedidoService();
            AuditoriaPedidos observerAuditoria = new AuditoriaPedidos();
            NotificadorCliente observerNotificador = new NotificadorCliente();
            PanelLogistica observerPanel = new PanelLogistica();

            observerAuditoria.Suscribir(pedidoServ);
            observerNotificador.Suscribir(pedidoServ);
            observerPanel.Suscribir(pedidoServ);

            //Flujo de pedido
            pedidoServ.AgregarPedido(101);
            pedidoServ.CambiarEstado(101,EstadoPedido.Recibido);
            Console.WriteLine();
            pedidoServ.CambiarEstado(101, EstadoPedido.Preparado);
            Console.WriteLine();
            pedidoServ.CambiarEstado(101, EstadoPedido.Enviado);
            Console.WriteLine();
            observerPanel.Desuscribir(pedidoServ);
            pedidoServ.CambiarEstado(101, EstadoPedido.Entregado);
            Console.WriteLine();
            pedidoServ.AgregarPedido(102);
            pedidoServ.CambiarEstado(102, EstadoPedido.Recibido);

            // Mostrar buffer
            Console.WriteLine("Historial de últimas transiciones:");
            foreach (var h in pedidoServ.ObtenerHistorial())
                Console.WriteLine($"Pedido {h.PedidoID} -> {h.NuevoEstado} ({h.Cuando:HH:mm:ss})");



        }
    }
}
