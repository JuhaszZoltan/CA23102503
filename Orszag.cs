using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA23102503
{
    internal class Orszag
    {
        public string Orszagnev { get; private set; }
        public int Terulet { get; private set; }
        public int Nepesseg { get; private set; }
        public string Fovaros { get; private set; }
        public int FovarosNepesseg { get; private set; }
        public int Nepsuruseg => (int)Math.Round(Nepesseg/(double)Terulet);
        public bool FovarosbaKoncentralodik => FovarosNepesseg * 1000 > Nepesseg * .3;

        public Orszag(string sor)
        {
            var v = sor.Split(';');
            Orszagnev = v[0];
            Terulet = int.Parse(v[1]);
            Nepesseg = int.Parse(v[2].Replace("g", "0000"));
            Fovaros = v[3];
            FovarosNepesseg = int.Parse(v[4]);
        }

        public override string ToString()
        {
            return "";
        }
    }

}
