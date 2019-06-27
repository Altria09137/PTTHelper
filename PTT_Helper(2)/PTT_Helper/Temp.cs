using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTT_Helper
{
    class Temp
    {
    }
}

#region Form1
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using HtmlAgilityPack;
//using Microsoft.Win32;
//using HtmlDocument = HtmlAgilityPack.HtmlDocument;

//namespace PTT_Helper
//{
//    public partial class Form1 : Form
//    {
//        #region AeroDefine
//        [StructLayout(LayoutKind.Sequential)]
//        public struct MARGINS
//        {
//            public int Left;
//            public int Right;
//            public int Top;
//            public int Bottom;
//        }
//        //DLL申明
//        [DllImport("dwmapi.dll", PreserveSig = false)]
//        static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS
//        margins);
//        //DLL申明
//        [DllImport("dwmapi.dll", PreserveSig = false)]
//        static extern bool DwmIsCompositionEnabled();
//        //直接添加代碼
//        protected override void OnLoad(EventArgs e)
//        {
//            if (DwmIsCompositionEnabled())
//            {
//                MARGINS margins = new MARGINS();
//                margins.Right = margins.Left = margins.Top = margins.Bottom =
//                this.Width + this.Height;
//                DwmExtendFrameIntoClientArea(this.Handle, ref margins);
//            }
//            base.OnLoad(e);
//        }
//        protected override void OnPaintBackground(PaintEventArgs e)
//        {
//            base.OnPaintBackground(e);
//            if (DwmIsCompositionEnabled())
//            {
//                e.Graphics.Clear(Color.Black);
//            }
//        }

//        //-------------------------------------------------------------
//        [DllImport("kernel32.dll", SetLastError = true)]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        static extern bool AllocConsole();

//        [DllImport("Kernel32")]
//        public static extern void FreeConsole();
//        #endregion
//        private int CPage = 1;


//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {
//            this.Text = "PTT Helper";
//            #region Data
//            dataGridView1.ColumnCount = 5;                             // 定義所需要的行數
//            //dataGridView1.AutoSize = true;
//            dataGridView1.Columns[0].Name = "Pop";
//            dataGridView1.Columns[1].Name = "Title";
//            dataGridView1.Columns[2].Name = "author";
//            dataGridView1.Columns[3].Name = "URL";
//            dataGridView1.Columns[4].Name = "Text";

//            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
//            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
//            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
//            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

//            dataGridView1.Columns[3].Visible = false;
//            dataGridView1.Columns[4].Visible = false;

//            this.dataGridView1.DefaultCellStyle.BackColor = Color.Black;
//            //
//            //dataGridView2.ColumnCount = 1;
//            //dataGridView2.Columns[0].Name = "Push";
//            //dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
//            #endregion
//            #region Console
//            AllocConsole();
//            //Console.Beep();
//            ConsoleColor oriColor = Console.ForegroundColor;
//            Console.ForegroundColor = ConsoleColor.Yellow;
//            Console.WriteLine("* Don't close this console window or the application will also close.");
//            Console.ForegroundColor = oriColor;
//            #endregion            
//            Properties.Settings MySetting = new Properties.Settings();//Resource Define
//            CPage = MySetting.int_Recoder;
//            textBox1.Text = CPage.ToString();

//            //ProgressBar1_Click(this, null);            
//        }

//        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
//        {
//            Properties.Settings MySetting = new Properties.Settings();//Resource Define
//            try
//            {
//                CPage = Convert.ToInt32(textBox1.Text);
//            }
//            catch
//            {
//                CPage = 10;
//            }
//            MySetting.int_Recoder = CPage;
//            MySetting.Save();
//        }

//        private void ProgressBar1_Click(object sender, EventArgs e)
//        {
//            dataGridView1.Rows.Clear();
//            Console.WriteLine("Load...");
//            Console.WriteLine("Running");
//            try
//            {
//                CPage = Convert.ToInt32(textBox1.Text);
//            }
//            catch (Exception number)
//            {
//                Console.WriteLine(number.Message);
//                textBox1.Text = "30";
//                CPage = 30;
//            }

//            //StartCrawlerasync("", CPage);
//            StartCrawlerasync("", CPage);

