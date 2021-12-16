using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;
using System.Threading;
using System.Timers;

namespace FT__Q2_Q3
{
    public class Player
    {
        private int hp;
        private int currentLocation;
        private (int, int, int)[][] graph;

        private int currentState;

        public int CurrentState
        {
            get { return currentState; }
        }

        public int GetHP()
        {
            return hp;
        }

        public bool DecreaseHP(int num)
        {
            hp -= num;

            if (hp <= 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        public Player(int hp, (int, int, int)[][] graph, int location)
        {
            this.hp = hp;
            this.graph = graph;
            this.currentLocation = location;
            this.currentState = 0;
        }
        public bool ChangeState(int state)
        {
            if (this.GetHP() <= 1)
            {
                return false;
            }

            if (state == currentState + 1)
            {
                currentState = state;
                DecreaseHP(1);
                return true;
            }

            else if (currentState == 1 || currentState == 3)
            {
                if (state == 0 || state == 2)
                {
                    currentState = state;
                    DecreaseHP(1);
                    return true;
                }

                else return false;
            }

            else return false;
        }

        public int CurrentLocation
        {
            get
            {
                return currentLocation;
            }

            set
            {
                currentLocation = value;
            }
        }

        public void IncreaseHP(int num)
        {
            hp += num;
        }
    }

    class Program
    {

        private static Player player;
        public static Program p;
        private int timeStarted;
        private int timeEnded;
        private int rounds;
        private bool winBoolean = false;
        private bool rightBoolean = false;
        private bool validBoolean = false;
        private System.Timers.Timer aTimer;
        private System.Timers.Timer stateInterval;
        private readonly object graphObj = new object();
        private readonly object validBooleanObj = new object();

        private static (int Cost, int Direction)[,] mGraph = new (int, int)[,]
        {
                //      A        B        C         D        E        F        G        H
                /*A*/{(0,0),   (1,1),   (5,2),   (-1,-1), (-1,-1), (-1,-1), (-1,-1), (-1,-1) },
                /*B*/{(-1,-1), (-1,-1), (-1,-1), (1,2),   (-1,-1), (7,2),   (-1,-1), (-1,-1) },
                /*C*/{(-1,-1), (-1,-1), (-1,-1), (0,0),   (2,3),   (-1,-1), (-1,-1), (-1,-1) },
                /*D*/{(-1,-1), (1,1),   (0,2),   (-1,-1), (-1,-1), (-1,-1), (-1,-1), (-1,-1) },
                /*E*/{(-1,-1), (-1,-1), (2,2),   (-1,-1), (-1,-1), (-1,-1), (2,0),   (-1,-1) },
                /*F*/{(-1,-1), (-1,-1), (-1,-1), (-1,-1), (-1,-1), (-1,-1), (-1,-1), (4,3)   },
                /*G*/{(-1,-1), (-1,-1), (-1,-1), (-1,-1), (2,3),   (1,2),   (-1,-1), (-1,-1) },
                /*H*/{(-1,-1), (-1,-1), (-1,-1), (-1,-1), (-1,-1), (-1,-1), (-1,-1), (-1,-1) }
        };

        private static (int Room, int Cost, int State)[][] lGraph = new (int, int, int)[][]
        {
                /*A*/new (int,int,int)[] {(1,1,1),(2,5,2) },
                /*B*/new (int,int,int)[] {(3,1,2),(5,7,2) },
                /*C*/new (int,int,int)[] {(3,0,0),(4,2,3) },
                /*D*/new (int,int,int)[] {(1,1,1),(2,0,2) },
                /*E*/new (int,int,int)[] {(2,2,2),(6,2,0) },
                /*F*/new (int,int,int)[] {(7,4,3) },
                /*G*/new (int,int,int)[] {(4,2,3),(5,1,2) },
                /*H*/new (int,int,int)[] { }
        };

        private static string[] roomNames = { "A", "B", "C", "D", "E", "F", "G", "H" };
        private static string[] stateType = { "ice", "liquid", "gas", "liquid" };
        private static string[] totalStates = { "ice", "liquid", "gas", "ice", "liquid", "gas", "ice", "liquid" };

        public static void ShowUI()
        {
            Console.WriteLine("Player HP: {0}", player.GetHP());
            Console.WriteLine("Current State: {0}", stateType[player.CurrentState]);
            Console.WriteLine("The room you are currently in: {0}", roomNames[player.CurrentLocation]);

            (int Room, int Cost, int State)[] availableRooms = RoomsAvailable();
            for (int i = 0; i < availableRooms.Length; i++)
            {
                if (availableRooms[i] != (-1, -1, -1))
                {
                    Console.WriteLine("You have access to {0} with cost {1}", roomNames[availableRooms[i].Room], availableRooms[i].Cost);
                }
            }
        }

        public static (int, int, int)[] RoomsAvailable()
        {
            (int Room, int Cost, int State)[] adjacentList = ((int, int, int)[])lGraph[player.CurrentLocation].Clone();
            for (int i = 0; i < adjacentList.Length; i++)
            {
                if (player.GetHP() - adjacentList[i].Cost <= 0) adjacentList[i] = (-1, -1, -1);
            }
            return adjacentList;
        }

        public static bool RaiseQuestion()
        {
            string answer = "";
            p.validBoolean = false;
            SetTimer(15000);
            List<TriviaResult> list = GenerateQuestions();
            Console.WriteLine(list[0].question);
            Console.WriteLine("Enter your answer");
            while (!p.validBoolean)
            {
                answer = Console.ReadLine();
                if (answer == "t" || answer == "f")
                {
                    if (answer == "t") answer = "True";
                    else answer = "False";
                    break;
                }
                Console.WriteLine("Enter valid answers: ");
            }
            p.aTimer.Stop();
            p.aTimer.Dispose();
            if (answer == list[0].correct_answer) return true;
            else return false;
        }
        private static void SetTimer(int time = 5000)
        {
            p.aTimer = new System.Timers.Timer(time);
            p.aTimer.Elapsed += OnTimedEvent;
            p.aTimer.AutoReset = false;
            p.aTimer.Enabled = true;
        }

        static void Main(string[] args)
        {
            bool playingBoolean = true;

            lGraph = new (int, int, int)[][]
            {
                /*A*/new (int,int,int)[] {(1,1,1),(2,5,2) },
                /*B*/new (int,int,int)[] {(3,1,2),(5,7,2) },
                /*C*/new (int,int,int)[] {(3,0,0),(4,2,3) },
                /*D*/new (int,int,int)[] {(1,1,1),(2,0,2) },
                /*E*/new (int,int,int)[] {(2,2,2),(6,2,0) },
                /*F*/new (int,int,int)[] {(7,4,3) },
                /*G*/new (int,int,int)[] {(4,2,3),(5,1,2) },
                /*H*/new (int,int,int)[] { }
            };

            do
            {
                ChangingStates();
                p.timeStarted = Environment.TickCount;
                p.rounds = 0;

                Console.WriteLine("Welcome to my World");

                player = new Player(5, lGraph, 0);

                Console.WriteLine("There are three types of rooms with states: Ice / Liquid / Gas");

                for (int i = 0; i < totalStates.Length; i++)
                {
                    Console.WriteLine(roomNames[i] + ": " + totalStates[i]);
                }
                
                Console.WriteLine("Room state changes from -> ice -> liquid -> gas -> liquid -> ice -> liquid -> ");
                Console.WriteLine("Player state changes from -> ice->liquid, liquid->gas, gas->liquid, or liquid->ice");

                while (!p.winBoolean && player.GetHP() > 0)
                {
                    p.rounds++;
                    
                    ShowUI();

                    p.validBoolean = false;
                    while (!p.validBoolean)
                    {
                        Console.WriteLine("You have two choices, either Leave or Wager");
                        Console.WriteLine("Enter c for state change, w for wager and l to leave the game");
                        string answer = Console.ReadLine();

                        if (answer == "l")
                        {
                            int nextAvailableDirection = -1;
                            bool validDirectionBoolean = false;
                            bool exitDirectionBoolean = false;

                            (int Room, int Cost, int State)[] availableRooms = RoomsAvailable();
                            do
                            {
                                int i = 0;
                                Console.WriteLine("Enter a room where you want to go");

                                while (i < availableRooms.Length)
                                {
                                    if (availableRooms[i] != (-1, -1, -1))
                                    {
                                        Console.WriteLine("Rooms that are available to you: {0}.", roomNames[availableRooms[i].Room]);
                                        exitDirectionBoolean = true;
                                    }
                                    i++;
                                }

                                if (!exitDirectionBoolean)
                                {
                                    Console.WriteLine("Sorry, no available rooms.");
                                    break;
                                }

                                nextAvailableDirection = Array.IndexOf(roomNames, Console.ReadLine());

                               while( i < availableRooms.Length )
                               {
                                    if (availableRooms[i] != (-1, -1, -1))
                                    {
                                        if (nextAvailableDirection == availableRooms[i].Room) validDirectionBoolean = true;
                                    }
                                    i++;
                               }
                            }
                            while (nextAvailableDirection < 0 || !validDirectionBoolean);

                            if (!exitDirectionBoolean)
                            {
                                break;
                            }

                            MoveToRoom(nextAvailableDirection, ref availableRooms);
                            break;
                        }

                        else if (answer == "w")
                        {
                            int wagerNumber;
                            do
                            {
                                Console.WriteLine("Please enter the HP you want to wager");
                            }
                            while (!int.TryParse(Console.ReadLine(), out wagerNumber) || wagerNumber < 0 || wagerNumber > player.GetHP());

                            bool bCorrect = RaiseQuestion();
                            if (bCorrect)
                            {
                                player.IncreaseHP(wagerNumber);
                                Console.WriteLine("Conguratulations! Your answer was correct. Your hp has been increased");
                            }
                            else
                            {
                                player.DecreaseHP(wagerNumber);
                                Console.WriteLine("Oh NO! Your answer was incorrect. Your hp has been decreased.");
                            }
                            break;
                        }

                        else if (answer == "c")
                        {
                            bool isStateValid = false;
                            while (!isStateValid)
                            {
                                int i=0;
                                Console.WriteLine("Please input the state you want to change to: ");
                                string tmpStateStr = Console.ReadLine();
                                while(i < stateType.Length)
                                {
                                    if (stateType[i] == tmpStateStr)
                                    {
                                        if (player.ChangeState(i))
                                        {
                                            isStateValid = true;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Cannot change states");
                                        }
                                    }

                                    i++;
                                }
                            }

                            Console.WriteLine("State changed successfully");
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Invalid Input");
                        }
                    }

                    if (player.CurrentLocation == roomNames.Length - 1)
                    {
                        p.winBoolean = true;
                    }
                }

                if (player.GetHP() <= 0)
                {
                    Console.WriteLine("You just lost all of your hp");
                }
                else if (p.winBoolean)
                {
                    Console.WriteLine("Congratulations! You have reached the final destination");

                    p.timeEnded = Environment.TickCount;
                    Console.WriteLine("You take {0} seconds and {1} rounds to reach the destination.",
                        (p.timeEnded - p.timeStarted) / 1000,
                        p.rounds);
                }

                else
                {
                    Console.WriteLine("Bug in winning condition. check it");
                }

                p.stateInterval.Stop();
                p.stateInterval.Dispose();

                bool isValidPlay = false;

                while (!isValidPlay)
                {
                    Console.WriteLine("Would you like to play again?");
                    string answer = Console.ReadLine();
                    if (answer == "y")
                    {
                        isValidPlay = true;
                        playingBoolean = true;
                        p.winBoolean = false;
                    }
                    else if (answer == "n")
                    {
                        isValidPlay = true;
                        playingBoolean = false;
                    }
                }
            }
            while (playingBoolean);

        }

        public static void MoveToRoom(int direction, ref (int Room, int Cost, int State)[] availableRooms)
        {
            for (int i = 0; i < availableRooms.Length; i++)
            {
                if (direction == availableRooms[i].Room)
                {
                    if (player.CurrentState == availableRooms[i].State)
                    {
                        player.CurrentLocation = availableRooms[i].Room;
                        player.DecreaseHP(availableRooms[i].Cost);
                        return;
                    }

                }
            }
            Console.WriteLine("incorrect state");
            return;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (source.GetType() == typeof(System.Timers.Timer))
            {
                lock (p.validBooleanObj)
                {
                    Console.WriteLine("Press Enter to continue!");
                    p.validBoolean = true;
                }
            }
        }

        public static void ChangingStates()
        {
            p.stateInterval = new System.Timers.Timer(1000);

            p.stateInterval.Elapsed += StateInterval_Elapsed;
            p.stateInterval.AutoReset = true;
            p.stateInterval.Enabled = true;
        }

        private static void StateInterval_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (p.graphObj)
            {
                for (int j = 0; j < lGraph.Length; j++)
                {
                    (int Room, int Cost, int State)[] aList = lGraph[j];
                    for (int i = 0; i < aList.Length; i++)
                    {
                        lGraph[j][i].State++;
                        if (aList[i].State >= stateType.Length) lGraph[j][i].State = 0;
                    }
                }
            }
        }

        public static List<TriviaResult> GenerateQuestions()
        {
            string url = null;
            string s = null;

            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader reader;

            url = "https://opentdb.com/api.php?amount=1&category=9&difficulty=easy&type=boolean";

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            s = reader.ReadToEnd();
            reader.Close();

            Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);


            for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
            {
                trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
                trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);
                trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
            }
            return trivia.results;
        }
    }

    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }

    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
    }
}