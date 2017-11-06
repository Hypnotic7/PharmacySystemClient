using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacySystemBusinessLogic.Interceptor
{
    public class Dispatcher
    {
        public List<IInterceptor> interceptors { get; }

        public Dispatcher()
        {
            interceptors = new List<IInterceptor>();
        }

        public void RegisterInterceptor(IInterceptor interceptor)
        {
            interceptors.Add(interceptor);
        }

        public void RemoveInterceptor(IInterceptor interceptor)
        {
            interceptors.Remove(interceptor);
        }
    }
}
