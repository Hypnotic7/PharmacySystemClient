using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacySystemAPI.Models.Account
{
    public class AccountResponse
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}
