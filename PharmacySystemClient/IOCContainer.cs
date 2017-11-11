using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
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
        
        public IocContainer()
        {
           
        }

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
