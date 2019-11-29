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
            bool b1 = true;
            char c = 'a';
            char c1 = 'b';

            //Reference Type:-
            //Address to the object     //Object
            Vitz1999Standard vitz = new Vitz1999Standard();
            Console.WriteLine(vitz.dimensions);
            Console.WriteLine(vitz.engine);
            
            //All references crate on heap
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
            Console.WriteLine("Hello world");
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
