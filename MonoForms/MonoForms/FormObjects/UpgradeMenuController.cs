using MonoForms.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonoForms.FormObjects
{
    public class UpgradeMenuController : Control
    {
        public Player player;

        


        public bool IsOwned()
        {
            if(player.ownedProperties[player.position])
                return true;
            return false;
        }
    }
}
