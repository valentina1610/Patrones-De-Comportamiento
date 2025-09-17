using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronCommand.Command
{
    public class CambiarCantidadCommand : ICommand
    {
        private readonly Carrito _carrito;
        private readonly Item _item;
        private readonly int _cantidadNueva;
        private int _cantidadAnterior;

        public CambiarCantidadCommand(Carrito carrito, Item item, int cantidadNueva)
        {
            this._carrito = carrito;
            this._item = item;
            this._cantidadNueva = cantidadNueva;
        }
        public void Execute()
        {
            _cantidadAnterior = _item.Cantidad;
            _item.Cantidad = _cantidadNueva;
            _carrito.CambiarCantidad(_item, _cantidadNueva);
            Console.WriteLine($"Cantidad de {_item.Nombre} cambiada a {_cantidadNueva}.");
        }
        public void Undo()
        {
            _item.Cantidad = _cantidadAnterior;
            Console.WriteLine($"Cantidad de {_item.Nombre} cambiada nuevamente a {_cantidadAnterior}.");
        }
    }
}
