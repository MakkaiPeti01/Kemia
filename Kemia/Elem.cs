using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kemia
{
    class Elem
    {
        static public int okori;

        private string sEv;

        public string SEV
        {
            get { return sEv; }
        }

        private string nev;

        public string Nev
        {
            get { return nev; }
        }

        private string vegyjel;

        public string Vegyjel
        {
            get { return vegyjel; }
        }

        private string rsz;

        public string Rsz
        {
            get { return rsz; }
        }

        private string felfedezo;

        public string Felfedezo
        {
            get { return felfedezo; }
        }

        public int Ev { get; set; }

        public Elem(string sEv, string nev, string vegyjel, string rsz, string felfedezo)
        {
            this.sEv = sEv;
            this.nev = nev;
            this.vegyjel = vegyjel;
            this.rsz = rsz;
            this.felfedezo = felfedezo;

            if (sEv != "Ókor")
            {
                Ev = int.Parse(sEv);         
            }
            else
            {
                Ev = 0;
                okori++;
            }
        }
    }
}