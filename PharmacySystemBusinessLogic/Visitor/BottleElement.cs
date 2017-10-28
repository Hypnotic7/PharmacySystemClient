namespace PharmacySystemBusinessLogic.Visitor
{
    public class BottleElement : IElement
    {
        public int Items;

        public BottleElement(int x)
        {
            Items = x;
        }

        //accept the visitor
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public int GetItems()
        {
            return Items;
        }
    }
}