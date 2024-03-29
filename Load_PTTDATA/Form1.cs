﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Load_PTTDATA
{

    public partial class Form1 : Form
    {
        SqlConnection conn;
        DataTable dt = new DataTable();
        string a, b, c;

        //DLL申明
        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int Left;
            public int Right;
            public int Top;
            public int Bottom;
        }

        //DLL申明
        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS
        margins);

        //DLL申明
        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern bool DwmIsCompositionEnabled();

        protected override void OnLoad(EventArgs e)
        {
            if (DwmIsCompositionEnabled())
            {
                MARGINS margins = new MARGINS();
                margins.Right = margins.Left = margins.Top = margins.Bottom =
        this.Width + this.Height;
                DwmExtendFrameIntoClientArea(this.Handle, ref margins);
            }
            base.OnLoad(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (DwmIsCompositionEnabled())
            {
                e.Graphics.Clear(Color.Black);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void Connect()
        {
            try
            {
                //WIN - K602VN7RVVF\SQLEXPRESS;Initial Catalog = PTT_Helper; Persist Security Info=True;User ID = sa; Password=Miku01
                string Constr = @"Data Source=WIN-K602VN7RVVF\SQLEXPRESS;Initial Catalog=PTT_Helper;Persist Security Info=True;User ID=sa;Password=Miku01";
                conn = new SqlConnection(Constr);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                Console.WriteLine($"Connect Error: {e.Message}");
            }


        }

        public void getMySQLDATA()
        {
            Connect();
            string query = "SELECT TOP 300 * FROM  dbo.PTTDATA";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter dat = new SqlDataAdapter();
            dat.SelectCommand = cmd;
            dat.Fill(dt);
            dat.Dispose();
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'pTT_HelperDataSet1.PTTDATA' 資料表。您可以視需要進行移動或移除。
            //this.pTTDATATableAdapter.Fill(this.pTT_HelperDataSet1.PTTDATA);
            this.comboBox1.Items.Add("Start");
            this.comboBox1.Items.Add("Desc ID");
            this.comboBox1.Items.Add("Pop");
            this.comboBox1.Items.Add("Regional Search");
            this.comboBox1.Items.Add("Basic Search");
            this.comboBox1.Items.Add("Title Search");
            this.comboBox1.SelectedIndex = 0;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
       
        }

        private void Button2_Click(object sender, EventArgs e)
        {
        
        }

        private void Button3_Click(object sender, EventArgs e)
        {
           
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            dt.Clear();
            this.comboBox1.SelectedIndex = 0;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            
        }


        private void Button5_Click(object sender, EventArgs e)
        {
            

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(Environment.ExitCode);
        }


        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FormView view = new FormView();
                var target = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                view.SetValue = target + "\n\n\n";
                view.Show();


            }
            catch (Exception E)
            {
                Console.Write(E.Message);
            }

        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


        }
        private void dataGridView1drowcolor()
        {
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {

                    int re = Int32.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());

                    if (re == 100)
                        this.dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    else if (re >= 10 && 100>re)
                        this.dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Yellow;
                    else
                        this.dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            this.dataGridView1.DefaultCellStyle.BackColor = Color.Black;
        }
        

        private void Button8_Click(object sender, EventArgs e)
        {
   
            if(comboBox1.SelectedIndex == 0)
            {
                getMySQLDATA();
                dataGridViewSizeMode();
                dataGridView1drowcolor();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                Connect();
                dataGridViewSizeMode();
                string query = "SELECT TOP 300 *  FROM dbo.PTTDATA ORDER BY ID DESC";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter dat = new SqlDataAdapter();
                dat.SelectCommand = cmd;
                dat.Fill(dt);
                dat.Dispose();
                dataGridView1.DataSource = dt;
                conn.Close();
                dataGridView1drowcolor();
            }

            else if (comboBox1.SelectedIndex == 2 )
            {
                Connect();
                dataGridViewSizeMode();
                string query = "select  TOP 300 * from dbo.PTTDATA order by  cast( pop as integer) DESC ";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter dat = new SqlDataAdapter();
                dat.SelectCommand = cmd;
                dat.Fill(dt);
                dat.Dispose();
                dataGridView1.DataSource = dt;
                conn.Close();
                dataGridView1drowcolor();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                
                Connect();
                dataGridViewSizeMode();
                conn.Open();
                Form2 input = new Form2();
                DialogResult dr = input.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    string[] aryStr = input.GetMsg().Split('@');
                    a = aryStr[0];
                    b = aryStr[1];



                    string query = $"select TOP 300  * from dbo.PTTDATA where 1=1 and {a}>pop and pop>{b} order by pop desc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter dat = new SqlDataAdapter();
                    dat.SelectCommand = cmd;
                    dat.Fill(dt);
                    dat.Dispose();
                    dataGridView1.DataSource = dt;
                    dataGridView1drowcolor();
                    conn.Close();
                }
                else if (dr == DialogResult.Cancel)
                {
                    input.Close();
                }
                else
                {
                    input.Close();
                }
            }
            else if (comboBox1.SelectedIndex == 4 )
            {
                Connect();
                dataGridViewSizeMode();
                conn.Open();
                Form3 input = new Form3();
                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    c = input.GetMsg();

                    try
                    {
                        
                           string query = $"SELECT TOP 300 * FROM dbo.PTTDATA  where pop={c} ";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            SqlDataAdapter dat = new SqlDataAdapter();
                            dat.SelectCommand = cmd;
                            dat.Fill(dt);
                            dat.Dispose();
                            dataGridView1.DataSource = dt;
                            dataGridView1drowcolor();
                            conn.Close();
                        

                        string count = dataGridView1.Rows.Count.ToString();
                        if (count == "1")
                        {
                            MessageBox.Show("no result");
                        }
                        else
                        {
                            int result = Int32.Parse(count);
                            result--;
                            MessageBox.Show("result have " + result);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No this value");
                    }
                    
                }
                else if (dr == DialogResult.Cancel)
                {
                    input.Close();
                }
                else
                {
                    input.Close();
                }
            }

            else if (comboBox1.SelectedIndex ==5)
            {
                Connect();
                dataGridViewSizeMode();
                conn.Open();
                Form4 input = new Form4();
                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    c = input.GetMsg();

                    try
                    {

                        string query = $"SELECT  * FROM dbo.PTTDATA  where title like '%{c}%'";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        SqlDataAdapter dat = new SqlDataAdapter();
                        dat.SelectCommand = cmd;
                        dat.Fill(dt);
                        dat.Dispose();
                        dataGridView1.DataSource = dt;
                        dataGridView1drowcolor();
                        conn.Close();


                        string count = dataGridView1.Rows.Count.ToString();
                        if (count == "1")
                        {
                            MessageBox.Show("no result");
                        }
                        else
                        {
                            int result = Int32.Parse(count);
                            result--;
                            MessageBox.Show("result have " + result);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No this value");
                    }

                }
                else if (dr == DialogResult.Cancel)
                {
                    input.Close();
                }
                else
                {
                    input.Close();
                }
            }

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt.Clear();
        }

        private void dataGridViewSizeMode()
        {
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
    }    
}
