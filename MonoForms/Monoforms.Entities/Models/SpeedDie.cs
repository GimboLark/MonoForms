using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monoforms.Entities.Models
{
    public class SpeedDie : Die
    {
        private static SpeedDie _instance;

        private SpeedDie()
        {
        }

        public static SpeedDie GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SpeedDie();
            }
            return _instance;
        }

        public void Roll()
        {
            Roll(1);
        }
    }
}
