using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacySystemBusinessLogic.Interceptor
{
    public class Logger : ILogger
    {
        public List<string> LogList { get; set; }
        public string Message { get; set; }

        public Logger()
        {
            LogList = new List<string>();
        }

        public void Log(string action)
        {
            LogList.Add(action);
        }
    }
}
