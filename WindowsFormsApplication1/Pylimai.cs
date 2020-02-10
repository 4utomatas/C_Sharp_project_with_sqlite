using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuras
{
    class Pylimai
    {
            long cardNumber; //korteles numeris
            //string group; //groupe pvz d01 ir kt 
            string date; //data ir laikas
            string location; //vieta
            string fuel; //dyzelinas ar benzinas ar vinjiete
            double price; // of a litre
            double amount; // of fuel
            double total; //total price
            
        public Pylimai(long cardNumber1, string date1, string location1, string fuel1, double price1, double amount1, double total1)
        {
            cardNumber = cardNumber1; 
            date = date1; 
            location = location1; 
            fuel = fuel1;
            price = price1;
            amount = amount1;
            total = total1;
        }
        public Pylimai() {}


        public double getPrice() { return price; }
        public double getAmount() { return amount; }
        public double getTotal() { return total; }
        public string getLocation() { return location; }
        public string getDate() { return date; }
    
    }
}
