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
    public partial class FormView : Form
    {
        public FormView()
        {
            InitializeComponent();
           
        }
        public FormView(String arg)
        {
            InitializeComponent();
            label1.Text = arg;
        
        }

        private void FormView_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            this.WindowState = FormWindowState.Maximized;
        }
        public string SetValue
        {
            set
            {
                label1.Text = value;
                textBox1.Text = label1.Text;
                this.label1.ForeColor = Color.White;
            }
            get
            {
                return label1.Text;
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = !textBox1.Visible;
            label1.Visible = !label1.Visible;
        }
        private void TextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Visible = !textBox1.Visible;
            label1.Visible = !label1.Visible;
        }
        private void FormView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                this.Close();

        }
    }
}
