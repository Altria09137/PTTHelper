using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Microsoft.Win32;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace PTT_Crawler
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("Kernel32")]
        public static extern void FreeConsole();


        private int CPage = 1;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "PTT_Crawler";
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Pop";
            dataGridView1.Columns[1].Name = "Title";
            dataGridView1.Columns[2].Name = "author";
            dataGridView1.Columns[3].Name = "URL";
            dataGridView1.Columns[4].Name = "Text";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;

            this.dataGridView1.DefaultCellStyle.BackColor = Color.Black;

            #region Console
            AllocConsole();
            ConsoleColor oriColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("* Don't close this console window or the application will also close.");
            Console.ForegroundColor = oriColor;
            #endregion

            #region ComboBox
            String[] str_combox = { "Gossiping","Gov_owned", "Stock","Option","FATE_GO", "Soft_Job","Tech_Job","HardwareSale","C_Chat",
                "nb-shopping","car", };
            foreach (string ApplicationSettings in str_combox)
            {
                comboBox1.Items.Add(ApplicationSettings);
            }
            #endregion
            Properties.Settings MySetting = new Properties.Settings();//Resource Define
            textBox1.Text = MySetting.str_page;
            comboBox1.SelectedIndex = MySetting.combox;

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings MySetting = new Properties.Settings();//Resource Define
            MySetting.str_page = textBox1.Text;
            MySetting.combox = comboBox1.SelectedIndex;
            MySetting.Save(); //Save Preference

        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Console.WriteLine("Running");
            try
            {
                CPage = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception number)
            {
                Console.WriteLine(number.Message);
                textBox1.Text = "30";
                CPage = 30;
            }
            StartCrawlerasync("", CPage);

        }
        private async Task StartCrawlerasync(string url, int pages)
        {

            string baseurl = "https://www.ptt.cc";
            string PageUp = "";
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            int step = 100 / pages;
            string str_url = "https://www.ptt.cc/bbs/Gossiping/index.html";
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();
            Uri uri = new Uri(str_url);
            Uri uris = new Uri("https://www.ptt.cc/bbs/Gossiping/");
            handler.CookieContainer.Add(uri, new Cookie("over18", "1"));// Add 18+ Cookie

            HttpClient httpClient = new HttpClient(handler);
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            string html = await httpClient.GetStringAsync(str_url);
            CookieCollection collection = handler.CookieContainer.GetCookies(uri); // Retrieving a                     
            HtmlDocument htmldocument = new HtmlDocument();
            htmldocument.LoadHtml(html);
        }
    }
}

