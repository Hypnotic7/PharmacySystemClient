namespace PharmacySystemBusinessLogic.Product
{
    public class Panadol : Drug
    {

        public Panadol(int productId, string name, int quantity, double price, bool checkRequiresPerscription, string container) :
            base(productId, name, quantity, price, checkRequiresPerscription, container) {}
    }
}