//        }

//        private void GridViewDoubleClick(object sender, EventArgs e)
//        {

//        }
//        private async Task StartCrawlerasync(string url, int pages)
//        {

//            string baseurl = "https://www.ptt.cc";
//            string PageUp = "";
//            progressBar1.Maximum = 100;
//            progressBar1.Value = 0;
//            progressBar1.Minimum = 0;
//            int step = 100 / pages;
//            string str_url = "https://www.ptt.cc/bbs/Gossiping/index.html";
//            HttpClientHandler handler = new HttpClientHandler();
//            handler.CookieContainer = new CookieContainer();
//            Uri uri = new Uri(str_url);
//            Uri uris = new Uri("https://www.ptt.cc/bbs/Gossiping/");
//            handler.CookieContainer.Add(uri, new Cookie("over18", "1")); // Adding a Cookie
//                                                                         //handler.CookieContainer.Add(new Cookie("over18", "1") { Domain = uris.Host }); // Adding a Cookie

//            HttpClient httpClient = new HttpClient(handler);
//            HttpResponseMessage response = await httpClient.GetAsync(uri);
//            string html = await httpClient.GetStringAsync(str_url);
//            CookieCollection collection = handler.CookieContainer.GetCookies(uri); // Retrieving a                     
//            HtmlDocument htmldocument = new HtmlDocument();
//            htmldocument.LoadHtml(html);

//            var list = new List<WebPTT>();
//            for (int i = 1; i <= pages; i++)
//            {
//                try
//                {
//                    if (i > 1)
//                    {
//                        handler = new HttpClientHandler();
//                        handler.CookieContainer = new CookieContainer();
//                        uri = new Uri(str_url);
//                        handler.CookieContainer.Add(uri, new Cookie("over18", "1"));
//                        httpClient = new HttpClient(handler);
//                        response = await httpClient.GetAsync(uri);
//                        collection = handler.CookieContainer.GetCookies(uri);
//                        html = await httpClient.GetStringAsync(str_url);
//                        htmldocument = new HtmlDocument();
//                        htmldocument.LoadHtml(html);
//                    }

//                    if (i <= 1)
//                    {
//                        var getpageup = htmldocument.DocumentNode.Descendants("div")
//                        .Where(node => node.GetAttributeValue("class", "").Equals("btn-group btn-group-paging")).ToList();
//                        foreach (var geturl in getpageup)
//                        {
//                            PageUp = geturl.Descendants("a").ElementAtOrDefault(1).ChildAttributes("href").FirstOrDefault().Value.ToString();
//                        }
//                        PageUp = PageUp.Remove(0, 20);
//                        PageUp = PageUp.Remove(PageUp.IndexOf('.'), 5);
//                        PageUp.Trim();
//                        //Console.WriteLine("Sub: " + PageUp);
//                    }
//                    else
//                    {
//                        PageUp = (Convert.ToInt32(PageUp) - 1).ToString();
//                    }
//                    System.Threading.Thread.Sleep(50);//

//                    var divs =
//                        htmldocument.DocumentNode.Descendants("div")
//                        .Where(node => node.GetAttributeValue("class", "").Equals("r-ent")).ToList();

//                    foreach (var div in divs)
//                    {
//                        if (
//                            div.Descendants("div").ElementAtOrDefault(1).InnerText.Trim().Contains("公告")
//                            ||
//                            div.Descendants("div").ElementAtOrDefault(1).InnerText.Trim().Contains("徵求")
//                            )
//                            continue;
//                        WebPTT webptt = new WebPTT();
//                        if (div.Descendants("div").FirstOrDefault().InnerText.Trim().Contains("X"))
//                        {
//                            webptt.Popularity_ptt = webptt.Popularity_ptt = div.Descendants("div").FirstOrDefault().InnerText.Trim().Replace('X', '-');
//                        }
//                        else if (div.Descendants("div").FirstOrDefault().InnerText.Trim() == "")
//                        {
//                            webptt.Popularity_ptt = "0";
//                        }
//                        else
//                        {
//                            webptt.Popularity_ptt = div.Descendants("div").FirstOrDefault().InnerText.Trim();
//                        }

