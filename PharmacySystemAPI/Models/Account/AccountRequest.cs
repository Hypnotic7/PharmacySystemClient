using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacySystemAPI.Models.Account
{
    public class AccountRequest
    {
        public string AccountName { get; set; }
        public string AccountPassword { get; set; }
        public string Name { get; set; }
        public string AccountRole { get; set; }
    }
}
