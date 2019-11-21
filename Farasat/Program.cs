using Farasat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farasat
{
    #region Multi Level
    class Human
    {
        public string name { get; set; }
        public string fathersName { get; set; }
        public string motherName { get; set; }
        public string gender { get; set; }
        public string location { get; set; }
        public string citizenship { get; set; }

        private string legs { get; set; }
        private string arms { get; set; }
        private string brain { get; set; }
        private string eyes { get; set; }

        public void Sleep()
        {

        }

        public void Walk()
        {

        }

        public void Eat()
        {

        }
    }

    class Doctor : Human
    {
        string Degree { get; set; }
        string PracticeLicense { get; set; }

        public void Treatment()
        {

        }
    }

    class Surgeon : Doctor
    {
        void Surgery()
        {

        }
    }

    class OrthopedicSurgeon : Surgeon
    {
        void OrthopedicSurgery()
        {

        }
    }
    #endregion

    #region Multiple

    class Sofa
    {
        string mattress { get; set; }
        string design { get; set; }
        string cover { get; set; }
        string backSupport { get; set; }

        public void Lay()
        {

        }
    }

    class Bed
    {
        string mattress { get; set; }
        string design { get; set; }
        string cover { get; set; }

        public void Lay()
        {

        }
    }

    //Cannot be compiled because of multiple inheritance
    //class SofaCumBed : Sofa, Bed
    //{
    //    void Lay() //Sofa
    //    {

    //    }

    //    void Lay() //Bed
    //    {

    //    }
    //}

    #endregion

    #region Multi Path

    class BedRoomFurniture
    {
        void Lay()
        {

        }
    }

    class Sofa1 : BedRoomFurniture
    {
        string mattress { get; set; }
        string design { get; set; }
        string cover { get; set; }
        string backSupport { get; set; }
    }

    class Bed1 : BedRoomFurniture
    {
        string mattress { get; set; }
        string design { get; set; }
        string cover { get; set; }
    }

    //Cannot be compiled because of multiple inheritance
    //class SofaCumBed : Sofa1, Bed1
    //{

    //}

    #endregion

    #region Containment

    //Aggregation implimenting multiple inheritance scenario
    public class FacebookSignOn
    {
        public string facebookId { get; set; }
        public string facebookPwd { get; set; }

        public void SignIn()
        {
        }

        public void SignOut()
        {
        }
    }

    public class InstagramSignOn
    {
        public string instagramId { get; set; }
        public string instagramPwd { get; set; }

        public void SignIn()
        {
        }

        public void SignOut()
        {
        }
    }

    public class GoogleSignOn
    {
        public string googleId { get; set; }
        public string googlePwd { get; set; }

        public void SignIn()
        {
        }

        public void SignOut()
        {
        }
    }

    //class SingleSignOn : FacebookSignOn, GoogleSignOn, InstagramSignOn
    //{
    //}

    public class SingleSignOn
    {
        public FacebookSignOn fbSignOn { get; set; }
        public GoogleSignOn googleSignOn { get; set; }
        public InstagramSignOn instaSignOn { get; set; }
    }

    //Containment 
    //Composition Real Life scenario implimenting multiple inheritance
    class SofaCumBed
    {
        public Sofa sofa { get; set; }
        public Bed bed { get; set; }
    }
    #endregion
}

#region Main()
public class EntryPoint
{
    public static void Main()
    {
        Vitz1999Standard vitz99 = new Vitz1999Standard();
        Console.WriteLine(vitz99.model);
        Console.WriteLine(vitz99.price);
        Console.WriteLine(vitz99.dimensions);
        vitz99.Start();
        vitz99.AirConditioning();
        vitz99.Transmission();
        vitz99.Braking();

        Console.WriteLine("***************************************");

        Vitz2004Auto vitz04 = new Vitz2004Auto();
        Console.WriteLine(vitz04.model);
        Console.WriteLine(vitz04.price);
        Console.WriteLine(vitz04.dimensions);
        vitz04.Start();
        vitz04.AirConditioning();
        vitz04.Transmission();
        vitz04.Braking();

        Console.WriteLine("********************************");

        Vitz2005 vitz05 = new Vitz2005();
        Console.WriteLine(vitz05.model);
        Console.WriteLine(vitz05.price);
        Console.WriteLine(vitz05.dimensions);
        vitz05.Start();
        vitz05.AirConditioning();
        vitz05.Transmission();
        vitz05.Braking();

        Console.WriteLine("********************************");

        NaseemSahab naseem = new NaseemSahab();
        naseem.FavouriteWork();

        Console.WriteLine("********************************");

        Farasat1 farast = new Farasat1();
        farast.FavouriteWork();

        Calculator cal = new Calculator();
        cal.Add(1, 2);
        cal.Add(1, 2.5);
        cal.Add(3.5, 2);
        cal.Add(1, 2, 3);

        ScientificCalculator scCal = new ScientificCalculator();
        scCal.Add(1, 2);
        scCal.Add(1, 2.5);
        scCal.Add(3.5, 2);
        scCal.Add(1, 2, 3);
        scCal.Add(1, 2, 3.3); // Overloaded version in the child class

        Console.WriteLine("********************************");

        IPhone5S iphone5s = new IPhone5S();
        iphone5s.Calling();
        iphone5s.InternetSurfing();
        iphone5s.Gaming();

        Console.ReadLine();

        SingleSignOn singleSignOn = new SingleSignOn();
        singleSignOn.fbSignOn.SignIn();
        singleSignOn.instaSignOn.SignIn();
        singleSignOn.googleSignOn.SignIn();

        SofaCumBed sofaCumBed = new SofaCumBed();
        sofaCumBed.bed.Lay();
        sofaCumBed.sofa.Lay();
    }
}

