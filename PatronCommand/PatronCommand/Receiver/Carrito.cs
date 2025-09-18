using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatronCommand.Singleton;

namespace PatronCommand
{
    public class Carrito
    {
        private Dictionary<string, Item> _items = new();

        public void Agregar(Item item)
        {
            if (item.Cantidad <= 0)
            {
                Logger.Instance.Log("[ERROR]: No se agrego al carrito, la cantidad tiene que ser mayor a 0!");
                return;
            }
            if (!_items.ContainsKey(item.Sku))
            {
                _items[item.Sku] = item;
                Logger.Instance.Log($"{item.Nombre} agregado correctamente !");
            }
            else
            {
                Logger.Instance.Log($"[ERROR]: {item.Nombre} ya agregado al carrito.");
            }
        }
        public void Quitar(Item item)
        {
            if (_items.ContainsKey(item.Sku))
            {
                _items.Remove(item.Sku);
                Logger.Instance.Log($"{item.Nombre} Eliminado correctamente !");
            }
            else
            {
                Logger.Instance.Log($"[ERROR]: {item.Nombre}  NO agregado al carrito.");
            }
        }
        public void CambiarCantidad(Item item, int nuevaCantidad)
        {
            if (nuevaCantidad <= 0)
            {
                Logger.Instance.Log("[ERROR]: La cantidad nueva tiene que ser mayor a 0!");
                return;
            }
            if (!_items.ContainsKey(item.Sku))
            {
                _items[item.Sku].Cantidad = nuevaCantidad;
                Logger.Instance.Log($"Cantidad de {item.Nombre} cambiada correctamente !");
            }
            else
            {
                Logger.Instance.Log($"[ERROR]: {item.Nombre} NO agregado al carrito.");
            }
        }
        public double Total()
        {
            Console.WriteLine("=== CARRITO ACTUAL ===");
            int cont = 0;
            foreach (var i in _items.Values)
            {
                Console.WriteLine($"Item nro {cont + 1}");
                Console.WriteLine($"Nombre: {i.Nombre}, Sku: {i.Sku}, Precio: {i.Precio}, Cantidad: {i.Cantidad}");
                cont++; // <--- importante, sumamos el contador
            }

            Console.WriteLine();
            Console.WriteLine("TOTAL DE TODO:");
            return _items.Values.Sum(i => i.Precio * i.Cantidad);
        }
    }
}
