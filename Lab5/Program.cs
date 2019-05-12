using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class A
    {
        protected int a = 1;
        protected int b = -5;

        public int c
        {
            get { if ((a > 0) && (b > 0)) return (a + b) / 2; else return (a * b); }
            set { a = value; b = value; }
        }

        public A()
        {
            a = 4;
            b = 4;
        }

        public A(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
    }

    class B: A
    {
        protected int d;
        public int c2
        {
            get { return a * b / d; }
            set { a = value; b = value; d = value; }
        }

        public B()
        {
            a = 1;
            b = -9;
            d = 5;
        }

        public B(int a, int b, int d): base(a,b)
        {
            this.d = d;
        }

       
    }
    class Program
    {
        static void Main(string[] args)
        {
            A myObject = new A();
            A myObject1 = new A(5, 3);

            B myObject2 = new B();
            B myObject3 = new B(-4, -5, 2);

            Console.WriteLine("Result c from A() = " + myObject.c);
            Console.WriteLine("Result c from A(567, 34) = " + myObject1.c);
            Console.WriteLine("Result c from B() = " + myObject2.c);
            Console.WriteLine("Result c from B(-454, -544, 20) = " + myObject3.c);

            Console.ReadKey();
        }
    }
}
