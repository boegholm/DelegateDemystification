﻿using System;

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
        }
    }
}
