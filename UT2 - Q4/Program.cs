using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT2___Q4
{
    public abstract class Phone
    {
        private string phoneNumber;
        public string address;

        public string PhoneNumber;

        public abstract void Connect();

        public abstract void Disconnect();
    }

    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }

    public class RotaryPhone : Phone, PhoneInterface
    {
        public void Answer()
        {

        }

        public void MakeCall()
        {

        }

        public void HangUp()
        {

        }

        public override void Connect()
        {

        }

        public override void Disconnect()
        {

        }
    }

    public class PushButtonPhone : Phone, PhoneInterface
    {
        public void Answer()
        {

        }

        public void MakeCall()
        {

        }

        public void HangUp()
        {

        }

        public override void Connect()
        {

        }

        public override void Disconnect()
        {

        }
    }

    public class Tardis : RotaryPhone
    {
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;
        public double exteriorSurfaceArea;
        public double interiorVolume;

        public byte WhichDrWho
        {
            get;
        }

        public string FemaleSideKick
        {
            get;
        }

        public void TimeTravel()
        {
            Console.WriteLine("*************** Time Travel ***************");
        }

        public static bool operator ==(Tardis t1, Tardis t2)
        {
            bool isTrueorNot = false;
            
            if (t1.whichDrWho == t2.whichDrWho)
            {
                isTrueorNot = true;
            
            }
            return isTrueorNot;
        }
        public static bool operator !=(Tardis t1, Tardis t2)
        {
            bool isTrueorNot = false;
            if (t1.whichDrWho != t2.whichDrWho)
            {

                isTrueorNot = true;
            }
            return isTrueorNot;
        }
        public static bool operator <(Tardis t1, Tardis t2)
        {
            bool isTrueorNot = false;
            if (t1.whichDrWho == 10)
            {
                isTrueorNot = false;
            }
            else if (t2.whichDrWho == 10)
            {
                isTrueorNot = true;
            }
            else if (t1.whichDrWho < t2.whichDrWho)
            {
                isTrueorNot = true;
            }
            return isTrueorNot;
        }
        public static bool operator >(Tardis t1, Tardis t2)
        {
            bool isTrueorNot = false;
            if (t1.whichDrWho == 10)
            {
                isTrueorNot = true;
            }
            else if (t2.whichDrWho == 10)
            {
                isTrueorNot = false;
            }
            else if (t1.whichDrWho > t2.whichDrWho)
            {
                isTrueorNot = true;
            }
            return isTrueorNot;
        }
        public static bool operator <=(Tardis t1, Tardis t2)
        {
            bool isTrueorNot = false;
            if (t1.whichDrWho == 10)
            {
                isTrueorNot = false;
            }
            else if (t2.whichDrWho == 10)
            {
                isTrueorNot = true;
            }
            else if (t1.whichDrWho <= t2.whichDrWho)
            {
                isTrueorNot = true;
            }
            return isTrueorNot;
        }
        public static bool operator >=(Tardis t1, Tardis t2)
        {
            bool isTrueorNot = false;
            if (t1.whichDrWho == 10)
            {
                isTrueorNot = true;
            }
            else if (t2.whichDrWho == 10)
            {
                isTrueorNot = false;
            }
            else if (t1.whichDrWho >= t2.whichDrWho)
            {
                isTrueorNot = true;
            }
            return isTrueorNot;
        }
        public override int GetHashCode()
        {
            return 0;
        }
        public override bool Equals(object o)
        {
            return true;
        }
    }

    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneCall;

        public void OpenDoor()
        {
            Console.WriteLine("*************** Open door ***************");
        }

        public void CloseDoor()
        {

        }
    }

    public class runtime

    {

        public static void Main(string[] args)
        {
            PhoneInterface t1 = new Tardis();
            PhoneInterface p1 = new PhoneBooth();

            UsePhone(t1);
            UsePhone(p1);

        }
        static void UsePhone(object obj)
        {
            ((PhoneInterface)obj).MakeCall();
            ((PhoneInterface)obj).HangUp();
            try
            {
                ((Tardis)obj).TimeTravel();
            }
            catch
            {
                ((PhoneBooth)obj).OpenDoor();
            }
        }
    }
}