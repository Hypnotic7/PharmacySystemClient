using PharmacySystemDataAccess.Models.Account;

namespace PharmacySystemBusinessLogic.Account.Validation
{
    public class AccountValidationStatus
    {
        public bool IsValid { get; set; }
        public AccountEntity Account { get; set; }
    }
}
