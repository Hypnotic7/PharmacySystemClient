namespace PharmacySystemBusinessLogic.Visitor
{
    public class BottleElement : IElement
    {
        public int Items { get; set; }

        public BottleElement(int x) { Items = x; }

        //accept the visitor
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}