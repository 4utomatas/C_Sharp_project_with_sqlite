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
    public partial class redaguoti : Form
    {
        public redaguoti()
        {
            InitializeComponent();
        }

        public void getDuomenys()
        {
            int cr = Variables.currentRow;
            Kortele temp = Variables.K.FirstOrDefault(x => x.getCardNumber() == cr);
            textBox1.Text = temp.getCardNumber().ToString();
            textBox2.Text = temp.getName();
            textBox3.Text = temp.getSurname();
            textBox4.Text = temp.getCity();
            textBox5.Text = temp.getLimit().ToString();
            textBox6.Text = temp.getNumberPlate();
            textBox7.Text = temp.getModel();
            textBox8.Text = temp.getGroup();
        }
        
        private void redaguoti_Load(object sender, EventArgs e)
        {
            getDuomenys();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vardas, pavarde, miestas, numeris, modelis;
            string grupe;
            long kortele = -1;
            int limitas = -1;
            long.TryParse(textBox1.Text, out kortele);
            vardas = textBox2.Text;
            pavarde = textBox3.Text;
            miestas = textBox4.Text;
            int.TryParse(textBox5.Text, out limitas);
            numeris = textBox6.Text;
            modelis = textBox7.Text;
            grupe = textBox8.Text;
            if (vardas != null && pavarde != null && miestas != null && numeris != null &&
                modelis != null && grupe != null && kortele != -1 && limitas != -1)
            {
                SQLiteCommand comm;
                SQLiteConnection conn;

                using (conn = new SQLiteConnection(Variables.dataSource))
                {
                    conn.Open();
                    string sql =
                    @"UPDATE Korteles SET NAME='"+ vardas +
                    "', SURNAME='" + pavarde + "', MODEL='" + modelis +"', NUMBERPLATE='"+ numeris +
                    "', CARDNUMBER='"+ kortele +"', CITY='"+ miestas +"', LIMITAS ='"+ limitas +
                    "', GRUPE='"+ grupe +"'" + "WHERE CARDNUMBER='"+ kortele +"'";
                    comm = new SQLiteCommand(sql, conn);
                    comm.ExecuteNonQuery();

                }
                Variables.K.FirstOrDefault(x => x.getCardNumber() == Variables.currentRow).update(kortele, vardas,
                    pavarde, miestas, limitas, numeris, modelis, grupe);

                MessageBox.Show("Sėkmingai atnaujintas vartotojas", "Success", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Ne visi laukai užpildyti", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
