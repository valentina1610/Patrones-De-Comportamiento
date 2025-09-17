using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronCommand
{
    public class Carrito
    {
        private Dictionary<string, Item> _items = new();

        public void Agregar(Item item)
        {
            if (!_items.ContainsKey(item.Sku))
            {
                _items[item.Sku] = item;
                Console.WriteLine($"{item.Nombre} agregado correctamente !");
            }
            else
            {
                Console.WriteLine($"[ERROR]: {item.Nombre} ya agregado al carrito.");
            }
        }
        public void Quitar(Item item)
        {
            if (_items.ContainsKey(item.Sku))
            {
                _items.Remove(item.Sku);
                Console.WriteLine($"{item.Nombre} Eliminado correctamente !");
            }
            else
            {
                Console.WriteLine($"[ERROR]: {item.Nombre}  NO agregado al carrito.");
            }
        }
        public void CambiarCantidad(Item item, int nuevaCantidad)
        {
            if (!_items.ContainsKey(item.Sku))
            {
                _items[item.Sku].Cantidad = nuevaCantidad;
                Console.WriteLine($"Cantidad de {item.Nombre} cambiada correctamente !");
            }
            else
            {
                Console.WriteLine($"[ERROR]: {item.Nombre} NO agregado al carrito.");
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
