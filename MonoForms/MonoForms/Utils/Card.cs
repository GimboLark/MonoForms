using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;


namespace MonoForms.Utils
{
    public enum PropertyType
    {
        Residential,
        Transport,
        Utility,
    }

    public class PropertyCards
    {
        public Property[] properties;

        public static PropertyCards FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PropertyCards>(json);
        }

        public static PropertyCards FromJsonFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return FromJson(json);
        }
    }

    public class Property
    {
        /*
        {
            "name": "Mediterranean Avenue",
            "color": "Brown",
            "category": "properties",
            "price": 60,
            "rent": [ 2, 10, 30, 90, 160, 250 ],
            "house_cost": 50,
            "hotel_cost": 50
        }
        
         */

        public string name;

        [JsonIgnore]
        public string nameUpdated
        {
            get {
                string str = name;
                if (upgradeLevel != 5)
                    for (int i = 0; i < upgradeLevel - 1; i++)
                        str += "+";
                else
                    str += "*";
                return str; 
            }
        }


        public string color;


        [JsonConverter(typeof(StringEnumConverter))]
        public PropertyType type;
        public int price;

        [JsonIgnore]
        public int mortgagePrice
        {
            get { return (int)(price * 0.6); }
        }


        [JsonIgnore]
        public bool IsBought;

        [JsonIgnore]
        public int rent
        {
            get
            {
                return rents[upgradeLevel];
            }
        }

        public int[] rents;
        // BURSA: 40 - 200 - 500 - 1800 - 3200 - 4500
        // Telekom: 40 - 100
        // Metro: 250 - 500 - 1000 - 2000

        // Jsonda servis , transport 0
        public int house_cost;
        public int hotel_cost;

        [JsonIgnore]
        public int upgradeLevel = 0;

    }

    public class LuckCards
    {
        public Luck[] lucks;

        public static LuckCards FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LuckCards>(json);
        }

        public static LuckCards FromJsonFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return FromJson(json);
        }
    }
    public class CommunityCards
    {
        public Community[] communities;
        public static CommunityCards FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CommunityCards>(json);
        }

        public static CommunityCards FromJsonFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return FromJson(json);
        }
    }

    public enum LuckType
    {
        GoToAdvance,
        GoToJail,
        GetMoney,
        LoseMoney,
        EscapePrison,
    }
    public enum CommunityType
    {
        GoToAdvance,
        GoToJail,
        GetMoney,
        LoseMoney,
    }

    public class Luck
    {
        public string name;

        [JsonConverter(typeof(StringEnumConverter))]
        public LuckType type;
        public int price;
        public string text;
    }

    public class Community
    {
        public string name;

        [JsonConverter(typeof(StringEnumConverter))]
        public CommunityType type;
        public int price;
        public string text;
    }
}
