namespace PharmacySystemDataAccess.Models.Account
{
    public class AccountPermissions
    {
        public bool CanModifyCustomer { get; set; }
        public bool CanModifyManager { get; set; }
        public bool CanModifyEmployee { get; set; }
        public bool CanModifyProducts { get; set; }
    }
}
