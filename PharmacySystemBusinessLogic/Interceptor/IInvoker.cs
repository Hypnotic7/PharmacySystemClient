using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacySystemBusinessLogic.Interceptor
{
    public interface IInvoker
    {
        List<string> InvokedList { get; set; }
        string Message { get; set; }
        void Invoke(string action);
    }
}
