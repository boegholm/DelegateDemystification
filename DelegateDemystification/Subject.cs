using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegateDemystification
{
    class Subject : ISubject
    {
        public Subject(Action action) : this(new RelayObserver(action))
        {

        }
        public Subject(List<IObserver> observers)
        {
            Observers = observers;
        }
        public  Subject(IObserver singleObserver)
        {
            Observers = new List<IObserver> { singleObserver };
        }
        public IEnumerable<IObserver> Observers { get; }

        public bool Equals(ISubject other)
        {
            if(other==null)
                return false;
            return Observers.SequenceEqual(other.Observers);
        }

        public void Notify()
        {
            foreach (var item in Observers)
            {
                item.Update();
            }
        }

        public ISubject Remove(ISubject other)
        {
            List<IObserver> observers = Observers.ToList();
            foreach (var item in other.Observers)
            {
                observers.Remove(item);
            }
            return observers.Any() ? new Subject(observers) : null;
        }
    }
}
