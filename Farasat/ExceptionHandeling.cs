using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farasat
{
    class ExceptionHandeling
    {
        public static void xMain()
        {
            AmazonPayment p = new AmazonPayment();
            p.CcNo = "4211111111";//Setter
            p.Amount = 500;//Setter

            //Function Call
            p.Pay("1002"); //Arguments: 400, "1002"
            p.Pay("1002", 400); //Arguments: 400, "1002"

            int paymentNo = 0;
            bool status = p.Pay("1002", 500, out paymentNo);
            Console.WriteLine(paymentNo);

            string paymentNum = "0";
            bool status1 = p.Pay("1002", 500, ref paymentNum);
            Console.WriteLine(paymentNum);

            //Params
            p.PrintNum(1, 2, 3, 4, 5, 6, 7, 10, 11, 2, 321, 4324, 4324, 4234, 4324, 432432, 2432, 4324, 234, 23423, 423, 432, 4);

            return;

            bool isPaymentSuccessfull = false;
            do
            {
                try
                {
                    Console.WriteLine("Enter CC No: ");
                    string ccNo = Console.ReadLine();

                    PaymentCheckout(500, ccNo, 100);
                    isPaymentSuccessfull = true;
                    DeliverGoods(100);
                }
                catch (NullReferenceException ex1)
                {

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Remove from the cart");
                }
            }
            while (!isPaymentSuccessfull);

            Console.ReadLine();
        }

        public static void PaymentCheckout(double amount, string ccNo, int orderNo)
        {
            try
            {
                Console.WriteLine("Here payment performs and amount is deducted from your account against orderNo");
                //Console.WriteLine("Payment Successfull");
                if (ccNo != "4211111111")
                    throw new Exception("Payment Failed");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeliverGoods(int orderNo)
        {
            Console.WriteLine("Deliver Goods Now");

            AmazonPayment p = new AmazonPayment();
            p.OrderNo = 213123;// setter
            Console.WriteLine(p.OrderNo); //Getter
        }
    }

    public class AmazonPayment
    {
        //Getter:- called when only read the value
        //Setter:- called when you set/change/assign/update the value

        public int OrderNo { get; set; }

        public string CcNo { get; set; }
        public double Amount { get; set; }

        //public string UserId
        //{
        //    get
        //    {
        //        return "1002";
        //    }
        //}

        public string UserId => "1002";

        //Function signature: public void Pay(int amount, string id)
        //Funtion Declaraation: public void Pay(int amount, string id)

        //Optional Parameter:-
        //Optional Parameter means like to overload the function
        public void Pay(string id, int amount = 100) /*Parameters*/
        {
            //Function Definition
        }

        //Out Parameter: which is used to return multiple values
        //It actually returns status which is bool also the payment No (copy by value)
        public bool Pay(string id, double amount, out int paymnetNo)
        {
            //Assume we have done payment here
            paymnetNo = 1000;
            return true;
        }

        //Ref Parameter: used to return multiple values(copy by reference)
        public bool Pay(string id, double amount, ref string paymentNo)
        {
            paymentNo = "1000";
            return true;
        }

        //Mulitiple Unlimited Parameters
        //public void PrintNum(int a, int b)
        //{
        //    Console.WriteLine($"{a},{b}");
        //}

        //public void PrintNum(int a, int b, int c)
        //{
        //    Console.WriteLine($"{a},{b},{c}");
        //}

        //public void PrintNum(int a, int b, int c, int d)
        //{
        //    Console.WriteLine($"{a},{b},{c},{d}");
        //}

        public void PrintNum(params int[] values)
        {
            Console.WriteLine(values.Length);

            A obj = new A("aamir");
            B obj1 = new B("aamir");
        }
    }

    public class A
    {
        public string name { get; set; }

        public A(string name)
        {
            this.name = name;
        }
    }

    public class B : A
    {
        public B(string name) : base(name)
        {
        }

        public void Print()
        {
            Console.WriteLine(name);
        }
    }
}