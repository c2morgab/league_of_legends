using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace league_of_legends
{
    public class Bajnok
    {
        int bajnok_id { get; set; }
        string nev { get; set; }
        string szerepkor { get; set; }
        DateTime megjelenes_datuma { get; set; }
        int nehezseg { get; set; }
        int alap_elet { get; set; }

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
    }
}
