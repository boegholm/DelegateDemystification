using System;

namespace DelegateDemystification
{
    class RelayObserver : IObserver
    {
        Action action;
        public RelayObserver(Action action)
        {
            this.action = action;
        }
        public override bool Equals(object obj) => (obj is RelayObserver r) && action.Equals(r.action);
        public void Update() => action.Invoke();
        public override int GetHashCode() => action.GetHashCode();
    }
}
