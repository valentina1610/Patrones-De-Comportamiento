using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatronCommand.Command;

namespace PatronCommand.Invoker
{
    public class EditorInvoker
    {
        // INVOCADOR (Invoker): maneja la ejecución y el historial para Undo/Redo.
        // Guarda pilas de comandos ejecutados y comandos deshechos.
        private readonly Stack<ICommand> _undo = new();
        private readonly Stack<ICommand> _redo = new();
        public void Run(ICommand cmd)
        {
            cmd.Execute();
            _undo.Push(cmd);
            _redo.Clear();
        }
        public void Undo()
        {
            if (_undo.Count == 0) return;
            var cmd = _undo.Pop();
            cmd.Undo();
            _redo.Push(cmd);
        }
        public void Redo()
        {
            if (_redo.Count == 0) return;
            var cmd = _redo.Pop();
            cmd.Execute();
            _undo.Push(cmd);
        }
    }

}
