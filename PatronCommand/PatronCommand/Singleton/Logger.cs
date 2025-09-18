using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronCommand.Singleton
{
    public class Logger
    {
        private static Logger _instance;
        private List<string> _logs = new();

        private Logger() { }   // Constructor privado para que nadie pueda hacer new Logger()

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Logger();
                return _instance;
            }
        }

        public void Log(string mensaje)
        {
            string linea =($"{DateTime.Now}: {mensaje}");
            _logs.Add(linea);
            Console.WriteLine(linea);
        }
        public void ShowLogs()
        {
            Console.WriteLine("=== HISTORIAL DE LOGS ===");
            foreach (var i in _logs)
                Console.WriteLine(i);
        }
    }
}
