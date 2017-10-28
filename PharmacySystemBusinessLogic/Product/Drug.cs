namespace PharmacySystemBusinessLogic.Product
{
    public class Drug
    {

        private int _productId { get; }
        private string _name { get; }
        private int _quantity { get; set; }
        private double _price { get; }
        private bool _lowQuantity { get; }
        private bool _checkRequiresPerscription { get; }
        private string _container { get; }

        public Drug(int productId, string name, int quantity, double price, bool checkRequiresPerscription, string container)
        {
            _productId = productId;
            _name = name;
            _quantity = quantity;
            _price = price;
            _lowQuantity = false;
            _checkRequiresPerscription = checkRequiresPerscription;
            _container = container;
        }
        public string GetDescription()
        {
            return _productId + " " + _name + " " + _quantity + " " + _price;
        }
    }
}