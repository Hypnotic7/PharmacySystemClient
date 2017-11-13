using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystemClient.Accounts
{
    public class AccountResponse
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public AccountEntity Account { get; set; }
    }

}
