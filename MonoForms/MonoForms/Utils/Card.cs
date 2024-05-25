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
        public string name;

        [JsonConverter(typeof(StringEnumConverter))]
        public PropertyType type;
        public int price;
        public int mortgagePrice;

        [JsonIgnore]
        public bool IsBought;

        public int[] rents;
        // BURSA: 40 - 200 - 500 - 1800 - 3200 - 4500
        // Telekom: 40 - 100
        // Metro: 250 - 500 - 1000 - 2000

        // Jsonda servis , transport 0
        public int[] upgradePrice;
        // Json 0 olacak
        public int upgradeLevel;
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
        Move,
        GetMoney,
        LoseMoney,
        EscapePrison,
    }
    public enum CommunityType
    {
        Move,
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
