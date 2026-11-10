using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace league_of_legends
{
    public class Merkozes
    {
        int merkozes_id { get; set; }
        int bajnok_id { get; set; }
        string jatekos_nev { get; set; }
        DateTime merkozes_datuma { get; set; }
        int kill { get; set; }
        int death { get; set; }
        int assist { get; set; }
        int gyozelem { get; set; }
        int idotartam_percben { get; set; }

        public Merkozes(string line)
        {
            string[] parts = line.Split(';');
            merkozes_id = int.Parse(parts[0]);
            bajnok_id = int.Parse(parts[1]);
            jatekos_nev = parts[2];
            merkozes_datuma = DateTime.Parse(parts[3]);
            kill = int.Parse(parts[4]);
            death = int.Parse(parts[5]);
            assist = int.Parse(parts[6]);
            gyozelem = int.Parse(parts[7]);
            idotartam_percben = int.Parse(parts[8]);
        }
    }
}
