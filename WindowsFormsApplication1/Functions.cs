using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using ClosedXML.Excel;
namespace Kuras
{
    class Functions
    {        
        //Ivedami is failo Menesio duomenys apie automobilius
        public static void getMenDuomenys(string menDuomFile1)
        {
            char[] sk = { ';', '\t' }; // Skirtukų masyvas
            string[] garazas = File.ReadAllLines(menDuomFile1, Encoding.GetEncoding(1257));
            foreach (var el in garazas)
            {
                string[] w = el.Split(sk);
                for (int i = 0; i < w.Length; i++)
                {
                    w[i] = w[i].Trim(' ');
                }
                if (w.Length >= 4)
                {
                    long cardNumber = long.Parse(w[0]);
                    int index = Array.IndexOf(Variables.K, Variables.K.FirstOrDefault(val => val.getCardNumber() == cardNumber));
                    if (index != -1)
                    {
                        //Array.Resize(ref Variables.K[index].d, Variables.K[index].d.Length + 1);
                        Variables.K[index].d = new MenDuomenys(
                            cardNumber, double.Parse(w[1], System.Globalization.CultureInfo.InvariantCulture),
                            double.Parse(w[2], System.Globalization.CultureInfo.InvariantCulture),
                            double.Parse(w[3], System.Globalization.CultureInfo.InvariantCulture));                          
                    }
                }
            }
        }           
        //Ivedami is failo Pylimu duomenys
        public static void getPylimaiData(string fileName)
        {
            char[] sk = { ';', '\t' }; // Skirtukų masyvas
            string[] garazas = File.ReadAllLines(fileName, Encoding.GetEncoding(1257));
            SQLiteConnection conn = new SQLiteConnection(Variables.dataSource);
            conn.Open();
            SQLiteCommand comm = new SQLiteCommand("begin", conn);
            comm.ExecuteNonQuery();
            string sql;
            foreach (var el in garazas)
            {
                string[] w = el.Split(sk);
                for (int i = 0; i < w.Length; i++)
                {
                    w[i] = w[i].Trim(' ');
                }
                if (w.Length >= 10)
                {
                    string[] a = { w[0], w[2], w[4], w[7], w[8], w[9], w[10] };
                    long cardNumber = 0;
                    long.TryParse(a[0], out cardNumber);
                    if (cardNumber != 0)
                    {
                        cardNumber = cardNumber % 1000000;
                        int index = Array.IndexOf(Variables.K, Variables.K.FirstOrDefault(val => val.getCardNumber() == cardNumber));
                        if (index != -1)
                        {
                            double price = 0;
                            double.TryParse(a[4], out price);                      
                            double amount = 0;
                            double.TryParse(a[5], out amount);
                            double total = 0;
                            double.TryParse(a[6], out total);

                            Array.Resize(ref Variables.K[index].p, Variables.K[index].p.Length + 1);
                            Variables.K[index].p[Variables.K[index].p.Length - 1] = new Pylimai(
                                cardNumber, a[1], a[2], a[3], price, amount, total);

                            sql = "SELECT * FROM Pylimai WHERE DATA ='"+ a[1] +"' AND LOCATION='" + a[2] + 
                                "' AND CARDNUMBER='" + cardNumber + "';";
                            comm = new SQLiteCommand(sql, conn);
                            //jei toks irasas jau egzistuoja, naujas nera sukuriamas
                            var query = comm.ExecuteScalar();
                            if (query == null)
                            {
                                sql = @"INSERT INTO Pylimai(CARDNUMBER, DATA, LOCATION, FUEL, AMOUNT, PRICE, SUMA)
                                    values('" + cardNumber + "','" + a[1] + "','" + a[2] + "','" + a[3]
                                        + "','" + a[4] + "','" + a[5] + "','" + a[6] + "')";
                                comm = new SQLiteCommand(sql, conn);
                                comm.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            comm = new SQLiteCommand("end", conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }      
        //Formuojama ataskaita
        public static void formuotiAtaskaita(string menDuomFile1)
        {
            getMenDuomenys(menDuomFile1);

            long cardNumber = 0;
            int limitas = 0;
            double km;
            double kmGps;
            double litrai = 0;
            double start, end;
            double suma = 0;

            StringBuilder data1 = new StringBuilder();
            DateTime date = DateTime.Today;
            date.AddMonths(-1);
            data1.AppendFormat("{0}{1}", date.Year.ToString(), date.Month.ToString("00"));        
            //tas pats menesis kaip ir daroma ataskaita
            string data = data1.ToString();
            date = date.AddMonths(-1);
            StringBuilder dataAgo1 = new StringBuilder();
            string dataAgo = dataAgo1.AppendFormat("{0}{1}", date.Year.ToString(), date.Month.ToString("00")).ToString();
            using (SQLiteConnection conn = new SQLiteConnection(Variables.dataSource))
            {
                conn.Open();
                SQLiteCommand comm;
                string sql;
                comm = new SQLiteCommand("begin", conn);
                comm.ExecuteNonQuery();

                foreach (var kortele in Variables.K)
                {
                    //iesko ar nera jau to menesio ataskaitu
                    int temp = kortele.k.Count(x => x.data == data);
                    if (temp == 0)
                    {
                        suma = 0;
                        litrai = 0;
                        if (kortele.d != null)
                        {
                            foreach (var pylimas in kortele.p)
                            {
                                litrai += pylimas.getAmount();
                                suma += pylimas.getTotal();
                            }
                            cardNumber = kortele.getCardNumber();
                            km = kortele.d.getKm();
                            kmGps = kortele.d.getKmGps();
                            start = 0;
                            if (kortele.k.FirstOrDefault(x => x.data == dataAgo) != null)
                                start = kortele.k.FirstOrDefault(x => x.data == dataAgo).end;
                            end = kortele.d.getLitrai();
                            limitas = kortele.getLimit();
                            Array.Resize(ref kortele.k, kortele.k.Length + 1);
                            double virsyta = 0;
                            if (limitas >= suma)
                                virsyta = 0;
                            else virsyta = suma - limitas;
                            kortele.k[kortele.k.Length - 1] = new MenAtaskaita(cardNumber, data, suma, Math.Round(virsyta, 3),
                                km, kmGps, litrai, start, end, limitas);

                            sql = @"INSERT INTO MenesioAtaskaita(CARDNUMBER, DATA, SUMA, VIRSYTASLIMITAS,
                                LIMITAS, KM, KMGPS, LITRAI, START, END)
                                VALUES('" + cardNumber + "','" + data + "','" +
                                    suma + "','" + virsyta + "','" + limitas + "','" +
                                    km + "','" + kmGps + "','" + litrai + "','" + start + "','" + end + "');";
                            comm = new SQLiteCommand(sql, conn);
                            comm.ExecuteNonQuery();
                        }
                    }
                }
                comm = new SQLiteCommand("end", conn);
                comm.ExecuteNonQuery();               
            }
        }
        //Spausdinti Vairuotojus visus(ar grupes), kurie virsijo sumos limita 
        public static void printSkolingi(string groupName)
        {
            var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Skolingi");

            //headers
            ws.Cell(1, 1).Value = "Kortelė";
            ws.Cell(1, 2).Value = "Vardas";
            ws.Cell(1, 3).Value = "Pavardė";
            ws.Cell(1, 4).Value = "Automobilis";
            ws.Cell(1, 5).Value = "Num.";
            ws.Cell(1, 6).Value = "Miestas";
            ws.Cell(1, 7).Value = "Ltr.";
            ws.Cell(1, 8).Value = "L/100km";
            ws.Cell(1, 9).Value = "km";
            ws.Cell(1, 10).Value = "km GPS";
            ws.Cell(1, 11).Value = "Suma";
            ws.Cell(1, 12).Value = "Skola";
            ws.Cell(1, 13).Value = "Limit";

            DateTime date1 = DateTime.Today;
            string data = date1.Year + date1.Month.ToString("00");
            int i = 2;
            int max = -100;
            foreach (var el in Variables.K)
            {
                if (el.getGroup() == groupName || groupName == "Visi")
                {
                    var skola = el.k.FirstOrDefault(x => x.limit < x.suma && x.data == data);
                    if (skola != null)
                    {
                        ws.Cell(i, 1).Value = el.getCardNumber();
                        ws.Cell(i, 2).Value = el.getName();
                        ws.Cell(i, 3).Value = el.getSurname();// skola.virsytasLimitas;
                        ws.Cell(i, 4).Value = el.getModel();
                        if (el.getModel().Length > max)
                            max = el.getModel().Length;
                        ws.Cell(i, 5).Value = el.getNumberPlate();
                        ws.Cell(i, 6).Value = el.getCity();
                        var kuras = el.k.FirstOrDefault(x => x.data == data);
                        ws.Cell(i, 7).Value = kuras.litrai;
                        ws.Cell(i, 8).Value = kuras.km > 0 ? (Math.Round((kuras.litrai / kuras.km) * 100, 1)).ToString() : "N/A";
                        ws.Cell(i, 9).Value = Math.Round(kuras.km);
                        ws.Cell(i, 10).Value = Math.Round(kuras.kmGps);
                        ws.Cell(i, 11).Value = Math.Round(kuras.suma, 2);
                        ws.Cell(i, 12).Value = Math.Round(kuras.virsytasLimitas, 1);
                        ws.Cell(i, 13).Value = kuras.limit;
                        i++;
                    }
                }
            }


            var firstCell = ws.FirstCellUsed();
            var lastCell = ws.LastCellUsed();
            var range = ws.Range(firstCell.Address, lastCell.Address);
            var table = range.CreateTable();

            //header style
            var rngHeaders = table.Range("A1:M1"); // The address is relative to rngTable (NOT the worksheet)
            rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            //atskiru stulpeliu style
            ws.Columns().AdjustToContents();
            ws.Column(1).Width = 8;
            ws.Column(1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Column(4).Width = max + 4;           
            ws.Column(5).Width = 8;
            ws.Column(6).Width = 8;
            ws.Column(6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Column(7).Width = 10;
            ws.Columns(8, 13).Width = 7;
            ws.Columns(7, 8).Style.NumberFormat.NumberFormatId = 2;
            ws.Columns(9, 10).Style.NumberFormat.NumberFormatId = 1;
            ws.Columns(11, 12).Style.NumberFormat.NumberFormatId = 2;
            ws.Column(12).Style.Font.Bold = true;
            ws.PageSetup.Margins.Left = 0.4;
            ws.PageSetup.Margins.Right = 0.4;
            ws.PageSetup.SetRowsToRepeatAtTop(1, 1);
            ws.PageSetup.PagesWide = 1;
            workbook.SaveAs(@"Results.xlsx");
            //paleidzia faila
            System.Diagnostics.Process.Start(@"Results.xlsx");
        }
        //Spausdinti Vairuotojus visus(ar grupes)
        public static void printVisi(string groupName)
        {
            var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Visi");

            //headers
            ws.Cell(1, 1).Value = "Kortelė";
            ws.Cell(1, 2).Value = "Vardas";
            ws.Cell(1, 3).Value = "Pavardė";
            ws.Cell(1, 4).Value = "Automobilis";
            ws.Cell(1, 5).Value = "Num.";
            ws.Cell(1, 6).Value = "Miestas";
            ws.Cell(1, 7).Value = "Ltr.";
            ws.Cell(1, 8).Value = "L/100km";
            ws.Cell(1, 9).Value = "km";
            ws.Cell(1, 10).Value = "km GPS";
            ws.Cell(1, 11).Value = "Suma";
            ws.Cell(1, 12).Value = "Skola";
            ws.Cell(1, 13).Value = "Limit";


            DateTime date1 = DateTime.Today;
            string data = date1.Year + date1.Month.ToString("00");
            int i = 2;
            int max = -100;
            foreach (var el in Variables.K)
            {              
                if (el.getGroup() == groupName || groupName == "Visi")
                {
                    var skola = el.k.FirstOrDefault(x => x.data == data);
                    if (skola != null)
                    {
                        ws.Cell(i, 1).Value = el.getCardNumber();
                        ws.Cell(i, 2).Value = el.getName();
                        ws.Cell(i, 3).Value = el.getSurname();// skola.virsytasLimitas;
                        ws.Cell(i, 4).Value = el.getModel();
                        if (el.getModel().Length > max)
                            max = el.getModel().Length;
                        ws.Cell(i, 5).Value = el.getNumberPlate();
                        ws.Cell(i, 6).Value = el.getCity();
                        var kuras = el.k.FirstOrDefault(x => x.data == data);
                        ws.Cell(i, 7).Value = kuras.litrai;
                        ws.Cell(i, 8).Value = kuras.km > 0 ? (Math.Round((kuras.litrai / kuras.km) * 100, 1)).ToString() : "N/A";
                        ws.Cell(i, 9).Value = Math.Round(kuras.km);
                        ws.Cell(i, 10).Value = Math.Round(kuras.kmGps);
                        ws.Cell(i, 11).Value = Math.Round(kuras.suma, 2);
                        ws.Cell(i, 12).Value = Math.Round(kuras.virsytasLimitas, 1);
                        ws.Cell(i, 13).Value = kuras.limit;
                        i++;
                    }
                }
            }


            var firstCell = ws.FirstCellUsed();
            var lastCell = ws.LastCellUsed();
            var range = ws.Range(firstCell.Address, lastCell.Address);
            var table = range.CreateTable();

            //header style
            var rngHeaders = table.Range("A1:M1"); // The address is relative to rngTable (NOT the worksheet)
            rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


            //atskiru stulpeliu style
            ws.Columns().AdjustToContents();
            ws.Column(1).Width = 8;
            ws.Column(1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Column(4).Width = max + 4;
            ws.Column(5).Width = 8;
            ws.Column(6).Width = 8;
            ws.Column(6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Column(7).Width = 10;
            ws.Columns(8, 13).Width = 7;
            ws.Columns(7, 8).Style.NumberFormat.NumberFormatId = 2;
            ws.Columns(9, 10).Style.NumberFormat.NumberFormatId = 1;
            ws.Columns(11, 12).Style.NumberFormat.NumberFormatId = 2;
            ws.Column(12).Style.Font.Bold = true;
            ws.PageSetup.Margins.Left = 0.4;
            ws.PageSetup.Margins.Right = 0.4;
            ws.PageSetup.SetRowsToRepeatAtTop(1, 1);
            ws.PageSetup.PagesWide = 1;
            workbook.SaveAs(@"Results.xlsx");
            //paleidzia faila
            System.Diagnostics.Process.Start(@"Results.xlsx");
        }
        //nenaudojama
        #region
        //funkcija naudota kurti lenteles database'e
        public static void createNewDB()
        {
            SQLiteCommand com;
            //SQLiteConnection.CreateFile("Kuras.dbf");
            SQLiteConnection conn = new SQLiteConnection("Data Source = Kuras.dbf; Version = 3;");
            conn.Open();

            string sql = @"CREATE TABLE MenDuomenys(
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                CARDNUMBER     VARCHAR(255),
                LITRAI REAL,
                KM REAL,
                KMGPS REAL);";
            com = new SQLiteCommand(sql, conn);
            com.ExecuteNonQuery();
            conn.Close();
        }
        //funkcija sukelti duomenis apie vartotojus is txt failo
        public static void updateNewDB()
        {
            SQLiteCommand com;
            SQLiteConnection conn = new SQLiteConnection("Data Source = Kuras.dbf; Version = 3;");
            conn.Open();
            int ind = 1;
            foreach (var n in Variables.K)
            {
                /*string sql =
                @"INSERT INTO Korteles (NAME, SURNAME, MODEL, NUMBERPLATE, CARDNUMBER, SUMA, SUMAPMOKETA, CITY, LIMITAS) values ('"
                + n.getName() + "','" + n.getSurname() + "','" + n.getModel() + "','" + n.getNumberPlate()
                + "','" + n.getCardNumber() + "','" + n.getSuma()
                + "','" + n.getSumaApmoketa() + "','" + n.getCity()
                + "','" + n.getLimit() +
                "')";
                */

                string sql = @"UPDATE Korteles SET ID ='" + ind + "'WHERE NUMBERPLATE = '" + n.getNumberPlate() + "';";
                com = new SQLiteCommand(sql, conn);
                com.ExecuteNonQuery();
                ind++;
            }
            conn.Close();
        }
        //funkcija sukelti menesio ataskaitas is txt failo
        public static void getDataAboutUsers()
        {
            char[] sk = { ';', '\t' }; // Skirtukų masyvas
            string[] garazas = File.ReadAllLines(@"..\..\1.txt", Encoding.GetEncoding(1257));
            int ind = 0;
            using (SQLiteConnection conn = new SQLiteConnection(Variables.dataSource))
            {
                //System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
                conn.Open();
                SQLiteCommand comm;
                string sql;
                comm = new SQLiteCommand("begin", conn);
                comm.ExecuteNonQuery();
                foreach (var el in garazas)
                {
                    string[] w = el.Split(sk);
                    for (int i = 0; i < w.Length; i++)
                    {
                        w[i] = w[i].Trim(' ');
                    }
                    if (w.Length == 10)
                    {
                        long temp;
                        long.TryParse(w[1], out temp);
                        int index = Array.IndexOf(Variables.K, Variables.K.FirstOrDefault(val => val.getCardNumber() == temp));// ? null : Variables.K.Single(val => val.getCardNumber() == int.Parse(w[1])));
                        if (index != -1)
                        {
                            Array.Resize(ref Variables.K[index].k, Variables.K[index].k.Length + 1);
                            Variables.K[index].k[Variables.K[index].k.Length - 1] = new MenAtaskaita();
                            Variables.K[index].k[Variables.K[index].k.Length - 1].data = w[0];
                            Variables.K[index].k[Variables.K[index].k.Length - 1].suma = float.Parse(w[2], System.Globalization.CultureInfo.InvariantCulture);
                            Variables.K[index].k[Variables.K[index].k.Length - 1].virsytasLimitas = double.Parse(w[3], System.Globalization.CultureInfo.InvariantCulture);
                            Variables.K[index].k[Variables.K[index].k.Length - 1].limit = int.Parse(w[4]);
                            Variables.K[index].k[Variables.K[index].k.Length - 1].km = double.Parse(w[6], System.Globalization.CultureInfo.InvariantCulture);
                            Variables.K[index].k[Variables.K[index].k.Length - 1].litrai = double.Parse(w[7], System.Globalization.CultureInfo.InvariantCulture);
                            Variables.K[index].k[Variables.K[index].k.Length - 1].start = double.Parse(w[8], System.Globalization.CultureInfo.InvariantCulture);
                            Variables.K[index].k[Variables.K[index].k.Length - 1].end = double.Parse((double.Parse(w[9], System.Globalization.CultureInfo.InvariantCulture)).ToString(System.Globalization.CultureInfo.CurrentCulture));
                            Variables.K[index].k[Variables.K[index].k.Length - 1].cardNumber = Variables.K[index].getCardNumber();

                            var temp1 = Variables.K[index].k[Variables.K[index].k.Length - 1];

                            sql = @"INSERT INTO MenesioAtaskaita(CARDNUMBER, DATA, SUMA, VIRSYTASLIMITAS,
                                LIMITAS, KM, KMGPS, LITRAI, START, END)
                                VALUES('" + Variables.K[index].getCardNumber() + "','" + temp1.data + "','" +
                                    temp1.suma + "','" + temp1.virsytasLimitas + "','" + temp1.limit + "','" +
                                    temp1.km + "','" + temp1.kmGps + "','" + temp1.litrai + "','" + temp1.start + "','" + temp1.end + "');";
                            comm = new SQLiteCommand(sql, conn);
                            comm.ExecuteNonQuery();

                            ind++;
                        }
                    }
                }
                comm = new SQLiteCommand("end", conn);
                comm.ExecuteNonQuery();
            }
            //SQLiteConnection conn = new SQLiteConnection("Data source = ")

        }
        #endregion
    }
}
