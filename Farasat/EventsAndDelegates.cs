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
     */

    //public delegate int Func(int a, int b);
    //This is a website
    public class EntryPoint
    {
        public static void Main()
        {
            //With Delegate
            FileProcess fp1 = new FileProcess();
            fp1.funcDel = SendEmailNotification;
            fp1.funcDel += SendSmsNotification;
            //fp1.funcDel = null; //The only diff b/w events and delegates is delegates can be modified like here we assign null, but events cannot be modified
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
}
