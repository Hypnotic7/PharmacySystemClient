namespace PharmacySystemDataAccess.Models.Order
{
    public class OrderEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool RequiresPrescription { get; set; }
        public string Container { get; set; }
    }
}
