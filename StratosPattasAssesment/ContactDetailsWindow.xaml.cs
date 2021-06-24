using StratosPattasAssesment.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace StratosPattasAssesment
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Customer selectedCustomer;
        private static bool visible = false;
        public ContactDetailsWindow(Customer selectedCustomer)
        {
            InitializeComponent();

            this.selectedCustomer = selectedCustomer;
            lblCustomerId.Content = this.selectedCustomer.Id;
            lblFirstName.Content = this.selectedCustomer.FirstName;
            lblLastName.Content = this.selectedCustomer.LastName;
            lblAddress.Content = this.selectedCustomer.Address;
            lblPhone.Content = this.selectedCustomer.Phone;
            txtBoxComments.Text = this.selectedCustomer.Comments;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

            selectedCustomer.Comments = txtBoxComments.Text;

            string strConn = App.connectionString;
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                int rowCount = 0;

                string query = "UPDATE [ContactInformations] SET [Comments] = '" + txtBoxComments.Text + "' WHERE ID = '" + lblCustomerId.Content + "'";

                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 12 * 3600;

                // Open.  
                sqlConnection.Open();

                // Result.  
                rowCount = sqlCommand.ExecuteNonQuery();

                // Close.  
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                // Close.  
                sqlConnection.Close();

                throw ex;
            }


            Close();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string strConn = App.connectionString;
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                int rowCount = 0;
                string query = "INSERT INTO [DropdownSelected] (SelectedValue, CustomerId) VALUES ('" + comboBox1.SelectedValue + "','" + lblCustomerId.Content + "') ";

                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 12 * 3600;

                // Open.  
                sqlConnection.Open();

                // Result.  
                rowCount = sqlCommand.ExecuteNonQuery();

                // Close.  
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                // Close.  
                sqlConnection.Close();

                throw ex;
            }
           
        }

        private void txtBoxComments_TextChanged(object sender, TextChangedEventArgs e)
        {

            string comments = txtBoxComments.Text;
            if (!visible)
            {
                visible = true;
            }
            else
            {
                updateButton.Visibility = Visibility.Visible;
            }

     
        }

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}