//                        webptt.title_ptt = div.Descendants("div").ElementAtOrDefault(1).InnerText.Trim();
//                        webptt.author_ptt = div.Descendants("div").ElementAtOrDefault(2).Descendants("div").FirstOrDefault().InnerText.Trim();

//                        try
//                        {
//                            webptt.URL_ptt = div.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value;
//                        }
//                        catch (Exception)
//                        {
//                            webptt.URL_ptt = "";
//                        }

//                        #region 爬內文
//                        if (webptt.URL_ptt != "" && webptt.URL_ptt != null)
//                        {

//                            try
//                            {
//                                handler = new HttpClientHandler();
//                                handler.CookieContainer = new CookieContainer();
//                                uri = new Uri(baseurl + webptt.URL_ptt);
//                                handler.CookieContainer.Add(uri, new Cookie("over18", "1"));
//                                httpClient = new HttpClient(handler);
//                                response = await httpClient.GetAsync(uri);
//                                collection = handler.CookieContainer.GetCookies(uri);
//                                html = await httpClient.GetStringAsync(baseurl + webptt.URL_ptt);
//                                htmldocument = new HtmlDocument();
//                                htmldocument.LoadHtml(html);

//                                var contents =
//                                           htmldocument.DocumentNode.Descendants("div")
//                                           .Where(node => node.GetAttributeValue("class", "").Equals("bbs-screen bbs-content")).ToList();
//                                foreach (var content in contents)
//                                {
//                                    webptt.InnerText_ptt = content.InnerText;
//                                }
//                            }
//                            catch (Exception x)
//                            {
//                                Console.WriteLine("Context :" + x.Message);
//                            }
//                        }


//                        #endregion

//                        list.Add(webptt);

//                    }
//                    Console.WriteLine(PageUp);
//                    str_url = baseurl + "/bbs/Gossiping/index" + PageUp + ".html";
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine(e.Message);
//                }
//                progressBar1.Value += step;
//                //Console.Write(" " + i.ToString());
//                foreach (var token in list)
//                {
//                    File.AppendAllText("log.text", token.Popularity_ptt + "   " + token.title_ptt + "   " + token.author_ptt + " " + token.URL_ptt + "\n");
//                    dataGridView1.Rows.Add(token.Popularity_ptt, token.title_ptt, token.author_ptt, baseurl + token.URL_ptt, token.InnerText_ptt);
//                }
//                list.Clear();
//            }

//            #region Result
//            progressBar1.Value = 0;
//            Console.WriteLine("Done");
//            Console.WriteLine("TotalData:" + dataGridView1.RowCount.ToString());
//            #endregion
//        }

//        private async Task PTTWebCrawlerasync(int pages, string str_board)
//        {
//            this.WindowState = FormWindowState.Minimized;
//            Console.WriteLine("PTT Crawler is Running");
//            string baseurl = "https://www.ptt.cc";
//            string str_index = "index.html";
//            string PageUp = "";
//            progressBar1.Maximum = 100;
//            progressBar1.Value = 0;
//            progressBar1.Minimum = 0;
//            int step = 100 / pages;
//            //string str_url = "https://www.ptt.cc/bbs/Gossiping/index.html";
//            string str_url = $"{baseurl}/bbs/{str_board}/{str_index}";
//            HttpClientHandler handler = new HttpClientHandler();
//            handler.CookieContainer = new CookieContainer();
//            Uri uri = new Uri(str_url);
//            //Uri uris = new Uri("https://www.ptt.cc/bbs/Gossiping/");
//            Uri uris = new Uri($"{baseurl}/bbs/{str_board}/");
//            handler.CookieContainer.Add(uri, new Cookie("over18", "1")); // Adding a Cookie
//                                                                         //handler.CookieContainer.Add(new Cookie("over18", "1") { Domain = uris.Host }); // Adding a Cookie

