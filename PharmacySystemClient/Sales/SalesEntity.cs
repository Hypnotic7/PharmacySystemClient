using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystemClient.Sales
{
    class SalesEntity
    {
        public string SalesId { get; set; }
        public int RegularSales { get; set; }
        public int MedicalCardSales { get; set; }
        public int DrugSchemeSales { get; set; }
    }
}
