using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacySystemBusinessLogic.Interceptor
{
    public class Invoker : IInvoker
    {
        public List<string> InvokedList { get; set; }
        public string Message { get; set; }

        public Invoker()
        {
            InvokedList = new List<string>();
        }
        public void Invoke(string action)
        {
            InvokedList.Add(action);
        }
    }
}
