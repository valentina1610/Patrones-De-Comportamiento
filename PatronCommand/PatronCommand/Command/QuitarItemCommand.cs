using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronCommand.Command
{
    public class QuitarItemCommand : ICommand
    {
        private Carrito _carrito;
        private Item _item;
        private Item _backup;

        public QuitarItemCommand(Carrito carrito, Item item)
        {
            this._carrito = carrito;
            this._item = item;
        }
        public void Execute()
        {
            _backup = new Item(_item.Sku, _item.Nombre, _item.Precio, _item.Cantidad);
            _carrito.Quitar(_item);
        }
        public void Undo()
        {
            _carrito.Agregar(_backup);
        }
    }
}
