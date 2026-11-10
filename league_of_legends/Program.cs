using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace league_of_legends
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Listák meghívása és feltöltése
            List<Merkozes> merkozes_lista = new List<Merkozes>();
            foreach (string item in File.ReadAllLines("LoL_merkozesek.csv").Skip(1))
            {
                merkozes_lista.Add(new Merkozes(item));
            }
            List<Bajnok> bajnok_lista = new List<Bajnok>();
            foreach (string item in File.ReadAllLines("LoL_bajnokok.csv").Skip(1))
            {
                bajnok_lista.Add(new Bajnok(item));
            }
        }
    }
}
