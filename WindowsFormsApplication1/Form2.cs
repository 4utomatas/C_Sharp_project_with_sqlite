using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuras
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //Pylimu langas
        private void Form2_Load(object sender, EventArgs e)
        {
            long cardNumber = Variables.currentRow;
            int i = 0;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            //int currentRow = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            var temp = Variables.K.FirstOrDefault(x => x.getCardNumber() == cardNumber).p;
            foreach (var k in temp)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = k.getDate();
                dataGridView1[1, i].Value = k.getLocation();
                dataGridView1[2, i].Value = k.getPrice();
                dataGridView1[3, i].Value = k.getAmount();
                dataGridView1[4, i].Value = k.getTotal();
                i++;
            }
            dataGridView1.Sort(dataGridView1.Columns["data"], ListSortDirection.Descending);
        }
    }
}
