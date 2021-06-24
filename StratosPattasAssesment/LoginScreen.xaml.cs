using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        //private string username = "stratos";
        //private string password = "pattas1984";
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            string password = Properties.Settings.Default.password;
            string username = Properties.Settings.Default.username;
            if (txtUsername.Text == username && txtPassword.Password == password)
            {
                MainWindow mainPage = new MainWindow();
                mainPage.Show();
                Logger.Info($"User {txtUsername.Text} logged in");
                Close();
            }
            else
            {
                MessageBox.Show("Wrong username or password.");
            }

        }
    }
}
