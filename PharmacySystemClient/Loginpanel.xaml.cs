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
using System.Windows.Shapes;

namespace PharmacySystemClient
{
    /// <summary>
    /// Interaction logic for Loginwindow.xaml
    /// </summary>
    public partial class Loginwindow : Window
    {
        public Loginwindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var username = GetUsername();
            var password = GetPassword();
            bool isValid = ValidateUsernameAndPassword(username, password);

            if (isValid == true)
             {
                  Window mainMenuWindow = new MainMenu();
                  mainMenuWindow.Show();
                  this.Close();
             }
            else
            {
                  MessageBox.Show("Invalid username or password", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private string GetUsername()
        {
            return UsernameTextField.Text;
        }
        private string GetPassword()
        {
            return PasswordField.Password;
        }

        private bool ValidateUsernameAndPassword(string username,string password)
        {
            if (username.Length > 0 && password.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
