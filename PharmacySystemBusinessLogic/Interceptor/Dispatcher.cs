using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacySystemBusinessLogic.Interceptor
{
    public class Dispatcher
    {
        public List<IInterceptor<ILogger>> interceptors { get; }
        public List<IInterceptor<IInvoker>> interceptorsInv { get; }

        public Dispatcher()
        {
            interceptors = new List<IInterceptor<ILogger>>();
            interceptorsInv = new List<IInterceptor<IInvoker>>();
        }

        public void RegisterInterceptor<T>(T interceptor)
        {
            if(typeof(T) == typeof(LoggerInterceptor))
            interceptors.Add((IInterceptor<ILogger>)interceptor);
            else if(typeof(T) == typeof(InvokerInterceptor))
                interceptorsInv.Add((IInterceptor<IInvoker>) interceptor);

        }

        public void RemoveInterceptor<T>(T interceptor)
        {
            if(typeof(T) == typeof(LoggerInterceptor))
            interceptors.Remove((IInterceptor<ILogger>)interceptor);
            else if (typeof(T) == typeof(InvokerInterceptor))
                interceptorsInv.Remove((IInterceptor<IInvoker>) interceptor);
        }
    }
}
