using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT2___Q14
{
    class Friend
    {
        public string name;
        public string greeting;
        public DateTime birthdate;
        public string address;
        public Friend()  
        {
        }
        public Friend(Friend f)  
        {
            f.name = name;
            f.greeting = greeting;
            f.birthdate = birthdate;
            f.address = address;
        }
    }



    class Program
    {

        static void Main(string[] args)
        {
            Friend friend = new Friend();  


            friend.name = "Charlie Sheen";
            friend.greeting = "Dear Charlie";
            friend.birthdate = DateTime.Parse("1967-12-25");
            friend.address = "123 Any Street, NY NY 12202";

            Friend enemy = new Friend(friend); 

            enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender.  Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");
        }
    }
}
