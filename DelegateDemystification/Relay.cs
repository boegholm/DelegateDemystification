using System;

namespace ConsoleApp23
{
    class Relay : SingleNotifySubject
    {
        class RelayObserver : IObserver
        {
            Action action;
            public RelayObserver(Action action)
            {
                this.action = action;
            }

            public void Update()
            {
                action.Invoke();
            }
        }
        public Relay(Action action) : base(new RelayObserver(action)){ }
    }

}
