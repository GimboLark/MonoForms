using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monoforms.Entities.Models
{
    public class RegularDie : Die
    {
        private static RegularDie _instance;

        private RegularDie()
        {
        }

        public static RegularDie GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RegularDie();
            }
            return _instance;
        }

        public void Roll()
        {
            Roll(2);
        }
    }
}
