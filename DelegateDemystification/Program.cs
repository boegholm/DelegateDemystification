using System;
using System.Collections.Generic;

namespace DelegateDemystification
{

class Example
{
    void Run(ISubject subject)
    {
        subject?.Notify();
    }
}


    class Program
    {
        static ISubject subjectone;

        static void Bar()=> Console.WriteLine("bar");
        static void Foo()=> Console.WriteLine("foo");
        static void Main(string[] args)
        {
            // null-status
            Console.WriteLine(subjectone == null);
            subjectone += Foo;
            Console.WriteLine(subjectone == null);
            subjectone -= Foo;
            Console.WriteLine(subjectone == null);


            // null-status på kopier

            subjectone += Foo;
            var othersubject = subjectone;

            othersubject += Bar;
            Console.WriteLine("added bar");
            othersubject -= Bar;
            Console.WriteLine("removed bar");
            othersubject.Notify();
            Console.WriteLine("---");
            subjectone.Notify();
            Console.WriteLine("------");
            othersubject.Notify();

            void Foo() => Console.Write("Observer pattern");
            void Bar() { Console.Write("For fun"); }
            ISubject fun = null; //initialize before use :(
            fun += Foo;
            fun += () => Console.WriteLine(" with fancy syntax ");
            fun += Bar;
            fun += () => Console.WriteLine(" and profit...");
            fun.Notify();
            new RelayObserver(() => Console.WriteLine());
        }
    }
    class ClassicSubject : ISubject
    {
        public IEnumerable<IObserver> Observers { get; }

        public void Notify()
        {
            foreach (var item in Observers)
            {
                item.Update();
            }
        }
    }
    class WriteObserver : IObserver
    {
        string v;
        public WriteObserver(string v)
        {
            this.v = v;
        }
        public void Update()
        {
            Console.Write(v);
        }
    }
    class WriteLineObserver : IObserver
    {
        string v;
        public WriteLineObserver(string v)
        {
            this.v = v;
        }
        public void Update()
        {
            Console.WriteLine(v);
        }
    }

}
