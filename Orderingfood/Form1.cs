using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orderingfood
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> catgory = Hostmeneger.getcategory();
            int i = 1;
            foreach (string c in catgory)
            {
                listBox1.Items.Add(i + ". " + c);
                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string name = textBox1.Text;
            Hostmeneger.addcatgory(name);
            List<string> catgory = Hostmeneger.getcategory();
            int i = 1;
            foreach (string c in catgory)
            {
                listBox1.Items.Add(i + ". " + c);
                i++;
            }
            textBox1.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dbconnaction.UnConnect();

            List<orders> forms = new List<orders>();

            List<string> categories = Hostmeneger.getcategory();
            for (int i = 0; i < categories.Count; i++)
            {
                forms.Add(new orders(forms, i, categories[i]));
            }
            Dbconnaction.UnConnect();

            forms.First().Show();
            //forms.First().Show();
            //Dbconnaction.UnConnect();
            //orders ord = new orders();
            //ord.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                string selectedindex = listBox1.SelectedItem.ToString();
                textBox1.Text = selectedindex.Substring(selectedindex.IndexOf('.') + 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

           
            string name = textBox1.Text;
            listBox1.Items.Clear();
            Hostmeneger.removecatgory(name);
            List<string> catgory = Hostmeneger.getcategory();
            int i = 1;
            foreach (string c in catgory)
            {
                listBox1.Items.Add(i + ". " + c);
                i++;
            }
            textBox1.Text = null;
        }
        //חיפוש
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
             Dbconnaction.UnConnect();

             List<string> catgory = Hostmeneger.search(textBox1.Text);
            listBox1.Items.Clear();

            foreach (string cat in catgory) {
               listBox1.Items.Add((string)cat); 
            }
        }
    }
}








