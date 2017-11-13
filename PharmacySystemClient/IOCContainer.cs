using System;
using PharmacySystemClient.Checkout;
using PharmacySystemClient.Command;
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
            container.RegisterInstance<ILogin>("Login",new Login());
            container.RegisterInstance<IOrder>("Order", new Order());
            container.RegisterInstance<ISales>("Sales", new Sales.Sales());
            container.RegisterInstance<ICheckout>("Checkout", new Checkout.Checkout());
            Console.WriteLine("Interfaces Registered");
        }
    }
}
