using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegateDemystification
{

    public interface ISubject
    {
        ISubject Remove(ISubject other);
        void Notify();
        IEnumerable<IObserver> Observers { get; }
        static ISubject operator +(ISubject one, ISubject other) => Combine(one, other);
        static ISubject Combine(ISubject first, ISubject second) => (first, second) switch
        {
            (null, null) => null,
            (null, _) => second,
            (_, null) => first,
            _ => new Subject(first.Observers.Concat(second.Observers).ToList())
        };

        static ISubject operator -(ISubject one, Action action) => action == null ? one : one - new Subject(action);
        static ISubject operator -(ISubject one, ISubject other) => (one, other) switch
        {
            (null, _) => other,
            (_, null) => one,
            _ => one.Remove(other)
        };
        static ISubject operator +(ISubject one, Action other) => one == null ? new Subject(other) : one + new Subject(other);
    }
}
