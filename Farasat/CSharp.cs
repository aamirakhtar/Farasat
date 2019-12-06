using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farasat
{
    class CSharp
    {
        //Pascal Casing Title Case.. which is used in method names, property names, class namespace names.
        public void GetName()
        {
            //Camel Casing which is used in variable names. first word's first letter is small, all other word's first letters are in upper case.
            string myFirstName = "Farasat";
        }

        public static void Main()
        {
            #region Type System (Value Types/Reference Types, Memory Allocation of value types and ref types, Methods,Type Casting
            //Value types:- all those types which are primitive types or system generated types.
            //1-All structs
            //2-Value types creates on Stack in memory(RAM)
            //3-Example all those types which are not human made.
            //4-It hold the values only.
            uint ui = 10;
            int i = 0; // Int32
            short s = 1; //Int16
            long l = 10; //Int64
            byte b = 1;
            double d = 1.6;
            float f = 1.34f;
            bool b_bool = true;
            char c = 'a';
            char c1 = 'b';

            //Reference Type:-
            //Address to the object     //Object
            Vitz1999Standard vitz = new Vitz1999Standard();
            Console.WriteLine(vitz.dimensions);
            Console.WriteLine(vitz.engine);

            //All references create on heap
            //User defined Types/Classes

            string str = "1dkashdkash1.45true";

            Vegitable v = GiveMeVegitable(100, new Bike());
            int subResult = Subtract(1, 2);

            //Type Casting
            int result = (int)(3.5 - 1.2);//Explicit type casting
            double dResult = 5 - 2;//Implicit Type Casting
            float fResult = 1.5f - 1;//Implicit Type Casting
            int iResult = (int)(1.5f - (float)3.2d);//Explicit type casting

            #endregion

            // Copy by Value (Value Type)
            int x = 10;
            int y = x;
            y = 12;
            Console.WriteLine($"{x}, {y}");// 10,12

            // Copy by Reference (Reference Type)
            //200       //100
            A obj1 = new A() { a = 10 };
            //300  = //200
            A obj2 = obj1;

            obj2.a = 12;
            Console.WriteLine($"{obj1.a}, {obj2.a}");//12,12

            Console.WriteLine("Hello world");

            //Arithmatic Operations:-
            //pre-fix
            int p1 = 0;
            // ++ == increment by one, => x=x+1, x+=1
            Console.WriteLine(++p1); // p1=1, print(1)

            Console.WriteLine(p1++); // p1=2, print(1)

            p1 = 0;
            int val = p1++ + ++p1;

            p1 += 2; p1 = p1 + 2;
            p1 -= 4; p1 = p1 - 4;

            --p1;
            p1--;

            //Concatination
            Console.WriteLine("aamir" + "akhtar");

            //Reference type casting
            C objC1 = new C();
            P objB1 = (P)objC1; // Valid bcz Child can be type casted to parent but not vice versa

            P objB2 = new P();
            //C objC2 = (C)objB2; //Invalid bcz Parent cannot be type casted to child

            //String Formatting
            //1-Parameterized
            Console.WriteLine("x={0}, y={1}", x, y);
            //2-Dollar
            Console.WriteLine($"x={x}, y={y}");

            Console.WriteLine("**aamir\nakhtar**");
            Console.WriteLine("**aamir\takhtar**");

            //Static property
            BioData.Name = "Donald";

            //Non-static properties
            BioData b1 = new BioData(); b1.FathersName = "noman";
            BioData b2 = new BioData(); b2.FathersName = "akhtar";
            BioData b3 = new BioData(); b3.FathersName = "hussain";

            b1.GetBio();

            BioData.GetFullName();

            Console.ReadLine();
        }

        public class BioData
        {
            public static string Name { get; set; } //Shared, in memory it has only one address shared among all objects of class BioData
            public string FathersName { get; set; } //Non-Static property

            public static string GetFullName()// Static function cannot use non-static properties and variables
            {
                return Name;
            }

            //Non-Static can use both static and non-static variables and members bcz non static is object dependent and all objects know the address of shared or static member but shared or static memeber doesnt know the addresses of all the objects
            public string GetBio()
            {
                return Name + FathersName;
            }
        }

        public class A
        {
            public int a { get; set; }
        }

        public class P
        {
            public int x { get; set; }
        }

        public class C : P
        {
            public int y { get; set; }
        }

        // () empty parameters, parameters, whats provided to function
        // Here void is return type: whats returning by the function
        public void PrintMyName()
        {
            Console.WriteLine("Farasat");
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        public float Subtract(float a, float b)
        {
            return a - b;
        }

        public static Vegitable GiveMeVegitable(float amount, Bike bike)
        {
            return new Vegitable();
        }

        public Vegitable GiveMeVegitable(float amount, Bike bike, ShoppingBag bag)
        {
            return new Vegitable();
        }
    }

    public class ShoppingBag
    {
    }

    public class Vegitable
    {
    }

    public class Bike
    {
    }
}
