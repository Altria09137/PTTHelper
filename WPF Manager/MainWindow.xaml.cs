using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace WPF_Manager
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection coon;
       
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                string Constr = @"Data Source=WIN-K602VN7RVVF\SQLEXPRESS;Initial Catalog=PTT_Helper;Persist Security Info=True;User ID=sa;Password=Miku01";
                 coon = new SqlConnection(Constr);
                

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            ShowZoos();
            
        }
        private void ShowZoos()
        {

            //string query = "select * from dbo.PTTDATA";
            coon.Open();
            string query = "select count(*) from dbo.PTTDATA";
            SqlCommand cmd = new SqlCommand(query, coon);
            MessageBox.Show(cmd.ExecuteScalar().ToString());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,coon);



            using (sqlDataAdapter)
            {
                DataTable ds = new DataTable();
                sqlDataAdapter.Fill(ds);

                listZoos.DisplayMemberPath = "pop";
                listZoos.SelectedValuePath = "ID";
                listZoos.ItemsSource = ds.DefaultView;
            }

                
            
        }

        /*public  void ShowAnimals()
        {
            try
            {
                string query = "select * from Animal a inner join ZooAnimal za on a.Id=AnimalID where za.ZooID = @ZooID ";
                SqlConnection sqlCommand = new SqlConnection(query, conn);
                SqlDataAdapter sqlDatadAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDatadAdapter)
                {
                    DataTable zooTable = new DataTable();
                    sqlDatadAdapter.Fill(zooTable);

                    listAnimals.DisplayMemberPath = "Location";
                    listAnimals.SelectedValuePath = "Id";
                    listAnimals.ItemsSource = zooTable.DefaultView;

                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


        }*/



    }
}

