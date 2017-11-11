using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystemClient
{
    public class CareTaker
    {

        private static CareTaker _instance;
        private Memento _productMemento;

        private CareTaker()
        {
        }

        public static CareTaker Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CareTaker();
                }
                return _instance;
            }
        }

        public Memento Memento
        {
            get
            {
                return _productMemento;
            }
            set
            {
                _productMemento = value;
            }
        }
    }
}

