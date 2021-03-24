using System;

namespace DelegateDemystification
{
    class Relay : SingleNotifySubject
    {
        class RelayObserver : IObserver
        {
            public override bool Equals(object obj)
            {
                var o = obj as RelayObserver;
                if (o != null)
                {
                    return action.Equals(o.action);
                }
                return false;
            }
            Action action;
            public RelayObserver(Action action)
            {
                this.action = action;
            }

            public void Update()
            {
                action.Invoke();
            }

            public override int GetHashCode()
            {
                return action.GetHashCode();
            }
        }
        public Relay(Action action) : base(new RelayObserver(action)){ }
    }

}
