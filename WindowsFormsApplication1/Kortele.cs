using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuras
{
    //pagal kortele kiekviena men surenkama info kur aprasoma masinos kuro sanaudu savybes 
    class Kortele
    {

        long cardNumber; //kortele
        int limit; //limitas kuro sanaudu
        string group; //grupe
        string model; //marke 
        string name; // vardas
        string surname; //pavarde
        string numberPlate; //masinos numeris
        string city; //miestas  
        double suma, //kiek is viso uz kura isleista
                sumaApmoketa; //kiek is viso uz kura sumoketa (padengta sumos)
        int id; 
        public Pylimai[] p = new Pylimai[0];
        public MenAtaskaita[] k = new MenAtaskaita[0];
        public MenDuomenys d;
        public Kortele(string name1, string surname1, string model1,
            string numberPlate1, long cardNumber1, double suma1,
            double sumaApmoketa1, string city1, int limit1, int id1, string group1)
        {
            cardNumber = cardNumber1;
            limit = limit1;
            model = model1;
            name = name1;
            surname = surname1;
            numberPlate = numberPlate1;
            city = city1;
            suma = suma1;
            sumaApmoketa = sumaApmoketa1;
            id = id1;
            group = group1;
        }

        public void update(long cardNumber1, string name1, string surname1,
            string city1, int limit1, string numberPlate1, string model1, string group1)
        {
            cardNumber = cardNumber1;
            limit = limit1;
            group = group1;
            model = model1;
            name = name1;
            surname = surname1;
            numberPlate = numberPlate1;
            city = city1; 
        }     
        //get Functions
        #region
        public string getName()
        {
            return name;
        }
        public string getSurname()
        {
            return surname;
        }
        public string getNumberPlate()
        {
            return numberPlate;
        }
        public string getCity()
        {
            return city;
        }
        public string getModel()
        {
            return model;
        }
        public string getGroup()
        {
            return group;
        }
        public int getLimit()
        {
            return limit;
        }
        public long getCardNumber()
        {
            return cardNumber;
        }
        public double getSuma()
        {
            return suma;
        }
        public double getSumaApmoketa()
        {
            return sumaApmoketa;
        }
        public int getID()
        {
            return id;
        }
        #endregion
    }
}
