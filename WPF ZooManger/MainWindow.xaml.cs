using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WPF_ZooManger
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();
            string connectionstring = ConfigurationManager.ConnectionStrings["WPF ZooManager.Properties.ConnectString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionstring);
            Console.ReadKey();
        }
        public void ShowZoos()
        {
            string query = "select * from Zoo";
            SqlDataAdapter sqlDatadAdapter = new SqlDataAdapter(query,sqlConnection) ;

                using (sqlDatadAdapter)
                {
                    DataTable zooTable = new DataTable();
                    sqlDatadAdapter.Fill(zooTable);

                    listZoos.DisplayMemberPath = "Location";
                    listZoos.SelectedValuePath = "Id";
                    listZoos.ItemsSource = zooTable.DefaultView;

                }
          

        }

       
    }
}
