using System.Collections.Generic;

namespace DelegateDemystification
{
    class MultiNotifySubject : ISubject
    {
        public MultiNotifySubject(IEnumerable<IObserver> observers) 
        {
            Observers = new List<IObserver>(observers);
        }
        public IEnumerable<IObserver> Observers { get; }
        public void Notify()
        {
            foreach (var item in Observers)
            {
                item.Update();
            }
        }
    }
}
