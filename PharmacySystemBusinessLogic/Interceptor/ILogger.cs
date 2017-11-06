using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacySystemBusinessLogic.Interceptor
{
    public interface ILogger
    {
        List<string> LogList { get; set; }
        string Message { get; set; }
        void Log(string action);
    }
}
