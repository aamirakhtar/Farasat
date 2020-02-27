using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farasat.Semester2
{
    public class EntryPoint
    {
        public static void Main()
        {
            Book book = new Book();
            book.Contents = "Computer Science Contents";
            book.Price = 500;
            book.Author = "Farasat";

            BookTranport bookTranport = new BookTranport();
            bookTranport.Departure(book);
            bookTranport.Delivery(book);
            bookTranport.ProofOfDelivery(book);

            MobilePhone mobile = new MobilePhone();
            mobile.Brand = "Samsung";
            mobile.ModelNum = "Note10";
            mobile.Price = 1200;
            mobile.Made = "US";

            MobilePhoneTranport mobilePhoneTranport = new MobilePhoneTranport();
            mobilePhoneTranport.Departure(mobile);
            mobilePhoneTranport.Delivery(mobile);
            mobilePhoneTranport.ProofOfDelivery(mobile);

            //Object Transport
            //Though it can transport any type of object but in this case there is type casting overhead
            ObjectTransport objectTransport = new ObjectTransport();
            objectTransport.Departure(book);
            objectTransport.Delivery(book);
            objectTransport.ProofOfDelivery(book);

            //Template
            //It can transport any type of object and in this case there is no type casting overhead
            Transport<Book> bookTransp = new Transport<Book>();
            bookTransp.Departure(book);
            bookTransp.Delivery(book);
            bookTransp.ProofOfDelivery(book);

            Transport<MobilePhone> mobileTransp = new Transport<MobilePhone>();
            mobileTransp.Departure(mobile);
            mobileTransp.Delivery(mobile);
            mobileTransp.ProofOfDelivery(mobile);

            //
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(3123);
            list.Add(45);

            List<int> intList = new List<int>();
            intList.Add(1);
            intList.Add(3123);
            intList.Add(45);

            Console.ReadLine();
        }
    }

    public class Book
    {
        public string Contents { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
    }

    public class MobilePhone
    {
        public double Price { get; set; }
        public string Brand { get; set; }
        public string ModelNum { get; set; }
        public string Made { get; set; }
    }

    public class BookTranport
    {
        public void Departure(Book book)
        {
            Console.WriteLine("Normal Book Departure");
        }

        public void Delivery(Book book)
        {
            Console.WriteLine("Normal Book Delivery");
        }

        public void ProofOfDelivery(Book book)
        {
            Console.WriteLine("Normal Book Proof Of Delivery");
        }
    }

    public class MobilePhoneTranport
    {
        public void Departure(MobilePhone mobile)
        {
            Console.WriteLine("Normal Mobile Departure");
        }

        public void Delivery(MobilePhone mobile)
        {
            Console.WriteLine("Normal Mobile Delivery");
        }

        public void ProofOfDelivery(MobilePhone mobile)
        {
            Console.WriteLine("Normal Mobile Proof Of Delivery");
        }
    }

    public class ObjectTransport
    {
        public void Departure(object product)
        {
            Console.WriteLine("Ojbect {0} Departure", typeof(object).Name);
        }

        public void Delivery(object product)
        {
            Console.WriteLine("Ojbect {0} Departure", typeof(object).Name);
        }

        public void ProofOfDelivery(object product)
        {
            Console.WriteLine("Ojbect {0} Proof Of Delivery", typeof(object).Name);
        }
    }

    //Templated Class / Generic Class
    public class Transport<T>
    {
        public void Departure(T product)
        {
            Console.WriteLine("Templated {0} Departure", typeof(T).Name);
        }

        public void Delivery(T product)
        {
            Console.WriteLine("Templated {0} Departure", typeof(T).Name);
        }

        public void ProofOfDelivery(T product)
        {
            Console.WriteLine("Templated {0} Proof Of Delivery", typeof(T).Name);
        }
    }

    //public class Utility
    //{
    //    public double CalculateBookPrice(Book book)
    //    {
    //        return book.Price - 5;
    //    }

    //    public double CalculateMobilePrice(MobilePhone mobile)
    //    {
    //        return mobile.Price - 5;
    //    }

    //    public double CalculateObjectPrice(object book)
    //}
}
