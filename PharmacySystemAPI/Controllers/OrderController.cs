using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PharmacySystemAPI.Models.Account;
using PharmacySystemAPI.Models.Order;
using PharmacySystemBusinessLogic.Account.Validation;
using PharmacySystemBusinessLogic.Order;
using PharmacySystemDataAccess.Models.Account;

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

            return new OrderResponse();
        }
    }
}