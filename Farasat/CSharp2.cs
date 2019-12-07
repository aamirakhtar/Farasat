using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farasat
{
    class CSharp2
    {
        public static void Main()
        {
            Console.WriteLine((WeekDays)4);
            Console.WriteLine((int)WeekDays.Wednesday);

            string productName = ProductType.Bakery.ToString();
            int productId = (int)ProductType.Bakery;

            Console.WriteLine(productName);
            Console.WriteLine(productId);

            //     1
            //    123
            //   12345
            //  1234567
            // 123456789

            Console.WriteLine("**************************");
            //0(once)    //1   //3
            Get_N:
            int n = int.Parse(Console.ReadLine());
            int displacement = 4;

            //if (n % 2 == 0)
            //displacement = 5;

            int spaceCount = n - displacement;

            for (int i = 1; i <= n; i += 2)
            {
                //2

                //Spaces
                for (int k = 0; k < spaceCount; k++)
                {
                    Console.Write(" ");
                }

                //Counting
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }

                //Line Change
                Console.WriteLine();
                spaceCount--;
            }

            goto Get_N;

            int count = 0;
            while (count < 10)
            {
                Console.WriteLine($"{count + 1}-Farasat");
                count++;

                if (count >= 5)
                    break;
            }

            count = 0;
            while (count < 10)
            {
                Console.Write($"{count + 1}Farasat");
                count++;

                if (count == 2)
                {
                    Console.WriteLine();
                    continue;
                }

                Console.WriteLine(" Hussain");
            }



            Console.ReadLine();
        }
    }

    enum WeekDays
    {
        Sunday = 1,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    enum ProductType
    {
        Cosmetics = 1,
        HouseHolds,
        Clothing,
        Bakery,
        Stationary
    }
}
