using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace PharmacySystemClient.Command
{
    interface ILogin
    {
        bool ValidateLogin();
    }

    class Login : ILogin
    {
        public string Username { get; set; }
        public string Password { get; set; }


        public Login()
        {
        }



        public bool ValidateLogin()
        {
            string json = ConvertToJson(Username, Password);
            bool valid = true;

                var request = WebRequest.Create("http://localhost:8080/api/Account");
                request.Method = "POST";
                request.ContentType = "application/json; charset=UTF-8";

                // Get the request stream.
                var dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                using (var writer = new StreamWriter(dataStream))
                {
                    writer.Write(json);
                }

                // Close the Stream object.
                dataStream.Close();

                // Get the response.
                var response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
             
            return valid;
        }

        private string ConvertToJson(string name, string password)
        {
            var obj = new Accounts()
            {
                AccountName = name,
                AccountPassword = password
            };
            string json = JsonConvert.SerializeObject(obj);

            return json;
        }


    }

}

    //class LoggedInAsEmployee : ILogin
    //{
    //    private Login login;

    //    public LoggedInAsEmployee(Login login)
    //    {
    //        this.login = login;
    //    }

    //    public void Execute()
    //    {
    //        MainMenu menu = new MainMenu();
    //        Window window = menu;
    //        window.Show();
    //        menu.ShowEmployeeMenu();
           
    //    }
    //}

    //class LoggedInAsManager : ILogin
    //{
    //    private Login login;

    //    public LoggedInAsManager(Login login)
    //    {
    //        this.login = login;
    //    }

    //    public void Execute()
    //    {
    //        MainMenu menu = new MainMenu();
    //        Window window = menu;
    //        window.Show();
         
    //    }
    //}

    //class LoginCommand
    //{
    //    ILogin ilogin;

    //    public LoginCommand(){}

    //    public void SetCommand(ILogin ilogin)
    //    {
    //        this.ilogin = ilogin;
    //    }

    //    public void ExecuteCommand()
    //    {
    //        ilogin.Execute();
    //    }
    //}
    

