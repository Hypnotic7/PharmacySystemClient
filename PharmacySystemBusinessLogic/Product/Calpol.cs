﻿namespace PharmacySystemBusinessLogic.Product
{
    public class Calpol : Drug
    {

        public Calpol(int productId, string name, int quantity, double price, bool checkRequiresPerscription, string container) :
            base(productId, name, quantity, price, checkRequiresPerscription, container) {}
    }
}