using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PharmacySystemClient
{
    public class Originator
    {

        public Originator()
        {
            MomentoList = new List<string>();
        }

        public List<string> MomentoList { get; set; }

        //Save an originator to a memento
        //When Save button is clicked
        public Memento SaveOriginator()
        {
            return new Memento(this.MomentoList);
        }

        //Restore the originator to a previous state held by a memento
        public void RestoreOriginator(Memento productMemento)
        {
            this.MomentoList = productMemento.MomentoList;
        }
    }
}
