using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PharmacySystemAPI.Models.Order;
using PharmacySystemBusinessLogic.Order;
using PharmacySystemBusinessLogic.Product;
using PharmacySystemDataAccess.Models.Order;
using PharmacySystemDataAccess.Repository.RepositoryFactory;


namespace PharmacySystemAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {

        private IOptions<AppSettings> _appSettings;

        public OrderController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }
        // POST api/values
        [HttpPost]

        public OrderResponse Post([FromBody]OrderRequest orderRequest)
        {
            OrderValidation orderValidation = new OrderValidation(new RepositoryFactory<OrderEntity>(), _appSettings.Value.MongoConnectionString);

            try
            {
                var orderValidationStatus = orderValidation.ValidateOrder(orderRequest.AccountName,
                    orderRequest.CustomerName, orderRequest.Products);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
            return new OrderResponse();
        }
    }
}