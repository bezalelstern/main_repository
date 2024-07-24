using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orderingfood
{
    public partial class orders : Form
    {
        public List<orders> Orders1;
        public int Position;

        public orders(List<orders> Orders, int position, string catgory)
        {
            InitializeComponent();
            Orders1 = Orders;
            Position = position;
            label1.Text = catgory;
        }


        int num = 1;
        private void button3_Click(object sender, EventArgs e)
        {
            Dbconnaction.UnConnect();
            Form1 form = new Form1();
            form.Show();
        }

        private void orders_Load(object sender, EventArgs e)
        {
            Dbconnaction.UnConnect();
            dataGridView1.DataSource = Hostmeneger.getbycategory(label1.Text);
            //tables(num);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tables(int valu)
        {
            Dbconnaction.UnConnect();
            DataTable dataTable = Hostmeneger.getbycategory(valu.ToString());
            dataGridView1.DataSource = dataTable;
            DataRow secondRow = dataTable.Rows[0];

            object firstColumnValue = secondRow[1];

            label1.Text = firstColumnValue.ToString();
        }

        //מעביר קטגוריה אחת קדימה
        private void button1_Click(object sender, EventArgs e)
        {
            //if (Position < Orders1.Count)
            //{
            //    num++;
            //    tables(num);
            //}

            Orders1[Position].Visible = false;
            Position = (Position + 1) % Orders1.Count;
            Orders1[Position].Show();

        }

        //מעביר קטגוריה אחת אחורה
        private void button2_Click(object sender, EventArgs e)
        {
            Orders1[Position].Visible = false;
            Position = (Position - 1 + Orders1.Count) % Orders1.Count;
            Orders1[Position].Show();
            //if (Position > 0)
            //{
            //    Position--;
            //    Orders1[Position].Show();
            //    Orders1[Position + 1].Visible = false;
            //}

            //if (num > 1)
            //{
            //    num -- ;
            //    tables(num);
            //}
        }
    }
}
