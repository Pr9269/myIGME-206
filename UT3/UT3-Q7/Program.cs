using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT3_Q7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Wizard> wizardList = new List<Wizard>();

            Wizard wizard1 = new Wizard("Eminem", 49);
            Wizard wizard2 = new Wizard("Avici", 32);
            Wizard wizard3 = new Wizard("Marshmellow", 29);
            Wizard wizard4 = new Wizard("BlackBear", 30);
            Wizard wizard5 = new Wizard("Bruno Mars", 36);
            Wizard wizard6 = new Wizard("Khalid", 23);
            Wizard wizard7 = new Wizard("Post Malone", 26);
            Wizard wizard8 = new Wizard("Juice WRLD", 23);
            Wizard wizard9 = new Wizard("Drake", 35);
            Wizard wizard10 = new Wizard("Rihana", 33);

            wizardList.Add(wizard1);
            wizardList.Add(wizard2);
            wizardList.Add(wizard3);
            wizardList.Add(wizard4);
            wizardList.Add(wizard5);
            wizardList.Add(wizard6);
            wizardList.Add(wizard7);
            wizardList.Add(wizard8);
            wizardList.Add(wizard9);
            wizardList.Add(wizard10);

            wizardList.Sort();

            wizardList = wizardList.OrderBy(delegate (Wizard n) { return n.Age; }).ToList();

            foreach (Wizard wizard in wizardList)
            {
                Console.WriteLine(wizard.Age);
            }
        }

        public class Wizard : IComparable<Wizard>
        {
            public string Name;
            public int Age;
            public Wizard(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
            public int CompareTo(Wizard number)
            {
                return this.Age.CompareTo(number.Age);
            }
        }
    }
}