namespace PharmacySystemBusinessLogic.Cart
{
    public abstract class CartDecorator : EmptyCart
    {
        public EmptyCart c;

        public CartDecorator(EmptyCart c)
        {
            this.c = c;
        }

        public double GetCost()
        {
            return c.GetCost();
        }
    }
}