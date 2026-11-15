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

            // Maximum keresés (legtöbb gyilkosság)
            var max_kill = merkozes_lista.Max(x => x.kill);
            Console.WriteLine($"A legtöbb gyilkosság egy mérkőzésen: {max_kill}\n");

            // Minimum keresés (legkevesebb halál)
            var min_death = merkozes_lista.Min(x => x.death);
            Console.WriteLine($"A legkevesebb halál egy mérkőzésen: {min_death}\n");

            // Összegzés (összes gyilkosság száma)
            var all_kill = merkozes_lista.Sum(x => x.kill);
            Console.WriteLine($"Az összes gyilkosság száma: {all_kill}\n");

            // Átlag (mérkőzések átlagos időtartama)
            var avg_match_duration = merkozes_lista.Average(x => x.idotartam_percben);
        }
    }
}
