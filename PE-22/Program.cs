using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using System.IO;

namespace PE_22
{
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
    class Program
    {
        public int currentRoom = 0;
        int playerHp = 15;
        // neighboring points can be determined by if (maxtrixGraph[x, y].Item1 == x)
        // relative direction is Item1 in the tuple
        // cost is Item2 in the tuple
        static (string, int)[,] matrixGraph = new (string, int)[,]
        {
                 //    A           B           C           D           E           F           G           H
          /*A*/  {("NE", 0),("S", 2),(null, -1),(null, -1),(null, -1),(null, -1),(null, -1),(null, -1)},
          /*B*/  {(null, -1),(null, -1),("S", 2),("E", 3),(null, -1),(null, -1),(null, -1),(null, -1)},
          /*C*/  {(null, -1),("N", 2),(null, -1),(null, -1),(null, -1),(null, -1),(null, -1),("S", 20)},
          /*D*/  {(null, -1),("W", 3),("S", 5),(null, -1),("N", 2),("E", 4),(null, -1),(null, -1)},
          /*E*/  {(null, -1),(null, -1),(null, -1),(null, -1),(null, -1),("S", 3),(null, -1),(null, -1)},
          /*F*/  {(null, -1),(null, -1),(null, -1),(null, -1),(null, -1),(null, -1),("E", 1),(null, -1)},
          /*G*/  {(null, -1),(null, -1),(null, -1),(null, -1),("N", 0),(null, -1),(null, -1),("S", 2)},
          /*H*/  {(null, -1),(null, -1),(null, -1),(null, -1),(null, -1),(null, -1),(null, -1),(null, -1)}
        };
        static (string, string)[,] mGraph = new (string, string)[,]
        {
            //Since there are paths with 0 weight -1 represents no connection.
                 /*N , S , E , W*/
            /*A*/{ ("N","A"), ("S","B"),("E","A"),("W","N") },
            /*B*/{ ("N","N"), ("S","C"),("E","D"),("W","N")},
            /*C*/{ ("N","B"), ("S","H"),("E","N"),("W","N")},
            /*D*/{ ("N","E"), ("S","C"),("E","F"),("W","B")},
            /*E*/{ ("N","N"), ("S","F"),("E","N"),("W","N")},
            /*F*/{ ("N","N"), ("S","N"),("E","G"),("W","N")},
            /*G*/{ ("N","E"), ("S","H"),("E","N"),("W","N")},
            /*H*/{ ("N","N"), ("S","N"),("E","N"),("W","N")}
        };
        //Item1 is the index of the neighbor, Item2 is the direction and Item3 is the cost
        static (int, string, int)[][] listGraph = new (int, string, int)[][]
        {
            /*A*/ new (int, string, int)[] {(0, "N", 0), (0, "E", 0), (1, "S", 2)},
            /*B*/ new (int, string, int)[] {(2, "S", 2), (3, "E", 3)},
            /*C*/new (int, string, int)[] {(1, "N", 2), (7, "S", 20)},
            /*D*/new (int, string, int)[] {(1, "W", 3), (2, "S", 5), (4, "N", 2), (5, "E", 4)},
            /*E*/new (int, string, int)[] {(5, "S", 3)},
            /*F*/new (int, string, int)[] {(6, "E", 1)},
            /*G*/new (int, string, int)[] {(4, "N", 0),(7,"S",2)},
            null
        };
        // parallel arrays to store the weight, direction and room indexes
        // weight graph
        static int[][] wGraph = new int[][]
        {
            /*A*/ new int[] {0, 0, 2},
                  new int[] {2,3},
                  new int[] {2,20},
                  new int[] {3,5,2,4},
                  new int[] {3},
                  new int[] {1},
                  new int[] {0,2},
                  null
            /*B new (int, string, int)[] {(2, "S", 2), (3, "E", 3)},
            new (int, string, int)[] {(1, "N", 2), (7, "S", 20)},
            new (int, string, int)[] {(1, "W", 3), (2, "S", 5), (4, "N", 2), (5, "E", 4)},
            new (int, string, int)[] {(5, "S", 3)},
            new (int, string, int)[] {(6, "E", 1)},
            new (int, string, int)[] {(4, "N", 0)},
            null  */
        };
        // room graphs: contains the indexes of the connected rooms
        static int[][] iGraph = new int[][]
        {
            /*A*/ new int[] {0, 0, 1},
                  new int[] {2,3},
                  new int[] {1,2,4,5},
                  new int[] {5},
                  new int[] {6},
                  new int[] {4,7}
            /*B new (int, string, int)[] {(2, "S", 2), (3, "E", 3)},
            new (int, string, int)[] {(1, "N", 2), (7, "S", 20)},
            new (int, string, int)[] {(1, "W", 3), (2, "S", 5), (4, "N", 2), (5, "E", 4)},
            new (int, string, int)[] {(5, "S", 3)},
            new (int, string, int)[] {(6, "E", 1)},
            new (int, string, int)[] {(4, "N", 0)},
            null  */
        };
        static void Main(string[] args)
        {
            Program p = new Program();
            int nRoom = 0;

            while (nRoom != 7)
            {
                Console.WriteLine("Room no:-" + nRoom);
                int nCntr = 0;
                // if not room A and not room H then randomly reduce their HP such that they don't die
                p.drophealth();
                // display a desc of the room
                roomDescription(nRoom);
                // Console.Writeline(desc[nRoom]);
                // display any exits from the room
                (int, string, int)[] thisRoomsNeighbors = listGraph[nRoom];
                int nExits = 0;
                foreach ((int, string, int) neighbor in thisRoomsNeighbors)
                {
                    //if (p.playerHp > neighbor.Item3)
                    {
                        Console.WriteLine("There is an exit to the " + neighbor.Item2 + " which costs " + neighbor.Item3 + "HP");
                        ++nExits;
                    }
                }
                // display the hp
                Console.WriteLine($"You have {p.playerHp} HP");
                // ask the player if they want wager (w) for more hp or leave (l) the room only if there are nExits > 0
                if (nExits > 0)
                {
                    Console.WriteLine("You can either wager your Hp against a trivia question(w) or leave the room using the HP value the path costs(l)\n What will it be?");
                }

                string sResponse = null;

                sResponse = Console.ReadLine();
                if (sResponse.ToLower() == "l" /* leaving room */ )
                {
                    bool bValid = false;
                    string sDirection = null;
                    while (!bValid)
                    {
                        sDirection = Console.ReadLine();
                        /*  for (nCntr = 0; nCntr < 8; ++nCntr)
                          {
                              Console.WriteLine(matrixGraph[nRoom, nCntr].Item1);
                              if (matrixGraph[nRoom, nCntr].Item1.Contains(sDirection) && p.playerHp > matrixGraph[nRoom, nCntr].Item2)
                              {
                                  nRoom = nCntr;
                                  Console.WriteLine("Room no(nRoom)" + nRoom);
                                  Console.WriteLine("Control no(nRoom)" + nCntr);
                                  p.playerHp -= matrixGraph[nRoom, nCntr].Item2;
                                  bValid = true;
                                  break;
                              }
                          }*/
                        for (nCntr = 0; nCntr < 4; nCntr++)
                        {
                            if (mGraph[nRoom, nCntr].Item1 == sDirection.ToUpper() && mGraph[nRoom, nCntr].Item2 != "N")
                            {
                                if (mGraph[nRoom, nCntr].Item2 == "A")
                                {
                                    nRoom = 0;
                                }
                                else if (mGraph[nRoom, nCntr].Item2 == "B")
                                {
                                    nRoom = 1;
                                }
                                else if (mGraph[nRoom, nCntr].Item2 == "C")
                                {
                                    nRoom = 2;
                                }

                                else if (mGraph[nRoom, nCntr].Item2 == "D")
                                {
                                    nRoom = 3;
                                }

                                else if (mGraph[nRoom, nCntr].Item2 == "E")
                                {
                                    nRoom = 4;
                                }
                                else if (mGraph[nRoom, nCntr].Item2 == "F")
                                {
                                    nRoom = 5;
                                }
                                else if (mGraph[nRoom, nCntr].Item2 == "G")
                                {
                                    nRoom = 6;
                                }

                                else if (mGraph[nRoom, nCntr].Item2 == "H")
                                {
                                    nRoom = 7;
                                }
                                bValid = true;
                                break;
                            }
                        }
                        if (!bValid)
                        {
                            Console.WriteLine("That isn't a valid direction");
                        }

                    }

                }
                else
                {
                    // trivia question

                    // fetch api
                    // 15 second limit to answer
                    // multiple choice 1-4
                    // ask player how much HP to wager (limited to playerHp)
                    string url = null;
                    string s = null;
                    HttpWebRequest request;
                    HttpWebResponse response;
                    StreamReader reader;
                    url = "https://opentdb.com/api.php?amount=1&type=multiple";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream());
                    s = reader.ReadToEnd();
                    reader.Close();
                    Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);
                    trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
                    trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);
                    for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
                    {
                        trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
                    }
                    // put the answers in random order
                    // prefix each answer with number 1-4 so the player only need to type the number
                    // 15 second timer
                }
            }
        }

        public static void roomDescription(int currentRoom)
        {
            if (currentRoom == 0)
            {
                Console.WriteLine("A room where a giant monster is sleeping");
            }
            else if (currentRoom == 1)
            {
                Console.WriteLine("A room full of spiders. \n ");
            }
            else if (currentRoom == 2)
            {
                Console.WriteLine("A room with a bunch of scary moving and live photos");
            }
            else if (currentRoom == 3)
            {
                Console.WriteLine("A dusty old room with insects cluttering around as you try not to step on them while walking in.\n the walls are stained with blood and the stench comeing from the dead body in the corner is hellish\n");
            }
            else if (currentRoom == 4)
            {
                Console.WriteLine("A room full of dead bodies hanging from the roof.");
            }
            else if (currentRoom == 5)
            {
                Console.WriteLine("A room with smoke and water. It looks like there was a explosion");
            }
            else if (currentRoom == 6)
            {
                Console.WriteLine("A room with a table in the corner with a lot of stationary clutter which is covered in spider webs and a bookself with lots of old books\n seems like it used to be someone's study\n ");
            }
            else if (currentRoom == 7)
            {
                Console.WriteLine("A room with knives flying around and if you go in then maybe they'll try to hit you");
            }
        }

        public void drophealth()
        {
            Random rand = new Random();
            int healthDrop = rand.Next(0, 10);
            //Keep generating new random number untill a valid health drop is generated
            while ((playerHp - healthDrop) <= 0)
            {
                healthDrop = rand.Next(0, 10);
            }

            playerHp -= healthDrop;

            // random lines to explain the damage to the player
            if (healthDrop == 1)
            {
                Console.WriteLine("You stepped on a nail and hurt yourself. \n You just lost 1HP");
            }
            else if (healthDrop == 2)
            {
                Console.WriteLine("While trying to exit the room you fell and hit your head. \n There goes your another 2HP");
            }
            else if (healthDrop == 3)
            {
                Console.WriteLine("You got electrocuted.........be happy you didn't die.");
            }
            else if (healthDrop == 4)
            {
                Console.WriteLine("Earthquake!!!!! watch your head!!! oh no you already got hit by a piece of ceiling in head \n");
            }
            else if (healthDrop == 5)
            {
                Console.WriteLine("Got bitten by a venomous spider");
            }
            else if (healthDrop == 6)
            {
                Console.WriteLine("Well....the door handle was hot and you just burnt yourself.");
            }
            else if (healthDrop == 7)
            {
                Console.WriteLine("You just hit with one of the escaped flying knives from one of the rooms");
            }
            else if (healthDrop == 8)
            {
                Console.WriteLine("The floor cracked open and you fell in a pit");
            }
            else if (healthDrop == 9)
            {
                Console.WriteLine("One of the flying bat just hit you head on and you got a concussion.");
            }
        }
    }
}