using System;

namespace ConsoleApp23
{
    class Program
    {
        static ISubject subjectone;

        static void Bar()=> Console.WriteLine("bar");
        static void Foo()=> Console.WriteLine("foo");
        static void Main(string[] args)
        {
            subjectone += Foo;

            var othersubject = subjectone;

            othersubject += Bar;
            othersubject -= Bar;

            subjectone.Notify();
            Console.WriteLine("------");
            othersubject.Notify();
        }
    }
}
