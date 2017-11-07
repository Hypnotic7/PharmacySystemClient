using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace PharmacySystemClient.Sales
{
    interface ISales
    {
        SalesResponse ValidateSales();
    }

    class Sales : ISales
    {
        public SalesResponse ValidateSales()
        {
            string responseFromServer;
            using (WebClient client = new WebClient())
            {
                responseFromServer = client.DownloadString("http://localhost:8080/api/Sales");
            }
            SalesResponse salesResponse = Json.Decode<SalesResponse>(responseFromServer);
            return salesResponse;
        }
    }
}
