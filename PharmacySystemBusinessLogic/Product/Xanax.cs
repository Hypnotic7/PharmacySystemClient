namespace PharmacySystemBusinessLogic.Product
{
    public class Xanax : Drug
    {

        public Xanax(int productId, string name, int quantity, double price, bool checkRequiresPerscription, string container) :
            base(productId, name, quantity, price, checkRequiresPerscription, container) {}
    }
}