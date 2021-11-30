using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegateDemystification
{
    public partial interface ISubject
    {
        public bool Equals(ISubject other) => 
            ReferenceEquals(this, other) || 
            Observers.SequenceEqual(other.Observers);
        static ISubject operator +(ISubject a, ISubject b) => (a, b) switch
        {
            (null, null) => null,
            (null, _) => b,
            (_, null) => a,
            _ => new Subject(a.Observers.Concat(b.Observers).ToList())
        };

        static ISubject operator -(ISubject s, Action a) => a == null ? s : s - new Subject(a);
        static ISubject operator -(ISubject a, ISubject b) => (a, b) switch
        {
            (null, _) => b,
            (_, null) => a,
            _ => a.Remove(b)
        };
        private ISubject Remove(ISubject other)
        {
            List<IObserver> observers = Observers.ToList();
            foreach (var item in other.Observers)
            {
                observers.Remove(item);
            }
            return observers.Any() ? new Subject(observers) : null;
        }
        static ISubject operator +(ISubject s, Action a) => s == null ? new Subject(a) : s + new Subject(a);
    }
}
