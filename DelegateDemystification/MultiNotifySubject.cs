using System.Collections.Generic;

namespace DelegateDemystification
{
    class MultiNotifySubject : ISubject
    {
        public MultiNotifySubject(IEnumerable<IObserver> observers)
        {
            foreach (var observer in observers)
            {
                this.observers.Add(observer);
            }
        }
        private List<IObserver> observers=new List<IObserver>();
        public IEnumerable<IObserver> Observers => observers;

        public void Notify()
        {
            foreach (var item in Observers)
            {
                item.Update();
            }
        }
    }

}
