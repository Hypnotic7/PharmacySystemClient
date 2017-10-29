using System.Collections;

namespace PharmacySystemBusinessLogic.Sales
{
    public class SalesDetails : ISubject
    {

        public SalesDetails()
        {
        }

        // A Collection to keep track of all Registered Observers
        ArrayList observers = new ArrayList();

        // Stores latest stock quote (example is purposely simplistic)
        private int medicalCardSales = 0;
        private int drugSchemeSales = 0;
        private int regularSales = 0;

        public void SetMedicalCardSales(int v)
        {
            medicalCardSales = v;
        }

        public void SetDrugSchemeSales(int w)
        {
            drugSchemeSales = w;
        }

        public void SetRegularSales(int x)
        {
            regularSales = x;
        }

        public void Register(IObserver o)
        {
            observers.Add(o);
        }

        public void Unregister(IObserver o)
        {
            int i = observers.IndexOf(o);
            observers.RemoveAt(i);
        }

        public void NotifyObserver()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                IObserver ob = (IObserver)observers[i];
                ob.Update(medicalCardSales, drugSchemeSales, regularSales);
            }
        }
    }
}