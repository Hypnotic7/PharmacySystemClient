namespace PharmacySystemBusinessLogic.Product
{
    public class Morphine : Drug
    {

        public Morphine(int productId, string name, int quantity, double price, bool checkRequiresPerscription, string container) :
            base(productId, name, quantity, price, checkRequiresPerscription, container) {}
    }
}