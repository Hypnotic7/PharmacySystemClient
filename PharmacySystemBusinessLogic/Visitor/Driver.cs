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

            var visitor = new PillCountVisitor();

            //iterate through each item in list
            foreach (IElement e in products)
            {
                e.Accept(visitor);
            }

            var totalPills = visitor._count;
            Debug.WriteLine(totalPills);
        }
    }
}