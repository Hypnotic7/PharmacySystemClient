namespace PharmacySystemBusinessLogic.Product
{
    public class DrugFactory
    {

        public Drug MakeDrug(int productId, string name, int quantity, double price, bool checkRequiresPerscription, string container)
        {
            if (name.Equals("Aspirin"))
            {
                return new Asprine(productId, name, quantity, price, checkRequiresPerscription, container);
            }
            else if (name.Equals("Xanax"))
            {
                return new Xanax(productId, name, quantity, price, checkRequiresPerscription, container);
            }
            else if (name.Equals("Panadol"))
            {
                return new Panadol(productId, name, quantity, price, checkRequiresPerscription, container);
            }
            else if (name.Equals("Morphine"))
            {
                return new Morphine(productId, name, quantity, price, checkRequiresPerscription, container);
            }
            else if (name.Equals("Calpol"))
            {
                return new Calpol(productId, name, quantity, price, checkRequiresPerscription, container);
            }

            return null;
        }
    }
}