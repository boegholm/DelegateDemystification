using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegateDemystification
{

    public partial interface ISubject 
    {
        void Notify();
        IEnumerable<IObserver> Observers { get; }
    }
}
