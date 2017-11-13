using System;
using PharmacySystemClient.Checkout;
using PharmacySystemClient.Accounts;
using PharmacySystemClient.Orders;
using PharmacySystemClient.Sales;
using Unity;

namespace PharmacySystemClient
{
    class IocContainer 
    {
        public IUnityContainer container  { get; set; }
        
        public void RegisterInterfaces()
        {
            container = new UnityContainer();
            container.RegisterInstance<ILoginService>("Login",new LoginService());
            container.RegisterInstance<IOrderService>("Order", new OrderService());
            container.RegisterInstance<ISalesService>("Sales", new SalesService());
            container.RegisterInstance<ICheckoutService>("Checkout", new CheckoutService());
            Console.WriteLine("Interfaces Registered");
        }
    }
}
