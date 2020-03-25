using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Farasat.Serialization_Deserialization
{
    [Serializable]
    public class A
    {
        public string SomeString
        {
            get;
            set;
        }
        public int SomeValue
        {
            get;
            set;
        }
    }









    /// <summary>
    /// If Person class is available to change and we suppose to give our own serialization then we implement ISerializable interface
    /// If Person class is available to change and we suppose to give our own deserialization then we implement IDeserializationCallback interface
    /// If Person class is "not" available to change and we suppose to give our own serialization or deserialization then we provide surrogate class for original class
    /// </summary>

    //[Serializable]//Attribute
    //public class Person : ISerializable, IDeserializationCallback
    //{
    //    [NonSerialized]
    //    private string name;

    //    [XmlIgnore]
    //    public string Name
    //    {
    //        get
    //        {
    //            return name;
    //        }
    //        set
    //        {
    //            this.name = value;
    //        }
    //    }
    //    public DateTime Birthday
    //    {
    //        get;
    //        set;
    //    }

    //    public Person()
    //    {
    //    }

    //    public Person(SerializationInfo info, StreamingContext context)
    //    {
    //        //this.Birthday = info.GetDateTime("birthday");
    //        this.Name = info.GetString("name");
    //    }

    //    public void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        info.AddValue("name", this.Name);
    //        //info.AddValue("birthday", this.Birthday);
    //    }

    //    public void OnDeserialization(object sender)
    //    {
    //        this.Name = "farasat";
    //    }
    //}

    ///    /// This class is "not" available to change, its in dll for example and we just refer it to our project, and we suppose to give our own    /// serialization or deseriazation then we implement ISerializationSurrogate interface    ///    public class Person
    {
        public DateTime Birthday { get; set; }
        public string Name { get; set; }
    }    public class PersonSerializationSurrogate : ISerializationSurrogate
    {
        //Serialization
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            //info.AddValue("Name", ((Person)obj).Name);
            info.AddValue("Birthday", ((Person)obj).Birthday);
        }

        //De-Serialization
        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Person p = (Person)obj;
            p.Birthday = info.GetDateTime("Birthday");
            //p.Name = info.GetString("Name");
            return p;
        }
    }
    public class EntryPoint
    {
        public static void SerializationMain()
        {
            //1-BinaryFormatter
            //2-SoapFormatter
            //3-XmlSerializer

            //A myFirstA = new A() { SomeString = "abc", SomeValue = 123 };
            //A mySecondA;
            //using (FileStream fs = new FileStream("data.dat", FileMode.Create,
            //FileAccess.ReadWrite,
            //FileShare.None))
            //{
            //    IFormatter formatter = new BinaryFormatter();
            //    formatter.Serialize(fs, myFirstA);
            //    fs.Seek(0, SeekOrigin.Begin);
            //    mySecondA = (A)formatter.Deserialize(fs);
            //    fs.Close();
            //}


            //Person p1 = new Person();
            //Person p2;
            //p1.Birthday = DateTime.Now;
            //p1.Name = "SomeName";
            //using (FileStream fs = new FileStream("data_soap.dat", FileMode.Create,
            //FileAccess.ReadWrite,
            //FileShare.None))
            //{
            //    IFormatter formatter = new SoapFormatter();
            //    formatter.Serialize(fs, p1);
            //    fs.Seek(0, SeekOrigin.Begin);
            //    p2 = (Person)formatter.Deserialize(fs);
            //    fs.Close();
            //}

            //Person p5 = new Person();
            //Person p6;
            //p5.Birthday = DateTime.Now;
            //p5.Name = "SomeName";
            //using (FileStream fs = new FileStream("data_binary.dat", FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            //{
            //    IFormatter formatter = new BinaryFormatter();
            //    formatter.Serialize(fs, p5);
            //    fs.Seek(0, SeekOrigin.Begin);
            //    p6 = (Person)formatter.Deserialize(fs);
            //    fs.Close();
            //}


            //Person p3 = new Person();
            //Person p4;
            //p3.Birthday = DateTime.Now;
            //p3.Name = "SomeName";
            //using (FileStream fs = new FileStream("data_xml.dat", FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            //{
            //    XmlSerializer formatter = new XmlSerializer(typeof(Person));
            //    formatter.Serialize(fs, p3);
            //    fs.Seek(0, SeekOrigin.Begin);
            //    p4 = (Person)formatter.Deserialize(fs);
            //    fs.Close();
            //}

            //Surrogate
            Person p1 = new Person();
            Person p2;
            p1.Birthday = DateTime.Now;
            p1.Name = "SomeName";
            using (FileStream fs = new FileStream("data_surrogate.dat", FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
            {
                SurrogateSelector ss = new SurrogateSelector();
                ss.AddSurrogate(typeof(Person), new StreamingContext(StreamingContextStates.All), new PersonSerializationSurrogate());

                IFormatter formatter = new BinaryFormatter();
                formatter.SurrogateSelector = ss;
                formatter.Serialize(fs, p1);
                fs.Flush();
                fs.Seek(0, SeekOrigin.Begin);

                p2 = (Person)formatter.Deserialize(fs);
                fs.Close();
            }

            //ISerializable
            //Person p5 = new Person();
            //Person p6;
            //p5.Birthday = DateTime.Now;
            //p5.Name = "SomeName";
            //using (FileStream fs = new FileStream("data_iserializable.dat", FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            //{
            //    IFormatter formatter = new BinaryFormatter();
            //    formatter.Serialize(fs, p5);
            //    fs.Seek(0, SeekOrigin.Begin);
            //    p6 = (Person)formatter.Deserialize(fs);
            //    fs.Close();
            //}

        }
    }
}
