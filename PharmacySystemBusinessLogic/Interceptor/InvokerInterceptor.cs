using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacySystemBusinessLogic.Interceptor
{
    public class InvokerInterceptor : IInterceptor<IInvoker>
    {
        public void Intercept(IInvoker invoker)
        {
            invoker.Invoke(invoker.Message);
        }
    }
}
