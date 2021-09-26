using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace UT1___Q4
{
    class Program
    {
        static Timer timer;
        static bool TimeComplete;
        static string[] AnswersArray;
        static int QuestionChose;

        public static void Main(string[] args)
        {
            string[] QuestionsArray = new string[3]
            { "What is your favorite color?", "What is the answer to life, the universe and everything?", "What is the airspeed velocity of an unladen swallow?" };

            AnswersArray = new string[3];
            AnswersArray[0] = "black";
            AnswersArray[1] = "42";
            AnswersArray[2] = "What do you mean? African or European swallow?";
            string RestartGame;
            bool ReplayGame = false;

            timer = new Timer(5000.0);
            timer.Elapsed += new ElapsedEventHandler(TimesUp);
            
            do
            {
                do
                {
                    Console.Write("Choose your question (1-3): ");
                }
                while (!int.TryParse(Console.ReadLine(), out QuestionChose) || QuestionChose < 1 || QuestionChose > 3);
                
                Console.WriteLine("You have 5 seconds to answer the following question:");
                Console.WriteLine(QuestionsArray[QuestionChose - 1]);
                
                TimeComplete = false;
                timer.Start();

                string UserAnser = Console.ReadLine();
                timer.Stop();
                
                if (!TimeComplete)
                {
                    if (UserAnser == AnswersArray[QuestionChose - 1])
                        Console.WriteLine("Well done!");
                    else
                        Console.WriteLine("Wrong!  The answer is: " + AnswersArray[QuestionChose - 1]);
                }
            
                Console.Write("Play again? ");
                RestartGame = Console.ReadLine();

                while(true)
                {
                    if (RestartGame.Length >= 1)
                    {
                        if (RestartGame.ToLower().StartsWith("n"))
                        {
                            ReplayGame = false;
                            break;
                        }

                        else if (RestartGame.ToLower().StartsWith("y"))
                        {
                            ReplayGame = true;
                            break;
                        }
                    }
                }
            }
            while (ReplayGame);
        }

        public static void TimesUp(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            TimeComplete = true;
            Console.WriteLine("Time's up!");
            Console.WriteLine("The answer is: " + AnswersArray[QuestionChose - 1]);
            Console.WriteLine("Please press enter.");
        }
    }
}
