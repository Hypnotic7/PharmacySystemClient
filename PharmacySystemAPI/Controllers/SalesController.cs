using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PharmacySystemAPI.Models.Sales;
using PharmacySystemBusinessLogic.Sales;
using PharmacySystemDataAccess.Models.Sales;
using PharmacySystemDataAccess.Repository.RepositoryFactory;

namespace PharmacySystemAPI.Controllers
{
    [Route("api/[controller]")]
    public class SalesController
    {
        private IOptions<AppSettings> _appSettings;

        public SalesController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        // GET api/values
        [HttpGet]
        public SalesResponse GetSales()
        {
            SalesValidation salesValidation = new SalesValidation(new RepositoryFactory<SalesEntity>(), _appSettings.Value.MongoConnectionString);

            try
            {
                var salesValidationStatus = salesValidation.GetAllSales();
                if (salesValidationStatus.GotAllSales)
                {
                    return new SalesResponse()
                    {
                        Message = "Sales found",
                        SalesEntity = salesValidationStatus.SalesEntity
                    };
                }
                else
                {
                    return new SalesResponse()
                    {
                        Message = "Sales not found",
                        SalesEntity = null
                    };
                }     
               
            }
            catch (KeyNotFoundException keyNotFound)
            {
                return new SalesResponse()
                {
                    Message = keyNotFound.Message,
                    SalesEntity = null
                };
            }
        }
    }
}
