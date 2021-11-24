using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT3___Q2
{
    class Program
    {
        public static string[] colors = { "Red", "Grey", "Light Blue", "Blue", "Orange", "Yellow", "Purple", "Green" };

        private static int[,] mGGraph = new int[,]
        {   //          0   1     2        3    4      5       6      7
            //         Red Grey LightBlue Blue Orange Yellow Purple Green
            /*Red*/   {-1,   5,    -1,      1,    -1,    -1,   -1,   -1 },
            /*Grey*/  {-1,  -1,     0,     -1,     1,    -1,   -1,   -1 },
            /*LB*/    {-1,   0,    -1,      1,    -1,    -1,   -1,   -1 },
            /*Blue*/  {-1,  -1,     1,     -1,    -1,     8,   -1,   -1 },
            /*Orange*/{-1,  -1,    -1,     -1,    -1,    -1,    1,   -1 },
            /*Yellow*/{-1,  -1,    -1,     -1,    -1,    -1,   -1,    6 },
            /*Purple*/{-1,  -1,    -1,     -1,    -1,     1,   -1,   -1 },
            /*Green*/ {-1,  -1,    -1,     -1,    -1,    -1,   -1,   -1 }
        };

        private static (int vertex, int edge)[][] lGraph = new (int, int)[][]
        {
            /*Red*/   new (int,int)[]{(1,5),(3,1) },
            /*Grey*/  new (int,int)[]{(2,0),(4,1) },
            /*LB*/    new (int,int)[]{(1,0),(3,1) },
            /*Blue*/  new (int,int)[]{(2,1),(5,8) },
            /*Orange*/new (int,int)[]{(6,1) },
            /*Yellow*/new (int,int)[]{(7,6) },
            /*Purple*/new (int,int)[]{(5,1) },
            /*Green*/ new (int,int)[]{ },
        };

        static void Main(string[] args)
        {
            Console.Write("DFS of node RED: ");
            DFS(0);

            Graph graph = new Graph(8);
            graph.AddNode(0, 1, 5);
            graph.AddNode(0, 3, 1);
            graph.AddNode(1, 2, 0);
            graph.AddNode(1, 4, 1);
            graph.AddNode(2, 1, 0);
            graph.AddNode(2, 3, 1);
            graph.AddNode(3, 2, 1);
            graph.AddNode(3, 5, 8);
            graph.AddNode(4, 6, 1);
            graph.AddNode(5, 7, 6);
            graph.AddNode(6, 5, 1);

            int[] distances = graph.DSPFunction(0);

            for (int i = 0; i < distances.Length; i++)
            {
                Console.WriteLine("\nDistance from Red to {0}: {1}", colors[i], distances[i]);
            }
        }

        public static void DFS(int startV)
        {
            bool[] visited = new bool[lGraph.Length];
            DFSProgram(startV, visited);
            Console.WriteLine();
        }

        private static void DFSProgram(int v, bool[] visited)
        {
            visited[v] = true;
            Console.Write("{0} ", colors[v]);

            //recur all
            (int vertex, int edge)[] vList = lGraph[v];

            foreach (var n in vList)
            {
                if (!visited[n.vertex])
                {
                    DFSProgram(n.vertex, visited);
                }
            }
        }
    }

    class Graph
    {
        List<LinkedList<(int destination, int edge)>> graph;

        public void AddNode()
        {
            graph.Add(new LinkedList<(int destination, int edge)>());
        }

        public Graph(int vertices)
        {
            graph = new List<LinkedList<(int, int)>>();

            for (int i = 0; i < vertices; i++)
            {
                graph.Add(new LinkedList<(int destination, int edge)>());
            }
        }

        public int FindNode(int vertex)
        {
            if (vertex >= 0 && vertex < graph.Capacity)
            {
                return vertex;
            }

            else
            {
                return -1;
            }
        }

        private int Min_Distance(int[] distance, bool[] Set)
        {
            int minCost = int.MaxValue;
            int minVertex = -1;
            for (int i = 0; i < graph.Capacity; i++)
            {
                if (Set[i] == false && distance[i] <= minCost)
                {
                    minCost = distance[i];
                    minVertex = i;
                }
            }
            return minVertex;
        }

        public bool AddNode(int origin, int destination, int edge)
        {
            if (this.FindNode(origin) >= 0 && this.FindNode(destination) >= 0)
            {
                graph[origin].AddLast((destination, edge));
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool RemoveNode(int origin, int destination, int edge)
        {
            (int, int) item = (destination, edge);
            return graph[origin].Remove(item);
        }

        public int CostFunction(int origin, int destination)
        {
            foreach (var item in graph[origin])
            {
                if (item.destination == destination)
                {
                    return item.edge;
                }
            }

            return -1;
        }

        public int[] DSPFunction(int origin)
        {
            int[] distance = new int[graph.Capacity];

            bool[] Set = new bool[graph.Capacity];

            for (int i = 0; i < graph.Capacity; i++)
            {
                distance[i] = int.MaxValue;
                Set[i] = false;
            }

            distance[origin] = 0;

            for (int vertex = 0; vertex < graph.Capacity - 1; vertex++)
            {
                int v1 = Min_Distance(distance, Set);
                Set[v1] = true;

                for (int v2 = 0; v2 < graph.Capacity; v2++)
                {
                    if (!Set[v2] && CostFunction(v1, v2) >= 0 && distance[v1] != int.MaxValue && distance[v1] + CostFunction(v1, v2) < distance[v2])
                    {
                        distance[v2] = distance[v1] + CostFunction(v1, v2);
                    }
                }
            }
            return distance;
        }

        public void PrintGraph()
        {
            foreach (var linkedList in graph)
            {
                Console.Write("{0}: ", Program.colors[graph.IndexOf(linkedList)]);
                foreach ((int destination, int edge) item in linkedList)
                {
                    Console.Write("({0}, {1})", Program.colors[item.destination], item.edge);
                }
                Console.WriteLine();
            }
        }
    }
}
