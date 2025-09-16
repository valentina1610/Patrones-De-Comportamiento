using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronCommand.Command
{
    public class CambiarCantidadCommand : ICommand
    {
        private int _cantidadNueva;
        private int _cantidadAnterior;
        private Item _item;

        public CambiarCantidadCommand(int _cantidadNueva, int _cantidadAnterior, Item item)
        {
            this._cantidadNueva = _cantidadNueva;
            this._cantidadAnterior = _cantidadAnterior;
            this._item = item;
        }
        public void Execute()
        {
            _cantidadAnterior = _item.Cantidad;
            _item.Cantidad = _cantidadNueva;
            Console.WriteLine($"Cantidad de {_item.Nombre} cambiada a {_cantidadNueva}.");
        }
        public void Undo()
        {
            _item.Cantidad = _cantidadAnterior;
            Console.WriteLine($"Cantidad de {_item.Nombre} cambiada nuevamente a {_cantidadAnterior}.");

        }
    }
}
