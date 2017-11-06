using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacySystemBusinessLogic.Interceptor
{
    //Concrete Interceptor
    public class LoggerInterceptor : IInterceptor
    {
        public void Intercept(ILogger logger)
        {
            logger.Log(logger.Message);
        }
    }
}