//            HttpClient httpClient = new HttpClient(handler);
//            HttpResponseMessage response = await httpClient.GetAsync(uri);
//            string html = await httpClient.GetStringAsync(str_url);
//            CookieCollection collection = handler.CookieContainer.GetCookies(uri); // Retrieving a                     
//            HtmlDocument htmldocument = new HtmlDocument();
//            htmldocument.LoadHtml(html);
//            //MessageBox.Show(str_url);
//            var list = new List<WebPTT>();
//            for (int i = 1; i <= pages; i++)
//            {
//                try
//                {
//                    if (i > 1)
//                    {
//                        handler = new HttpClientHandler();
//                        handler.CookieContainer = new CookieContainer();
//                        uri = new Uri(str_url);
//                        handler.CookieContainer.Add(uri, new Cookie("over18", "1"));
//                        httpClient = new HttpClient(handler);
//                        response = await httpClient.GetAsync(uri);
//                        collection = handler.CookieContainer.GetCookies(uri);
//                        html = await httpClient.GetStringAsync(str_url);
//                        htmldocument = new HtmlDocument();
//                        htmldocument.LoadHtml(html);
//                    }

//                    var getpageup = htmldocument.DocumentNode.Descendants("div")
//                    .Where(node => node.GetAttributeValue("class", "").Equals("btn-group btn-group-paging")).ToList();
//                    foreach (var geturl in getpageup)
//                    {
//                        PageUp = geturl.Descendants("a").ElementAtOrDefault(1).ChildAttributes("href").FirstOrDefault().Value.ToString();
//                    }

//                    //System.Threading.Thread.Sleep(50);

//                    var divs =
//                        htmldocument.DocumentNode.Descendants("div")
//                        .Where(node => node.GetAttributeValue("class", "").Equals("r-ent")).ToList();

//                    foreach (var div in divs)
//                    {
//                        if (
//                            div.Descendants("div").ElementAtOrDefault(1).InnerText.Trim().Contains("公告")
//                            ||
//                            div.Descendants("div").ElementAtOrDefault(1).InnerText.Trim().Contains("徵求")
//                            ||
//                            div.Descendants("div").ElementAtOrDefault(1).InnerText.Trim().Contains("板務")
//                            ||
//                            div.Descendants("div").ElementAtOrDefault(1).InnerText.Trim().Contains("問卷")
//                            )
//                            continue;
//                        WebPTT webptt = new WebPTT();
//                        if (div.Descendants("div").FirstOrDefault().InnerText.Trim().Contains("X"))
//                        {
//                            webptt.Popularity_ptt = webptt.Popularity_ptt = div.Descendants("div").FirstOrDefault().InnerText.Trim().Replace('X', '-');
//                        }
//                        else if (div.Descendants("div").FirstOrDefault().InnerText.Trim() == "")
//                        {
//                            webptt.Popularity_ptt = "0";
//                        }
//                        else
//                        {
//                            webptt.Popularity_ptt = div.Descendants("div").FirstOrDefault().InnerText.Trim();
//                        }

//                        webptt.title_ptt = div.Descendants("div").ElementAtOrDefault(1).InnerText.Trim();
//                        webptt.author_ptt = div.Descendants("div").ElementAtOrDefault(2).Descendants("div").FirstOrDefault().InnerText.Trim();

//                        try
//                        {
//                            webptt.URL_ptt = div.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value;
//                        }
//                        catch (Exception)
//                        {
//                            webptt.URL_ptt = null;
//                        }

//                        #region 爬內文
//                        if (webptt.URL_ptt != "" && webptt.URL_ptt != null)
//                        {

//                            try
//                            {
//                                handler = new HttpClientHandler();
//                                handler.CookieContainer = new CookieContainer();
//                                uri = new Uri(baseurl + webptt.URL_ptt);
//                                handler.CookieContainer.Add(uri, new Cookie("over18", "1"));
//                                httpClient = new HttpClient(handler);
//                                response = await httpClient.GetAsync(uri);
//                                collection = handler.CookieContainer.GetCookies(uri);
//                                html = await httpClient.GetStringAsync(baseurl + webptt.URL_ptt);
//                                htmldocument = new HtmlDocument();
//                                htmldocument.LoadHtml(html);

