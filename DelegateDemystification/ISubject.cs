using System;
using System.Collections.Generic;

namespace DelegateDemystification
{
    interface ISubject
    {
        void Notify();
        IEnumerable<IObserver> Observers { get; }
        public static ISubject operator +(ISubject one, Action other) => one==null? new Relay(other) : one+new Relay(other);
        public static ISubject operator +(ISubject one, ISubject other) => SingleNotifySubject.Combine(one, other);
        public static ISubject operator -(ISubject one, Action other) => one == null ? new Relay(other) : one - new Relay(other);
        public static ISubject operator -(ISubject one, SingleNotifySubject other) => SingleNotifySubject.Remove(one, other);
    }
}
