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

        public static void xMain()
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

            p1 += 2; /*equals*/ p1 = p1 + 2;
            p1 -= 4; /*equals*/ p1 = p1 - 4;

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

            //BioData objBioData1 = new BioData();//Default Constructor
            //BioData objBioData2 = new BioData(30);//Overloaded Constructor

            BioData farasatBioData = new BioData()
            {
                FirstName = "Farasat",
                LastName = "Hussain",
                Age = 21,
                Address = "Austria",
                Gender = "Male",
                Profession = "Student"
            };

            BioData farasatBioDataCopy = new BioData(farasatBioData);

            BioData objBioData3 = new BioData();

            //Static property
            BioData.FathersName = "Donald";

            //Non-static properties
            BioData b1 = new BioData(); b1.FirstName = "noman"; b1.LastName = "Aqeel";
            BioData.GetFullName(b1.FirstName, b1.LastName);
            BioData b2 = new BioData(); b2.FirstName = "aamir"; b2.LastName = "akhtar";
            BioData.GetFullName(b2.FirstName, b2.LastName);
            BioData b3 = new BioData(); b3.FirstName = "farast"; b3.LastName = "hussain";
            BioData.GetFullName(b3.FirstName, b3.LastName);

            b1.GetBio();

            BioData.PrintFathersName();

            Console.ReadLine();
        }

        //Static Default Constructor
        //Non-Static Default Consutructor
        //Overloaded Constructor
        //Copy Constructor
        //Note: No constructor returns value, no return type

        //When we only need single object
        public static class Watsapp
        {
            public static string SendMsg(string msg)
            {
                return "sent";
            }

            public static WatsappUser RegisterUser(string number)
            {
                return new WatsappUser();
            }

            public static void StartVideoCall(string number)
            {
                Console.WriteLine("Video Cal Started");
            }

            public static void StartVoiceCall(string number)
            {
                Console.WriteLine("Voice Call Started");
            }
        }

        public static class DAL
        {
            //CRUD operations (create, read, update, delete)
            public static Product GetProduct(int id)
            {
                //Got the data from databse and return
                return new Product();
            }

            public static void InsertProduct(Product product)
            {
                //Insert product into Product table in db and return nothing
            }

            public static void UpdateProduct(Product product)
            {
                //Update the product in DB and return nothing
            }

            public static void DeleteProduct(int id)
            {
            }
        }

        public class BioData : BioDataBase
        {
            static BioData() //Static default constructor and it has to be public
            {
                Console.WriteLine("Static Default Constructor");
            }

            public BioData() //Non-static Default constructor
            {
                Console.WriteLine("Non-Static Default Constructor");
            }

            public BioData(int age)//Overloaded constructor
            {
                this.Age = age;
                Console.WriteLine("Overloaded Constructor");
            }

            public BioData(BioData bioData) //Copy Constructor
            {
                this.FirstName = bioData.FirstName;
                this.LastName = bioData.LastName;
                this.Age = bioData.Age;
                this.Address = bioData.Address;
                this.Profession = bioData.Profession;
                this.Gender = bioData.Gender;
                Console.WriteLine("Copy Constructor");
            }

            public static string FathersName { get; set; } //Shared, in memory it has only one address shared among all objects of class BioData

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
            public string Profession { get; set; }
            public string Gender { get; set; }

            public static string GetFullName(string fName, string lName) // Non-Static
            {
                return fName + " " + lName;
            }

            public static void PrintFathersName()// Static function cannot use non-static properties and variables
            {
                Console.WriteLine(FathersName);
            }

            //Non-Static can use both static and non-static variables and members bcz non static is object dependent and all objects know the address of shared or static member but shared or static memeber doesnt know the addresses of all the objects
            public string GetBio()
            {
                return FirstName + FathersName;
            }

            public int Addition(int a, int b)
            {
                return a + b;
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

    public class BioDataBase
    {
        static BioDataBase()
        {
            Console.WriteLine("Parent Static Constructor");
        }

        public BioDataBase()
        {
            Console.WriteLine("Parent Default Constructor");
        }
    }

    public class Product
    {
    }

    public class WatsappUser
    {
        public string Number { get; set; }
        public string Status { get; set; }
        public string NickName { get; set; }
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
