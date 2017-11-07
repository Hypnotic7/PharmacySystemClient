using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacySystemBusinessLogic.Interceptor
{
    public interface IInterceptor
    {
        void Intercept(ILogger logger);
    }
}
