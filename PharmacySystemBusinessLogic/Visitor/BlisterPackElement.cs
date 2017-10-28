namespace PharmacySystemBusinessLogic.Visitor
{
    public class BlisterPackElement : IElement
    {
        public int TabletPairs;

        public BlisterPackElement(int x)
        {
            TabletPairs = x;
        }

        //accept the visitor
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public int GetTabletPairs()
        {
            return TabletPairs;
        }
    }
}