//                                var contents =
//                                           htmldocument.DocumentNode.Descendants("div")
//                                           .Where(node => node.GetAttributeValue("class", "").Equals("bbs-screen bbs-content")).ToList();
//                                foreach (var content in contents)
//                                {
//                                    try
//                                    {
//                                        webptt.InnerText_ptt = content.InnerText;
//                                        webptt.InnerText_ptt = webptt.InnerText_ptt.Insert(webptt.InnerText_ptt.IndexOf("看板"), "\n");
//                                        webptt.InnerText_ptt = webptt.InnerText_ptt.Insert(webptt.InnerText_ptt.IndexOf("時間"), "\n");
//                                    }
//                                    catch (Exception Exwebptt)
//                                    {
//                                        Console.WriteLine($"WebPtt Cotent phase Error:{Exwebptt.Message}");
//                                    }

//                                }

//                                var pushs =
//                                      htmldocument.DocumentNode.Descendants("div")
//                                           .Where(node => node.GetAttributeValue("class", "").Equals("push")).ToList();
//                                List<WebPTT_Push> List_webptt_push = new List<WebPTT_Push>();
//                                foreach (var push in pushs)
//                                {
//                                    try
//                                    {
//                                        WebPTT_Push obpush = new WebPTT_Push();
//                                        obpush.push_tag = push.Descendants("span").ElementAtOrDefault(0).InnerText.Trim();
//                                        obpush.user_id = push.Descendants("span").ElementAtOrDefault(1).InnerText.Trim();
//                                        obpush.context = push.Descendants("span").ElementAtOrDefault(2).InnerText.Trim();
//                                        obpush.datetime = push.Descendants("span").ElementAtOrDefault(3).InnerText.Trim();
//                                        List_webptt_push.Add(obpush);
//                                    }
//                                    catch (Exception ExGetPushData)
//                                    {
//                                        Console.WriteLine($"Get Push info Data Error:{ExGetPushData.Message}");
//                                    }
//                                }
//                                webptt.ptt_Push_info = List_webptt_push;
//                                List_webptt_push.Clear();//Clear Data
//                            }
//                            catch (Exception x)
//                            {
//                                Console.WriteLine("Context :" + x.Message);
//                            }
//                        }


//                        #endregion

//                        list.Add(webptt);

//                    }
//                    //Console.WriteLine(PageUp);
//                    //str_url = baseurl + "/bbs/Gossiping/index" + PageUp + ".html";
//                    //str_url = $"{baseurl}/{PageUp}";
//                    str_url = $"{baseurl}{PageUp}";
//                    Console.WriteLine(str_url);
//                    //$"{baseurl}/bbs/{str_board}/"
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine($"Crawling Error: {e.Message}");
//                }
//                progressBar1.Value += step;
//                //Console.Write(" " + i.ToString());
//                foreach (var token in list)
//                {
//                    File.AppendAllText("log.text", token.Popularity_ptt + "   " + token.title_ptt + "   " + token.author_ptt + " " + token.URL_ptt + "\n");
//                    dataGridView1.Rows.Add(token.Popularity_ptt, token.title_ptt, token.author_ptt, baseurl + token.URL_ptt, token.InnerText_ptt);
//                }
//                list.Clear();


//            }

//            #region Result
//            progressBar1.Value = 0;
//            Console.Clear();
//            Console.WriteLine("Done");
//            Console.WriteLine("TotalData:" + dataGridView1.RowCount.ToString());
//            #endregion
//            this.WindowState = FormWindowState.Normal;
//        }


//        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
//        {
//            try
//            {
//                FormView view = new FormView();
//                var target = dataGridView1.CurrentRow.Cells[4].Value.ToString();
//                view.SetValue = target + "\n\n\n";
//                view.Show();

//            }
//            catch (Exception E)
//            {
//                Console.Write(E.Message);
//            }
//        }

//        private void TabPage1_Click(object sender, EventArgs e)
//        {

//        }

//        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
//        {
//            if (e.KeyCode == Keys.Enter)
//            {
//                try
//                {
//                    CPage = Convert.ToInt32(textBox1.Text);
//                }
//                catch (Exception x)
//                {
//                    Console.WriteLine("Textbox1:" + x.Message);
//                    textBox1.Text = "30";
//                }
//            }
//        }

