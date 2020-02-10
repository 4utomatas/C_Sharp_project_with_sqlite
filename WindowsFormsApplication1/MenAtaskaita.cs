using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace Kuras
{
    class MenAtaskaita
    {
        //pagal kortele kiekviena men surenkama info kur aprasoma masinos kuro sanaudu savybes 
        public string data; //data pvz 201602                
        public double suma, //kokia is viso suma uz men
                sumaApmoketa,//kokia suma apmoketa
                virsytasLimitas,//suma - limitas
                km,    //kiek kilometru nuvaziuota
                kmGps, //kiek km nuvaziuota pagal gps rodmenis
                litrai,//uzpilto kuro kiekis litrais
                start, //menesio pradzioje kuro likutis bake
                end;   //menesio gale kuro likutis bake
        public int limit; //kuro sanaudu limitas
        public long cardNumber; // korteles numeris (paskutiniai 6 skaiciai) 

        public MenAtaskaita() { }
        public MenAtaskaita(long cardNumber1, string data1, double suma1, double suma2,
            double km1, double litrai1, double start1, double end1,
            int limit1) 
        {
            cardNumber = cardNumber1;
            data = data1;
            suma = suma1;
            virsytasLimitas = suma2;
            km = km1;
            litrai = litrai1;
            start = start1;
            end = end1;
            limit = limit1;
            if (limit > suma)
                sumaApmoketa = suma;
            else sumaApmoketa = limit;
        }
        public MenAtaskaita(long cardNumber1, string data1, double suma1, double suma2,
            double km1, double km2, double litrai1, double start1, double end1,
            int limit1)
        {
            cardNumber = cardNumber1;
            data = data1;
            suma = suma1;
            virsytasLimitas = suma2;
            km = km1;
            kmGps = km2;
            litrai = litrai1;
            start = start1;
            end = end1;
            limit = limit1;
            if (limit > suma)
                sumaApmoketa = suma;
            else sumaApmoketa = limit;
        }
    }
}
