using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MonoForms.Utils
{
    public class Player
    {
        // ayarlarda eklenene kısım
        public string name;
        public string imageName;
        public int turn;

        // default değerler
        public int money;
        public bool[] ownedProperties;
        public bool hasEscapeFromJailCard = false;
        public int jailCounter;
        public bool isBankrupt = false;

        public int previousPosition;
        public int position;
        public bool IN_JAIL = false;

        // diğer değerler
        public RollCache rollCache;

        public Player(string name, string imageName, int turn)
        {
            this.name = name;
            this.imageName = imageName;
            this.turn = turn;

            money = Globals.STARTING_MONEY;
            position = 0;
            jailCounter = 0;

            ownedProperties = new bool[40];

            rollCache = new RollCache();

        }

        public bool HasConsecutiveSameRolls
        {
            get { return rollCache.HasConsecutiveSameRolls; }
        }

        public void NewRoll((int, int) roll)
        {
            rollCache.NewRoll(roll);
        }

        public class RollCache
        {
            public (int, int)[] array = new (int,int)[3];
            public int index = 0;

            public void NewRoll((int, int) roll)
            {
                array[index] = roll;
                index = (index + 1) % 3;
            }

            public bool HasConsecutiveSameRolls
            {
                get
                {
                    int val = 0;

                    foreach ((int, int) roll in array)
                    {
                        if (roll.Item1 != 0 && (roll.Item1 == roll.Item2))
                        {
                            Console.WriteLine(roll.Item1);
                            Console.WriteLine(roll.Item2);
                            val++;
                        }
                    }   

                    return val == 3;
                }
            }
        }
    }

}
