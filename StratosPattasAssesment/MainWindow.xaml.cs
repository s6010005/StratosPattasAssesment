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
using System.Data;
using StratosPattasAssesment.Classes;

namespace StratosPattasAssesment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ReadDatabase();
        }

        /// <summary>
        /// Fetches data from DB(ContactInformations table) and fills listViewContactInformations ListView.
        /// </summary>
        void ReadDatabase()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                SqlDataAdapter ad = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                String str = "SELECT Id, FirstName, LastName, Address, Phone, Comments FROM ContactInformations";
                cmd.CommandText = str;
                ad.SelectCommand = cmd;
                con.ConnectionString = App.connectionString;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                ad.Fill(ds);
                listViewContactInformations.DataContext = ds.Tables[0].DefaultView;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Can't connect to DB");
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the listViewContactInformations control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void listViewContactInformations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataRowView dataRowView = (DataRowView)listViewContactInformations.SelectedItem;

            if (dataRowView != null)
            {
                Customer customer = new Customer
                {
                    Id = Convert.ToInt32(dataRowView.Row[0]),
                    FirstName = Convert.ToString(dataRowView.Row[1]),
                    LastName = Convert.ToString(dataRowView.Row[2]),
                    Address = Convert.ToString(dataRowView.Row[3]),
                    Phone = Convert.ToInt64(dataRowView.Row[4]),
                    Comments = Convert.ToString(dataRowView.Row[5]),
                };

                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(customer);
                contactDetailsWindow.ShowDialog();
                ReadDatabase();
            }

        }
    }
}