using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using Newtonsoft.Json;
using PharmacySystemClient.Accounts;
using Unity;


namespace PharmacySystemClient
{
    /// <summary>
    /// Interaction logic for Loginwindow.xaml
    /// </summary>; 
    public partial class Loginwindow : Window
    {
        private IocContainer ioccontainer;

        public Loginwindow()
        {
            InitializeComponent();
            ioccontainer = new IocContainer();
            ioccontainer.RegisterInterfaces();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            bool isValid = ValidateUsernameAndPassword(UsernameTextField.Text, PasswordField.Password);

            if (isValid)
            {
                LoginService login = new LoginService();
                login.Username = UsernameTextField.Text;
                login.Password = PasswordField.Password;
                AccountResponse response = login.ValidateLogin();
                bool check = response.IsValid;
                if (check)
                {
                    UIRemote remote = new UIRemote();
                    ViewMainMenu viewMenu = new ViewMainMenu(response);
                    remote.SetCommand(viewMenu);
                    remote.ExecuteCommand();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Account not valid! " + response.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                  
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password! ", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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
