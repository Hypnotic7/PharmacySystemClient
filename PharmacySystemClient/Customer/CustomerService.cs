using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using Newtonsoft.Json;
using PharmacySystemClient;

namespace PharmacySystemClient
{
    interface ICustomerService
    {
        CustomerResponse GetCustomer();
    }
    class CustomerService : ICustomerService
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CustomerResponse GetCustomer()
        {
            string json = ConvertToJson(FirstName, LastName);
            Console.WriteLine(json);

            var request = WebRequest.Create("http://localhost:8080/api/Customer");
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
            CustomerResponse customerResponse = Json.Decode<CustomerResponse>(responseFromServer);

            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            return customerResponse;
        }

        private string ConvertToJson(string firstName, string lastName)
        {
            var obj = new CustomerService()
            {
                FirstName = firstName,
                LastName = lastName
            };
            string json = JsonConvert.SerializeObject(obj);

            return json;
        }
    }
    
}
