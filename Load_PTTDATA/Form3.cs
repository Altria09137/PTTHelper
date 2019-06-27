using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Load_PTTDATA
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string Msg;
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
  
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Msg = textBox1.Text;
        }

        public string GetMsg()
        {
            return Msg;
        }
    }
}
