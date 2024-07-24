using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            textBox1.Visible = false;
            label8.Visible = false;
            textBox14.Visible = false;
            textBox13.Visible = false;
            label7.Visible = false;
            textBox2.Visible = false;
           
            button1.Visible = false;
            textBox13.Visible = true;
            textBox7.Visible = true;
            textBox10.Visible = true;
            label5.Visible = true;
            label4.Visible = true;
            label3.Visible = true;
            textBox3.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            Collegemeneger.addcourse(textBox1.Text, textBox14.Text, textBox2.Text);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox13.Visible = false;
            textBox7.Visible = false;
            textBox10.Visible = false;
            label5.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            textBox3.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Collegemeneger.addlecturer(textBox13.Text, textBox3.Text);
            Collegemeneger.addsubject(textBox2.Text , textBox1.Text, textBox7.Text, textBox10.Text);
            textBox13.Text = null;
            textBox7.Text = null;
            textBox10.Text = null;
           
            textBox3.Text = null;
            
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 y = new Form1();
            y.Show();
        }
    }
}
