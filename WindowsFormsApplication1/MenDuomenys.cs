using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuras
{
    class MenDuomenys
    {
        long cardNumber;
        double litrai;
        double km, kmGps;

        public MenDuomenys() { }
        public MenDuomenys(long card, double litrai1, double km1, double km2)
        {
            cardNumber = card;
            litrai = litrai1;
            km = km1;
            kmGps = km2;
        }
        public double getLitrai()
        {
            return litrai;
        }
        public double getKm()
        {
            return km;
        }
        public double getKmGps()
        {
            return kmGps;
        }
        
    }
}