//        private void DataGridView1_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            if (e.KeyChar == 32)
//            {
//                try
//                {
//                    var target = dataGridView1.CurrentRow.Cells[3].Value.ToString();
//                    if (target != null || target != string.Empty)
//                    {
//                        RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
//                        string s = key.GetValue("").ToString();
//                        //s就是你的預設瀏覽器，不過後面帶了引數，把它截去，不過需要注意的是：不同的瀏覽器後面的引數不一樣！
//                        //"D:\Program Files (x86)\Google\Chrome\Application\chrome.exe" -- "%1"
//                        System.Diagnostics.Process.Start(s.Substring(0, s.Length - 8), target);
//                    }

//                }
//                catch (Exception E)
//                {
//                    Console.Write("KeyPress:" + E.Message);
//                }
//            }
//        }

//        private void Button1_Click(object sender, EventArgs e)
//        {
//            //Console.Clear();
//            Console.WriteLine("Running");
//            StartCrawlerasync("", 10);
//            tabControl1.SelectTab(tabPage1);
//        }

//        private void Button2_Click(object sender, EventArgs e)
//        {
//            Console.Clear();
//            Console.WriteLine("Running");
//            StartCrawlerasync("", 20);
//            tabControl1.SelectTab(tabPage1);
//        }

//        private void Button3_Click(object sender, EventArgs e)
//        {
//            Console.Clear();
//            Console.WriteLine("Running");
//            StartCrawlerasync("", 30);
//            tabControl1.SelectTab(tabPage1);
//        }

//        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            if (e.KeyChar == 27)
//            {
//                Console.WriteLine("Abord Task");

//            }
//        }

//        private void Button6_Click(object sender, EventArgs e)
//        {
//            dataGridView1.Rows.Clear();
//            try
//            {
//                int i = Convert.ToInt32(textBox1.Text);
//                PTTWebCrawlerasync(i, comboBox1.Text);
//                tabControl1.SelectTab(tabPage1);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"PTTWebCrawler:{ex}");
//            }

//        }

//        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
//        {
//            if (e.RowIndex > -1 && e.ColumnIndex == this.dataGridView1.Columns["Pop"].Index)

//            {

//                if (e.Value != null)
//                {

//                    if (e.Value.ToString().Trim() == "爆")
//                    {
//                        this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
//                    }
//                    else if (e.Value.ToString().Trim().Contains("X"))
//                    {
//                        this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Gray;
//                        //this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.Font
//                    }
//                    else
//                    {
//                        try
//                        {
//                            int pop = Convert.ToInt32(e.Value.ToString().Trim());
//                            if (pop >= 10)
//                            {
//                                this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Yellow;
//                            }
//                            else
//                            {
//                                this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
//                            }
//                        }
//                        catch (Exception)
//                        {

//                        }
//                    }
//                }
//            }
//        }
//    }
//}
#endregion

#region
//namespace PTT_Helper
//{
//    public class WebPTT
//    {
//        public string Popularity_ptt { get; set; }
//        public string title_ptt { get; set; }
//        public string author_ptt { get; set; }
//        public string URL_ptt { get; set; }
//        public string InnerText_ptt { get; set; }
//        public List<WebPTT_Push> ptt_Push_info { get; set; }


//    }
//    public class WebPTT_InnerContext
//    {
//        public string Text { get; set; }

//    }

//    public class WebPTT_Push
//    {
//        public string push_tag { get; set; }
//        public string user_id { get; set; }
//        public string context { get; set; }
//        public string datetime { get; set; }

//    }
//}
#endregion

//#region
//#region Form1 Designer
//namespace PTT_Helper
//{
//    partial class Form1
//    {
//        /// <summary>
//        /// 設計工具所需的變數。
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// 清除任何使用中的資源。
//        /// </summary>
//        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form 設計工具產生的程式碼

