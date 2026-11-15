using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace league_of_legends
{
    public class Bajnok
    {
        public int bajnok_id { get; set; }
        public string nev { get; set; }
        public string szerepkor { get; set; }
        public DateTime megjelenes_datuma { get; set; }
        public int nehezseg { get; set; }
        public int alap_elet { get; set; }

        public Bajnok(string line)
        {
            string[] parts = line.Split(';');
            bajnok_id = int.Parse(parts[0]);
            nev = parts[1];
            szerepkor = parts[2];
            megjelenes_datuma = DateTime.Parse(parts[3]);
            nehezseg = int.Parse(parts[4]);
            alap_elet = int.Parse(parts[5]);
        }

        // A bajnok adatainak szöveges megjelenítése (a felhasználói keresés kiíratásához)
        public override string ToString()
        {
            return $"Bajnok neve: {nev}{Environment.NewLine}\nSzerepkör: {szerepkor}{Environment.NewLine}\nMegjelenés dátuma: {megjelenes_datuma.ToShortDateString()}{Environment.NewLine}\nNehézség: {nehezseg}{Environment.NewLine}\nAlap élet: {alap_elet}";
        }
    }
}