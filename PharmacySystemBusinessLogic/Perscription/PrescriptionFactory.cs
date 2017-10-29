namespace PharmacySystemBusinessLogic.Perscription
{
    public class PrescriptionFactory
    {

        public static Prescription MakePrescription(string name, string gpName, string prescription, int prescriptionId)
        {
            return new Prescription(name, gpName, prescription, prescriptionId);
        }
    }
}