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
        public bool hasEscapeFromJailCard;
        public int position;

        // diğer değerler

        public Player(string name, string imageName, int turn)
        {
            this.name = name;
            this.imageName = imageName;
            this.turn = turn;

            money = 1500;
            position = 0;

            ownedProperties = new bool[40];
        }
    }

}
