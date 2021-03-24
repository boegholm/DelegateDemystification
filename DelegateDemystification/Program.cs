using System;

namespace DelegateDemystification
{
    class Program
    {
        static ISubject subjectone;

        static void Bar()=> Console.WriteLine("bar");
        static void Foo()=> Console.WriteLine("foo");
        static void Main(string[] args)
        {
            Console.WriteLine(subjectone == null);
            subjectone += Foo;
            Console.WriteLine(subjectone == null);
            subjectone -= Foo;
            Console.WriteLine(subjectone == null);


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
        }
    }
}
