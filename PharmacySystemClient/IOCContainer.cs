using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using PharmacySystemClient.Command;
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

            //container.RegisterInstance<ILogin>("ILogin",new Login());
            //Console.WriteLine("Interfaces Registered");
        }
    }
}
