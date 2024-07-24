using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timeclock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                string result = Employemeneger.Login(textBox2.Text, textBox1.Text);
                MessageBox.Show(result);
                textBox2.Text = null;
                textBox1.Text = null;
            }
        }

        

        private void S(object sender, EventArgs e)
        {
            Form2 fre = new Form2();
            fre.Show();
        }
    }
}
