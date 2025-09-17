using System;
using PatronCommand.Command;
using PatronCommand.Invoker;
using System.Collections.Generic;

namespace PatronCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            Carrito carrito = new Carrito();
            EditorInvoker invoker = new EditorInvoker();

            while (true)
            {
                Console.WriteLine("\n=== MENÚ ===");
                Console.WriteLine("1) Agregar item");
                Console.WriteLine("2) Quitar item");
                Console.WriteLine("3) Cambiar cantidad");
                Console.WriteLine("4) Undo");
                Console.WriteLine("5) Redo");
                Console.WriteLine("6) Total");
                Console.WriteLine("7) Promo (Macro)");
                Console.WriteLine("0) Salir");
                Console.Write("Opción: ");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        {
                            Console.Write("SKU: ");
                            var sku = Console.ReadLine();
                            Console.Write("Nombre: ");
                            var nombre = Console.ReadLine();
                            Console.Write("Precio: ");
                            var precio = double.Parse(Console.ReadLine());
                            Console.Write("Cantidad: ");
                            var cantidad = int.Parse(Console.ReadLine());

                            var item = new Item(sku, nombre, precio, cantidad);
                            invoker.Run(new AgregarItemCommand(carrito, item));
                            break;
                        }
                        

                    case "2":
                        {
                            Console.Write("SKU del item a quitar: ");
                            var skuQuitar = Console.ReadLine();
                            var itemQuitar = new Item(skuQuitar, "", 0, 0);
                            invoker.Run(new QuitarItemCommand(carrito, itemQuitar));
                            break;
                        }
                        

                    case "3":
                        {
                            Console.Write("SKU: ");
                            var skuCambiar = Console.ReadLine();
                            Console.Write("Nueva cantidad: ");
                            var nuevaCantidad = int.Parse(Console.ReadLine());
                            var itemCambiar = new Item(skuCambiar, "", 0, nuevaCantidad);
                            invoker.Run(new CambiarCantidadCommand(carrito, itemCambiar, nuevaCantidad));
                            break;
                        }
                        

                    case "4":
                        {
                            invoker.Undo();
                            break;
                        }
                        

                    case "5":
                        {
                            invoker.Redo();
                            break;
                        }
                        

                    case "6":
                        {
                            Console.WriteLine($"TOTAL = {carrito.Total()}");
                            break;
                        }
                        

                    case "7":
                        {
                            var itemCafe = new Item("skuA", "Promo-Café", 100, 1);
                            var itemMedialuna = new Item("skuB", "Promo-Medialuna", 50, 1);

                            var promoItems = new List<ICommand>
                            {
                                 new AgregarItemCommand(carrito, itemCafe),
                                 new AgregarItemCommand(carrito, itemMedialuna),
                                 new CambiarCantidadCommand(carrito, itemCafe, 2)
                            };
 
                            var promoMacro = new MacroCommand(promoItems);
                            invoker.Run(promoMacro);
                            break;
                        }
                       

                    case "0": return;
                }
            }
        }
    }
}

