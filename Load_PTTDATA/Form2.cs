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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        string Msg1;
        string Msg2;
        string Msg;
        private void Button1_Click(object sender, EventArgs e)
        {
            Msg1 = textBox1.Text;
            Msg2 = textBox2.Text;
            Msg = Msg1 + "@" + Msg2;
        }
        public string GetMsg()
        {
            return Msg;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
  
         
        }
    }

}







