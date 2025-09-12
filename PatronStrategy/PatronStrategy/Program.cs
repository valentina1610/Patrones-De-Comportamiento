using System;
using PatronStrategy.Factory;
using PatronStrategy.Strategys;

namespace PatronStrategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el subtotal:");
            decimal subtotal = decimal.Parse(Console.ReadLine());
            Carrito carrito = new Carrito(new SinDescuento());

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("1. Sin descuento");
                Console.WriteLine("2.10% descuento");
                Console.WriteLine("3. Promo banco (tope $5000)");
                Console.WriteLine("4. Usar codigo de promocion (WKND, BANK)");
                Console.WriteLine("5. Salir");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        {
                            carrito.SetDescuento(new SinDescuento());
                            break;
                        }
                    case "2":
                        {
                            carrito.SetDescuento(new Porcentaje(0.10m));
                            break;
                        }
                    case "3":
                        {
                            carrito.SetDescuento(new TopeBanco(3000m, 5000m));
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Ingrese el codigo:");
                            string codigo = Console.ReadLine();
                            carrito.SetDescuento(DescuentoFactory.Crear(codigo));
                            break;
                        }
                    case "5":
                        {
                            salir = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Opcion invalida.");
                            break;
                        }
                }
                decimal total = carrito.Total(subtotal);
                Console.WriteLine($"\nSubtotal: ${subtotal}");
                Console.WriteLine($"Total con {carrito._estrategia.Nombre}: ${total}");
                Console.WriteLine($"Total ahorrado: {subtotal - total}$");

            }
           
        }
    }
}
