using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Farasat.Multithreading
{
    class A : Array
    {
        public A()
        {
            this.MyProperty = 4;
        }
    }

    class EntryPoint
    {
        static object lockObj = new object();

        static int count = 0;

        static int counter1 = 0;
        static int counter2 = 0;
        //static int counter3 = 0;

        public static string GetHash(string password)
        {
            //Get the hash of entered password
            var data = Encoding.ASCII.GetBytes(password);

            var sha1 = new SHA1CryptoServiceProvider();
            var sha1Data = sha1.ComputeHash(data);

            ASCIIEncoding obj = new ASCIIEncoding();
            var hashedPassword = obj.GetString(sha1Data);

            return hashedPassword;
        }

        public static bool Authenticate(string enteredPassword, string savedPassword)
        {
            //Get the hash of entered password
            string enteredHashedPassword = GetHash(enteredPassword);

            //Get the hash of saved password

            string savedHashedPassword = GetHash(savedPassword);

            return enteredHashedPassword == savedHashedPassword;
        }

        public static void Main() //calling thread
        {
            AsymmetricEncryptionDecryption.RSA();

            bool isMatched = Authenticate("aamir", "aamir");

            #region Time Sharing and Join
            /*
            Console.WriteLine("Main thread is started");

            Thread t1 = new Thread(func1);
            Thread t2 = new Thread(func2);
            Thread t3 = new Thread(func3);

            t1.Start(70); //assume its checking out payment from paypal
            t2.Start(70); //assume its writing in file
            t3.Start(70); //assume its writing in database

            //Join method will make the calling method wait to completed the joined thread
            //Means main thread will wait untill the t1 thread will exit, and then Main thread will exit.
            t1.Join();

            Console.WriteLine("Email sent to user after checkout");

            Console.WriteLine("Main thread is exiting");
            */
            #endregion

            #region Locking
            /*
            Thread th1 = new Thread(WritingToResource);
            Thread th2 = new Thread(WritingToResource);
            Thread th3 = new Thread(WritingToResource);

            //th1.Start();
            //th2.Start();
            //th3.Start();

            //WritingToResource();
            //WritingToResource();
            //WritingToResource();

            th1 = new Thread(IncrementCount);
            th2 = new Thread(IncrementCount);
            th3 = new Thread(IncrementCount);

            th1.Start();
            th2.Start();
            th3.Start();

            //Main has to wait for thee 3 threads to complete their execution, because we want to print final value of count
            th1.Join();
            th2.Join();
            th3.Join();

            Console.WriteLine(count);
            */
            #endregion

            #region Thread Priority
            /*
            Thread thread1 = new Thread(ExecuteLightJob);
            Thread thread2 = new Thread(ExecuteHeavyJob);

            thread1.Priority = ThreadPriority.Lowest;
            thread2.Priority = ThreadPriority.Highest;

            thread1.Start();
            thread2.Start();

            Thread.Sleep(3000);

            thread1.Abort();
            thread2.Abort();

            thread1.Join();
            thread2.Join();

            Console.WriteLine(counter1);
            Console.WriteLine(counter2);
            */
            #endregion

            #region Thread Performance Calculation

            AA v = null;
            aa(v);

            Stopwatch watch = new Stopwatch();
            watch.Start();

            ExecuteJobForPerformanceCounter();
            ExecuteJobForPerformanceCounter();
            ExecuteJobForPerformanceCounter();

            watch.Stop();

            Console.WriteLine("Time Taken by sequential run: {0}", watch.ElapsedMilliseconds);


            Thread pt1 = new Thread(ExecuteJobForPerformanceCounter);
            Thread pt2 = new Thread(ExecuteJobForPerformanceCounter);
            Thread pt3 = new Thread(ExecuteJobForPerformanceCounter);

            Stopwatch tWatch = new Stopwatch();
            tWatch.Start();

            pt1.Start();
            pt2.Start();
            pt3.Start();

            tWatch.Stop();

            pt1.Join();
            pt2.Join();
            pt3.Join();

            Console.WriteLine("Time Taken by multithreading run: {0}", tWatch.ElapsedMilliseconds);

            #endregion

            Console.ReadLine();

            #region Anonymous function calling through delegate
            //Its a current thread which is by default main thread
            //Thread.CurrentThread.Name = "Main thread";
            //Console.WriteLine(Thread.CurrentThread.Name);

            //Anonymous functions
            //ParameterizedThreadStart th1 = (object num) => 
            //{
            //    int n = (int)num;
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine("func1: {0}", i);
            //    }
            //};
            #endregion
        }

        public static void aa(AA lst)
        {
            lst = new AA();
            lst.MyProperty = 2;
        }

        public static void func1(object num)
        {
            int n = (int)num;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("func1: {0}", i);
            }
        }

        public static void func2(object num)
        {
            int n = (int)num;
            for (int i = 0; i < n; i++)
            {

                if (i == 50)
                {
                    Console.WriteLine("Thread 2 is going to sleep");
                    Thread.Sleep(3000);//Lets assume its a database call and database server is down so its waiting to be up
                    Console.WriteLine("Thread 2 is awake");
                }

                Console.WriteLine("func2: {0}", i);
            }
        }

        public static void func3(object num)
        {
            int n = (int)num;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("func3: {0}", i);
            }
        }

        public static void WritingToResource()
        {
            lock (lockObj)
            {
                Console.Write("[Farasat is a");
                Thread.Sleep(2000);
                Console.WriteLine(" good boy]");
            }
        }

        public static void IncrementCount()
        {
            lock (lockObj)
            {
                for (int i = 0; i < 100000; i++)
                    count++;
            }
        }

        public static void ExecuteLightJob()
        {
            //Assume its writing to db
            while (true)
            {
                counter1++;
            }
        }

        public static void ExecuteHeavyJob()
        {
            //Assume its writing in file and its a heavy job, so require more CPUU resources than database writing
            while (true)
            {
                counter2++;
            }
        }

        public static void ExecuteJobForPerformanceCounter()
        {
            int count = 0;

            for (int i = 0; i < 100000000; i++)
            {
                count++;
            }

            Console.WriteLine(count++);
        }
    }

    class AA
    {
        public int MyProperty { get; set; }
    }

    public class AsymmetricEncryptionDecryption
    {
        public static void RSA()
        {
            var rsa = new RSACryptoServiceProvider();
            string privateKey = rsa.ToXmlString(true);
            string publicKey = rsa.ToXmlString(false);

            var text = "test1";

            Console.WriteLine("Text to encrypt: " + text);
            var enc = Encrypt(text, publicKey);

            var dec = Decrypt(enc, privateKey);
            Console.WriteLine("Decrypted Text: " + dec);
        }

        public static string Encrypt(string data, string publicKey)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);

            var dataBytes = Encoding.UTF8.GetBytes(data);

            var encryptedBytes = rsa.Encrypt(dataBytes, false);

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string data, string privateKey)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);

            var dataBytes = Convert.FromBase64String(data);            

            var decryptedBytes = rsa.Decrypt(dataBytes, false);

            return Encoding.ASCII.GetString(decryptedBytes);
        }
    }
}
