﻿using Newtonsoft.Json;
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

        public ProductResponse GetProducts() 
        {
           
            string responseFromServer;
            using (WebClient client = new WebClient())
            {
                responseFromServer = client.DownloadString("http://localhost:8080/api/Product");
            }
            ProductResponse productResponse = Json.Decode<ProductResponse>(responseFromServer);
            return productResponse;
        }

    }
}
