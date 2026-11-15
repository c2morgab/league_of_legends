using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            Console.WriteLine($"A mérkőzések átlagos időtartama: {avg_match_duration.ToString("F2")} perc\n");

            // Átlag alatti (átlag alatti mérkőzések száma)
            var atlag_alatti = merkozes_lista.Where(x => x.idotartam_percben < avg_match_duration);
            Console.WriteLine($"Az átlag alatti mérkőzések száma: {atlag_alatti.Count()}\n");

            // Adatok száma (összes mérkőzés száma)
            var all_matches = merkozes_lista.Count();
            Console.WriteLine($"Az összes mérkőzés száma: {all_matches}\n");

            // Statisztika (bajnokok száma szerepenként)
            var stat = bajnok_lista.GroupBy(x => x.szerepkor).Select(x => new Dictionary<string, int> { { x.Key, x.Count() } }).ToList();
            stat.ForEach(x => Console.WriteLine($"Szerepkör: {x.Keys.First()} - Bajnokok száma: {x.Values.First()}"));

            // Van-e (van-e 20 gyilkosság feletti mérkőzés)
            var husz_feletti = merkozes_lista.Count(x => x.kill > 20);
            Console.WriteLine(husz_feletti > 20 ? "Igen, van 20 gyilkosság feletti mérkőzés." : "Nem, nincs 20 gyilkosság feletti mérkőzés.");

            // Feltétel szerinti darabszám (hány győzelem született)
            var gyozelem = merkozes_lista.Count(x => x.gyozelem == 1);
            Console.WriteLine($"A győzelmek száma: {gyozelem}\n");

            // Felhasználói keresés (bajnok nevének keresése)
            while (true)
            {
                Console.Write("Kérem adja meg a keresett bajnok nevét: ");
                string keresett_bajnok = Console.ReadLine();
                var bajnok = bajnok_lista.FirstOrDefault(x => x.nev.ToLower() == keresett_bajnok.ToLower());
                if (bajnok != null)
                {
                    Console.WriteLine($"Bajnok neve: {bajnok.nev}");
                    Console.WriteLine($"Szerepkör: {bajnok.szerepkor}");
                    Console.WriteLine($"Megjelenés dátuma: {bajnok.megjelenes_datuma.ToShortDateString()}");
                    Console.WriteLine($"Nehezség: {bajnok.nehezseg}");
                    Console.WriteLine($"Alap élet: {bajnok.alap_elet}\n");
                    break;
                }
                else
                {
                    Console.WriteLine("A keresett bajnok nem található.\n");
                }
            }

            // Fájlba írás (vesztes mérkőzések listája)
            try
            {
                var vesztes_merkozesek = merkozes_lista.Where(x => x.gyozelem == 0).Select(x => $"{x.merkozes_id};{x.bajnok_id};{x.jatekos_nev};{x.merkozes_datuma.ToShortDateString()};{x.kill};{x.death};{x.assist};{x.gyozelem};{x.idotartam_percben}");
                File.WriteAllLines("vesztes_merkozesek.csv", vesztes_merkozesek);
                Console.WriteLine("A vesztes mérkőzések listája sikeresen kiírva a 'vesztes_merkozesek.csv' fájlba.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt a fájl írása közben: {ex.Message}\n");
            }

            // Join() (mérkőzések összekapcsolása a bajnokok adataival)
            var osszekapcsolt_adatok = merkozes_lista.Join(bajnok_lista, m => m.bajnok_id, b => b.bajnok_id, (m, b) => new
            {
                m.jatekos_nev,
                BajnokNev = b.nev,
                b.szerepkor,
                m.kill,
                m.death,
                m.assist,
                m.gyozelem
            }).ToList();
            Console.WriteLine("\nÖsszekapcsolt mérkőzések:");
            foreach (var item in osszekapcsolt_adatok)
            {
                Console.WriteLine(
                    $"{item.jatekos_nev} | {item.BajnokNev} | {item.szerepkor} | K/D/A: {item.kill}/{item.death}/{item.assist} | Győzelem: {item.gyozelem}");
            }

        }
    }
}
