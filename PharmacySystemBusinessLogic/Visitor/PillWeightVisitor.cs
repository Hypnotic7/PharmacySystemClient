namespace PharmacySystemBusinessLogic.Visitor
{
    public class PillWeightVisitor : IVisitor
    {
        public double _weight { get; private set; }

        //collect data about pills in BlisterPacks
        public void Visit(BlisterPackElement blisterpack)
        {
            _weight += ((blisterpack.TabletPairs * 2) * .26); //in BlisterPacks, pills come in pairs
        }

        //collect data about pills in Bottles
        public void Visit(BottleElement bottle)
        {
            _weight += ((bottle.Items) * .41);
        }
    }
}