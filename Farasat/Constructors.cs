using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farasat.Constructors
{
    public class Vitz
    {
        public string Engine { get; set; }
        public string Color { get; set; }

        public Vitz()
        {
            this.Engine = "1KR";
            this.Color = "Red";
        }

    }

    public struct Employee
    {
        public static string FirstName { get; set; }
        public string Department { get; set; }

        static Employee()
        {

        }


    }

    public class EntryPoint
    {
        public static void Main()
        {
            Employee st1;
            Employee st2;
            Employee st3;
            Employee st4;
            Vitz v;
            Vitz v1;
            Vitz v2;
            Vitz v3;
            //st1.Department = "IT";

            Employee.FirstName = "Farasat";
        }
    }
}
