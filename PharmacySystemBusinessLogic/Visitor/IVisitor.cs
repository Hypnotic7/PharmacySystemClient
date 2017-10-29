namespace PharmacySystemBusinessLogic.Visitor
{
    public interface IVisitor
    {
        void Visit(BlisterPackElement blisterpack);
        void Visit(BottleElement bottle);
    }
}