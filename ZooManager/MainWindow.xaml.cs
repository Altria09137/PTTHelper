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

namespace ZooManager
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn;
        public MainWindow()
        {

            try
            {
                InitializeComponent();
                string Constr = @"Data Source=WIN-MNSOA82A42O;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=Miku01";
                conn = new SqlConnection(Constr);


            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            ShowZoos();
            ShowAllAnimals();

        }

        private void ShowZoos()
        {

            string query = "select * from Zoo";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);



            using (sqlDataAdapter)
            {
                DataTable ZooTable = new DataTable();

                sqlDataAdapter.Fill(ZooTable);

                listZoos.DisplayMemberPath = "Location";
                listZoos.SelectedValuePath = "Id";
                listZoos.ItemsSource = ZooTable.DefaultView;

            }



        }

        private void ShowAssocatedAnimals()
        {
           
                string query = "select * from Animal a inner join ZooAnimal za " +
                    "on a.Id = za.AnimalId where za.ZooId = @ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);



                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);

                    DataTable AnimalTable = new DataTable();

                    sqlDataAdapter.Fill(AnimalTable);

                    listAnimals.DisplayMemberPath = "Name";
                    listAnimals.SelectedValuePath = "Id";
                    listAnimals.ItemsSource = AnimalTable.DefaultView;

                }


          
        }


        private void ShowAllAnimals()
        {

            string query = "select * from Animal";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);



            using (sqlDataAdapter)
            {
                DataTable allanimalTable = new DataTable();

                sqlDataAdapter.Fill(allanimalTable);

                listAllanimals.DisplayMemberPath = "Name";
                listAllanimals.SelectedValuePath = "Id";
                listAllanimals.ItemsSource = allanimalTable.DefaultView;

            }



        }

        private void ListZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowAssocatedAnimals();
        }

        private void DeleteZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Zoo where Id = @ZooId ";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.ToString());
            }
            finally
            {
                conn.Close();
                ShowZoos();
            }
        }

        private void AddZoo_Click(object sender,RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Zoo values (@Location)  ";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@Location", TextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.ToString());
            }
            finally
            {
                conn.Close();
                ShowZoos();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}




