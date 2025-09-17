using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatronCommand.Command;


namespace PatronCommand.Command
{
    public class MacroCommand : ICommand
    {
        private readonly List<ICommand> _commands;

        public MacroCommand(List<ICommand> commands)
        {
            this._commands = commands;
        }

        public void Execute()
        {
            foreach (var cmd in _commands)
            {
                cmd.Execute();
            }
        }
        public void Undo()
        {
            for (int i = _commands.Count-1; i>0; i++)
            {
                _commands[i].Undo();
            }
        }
    }
}
