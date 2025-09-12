using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatronStrategy.Interfaces;
using PatronStrategy.Strategys;

namespace PatronStrategy.Factory
{
    public static class DescuentoFactory
    {
        public static IDescuentoStrategy Crear(string codigo)
        {
            switch(codigo.ToUpper())
            {
                case "WKND":
                    {
                        return new Porcentaje(0.50m);
                    }
                case "BANK":
                    {
                        return new TopeBanco(5000m, 5000m);
                    }
                default:
                    {
                        Console.WriteLine("Codigo invalido!");
                        return new SinDescuento();
                    }
            }
        }
    }
}
