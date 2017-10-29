namespace PharmacySystemBusinessLogic.Perscription
{
    public class Prescription
    {

        private string CustomerName { get; }
        private string GpName { get; }
        private string Items { get; }
        private int PrescriptionId { get; }

        public Prescription(string name, string gpName, string items, int prescriptionId)
        {
            CustomerName = name;
            GpName = gpName;
            PrescriptionId = prescriptionId;
            Items = items;

        }

        public string GetDescription()
        {
            return "Customer Name " + CustomerName + " GP Name " + GpName + "items " + Items + " Prescription ID " + PrescriptionId;
        }
    }
}