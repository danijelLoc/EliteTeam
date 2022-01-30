using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.Model
{
    public abstract class Subject : ISubject
    {
        protected List<IObserver> _observers = new List<IObserver>();

        public void Subscribe(IObserver obs)
        {
            _observers.Add(obs);
        }

        public void Unsubscribe(IObserver obs)
        {
            _observers.Remove(obs);
        }

        public void NotifyObservers()
        {
            foreach (IObserver obs in _observers)
                obs.UpdateYourself();
        }

    }
}
