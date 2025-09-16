using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronCommand.Command
{
    public class AgregarItemCommand : ICommand
    {
        private Carrito _carrito;
        private Item _item;

        public AgregarItemCommand(Carrito carrito, Item item)
        {
            this._carrito = carrito;
            this._item = item;
        }
        public void Execute()
        {
            _carrito.Agregar(_item);
        }
        public void Undo()
        {
            _carrito.Quitar(_item);
        }
    }
}
