using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farasat
{
    // Lets assume this class in un-editable
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
    }

    public static class EmpExtensions
    {
        public static double CalculateWorkingHours(this Employee emp)
        {
            return 10.5;
        }

        public static double ToDecimalPlaces(this string val, int decimalPlaces)
        {

            double value = 0;
            double.TryParse(val, out value);

            string format = "0.";
            for (int i = 0; i < decimalPlaces; i++)
            {
                format += "0";
            }

            return double.Parse(value.ToString(format));
        }
    }

    public class EntryPoint
    {
        public static void Main()
        {
            Employee emp = new Employee();
            Console.WriteLine(emp.CalculateWorkingHours());

            string amount = "45.323432432";
            double value = amount.ToDecimalPlaces(100);

            string a = "farasat";
            double v = a.ToDecimalPlaces(4);

            //Anaonymous Type
            var d = new { Name = "aamir", Age = 20, Salary = 4.5 };

            //Dynamic Type with Expando Object
            dynamic d1 = new System.Dynamic.ExpandoObject();
            d1.DepartmentId = 2;
            d1.Name = "aamir";

            d1.FathersName = "aakhtar";
        }
    }
}
