using System.Collections.Generic;
using System.Diagnostics;

namespace PharmacySystemBusinessLogic.Visitor
{
    class Driver
    {
        static void Main(string[] args)
        {
            List<IElement> products = new List<IElement>
            {
                new BlisterPackElement(10),
                new BottleElement(50)
            };

            var totalPills = CalculateAmount(products);
            var totalWeight = CalculateWeight(products);

            Debug.WriteLine("\nNumber of Pills  ->  " + totalPills);
            Debug.WriteLine("Weight of Pills  ->  " + totalWeight + "mg\n");

            int CalculateAmount(List<IElement> productsB)
            {
                var visitor = new PillCountVisitor();

                //iterate through each item in list
                foreach (IElement e in productsB)
                {
                    e.Accept(visitor);
                }

                return visitor._count;
            }

            double CalculateWeight(List<IElement> productsC)
            {
                var visitor = new PillWeightVisitor();

                //iterate through each item in list
                foreach (IElement e in productsC)
                {
                    e.Accept(visitor);
                }

                return visitor._weight;
            }
        }
    }
}
