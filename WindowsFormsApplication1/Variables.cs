using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuras
{
    class Variables
    {
        //Sqlite Connection string, kad nereiktu kiekviena kart rasyt
        public static string dataSource = @"Data Source = ..\..\Kuras.sqlite; Version = 3;";
        //Visi duomenys
        public static Kortele[] K = new Kortele[0];
        //Judant tarp formu dataGridView pasirinkta eilute
        public static int currentRow = 0;
        //ar pasirinktas failas pylimu
        public static bool pylimaiYra = false;
    }
}
