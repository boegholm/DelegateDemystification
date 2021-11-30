using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegateDemystification
{
    class Subject : ISubject
    {
        internal Subject(Action a) : this(new RelayObserver(a)){}
        internal Subject(IObserver o) : this(new List<IObserver> { o }) { }
        internal Subject(List<IObserver> observers)
        { 
            Observers = observers;
        }
        public IEnumerable<IObserver> Observers { get; }
        public bool Equals(ISubject other) => other != null && Observers.SequenceEqual(other.Observers);
        public void Notify()
        {
            foreach (var item in Observers)
                item.Update();
        }
    }
}
