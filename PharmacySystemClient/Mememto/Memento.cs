using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PharmacySystemClient
{
    public class Memento
    {
        private List<string> _amount;

        public Memento(Originator originator)
        {
            _amount = originator.MomentoList;
        }

        public Memento(List<string> amount)
        {
            _amount = amount;
        }

        public List<string> MomentoList
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }
    }
}
