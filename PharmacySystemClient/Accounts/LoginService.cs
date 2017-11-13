using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Windows;
using Newtonsoft.Json;

namespace PharmacySystemClient.Accounts
{
    interface ILoginService
    {
        AccountResponse ValidateLogin();
    }

    class LoginService : ILoginService
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AccountResponse ValidateLogin()
        {
            string json = ConvertToJson(Username, Password);
            Console.WriteLine(json);

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
            AccountResponse accountResponse = Json.Decode<AccountResponse>(responseFromServer);

            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            return accountResponse;
        }

        private string ConvertToJson(string name, string password )
        {
            var obj = new AccountRequest()
            {
                AccountName = name,
                AccountPassword = password
            };
            string json = JsonConvert.SerializeObject(obj);

            return json;
        }
    }
}

  
    

