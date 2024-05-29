using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MonoForms.Utils
{
    public static class Globals
    {
        public const bool DEBUG = true;

        public const int TIMER_TICK_LENGHT = 50; // DEFAULT 500

        public const int APP_WIDTH = 1280;
        public const int APP_HEIGHT = 720;

        public const int SETTINGS_WIDTH = 1280;
        public const int SETTINGS_HEIGHT = 720;

        public const string PROPERTY_PATH = "../../Data/Property.json";
        public const string LUCK_PATH = "../../Data/Luck.json";
        public const string COMMUNITY_PATH = "../../Data/Community.json";

        public static int STARTING_MONEY = 1500; // DEFAULT 1500
        public static int PASS_MONEY_GAIN = 200;
        public static int TAX_DIFFICULTY = 1;

        public static int JAIL_PRICE = (int) (PASS_MONEY_GAIN * 1.25 * TAX_DIFFICULTY);




        public static readonly (int, int)[] positions = new (int, int)[]
        {
            (956,956), /* start */

            (847,956),
            (763,956),
            (680,956),

            (596,956),
            (512,956),
            (428,956),

            (344,956),
            (269,956),
            (176,956),

            ( 67,956), /* kodes */

            ( 67,847),
            ( 67,763),
            ( 67,680),

            ( 67,596),
            ( 67,512),
            ( 67,428),

            ( 67,344),
            ( 67,269),
            ( 67,176),

            ( 67, 67), /* park */

            (176, 67),
            (269, 67),
            (344, 67),

            (428, 67),
            (512, 67),
            (596, 67),

            (680, 67),
            (763, 67),
            (847, 67),


            (956, 67), /* kodese git */

            (956,176),
            (956,269),
            (956,344),

            (956,428),
            (956,512),
            (956,596),

            (956,680),
            (956,763),
            (956,847),

        };

        // in box offests for icons so they wont overlap if they are in same box, 
        public static readonly (int, int)[] offsets = new (int, int)[]
        {
            (-25,-15),
            (  5,-15),
            (-25, 15),
            (  5, 15),
        };

        public static readonly bool[] propertyMapBool = new bool[]
        {
            false, true ,false, true,  false, true, true,  false, true,  true,
            false, true ,true,  true,  true,  true, true,  false, true,  true,
            false, true ,false, true,  true,  true, true,  true,  true,  true,
            false, true ,true,  false, true,  true, false, true,  false, true
        };


        // updates when init
        public static Property[] Properties;
        public static Luck[] Lucks;
        public static Community[] Communities;

        public static Queue<Luck> LuckQueue;
        public static Queue<Community> CommunityQueue;

        // updates from game settings
        public static int PlayerCount;
        public static Player[] Players;

        public static void Init()
        {
            Console.WriteLine("GLOBALS INITILIZED");

            PropertyCards pc = PropertyCards.FromJsonFile(PROPERTY_PATH);
            LuckCards lc = LuckCards.FromJsonFile(LUCK_PATH);
            CommunityCards cc = CommunityCards.FromJsonFile(COMMUNITY_PATH);

            Lucks = lc.lucks;
            Communities = cc.communities;

            //Lucklar enqueue edilmeden önce Luck listesi burada karılır
            Lucks = Lucks.OrderBy(x => Guid.NewGuid()).ToArray();

            //Communities enqueue edilmeden önce Communities listesi burada karılır
            Communities = Communities.OrderBy(x => Guid.NewGuid()).ToArray();

            LuckQueue = new Queue<Luck>();
            foreach (Luck luck in Lucks)
                LuckQueue.Enqueue(luck);

            CommunityQueue = new Queue<Community>();
            foreach (Community community in Communities)
                CommunityQueue.Enqueue(community);

            Properties = new Property[40];

            // propertyler içine koyulacak tam düzgün
            for(int i = 0, j = 0; i < 40; i++)
            {
                if (propertyMapBool[i])
                {
                    Properties[i] = pc.properties[j++];
                }
            }
            

        }

        public static void SettingsUpdate(int playerCount, Player[] players)
        {
            PlayerCount = playerCount;
            Players = players;
        }
    }
}
