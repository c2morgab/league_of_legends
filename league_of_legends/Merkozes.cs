using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace league_of_legends
{
    public class Merkozes
    {
        public int merkozes_id { get; set; }
        public int bajnok_id { get; set; }
        public string jatekos_nev { get; set; }
        public DateTime merkozes_datuma { get; set; }
        public int kill { get; set; }
        public int death { get; set; }
        public int assist { get; set; }
        public int gyozelem { get; set; }
        public int idotartam_percben { get; set; }

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

        // Osztálybeli metódus (mérkőzés KDA)
        public double KDA()
        {
            if (death == 0)
            {
                return kill + assist;
            }
            return Math.Round((double)(kill + assist) / death, 2);
        }
    }
}