using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hebrewdate
{
    public partial class Form1 : Form
    {
        private Datemeneger datemeneger;
        public Form1()
        {
            InitializeComponent();
            XmlDocument dates = Mainproject.Main();
            datemeneger = new Datemeneger(dates);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dayweek = datemeneger.getdayweek(comboBox1.Text);
            string day = datemeneger.getday(comboBox2.Text);
            string month  = datemeneger.getdaymonth(comboBox4.Text);
            //string month = 
            string result = $"ב{dayweek} בשבת  {day} לירח {comboBox3.Text} שנת חמשת אלפים ושבע מאות {month} לבריאת העולם";

            string[] values = new string[5];
            values[0] = comboBox1.Text;
            values[1] = comboBox2.Text;
            values[2] = comboBox3.Text;
            values[3] = comboBox4.Text;
            values[4] = result;
            //{
            //comboBox1.Text,
            //comboBox2.Text,
            //comboBox3.Text,
            //comboBox4.Text,
            
            //};
            string[] names = new string[]
            {
                "Day",
                "Daymonth",
                "month",
                "Year",
                "result"

            };
            datemeneger.AddQuery(names, values);
            datemeneger.Save();

            MessageBox.Show(result);

            datemeneger.Save();

            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;  
            comboBox4.Text = null;
        }
    }
}
