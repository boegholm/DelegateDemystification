using System.Collections.Generic;
using System.Linq;

namespace DelegateDemystification
{
    class SingleNotifySubject : ISubject
    {
        IObserver singleObserver;

        public IEnumerable<IObserver> Observers { 
            get {
                yield return singleObserver;
            } 
        }

        public SingleNotifySubject(IObserver obs)
        {
            singleObserver = obs;
        }
        public static ISubject Combine(ISubject first, ISubject second)
        {
            return new MultiNotifySubject(first.Observers.Concat(second.Observers).ToList());
        }
        public static ISubject Remove(ISubject first, SingleNotifySubject second)
        {
            bool skipped = false;
            List<IObserver> observers = new List<IObserver>();
            foreach (var item in first.Observers)
            {
                if (!skipped && item.Equals(second.singleObserver))
                {
                    skipped = true;
                }
                else
                {
                    observers.Add(item);
                }
            }
            if (observers.Count == 0)
                return null;
            if (observers.Count == 1)
                return new SingleNotifySubject(observers[0]);
            return new MultiNotifySubject(observers);                
        }

        public void Notify()
        {
            singleObserver.Update();
        }
    }

}
