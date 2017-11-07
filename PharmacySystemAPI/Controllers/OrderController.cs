using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PharmacySystemAPI.Models.Order;
using PharmacySystemBusinessLogic.Interceptor;
using PharmacySystemBusinessLogic.Order;
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
            Dispatcher dispatcher = new Dispatcher();
            dispatcher.RegisterInterceptor(new LoggerInterceptor());
            OrderValidation orderValidation = new OrderValidation(new RepositoryFactory<OrderEntity>(), _appSettings.Value.MongoConnectionString, dispatcher, new Logger());

            try
            {
                var orderValidationStatus = orderValidation.ValidateOrder(orderRequest.AccountName,
                   orderRequest.CustomerName, orderRequest.Products);

                orderValidation.AddOrderToRepository(orderValidationStatus.OrderEntity);
                return new OrderResponse()
                {
                    Message = "Order Complete",
                    OrderComplete = orderValidationStatus.IsValid,
                    OrderEntity = orderValidationStatus.OrderEntity
                };
            }
            catch (Exception e)
            {
                return new OrderResponse()
                {
                    Message = "Order Not Complete",
                    OrderComplete = false
                };
            }
        }
    }
}