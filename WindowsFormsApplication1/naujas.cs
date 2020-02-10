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
namespace Kuras
{
    public partial class naujas : Form
    {
        public naujas()
        {
            InitializeComponent();
        }
        //Sukurti nauja vartotoja
        private void button1_Click(object sender, EventArgs e)
        {
            string vardas, pavarde, miestas, numeris, modelis;
            string grupe;
            long kortele = -1;
            int limitas = -1;
            long.TryParse(textBox1.Text, out kortele);
            vardas = textBox2.Text;
            pavarde = textBox3.Text;
            miestas = textBox5.Text;
            int.TryParse(textBox4.Text, out limitas);
            numeris = textBox6.Text;
            modelis = textBox7.Text;
            grupe  = textBox8.Text;
            if (vardas != null && pavarde != null && miestas != null && numeris != null &&
                modelis != null && grupe != null && kortele != -1 && limitas != -1)
            {
                Array.Resize(ref Variables.K, Variables.K.Length + 1);
                Variables.K[Variables.K.Length - 1] = new Kortele(vardas, pavarde, modelis, numeris,
                    kortele, 0, 0, miestas, limitas, Variables.K[Variables.K.Length - 2].getID() + 1, grupe);
                
                SQLiteCommand comm;
                SQLiteConnection conn;

                using (conn = new SQLiteConnection(Variables.dataSource))
                {
                    conn.Open();
                    string sql =
                    @"INSERT INTO Korteles (NAME, SURNAME, MODEL, NUMBERPLATE, CARDNUMBER, SUMA, SUMAPMOKETA, CITY, LIMITAS, GRUPE) values ('"
                    + vardas + "','" + pavarde + "','" + modelis + "','" + numeris
                    + "','" + kortele + "','" + 0
                    + "','" + 0 + "','" + miestas
                    + "','" + limitas + "','" + grupe + 
                    "')";
                    comm = new SQLiteCommand(sql, conn);
                    comm.ExecuteNonQuery();
                    
                }
                MessageBox.Show("Sėkmingai pridėtas vartotojas", "Success", MessageBoxButtons.OK);
            }
            else 
            {
                MessageBox.Show("Ne visi laukai užpildyti", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
