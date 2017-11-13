using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using Newtonsoft.Json;
using PharmacySystemClient.Orders;

namespace PharmacySystemClient.Checkout
{
    interface ICheckoutService
    {
        OrderResponse ValidateOrder();
    } 
    class CheckoutService : ICheckoutService
    {
        public string accountName { get; set; }
        public string customerName { get; set; }
        public List<ProductEntity> products { get; set; }

        public OrderResponse ValidateOrder()
        {
            string json = ConvertToJson(accountName, customerName,products);
            Console.WriteLine(json);

            var request = WebRequest.Create("http://localhost:8080/api/Order");
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
            OrderResponse orderResponse = Json.Decode<OrderResponse>(responseFromServer);

            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            return orderResponse;
        }


        private string ConvertToJson(string accountName, string customerName, List<ProductEntity> products)
        {
            var obj = new OrderRequest()
            {
                AccountName = accountName,
                CustomerName = customerName,
                Products = products
            };
            string json = JsonConvert.SerializeObject(obj);

            return json;
        }
    }
}


