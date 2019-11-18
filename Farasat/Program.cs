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

    // Containment

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
}

public class EntryPoint
{
    public static void Main()
    {
        SingleSignOn singleSignOn = new SingleSignOn();
        singleSignOn.fbSignOn.SignIn();
        singleSignOn.instaSignOn.SignIn();
        singleSignOn.googleSignOn.SignIn();

        SofaCumBed sofaCumBed = new SofaCumBed();
        sofaCumBed.bed.Lay();
        sofaCumBed.sofa.Lay();
    }
}