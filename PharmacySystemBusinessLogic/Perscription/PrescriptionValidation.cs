using PharmacySystemDataAccess.Models.Prescription;
using PharmacySystemDataAccess.Repository;
using PharmacySystemDataAccess.Repository.RepositoryFactory;

namespace PharmacySystemBusinessLogic.Perscription
{
    public class PrescriptionValidation
    {
        public IDataAccess<PrescriptionEntity> PrescriptionRepository { get; }

        public PrescriptionValidation(IRepositoryFactory<PrescriptionEntity> prescriptionFactory, string connectionString)
        {
            PrescriptionRepository = prescriptionFactory.CreateRepository(connectionString, "PrescriptionRepository");
        }

        public PrescriptionValidationStatus CheckForCustomerOrGpName(string name)
        {
            var prescriptionValidationStatus = new PrescriptionValidationStatus(){IsValid = false};

            if (name.Equals(string.Empty)) return prescriptionValidationStatus;

            name = name.Trim();

            var prescription = PrescriptionRepository.Find(name);

            if (prescription.Equals(null)) return prescriptionValidationStatus;

            prescriptionValidationStatus.Prescription = prescription;
            prescriptionValidationStatus.IsValid = true;

            return prescriptionValidationStatus;
        }


    }
}