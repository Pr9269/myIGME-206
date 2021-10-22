using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT2___Q9
{
    public abstract class Guitar
    {
        public string model;
        public string company;
        public string type;

        public virtual void Strumming()
        {

        }
    }

    public interface IAcoustic
    {
        void Party();
    }

    public interface IElectric
    {
        void Play();
    }

    public class Acoustic : Guitar, IAcoustic
    {
        public bool capo;

        public void Play()
        {

        }

        public void Party()
        {

        }
    }

    public class Electric : Guitar, IElectric
    {
        public string speciality;

        public void Strumming()
        {

        }

        public void Play()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
