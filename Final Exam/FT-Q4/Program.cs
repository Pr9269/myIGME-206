using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FT__Q4
{
    class Program
    {
        [Serializable]
        public class Singleton
        {
            private static Singleton _instance = null;

            public string stringName;
            public int currentLevelInteger;
            public int playerHealth;
            public string[] inventoryStringArray;
            public string liscense_KeyStrings;

            public static Singleton Instance()
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }

        static void Main(string[] args)
        {
            Singleton singleton = Singleton.Instance();

            singleton.stringName = "dschuh";

            singleton.currentLevelInteger = 4;

            singleton.playerHealth = 99;

            singleton.liscense_KeyString = "DFGU99 - 1454";

            singleton.inventoryStringArray = new string[] {
                "spear", "water bottle", "hammer", "sonic screwdriver", "cannonball",
                "wood", "Scooby snack", "Hydra", "poisonous potato", "dead bush", "repair powder"
            };

            

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("D:\\PlayerInformation.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, singleton);
            Singleton newSingleton = (Singleton)formatter.Deserialize(stream);
        }
    }
}