namespace PharmacySystemBusinessLogic.Product
{
    public class Asprine : Drug
    {

        public Asprine(int productId, string name, int quantity, double price, bool checkRequiresPerscription, string container) : 
            base(productId, name, quantity, price, checkRequiresPerscription, container) {}
    }
}