//        /// <summary>
//        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
//        /// 這個方法的內容。
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.progressBar1 = new System.Windows.Forms.ProgressBar();
//            this.tabControl1 = new System.Windows.Forms.TabControl();
//            this.tabPage1 = new System.Windows.Forms.TabPage();
//            this.dataGridView1 = new System.Windows.Forms.DataGridView();
//            this.tabPage2 = new System.Windows.Forms.TabPage();
//            this.button6 = new System.Windows.Forms.Button();
//            this.comboBox1 = new System.Windows.Forms.ComboBox();
//            this.button5 = new System.Windows.Forms.Button();
//            this.button4 = new System.Windows.Forms.Button();
//            this.button3 = new System.Windows.Forms.Button();
//            this.button2 = new System.Windows.Forms.Button();
//            this.button1 = new System.Windows.Forms.Button();
//            this.textBox1 = new System.Windows.Forms.TextBox();
//            this.tabControl1.SuspendLayout();
//            this.tabPage1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
//            this.tabPage2.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // progressBar1
//            // 
//            this.progressBar1.Location = new System.Drawing.Point(22, 826);
//            this.progressBar1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
//            this.progressBar1.Name = "progressBar1";
//            this.progressBar1.Size = new System.Drawing.Size(1646, 67);
//            this.progressBar1.TabIndex = 1;
//            this.progressBar1.Click += new System.EventHandler(this.ProgressBar1_Click);
//            // 
//            // tabControl1
//            // 
//            this.tabControl1.Controls.Add(this.tabPage1);
//            this.tabControl1.Controls.Add(this.tabPage2);
//            this.tabControl1.Location = new System.Drawing.Point(0, 0);
//            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
//            this.tabControl1.Name = "tabControl1";
//            this.tabControl1.SelectedIndex = 0;
//            this.tabControl1.Size = new System.Drawing.Size(1668, 816);
//            this.tabControl1.TabIndex = 2;
//            // 
//            // tabPage1
//            // 
//            this.tabPage1.Controls.Add(this.dataGridView1);
//            this.tabPage1.Location = new System.Drawing.Point(4, 31);
//            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
//            this.tabPage1.Name = "tabPage1";
//            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
//            this.tabPage1.Size = new System.Drawing.Size(1660, 781);
//            this.tabPage1.TabIndex = 0;
//            this.tabPage1.Text = "PTT_List";
//            this.tabPage1.UseVisualStyleBackColor = true;
//            this.tabPage1.Click += new System.EventHandler(this.TabPage1_Click);
//            // 
//            // dataGridView1
//            // 
//            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
//            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
//            this.dataGridView1.Location = new System.Drawing.Point(47, 0);
//            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
//            this.dataGridView1.Name = "dataGridView1";
//            this.dataGridView1.ReadOnly = true;
//            this.dataGridView1.RowTemplate.Height = 24;
//            this.dataGridView1.Size = new System.Drawing.Size(1613, 776);
//            this.dataGridView1.TabIndex = 1;
//            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView1_CellFormatting);
//            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DataGridView1_KeyPress);
//            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataGridView1_MouseDoubleClick);
//            // 
//            // tabPage2
//            // 
//            this.tabPage2.Controls.Add(this.button6);
//            this.tabPage2.Controls.Add(this.comboBox1);
//            this.tabPage2.Controls.Add(this.button5);
//            this.tabPage2.Controls.Add(this.button4);
//            this.tabPage2.Controls.Add(this.button3);
//            this.tabPage2.Controls.Add(this.button2);
//            this.tabPage2.Controls.Add(this.button1);
//            this.tabPage2.Controls.Add(this.textBox1);
//            this.tabPage2.Location = new System.Drawing.Point(4, 26);
//            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
//            this.tabPage2.Name = "tabPage2";
//            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
//            this.tabPage2.Size = new System.Drawing.Size(1660, 786);
//            this.tabPage2.TabIndex = 1;
//            this.tabPage2.Text = "Page";
//            this.tabPage2.UseVisualStyleBackColor = true;
//            // 
//            // button6
//            // 
//            this.button6.Location = new System.Drawing.Point(905, 13);
//            this.button6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
//            this.button6.Name = "button6";
//            this.button6.Size = new System.Drawing.Size(103, 30);
//            this.button6.TabIndex = 7;
//            this.button6.Text = "Start";
//            this.button6.UseVisualStyleBackColor = true;
//            this.button6.Click += new System.EventHandler(this.Button6_Click);
//            // 
//            // comboBox1
//            // 
//            this.comboBox1.FormattingEnabled = true;
//            this.comboBox1.Items.AddRange(new object[] {
//            "Gossiping",
//            "Stock",
//            "Option",
//            "HardwareSale",
//            "C_Chat",
//            "Tech_Job",
//            "Soft_Job",
//            "FATE_GO"});
//            this.comboBox1.Location = new System.Drawing.Point(730, 13);
//            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
//            this.comboBox1.Name = "comboBox1";
//            this.comboBox1.Size = new System.Drawing.Size(165, 29);
//            this.comboBox1.TabIndex = 6;
//            // 
//            // button5
//            // 
//            this.button5.Location = new System.Drawing.Point(619, 13);
//            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
//            this.button5.Name = "button5";
//            this.button5.Size = new System.Drawing.Size(103, 30);
//            this.button5.TabIndex = 5;
//            this.button5.Text = "100";
//            this.button5.UseVisualStyleBackColor = true;
//            // 
//            // button4
//            // 
//            this.button4.Location = new System.Drawing.Point(507, 13);
//            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
//            this.button4.Name = "button4";
//            this.button4.Size = new System.Drawing.Size(103, 30);
//            this.button4.TabIndex = 4;
//            this.button4.Text = "50";
//            this.button4.UseVisualStyleBackColor = true;
//            // 
//            // button3
//            // 
//            this.button3.Location = new System.Drawing.Point(396, 13);
//            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
//            this.button3.Name = "button3";
//            this.button3.Size = new System.Drawing.Size(103, 30);
//            this.button3.TabIndex = 3;
//            this.button3.Text = "30";
//            this.button3.UseVisualStyleBackColor = true;
//            this.button3.Click += new System.EventHandler(this.Button3_Click);
//            // 
//            // button2
//            // 
//            this.button2.Location = new System.Drawing.Point(285, 13);
//            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
//            this.button2.Name = "button2";
//            this.button2.Size = new System.Drawing.Size(103, 30);
//            this.button2.TabIndex = 2;
//            this.button2.Text = "20";
//            this.button2.UseVisualStyleBackColor = true;
//            this.button2.Click += new System.EventHandler(this.Button2_Click);
//            // 
//            // button1
//            // 
//            this.button1.Location = new System.Drawing.Point(173, 13);
//            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
//            this.button1.Name = "button1";
//            this.button1.Size = new System.Drawing.Size(103, 30);
//            this.button1.TabIndex = 1;
//            this.button1.Text = "10";
//            this.button1.UseVisualStyleBackColor = true;
//            this.button1.Click += new System.EventHandler(this.Button1_Click);
//            // 
//            // textBox1
//            // 
//            this.textBox1.Location = new System.Drawing.Point(11, 8);
//            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
//            this.textBox1.Name = "textBox1";
//            this.textBox1.Size = new System.Drawing.Size(136, 33);
//            this.textBox1.TabIndex = 0;
//            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
//            // 
//            // Form1
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.AutoScroll = true;
//            this.AutoSize = true;
//            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
//            this.ClientSize = new System.Drawing.Size(1690, 914);
//            this.Controls.Add(this.tabControl1);
//            this.Controls.Add(this.progressBar1);
//            this.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
//            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
//            this.Name = "Form1";
//            this.Text = "Form1";
//            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
//            this.Load += new System.EventHandler(this.Form1_Load);
//            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
//            this.tabControl1.ResumeLayout(false);
//            this.tabPage1.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
//            this.tabPage2.ResumeLayout(false);
//            this.tabPage2.PerformLayout();
//            this.ResumeLayout(false);

//        }

//        #endregion
//        private System.Windows.Forms.ProgressBar progressBar1;
//        private System.Windows.Forms.TabControl tabControl1;
//        private System.Windows.Forms.TabPage tabPage1;
//        private System.Windows.Forms.TabPage tabPage2;
//        private System.Windows.Forms.DataGridView dataGridView1;
//        private System.Windows.Forms.TextBox textBox1;
//        private System.Windows.Forms.Button button5;
//        private System.Windows.Forms.Button button4;
//        private System.Windows.Forms.Button button3;
//        private System.Windows.Forms.Button button2;
//        private System.Windows.Forms.Button button1;
//        private System.Windows.Forms.ComboBox comboBox1;
//        private System.Windows.Forms.Button button6;
//    }
//}

//#endregion
//#endregion
