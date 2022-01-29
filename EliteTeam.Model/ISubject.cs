using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.Model
{
    public interface ISubject
    {
        public void Subscribe(IObserver obs);

        public void Unsubscribe(IObserver obs);

        public void NotifyObservers();
    }
}
