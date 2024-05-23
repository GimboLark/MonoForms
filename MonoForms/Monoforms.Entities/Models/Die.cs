using Monoforms.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monoforms.Entities.Models
{
    public class Die : IEntity
    {
        private List<int> lastValues = new List<int>(3);
        private Random randomGen = new Random();

        public void Roll()
        {
            
        }

        public void Roll(int times)
        {
            lastValues.Clear();
            for (int k = 0; k < times; k++)
            {
                int n = randomGen.Next(1, 7);
                lastValues.Add(n);
            }
        }

        public List<int> GetLastValues()
        {
            return new List<int>(lastValues);
        }

        public void SetLastValues(List<int> list)
        {
            lastValues = new List<int>(list);
        }
    }
}
