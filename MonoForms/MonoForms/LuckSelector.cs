using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MonoForms
{

    public class JsonRandomSelector
    {
        public List<Luck> LoadLuckFromFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            List<Luck> luckList = JsonConvert.DeserializeObject<List<Luck>>(json);
            return luckList;
        }

        public Luck GetRandomLuck(string filePath)
        {
            List<Luck> luckList = LoadLuckFromFile(filePath);
            if (luckList == null || luckList.Count == 0)
                return null;

            Random random = new Random();
            int randomIndex = random.Next(luckList.Count);
            return luckList[randomIndex];
        }
    }

    public class PositionTracker
    {
        public int currentPosition = 0;
        public int targetPosition = 15;
        public readonly JsonRandomSelector jsonRandomSelector;
        private readonly string jsonFilePath;

        public PositionTracker(string jsonFilePath)
        {
            this.jsonRandomSelector = new JsonRandomSelector();
            this.jsonFilePath = jsonFilePath;
        }

        public void MoveToPosition(int newPosition)
        {
            currentPosition = newPosition;
            if (currentPosition == targetPosition)
            {
                Luck randomLuck = jsonRandomSelector.GetRandomLuck(jsonFilePath);
                MessageBox.Show($"Name: {randomLuck.Name}\nType: {randomLuck.Type}\nPrice: {randomLuck.Price}\nText: {randomLuck.Text}");
            }
        }

    }

    public class JsonLuckSelector
    {
        public List<Luck> LoadLuckFromFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            List<Luck> luckList = JsonConvert.DeserializeObject<List<Luck>>(json);
            return luckList;
        }

        public Luck GetRandomLuck(string filePath)
        {
            List<Luck> luckList = LoadLuckFromFile(filePath);
            if (luckList == null || luckList.Count == 0)
            {
                return null;
            }

            Random random = new Random();
            int randomIndex = random.Next(luckList.Count);
            return luckList[randomIndex];
        }
    }

    public class Luck
    {
        public string Name;
        public string Type;
        public int Price;
        public string Text;
    }
}
