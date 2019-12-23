using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farasat
{
    class ArrayClass
    {
        public static void ArrayMain()
        {
            try
            {
                //Array.ArrayPractice();

                //Array List has properties of array as well as list, means you can run the index on it unlike list.. as well as any type of values can be stored in it unlike arrays
                //In this you can add abd delete values unlike arrays and like lists... also you can read any value in single clock cycle like arrays and unlike lists.
                //But it has Overhead of type casting

                ArrayList arrList = new ArrayList();
                arrList.Add("dasds");
                arrList.Add(1);
                arrList.Add(3.4);

                //Overhead of type casting
                string obj = arrList[0].ToString();
                int iV = (int)arrList[1];
                double d = (double)arrList[2];

                //Templated List
                //Array List has properties of array as well as list, means you can run the index on it unlike list.. but it can only store that type of values which is defined in the creation of list
                //In this you can add abd delete values unlike arrays and like lists... also you can read any value in single clock cycle like arrays and unlike lists.
                //It has No Overhead of type casting

                List<int> list = new List<int>();
                list.Add(1);
                list.Add(2);
                list.Add(2);
                list.Add(2);
                list.Add(2);
                list.Add(3);

                list.Any(v => v == 5); //Linq
                list.Contains(5); //List
                list.Exists(v => v == 5); //List

                //Select returns copy of list
                List<int> l1 = list.Select(v => v).ToList();
                l1.Add(4);

                // Its a copy of reference of list thats why original list will be changed
                List<int> l2 = list;
                l2.Add(10);

                //If you have List objects then you can select any property just like you can select any column in database
                List<Vitz2005> vitzCars = new List<Vitz2005>();
                vitzCars.Add(new Vitz2005());
                vitzCars.Add(new Vitz2005());
                vitzCars.Add(new Vitz2005());

                vitzCars.Any(v => v.engine == "dasdasd"); //Linq
                vitzCars.Contains(new Vitz2005()); //List
                vitzCars.Exists(v => v.engine == "dadadad"); //List

                //select model from vitzCars
                List<string> selectedCars = vitzCars.Select(v => v.model).ToList();

                Vitz2005[] arr = vitzCars.ToArray();

                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list[i]);
                }

                Console.WriteLine("****************************");

                //Its a wrapper of for loop
                //list[i]
                foreach (int val in list)
                {
                    Console.WriteLine(val);
                }

                List<int> tempList = list.Where(val => val == 2).ToList();

                //First Value when this condition is true
                int first = list.First(val => val == 2);

                //Last Value when this condition is true
                int last = list.Last(val => val == 2);

                //Single Value when this condition is true
                int single = list.Single(val => val == 3);

                List<string> strList = new List<string>();
                strList.Add(null);
                strList.Add("asa");

                string def = strList.FirstOrDefault(s => s == "aamir");

                int iDef = list.FirstOrDefault(i => i == 5);

                //Its a wrapper of foreach loop (lambda notation used only in linq)
                list.ForEach(val => Console.WriteLine(val));

                if (list.Exists(val => val == 2 && val < 4))
                    Console.WriteLine("2 Exists");

                var tempL = list.Find(val => val == 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}