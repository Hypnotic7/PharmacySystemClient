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
                var obj = convertToJson(username,password);
                postToWebService(obj);
                //Window mainMenuWindow = new MainMenu();
                //mainMenuWindow.Show();
                //this.Close();
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


        private object convertToJson(string name, string password)
        {
            var obj = new Accounts
            {
                username = name,
                password = password
            };
            var json =  JsonConvert.SerializeObject(obj);
            return json;
        }

        class Accounts
        {
            public string username;
            public string password;
            private string name;
            private string role;
        }

        static HttpClient client = new HttpClient();
        public void postToWebService(object obj)
        {
            var request = WebRequest.Create("http://localhost:8080/api/Account");
            request.Method = "POST";
            request.ContentType = "application/json; charset=UTF-8";
            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(obj);
            }
        }
    }
}
