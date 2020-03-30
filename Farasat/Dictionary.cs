using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Farasat.Dictionary
{
    class EntryPoint
    {
        public static void Main()
        {
            //Dictionary always for lookups.
            //When you supose to get the value associated to unique id
            //Key must be unique in case of dictionary

            Dictionary<int, string> students = new Dictionary<int, string>();

            students.Add(1, "Aamir");
            students.Add(2, "Farasat");
            students.Add(3, "Faizan");
            students.Add(4, "Faizan");
            students.Add(5, "Noman");

            foreach (KeyValuePair<int, string> kv in students)
            {
                Console.WriteLine("{0}: {1}", kv.Key, kv.Value);
            }

            List<KeyValuePair<int, string>> lst = students.Where(kv => kv.Value == "Faizan").ToList();

            lst.ForEach(kv => Console.WriteLine("{0}: {1}", kv.Key, kv.Value));

            bool isExists = students.ToList().Exists(kv => kv.Value == "Aamir");

            isExists = students.ContainsValue("Aamir");

            students.Remove(1);

            Console.ReadLine();
        }
    }
}
