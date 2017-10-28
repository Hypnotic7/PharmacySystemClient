namespace PharmacySystemBusinessLogic.Visitor
{
    public class PillCountVisitor : IVisitor
    {
        public int _count { get; set; }

        //collect data about pills in BlisterPacks
        public void Visit(BlisterPackElement blisterpack)
        {
            _count += blisterpack.TabletPairs * 2; //in BlisterPacks, pills come in pairs
        }

        //collect data about pills in Bottles
        public void Visit(BottleElement bottle)
        {
            _count += bottle.Items;
        }

        //return PillCount
    }
}