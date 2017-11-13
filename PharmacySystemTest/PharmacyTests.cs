using System;
using System.IO;
using System.Net;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PharmacySystemAPI;
using PharmacySystemAPI.Controllers;
using PharmacySystemAPI.Models.Account;
using PharmacySystemAPI.Models.Customer;
using PharmacySystemAPI.Models.Order;
using PharmacySystemAPI.Models.Product;
using System.Web.Helpers;
using PharmacySystemBusinessLogic;
using PharmacySystemBusinessLogic.Account.Validation;
using PharmacySystemDataAccess;
using PharmacySystemDataAccess.Models.Account;
using PharmacySystemDataAccess.Models.Product;
using PharmacySystemDataAccess.Repository.RepositoryFactory;

namespace PharmacySystemTest
{
    [TestClass]
    public class PharmacyTests
    {
        private string accountName = "employee";
        private string accountPassword = "test";
        private string firstName = "John";
        private string lastName = "Doe";

        [TestMethod]
        public void ValidateLogin()
        {
            AccountRequest accRequest = new AccountRequest()
            {
                AccountName = accountName,
                AccountPassword = accountPassword
            };
            string json = JsonConvert.SerializeObject(accRequest);
            string responseFromServer = PostAndGetResponseAPI("http://localhost:8080/api/Account", json);
            
            Assert.IsTrue(responseFromServer.Contains("true"),"Account not found");
            Assert.IsTrue(responseFromServer.Contains(" has been found"), "Account not found");
        }

        [TestMethod]
        public void GetProducts()
        {
            string response = ResponseFromAPI("http://localhost:8080/api/Product");
            Assert.IsTrue(response.Contains("Products found"),"Products not found");
        }

        [TestMethod]
        public void GetSales()
        {
            string response = ResponseFromAPI("http://localhost:8080/api/Sales");

            Assert.IsTrue(response.Contains("Sales found"), "Sales not found");
        }

      
        [TestMethod]
        public void ValidateCustomer()
        {
            CustomerRequest accRequest = new CustomerRequest()
            {
                FirstName = firstName,
                LastName = lastName
            };
            string json = JsonConvert.SerializeObject(accRequest);
            string responseFromServer = PostAndGetResponseAPI("http://localhost:8080/api/Customer", json);

            Assert.IsTrue(responseFromServer.Contains("true"), "Customer not found");
            Assert.IsTrue(responseFromServer.Contains(" has been found"), "Customer not found");
        }


        public string PostAndGetResponseAPI(string mongoURL, string postRequest)
        {
            var request = WebRequest.Create(mongoURL);
            request.Method = "POST";
            request.ContentType = "application/json; charset=UTF-8";

            // Get the request stream.
            var dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            using (var writer = new StreamWriter(dataStream))
            {
                writer.Write(postRequest);
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
           
            return responseFromServer;
        }

        public string ResponseFromAPI(string mongoURL)
        {
            string responseFromServer;
            using (WebClient client = new WebClient())
            {
                responseFromServer = client.DownloadString(mongoURL);
            }
            return responseFromServer;
        }


    }
}
