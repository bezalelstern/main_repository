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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = Employemeneger.ChangePassword(textBox1.Text, textBox3.Text, textBox4.Text, textBox2.Text);
            MessageBox.Show(result);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
