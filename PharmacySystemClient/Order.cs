using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace PharmacySystemClient
{
    interface IOrder
    {
        ProductResponse GetProducts();
    }
    class Order : IOrder
    {

        //************************************* Change URL and write in json
        public ProductResponse GetProducts() 
        {
            // string json = ConvertToJson(Username, Password);
            string item = "ListOfProducts";

            var request = WebRequest.Create("http://localhost:8080/api/Products"); 
            request.Method = "POST";
            request.ContentType = "application/json; charset=UTF-8";

            // Get the request stream.
            var dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            using (var writer = new StreamWriter(dataStream))
            {
                writer.Write(item);
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
           ProductResponse productResponse = Json.Decode(responseFromServer);

            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();

            return productResponse;
        }

        private string ConvertToJson(string name, string password)
        {
            var obj = new Accounts
            {
                AccountName = name,
                AccountPassword = password
            };
            string json = JsonConvert.SerializeObject(obj);

            return json;
        }

    }
}
