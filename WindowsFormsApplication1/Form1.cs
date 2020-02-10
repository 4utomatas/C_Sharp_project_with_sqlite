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
using System.Globalization;
using System.Reflection;
namespace Kuras
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
        //STARTUP
        private void Form1_Load_1(object sender, EventArgs e)
        {
            //keiciama i "." nes SQLite Default decimal separator => "."
            CultureInfo culture = new CultureInfo("lt-LT");
            culture.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            getKorteles();
            getMenesioAtaskaita();
            loadDataGridView_1();
            populateComboBox();
        }

        //Gauti visus nepasleptus vartotojus      
        public void getKorteles()
        {
            SQLiteCommand command;
            SQLiteConnection conn = new SQLiteConnection(Variables.dataSource);
            conn.Open();
            string sql = "SELECT * FROM Korteles WHERE HIDDEN=1";
            command = new SQLiteCommand(sql, conn);
            command.CommandType = CommandType.Text;
            SQLiteDataReader reader = command.ExecuteReader();
            int ind = 0;
            while (reader.Read())
            {
                Array.Resize(ref Variables.K, Variables.K.Length + 1);
                Variables.K[ind] = new Kortele(reader["NAME"] != System.DBNull.Value ? Convert.ToString(reader["NAME"]) : null,
                    reader["SURNAME"] != System.DBNull.Value ? Convert.ToString(reader["SURNAME"]) : null,
                    reader["MODEL"] != System.DBNull.Value ? Convert.ToString(reader["MODEL"]) : null,
                    reader["NUMBERPLATE"] != System.DBNull.Value ? Convert.ToString(reader["NUMBERPLATE"]) : null,
                    reader["CARDNUMBER"] != System.DBNull.Value ? Convert.ToInt64(reader["CARDNUMBER"]) : -1,
                    reader["SUMA"] != System.DBNull.Value ? Convert.ToDouble(reader["SUMA"]) : -1,
                    reader["SUMAPMOKETA"] != System.DBNull.Value ? Convert.ToDouble(reader["SUMAPMOKETA"]) : -1,
                    reader["CITY"] != System.DBNull.Value ? Convert.ToString(reader["CITY"]) : null,
                    reader["LIMITAS"] != System.DBNull.Value ? Convert.ToInt32(reader["LIMITAS"]) : -1,
                    reader["ID"] != System.DBNull.Value ? Convert.ToInt32(reader["ID"]) : -1,
                    reader["GRUPE"] != System.DBNull.Value ? Convert.ToString(reader["GRUPE"]) : null);
                ind++;
            }
            conn.Close();
        }
        //(Istrinti vartotoja)
        public void deleteKortele(int id)
        {
            SQLiteCommand com;
            SQLiteConnection conn = new SQLiteConnection(Variables.dataSource);
            conn.Open();
            string sql = "UPDATE Korteles SET HIDDEN = '0' WHERE ID = '" + id + "';";
            com = new SQLiteCommand(sql, conn);
            com.ExecuteNonQuery();
            conn.Close();
        }
        
        //Menesio ataskaitos
        public void getMenesioAtaskaita()
        {
            using (SQLiteConnection connect = new SQLiteConnection(Variables.dataSource))
            {
                connect.Open();
                using (SQLiteCommand cmd = connect.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM MenesioAtaskaita";
                    cmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        int index = Array.IndexOf(Variables.K, Variables.K.FirstOrDefault(
                            val => val.getCardNumber() == Convert.ToInt64(r["CARDNUMBER"])));
                        if (index != -1)
                        {
                            Array.Resize(ref Variables.K[index].k, Variables.K[index].k.Length + 1);
                            Variables.K[index].k[Variables.K[index].k.Length - 1] = new MenAtaskaita();
                            Variables.K[index].k[Variables.K[index].k.Length - 1].data = Convert.ToString(r["DATA"]);
                            Variables.K[index].k[Variables.K[index].k.Length - 1].suma = Convert.ToDouble(r["SUMA"]);
                            Variables.K[index].k[Variables.K[index].k.Length - 1].virsytasLimitas = Convert.ToDouble(r["VIRSYTASLIMITAS"]);
                            Variables.K[index].k[Variables.K[index].k.Length - 1].limit = Convert.ToInt32(r["LIMITAS"]);
                            Variables.K[index].k[Variables.K[index].k.Length - 1].km = Convert.ToDouble(r["KM"]);
                            Variables.K[index].k[Variables.K[index].k.Length - 1].sumaApmoketa =
                                Variables.K[index].k[Variables.K[index].k.Length - 1].suma;
                            Variables.K[index].k[Variables.K[index].k.Length - 1].litrai = Convert.ToDouble(r["LITRAI"]);
                            Variables.K[index].k[Variables.K[index].k.Length - 1].start = Convert.ToDouble(r["START"]);
                            Variables.K[index].k[Variables.K[index].k.Length - 1].end = Convert.ToDouble(r["END"]);
                            Variables.K[index].k[Variables.K[index].k.Length - 1].kmGps = Convert.ToDouble(r["KMGPS"]);
                            Variables.K[index].k[Variables.K[index].k.Length - 1].cardNumber = Variables.K[index].getCardNumber();
                        }
                    }
                }
            }
        }
        
        //dataGridView1 populiacija
        public void loadDataGridView_1()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            foreach (var k in Variables.K)
            {

                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = k.getName();
                dataGridView1[1, i].Value = k.getSurname();
                dataGridView1[2, i].Value = k.getCardNumber();
                dataGridView1[3, i].Value = k.getLimit();
                dataGridView1[4, i].Value = k.getCity();
                dataGridView1[5, i].Value = k.getNumberPlate();
                dataGridView1[6, i].Value = k.getModel();
                i++;
            }
        }
        //Search funkcijos dataGridView1 populiacija
        public void loadDataGridView_1(string cardNumber)
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            foreach (var k in Variables.K)
            {
                if (Convert.ToString(k.getCardNumber()).Contains(cardNumber))
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, i].Value = k.getName();
                    dataGridView1[1, i].Value = k.getSurname();
                    dataGridView1[2, i].Value = k.getCardNumber();
                    dataGridView1[3, i].Value = k.getLimit();
                    dataGridView1[4, i].Value = k.getCity();
                    dataGridView1[5, i].Value = k.getNumberPlate();
                    dataGridView1[6, i].Value = k.getModel();
                    i++;
                }
            }
        }
        //Vartotoju Grupes
        public void populateComboBox()
        {
            comboBox1.Items.Clear();
            List<string> groups = new List<string>();
            groups.Add("Visi");
            foreach(var kortele in Variables.K)
            {
                if(!groups.Contains(kortele.getGroup()) && kortele.getGroup() != null)
                {
                    groups.Add(kortele.getGroup());
                }
            }
            comboBox1.Items.AddRange(groups.ToArray());
            comboBox1.SelectedIndex = 0;
        }
        //Istrinti vartotoja
        private void button2_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            int id = Variables.K.Single(val => val.getCardNumber() == Convert.ToInt64(dataGridView1[2, row].Value)).getID();
            Variables.K = Variables.K.Where(val => val.getCardNumber() != Convert.ToInt64(dataGridView1[2, row].Value)).ToArray();
            deleteKortele(id);
            loadDataGridView_1();
        }
        
        //Search
        private void button4_Click(object sender, EventArgs e)
        {
            string text = searchBox.Text;
            loadDataGridView_1(text);
        }              
        //rodyti pylimus
        private void button6_Click(object sender, EventArgs e)
        {
            //pereina i kita langa
            Variables.currentRow = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            Form2 frm = new Form2();
            frm.Show();
        }
        //atveria menesio ataskaitas
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = 0;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            int currentRow = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            var temp = Variables.K.FirstOrDefault(x => x.getCardNumber() == currentRow).k;
            foreach (var k in temp)
            {
                dataGridView2.Rows.Add();
                dataGridView2[0, i].Value = k.data;
                dataGridView2[1, i].Value = Math.Round(k.suma,3);
                dataGridView2[2, i].Value = Math.Round(k.sumaApmoketa, 3);
                dataGridView2[3, i].Value = k.virsytasLimitas;
                if(k.virsytasLimitas > 0)
                {
                    dataGridView2[3, i].Style.ForeColor = Color.Red;
                }
                dataGridView2[4, i].Value = k.limit;
                dataGridView2[5, i].Value = k.km != 0 ? Math.Round((k.litrai / k.km) * 100, 3) : 0;
                dataGridView2[6, i].Value = k.km;
                dataGridView2[7, i].Value = k.kmGps;
                dataGridView2[8, i].Value = k.litrai;
                dataGridView2[9, i].Value = k.start;
                dataGridView2[10, i].Value = k.end;
                i++;
            }
            dataGridView2.Sort(dataGridView2.Columns["data"], ListSortDirection.Descending);
        }
        //formuoti ataskaita
        private void button7_Click(object sender, EventArgs e)
        {
            if (Variables.pylimaiYra)
            {
                openFileDialog1.Filter = "TXT files|*.txt";
                openFileDialog1.Title = "Pasirinkite Menesio Duomenų failą";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Sėkmingai pridėti Mėnesio duomenys!");
                    Functions.formuotiAtaskaita(openFileDialog1.FileName.ToString());
                    MessageBox.Show("Sėkmingai suformuota ataskaita!");
                }
                else
                {
                    MessageBox.Show("Nepavyko pasirinkti Mėnesio Duomenų failo! Bandykite dar kartą.");
                }
            }
            else
            {
                MessageBox.Show("Pasirinkite Mėnesio Pylimų failą!");
            }
        }
        //pasirinkus grupe atnaujina sarasa automobiliu
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string groupName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            if (groupName == "Visi")
            {
                loadDataGridView_1();
                return;
            }
            int i = 0;
            dataGridView1.Rows.Clear();
            foreach (var k in Variables.K)
            {
                if (k.getGroup() != null && k.getGroup().Contains(groupName))
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, i].Value = k.getName();
                    dataGridView1[1, i].Value = k.getSurname();
                    dataGridView1[2, i].Value = k.getCardNumber();
                    dataGridView1[3, i].Value = k.getLimit();
                    dataGridView1[4, i].Value = k.getCity();
                    dataGridView1[5, i].Value = k.getNumberPlate();
                    dataGridView1[6, i].Value = k.getModel();
                    i++;
                }
            }                   
        }
        //pasirinkti pylimu faila
        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "TXT files|*.txt";
            openFileDialog1.Title = "Pasirinkite Pylimų failą";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Functions.getPylimaiData(openFileDialog1.FileName.ToString());
                MessageBox.Show("Sėkmingai pridėti pylimai!");
                button8.FlatAppearance.BorderColor = System.Drawing.Color.Green;
                Variables.pylimaiYra = true;
            }
        }
        //Print Visi
        private void button9_Click(object sender, EventArgs e)
        {
            int a = comboBox1.SelectedIndex;

            string groupName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            Functions.printVisi(groupName);
        }
        //Print Skolingi
        private void button3_Click(object sender, EventArgs e)
        {
            int a = comboBox1.SelectedIndex;

            string groupName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            Functions.printSkolingi(groupName);

        }
        //naujas vartotojas
        private void button5_Click(object sender, EventArgs e)
        {
            naujas frm1 = new naujas();
            frm1.Show();
            frm1.FormClosing += frm1_FormClosing;
        }
        //naujas close event
        void frm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            loadDataGridView_1();
        }
        //redaguoti
        private void button10_Click(object sender, EventArgs e)
        {
            Variables.currentRow = int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            redaguoti frm2 = new redaguoti();
            frm2.Show();
            frm2.FormClosing += frm2_FormClosing;
        }
        //redaguoti close event
        void frm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            loadDataGridView_1();
        }      
    }
}
