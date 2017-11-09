using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacySystemBusinessLogic.Interceptor
{
    public interface IInterceptor<T>
    {
        void Intercept(T logger);
    }
}
