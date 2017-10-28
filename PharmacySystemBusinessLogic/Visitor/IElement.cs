namespace PharmacySystemBusinessLogic.Visitor
{
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }
}