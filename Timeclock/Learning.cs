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
    public partial class Learning : Form
    {
        public Learning()
        {
            InitializeComponent();
        }

        private void Learning_Load(object sender, EventArgs e)
        {
            string sql = "select * from timeclock";
            string result = Dbconnaction.runSQL(sql);
            MessageBox.Show(result);
        }
    }
}