#endregion

#region Polymorphism
//**************************Polymorphism
public class Vitz1999Standard
{
    virtual public string model => "1999";
    virtual public float price => 500000;
    virtual public string steering => "Hydraulic Power Steering";
    virtual public string soundSystem => "CD Player";

    public string engine => "1SZ-FE14";
    virtual public string dimensions => "5x5x12";
    public float weight => 900;
    public string shockAbsorbers => "OIL Absorbers";
    public int tireSize => 13;

    public void Braking()
    {
        Console.WriteLine("ABS");
    }

    public void Start()
    {
        Console.WriteLine("Key Ignition Start");
    }

    virtual public void AirConditioning()
    {
        Console.WriteLine("Manual Cliamte Control");
    }

    virtual public void Drive()
    {
        Console.WriteLine("Manual Drive");
    }

    virtual public void Transmission()
    {
        Console.WriteLine("Manual Transmission");
    }
}

//Vitz2004 auto is a specialized or upgraded version of vitz 1999 standard
public class Vitz2004Auto : Vitz1999Standard
{
    public override string model => "2004";
    public override float price => 600000;
    public override string steering => "Electric Power Steering";
    public override string soundSystem => "DVD Player";

    public override void AirConditioning()
    {
        Console.WriteLine("Digital Cliamte Control");
    }

    public override void Drive()
    {
        Console.WriteLine("Auto Drive");
    }

    public override void Transmission()
    {
        Console.WriteLine("Auto Transmission");
    }
}

public class Vitz2005 : Vitz2004Auto
{
    public override string model => "2005";
    public override float price => 700000;
    public override string dimensions => "5x6x13";
}

public class NaseemSahab
{
    virtual public void FavouriteWork()
    {
        Console.WriteLine("Listening to qawwali");
    }
}

public class Farasat1 : NaseemSahab
{
    override public void FavouriteWork()
    {
        Console.WriteLine("Listening to music");
    }
}
//*****************************************************
/// <summary>
/// 1-Number of aprameters
/// 2-Type of the parameters
/// 3-Order of the Type of the parameters
/// </summary>

public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    //eg of point 1
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    //eg of point 2
    public double Add(int a, double b)
    {
        return a + b;
    }

    //eg of point 3
    public double Add(double a, int b)
    {
        return a + b;
    }
}

public class ScientificCalculator : Calculator
{
    //Static Polyorphism with inheritance, but inheritance is not necessary of static polymorphism but inheritance can be used
    public double Add(int a, int b, double c)
    {
        return a + b + c;
    }
}

#endregion
#region Abstraction
public abstract class SmartPhone
{
    public abstract string camera { get; }
    public abstract string touchScreen { get; }
    public abstract string entainment { get; }
    public abstract string size { get; }
    public abstract string color { get; }
    public abstract string price { get; }

    public abstract string OS { get; }
    public abstract string messaging { get; }
    public abstract string syncing { get; }

    public abstract void InternetSurfing();
    public abstract void VideoRecording();
    public abstract void Gaming();
    public abstract void Calling();
}

//Concept or Idea, in which mostly we have conceptual(abstract) properties and functionalities, but we can define concrete(Specific) properties and functionalities
public abstract class IPhone : SmartPhone
{    //Concrete Properties
    public override string OS => "IOS";
    public override string messaging => "IMessaging";
    public override string syncing => "ICloud";
}

//Concrete class
public class IPhone5S : IPhone
{
    public override string camera => "5mp";
    public override string touchScreen => "GorillaGlassTouch";
    public override string entainment => "Sound recorder, Radio";
    public override string size => "4 inches";
    public override string color => "WhiteGold";
    public override string price => "50000";

    public override void Gaming()
    {
        Console.WriteLine("3D Gaming");
    }

    public override void InternetSurfing()
    {
        Console.WriteLine("LTE");
    }

    public override void VideoRecording()
    {
        Console.WriteLine("360 5mp Video Recording");
    }

    public override void Calling()
    {
        Console.WriteLine("705 Band");
    }
}
#endregion