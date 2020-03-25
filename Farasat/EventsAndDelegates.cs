using System;
using System.Collections.Generic;
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
            FileProcess fp = new FileProcess();

            fp.OnFileProcessed += SendEmailNotification;
            fp.OnFileProcessed += SendEmailNotification;
            fp.OnFileProcessed += SendSmsNotification;

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

        public void Process(string fileName)
        {
            Console.WriteLine("File Processing Starts...");
            Thread.Sleep(2000);
            //Some file processing
            Console.WriteLine("File Processing Completed.");

            //Sending Notifications
            if (this.OnFileProcessed != null)
                OnFileProcessed(fileName);
        }
    }
}
