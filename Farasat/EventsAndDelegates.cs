using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Farasat.EventsAndDelegates
{
    /*
     * Function Reference or Function Pointer
     * Loosely coupled: minimum dependencies.
     * Tightly coupled: when there are many dependencies
     * For loosely coupled applications events and delegates are used
     */

    //public delegate int Func(int a, int b);
    //This is a website
    public class EntryPoint
    {
        //public void ShowNumbers(int n)
        //{
        //    for (int i = 0; i < n; i++)
        //        Console.WriteLine(i);
        //}

        //Subscriber 1
        public static void Print(int counter)
        {
            Console.WriteLine(counter);
        }

        //Subscriber 2
        public static void PrintName(int counter)
        {
            Console.WriteLine("Aamir {0}", counter);
        }

        //Subscriber 3
        public static void PrintPhoneNumber(int counter)
        {
            Console.WriteLine("03212534148-{0}", counter);
        }

        public static void EventsMain()
        {
            //Multicast Delegate example
            //EventPractice obj = new EventPractice();
            //obj.funcDel = Print;
            //obj.funcDel += PrintName;
            //obj.funcDel += PrintPhoneNumber;

            //obj.funcDel -= PrintPhoneNumber;//un-subscribe

            ////Multicast delegate can be modified thats why its not publisher subscriber model. 
            ////But in case of events you cannot modfy the subscription list thats why its a publisher subscriber model.
            //obj.funcDel = null;

            //obj.ShowNumbersViaDelegate();

            ////Events
            //EventPractice obj1 = new EventPractice();
            //obj1.OnPrint += Print;
            //obj1.OnPrint += PrintName;
            ////obj1.OnPrint = null;
            //obj1.OnPrint += PrintPhoneNumber;

            //obj1.ShowNumbersViaEvent();

            //With Multcast Delegate
            FileProcess fp1 = new FileProcess();
            fp1.funcDel = SendEmailNotification;
            fp1.funcDel += SendSmsNotification;
            fp1.funcDel = null; //The only diff b/w events and delegates is delegates can be modified like here we assign null, but events cannot be modified
            fp1.funcDel += SendWatsappNotification;

            fp1.ProcessWithDelegate("file2.txt");

            //With Event, Event is the encapsulation of Delegate which implements publisher subscriber model. Means a client can subscribe or unsubscribe to publisher but cannot modify publisher. Means they can only listen but cannot modify broadcaster.
            FileProcess fp = new FileProcess();
            fp.OnFileProcessed += SendEmailNotification;
            fp.OnFileProcessed += SendSmsNotification;
            //fp.OnFileProcessed = null; //Here event cannot be modified as you see "=" sign is not allowed but += and -= is allowed
            fp.OnFileProcessed += SendWatsappNotification;

            fp.Process("file1.txt");

            Console.ReadLine();
        }

        public static void SendEmailNotification(string fileName)
        {
            Console.WriteLine("Email sent, processed file name: {0}", fileName);
        }

        public static void SendSmsNotification(string fileName)
        {
            Console.WriteLine("Sms sent, processed file name: {0}", fileName);
        }

        public static void SendWatsappNotification(string fileName)
        {
            Console.WriteLine("Watsapp msg sent, processed file name: {0}", fileName);
        }
    }


    //Lets suppose this is different project named: FileProcessing
    public class FileProcess
    {
        public delegate void SendNotification(string fileName);

        public event SendNotification OnFileProcessed;

        public SendNotification funcDel;

        public void Process(string fileName)
        {
            Console.WriteLine("File Processing Starts...");
            Thread.Sleep(2000);
            //Some file processing
            Console.WriteLine("File Processing Completed.");

            //Sending Notifications
            if (OnFileProcessed != null)
                OnFileProcessed(fileName);

            //Tight coupling, when you are calling the function after file processing
            //SendEmailNotification()
            //SendSmsNotification()
            //SendWatsappNotification()
            //SendFacebookNotification()
        }

        public void ProcessWithDelegate(string fileName)
        {
            Console.WriteLine("File Processing Starts...");
            Thread.Sleep(2000);
            //Some file processing
            Console.WriteLine("File Processing Completed.");

            //Sending Notifications via delegate
            funcDel(fileName);
        }
    }

    public class EventPractice
    {
        //Publisher
        public delegate void PrintNum(int n);

        public event PrintNum OnPrint; //event

        public PrintNum funcDel; //multicast delegate

        public void ShowNumbersViaDelegate()
        {
            for (int i = 0; i < 10; i++)
                if (funcDel != null)
                    funcDel(i + 1);
        }        

        public void ShowNumbersViaEvent()
        {
            for (int i = 0; i < 10; i++)
                if (OnPrint != null)
                    OnPrint(i + 1);
        }
    }

    /* eg 1: After processing we can send notifications, and multiple functions can subscribe the list.. like email notification, sms notification, watsapp notification can be sent
     * eg 2: File can be compressed by multiple compression functions which are the subscribers of file class.
     * eg 3: Book can be translated in multiple languages.. class Book expose event OnTranslate... you can subscribe multiple functions to translate in languages
     * eg 4: 
     */
}
