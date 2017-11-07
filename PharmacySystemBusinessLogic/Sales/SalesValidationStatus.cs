using PharmacySystemDataAccess.Models.Sales;

namespace PharmacySystemBusinessLogic.Sales
{
    public class SalesValidationStatus
    {
        public bool GotAllSales { get; set; }
        public SalesEntity SalesEntity { get; set; }
    }
}
