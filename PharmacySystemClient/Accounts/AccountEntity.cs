using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystemClient
{
    public class AccountEntity
    {
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        //public AccountPermissions AccountPermissions { get; set; }

        public bool IsLoggedIn { get; set; }
        public DateTime LastLoginDate { get; set; }
    }

    public enum AccountTypeEnum
    {
        Admin,
        Manager,
        Employee
    }
}


