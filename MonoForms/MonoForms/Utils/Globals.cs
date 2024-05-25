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
        public const int APP_WIDTH = 1280;
        public const int APP_HEIGHT = 720;

        public const int SETTINGS_WIDTH = 1280;
        public const int SETTINGS_HEIGHT = 720;

        public const string PROPERTY_PATH = "../../Data/Property.json";
        public const string LUCK_PATH = "../../Data/Luck.json";
        public const string COMMUNITY_PATH = "../../Data/Community.json";

        public static int STARTING_MONEY = 1500;

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


        // updates when init
        public static Property[] Properties;
        public static Luck[] Lucks;
        public static Community[] Communities;

        // updates from game settings
        public static int PlayerCount;
        public static Player[] Players;

        public static void Init()
        {
            PropertyCards pc = PropertyCards.FromJsonFile(PROPERTY_PATH);
            LuckCards lc = LuckCards.FromJsonFile(LUCK_PATH);
            CommunityCards cc = CommunityCards.FromJsonFile(COMMUNITY_PATH);

            Properties = pc.properties;
            Lucks = lc.lucks;
            Communities = cc.communities;
        }

        public static void SettingsUpdate(int playerCount, Player[] players)
        {
            PlayerCount = playerCount;
            Players = players;
        }
    }

}
