using MonoForms.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MonoForms.FormObjects
{
    public class UpgradeMenuController : Control
    {
        public GameController gc;

        public Label[] PropertyNames;
        public Button[] UpgradeButtons;

        public int currentPosition;
        public Property currentProperty;

        public List<int> groupMembers;

        public UpgradeMenuController(GameController gc, List<int> groupMembers)
        {
            Console.WriteLine("UPGRADE MENU CONTROLLER CALLED");

            this.gc = gc;
            this.groupMembers = groupMembers;

            currentPosition = Globals.Players[gc.turn].position;
            currentProperty = Globals.Properties[currentPosition];

            PropertyNames = new Label[groupMembers.Count];
            UpgradeButtons = new Button[groupMembers.Count];

            for (int i = 0; i < groupMembers.Count; i++)
            {
                Console.WriteLine("i = {0}",i);
                PropertyNames[i] = new Label();
                PropertyNames[i].Text = Globals.Properties[groupMembers[i]].nameUpdated;
                PropertyNames[i].Bounds = new Rectangle(i * 130, 20, 120, 40);

                UpgradeButtons[i] = new Button();

                int upgradeCost = 0;

                if (Globals.Properties[groupMembers[i]].upgradeLevel < 4)
                {
                    upgradeCost = Globals.Properties[groupMembers[i]].house_cost;
                    UpgradeButtons[i].Text = String.Format("UPGRADE {0}$", upgradeCost);

                }
                else if (Globals.Properties[groupMembers[i]].upgradeLevel == 4)
                {
                    upgradeCost = Globals.Properties[groupMembers[i]].hotel_cost;
                    UpgradeButtons[i].Text = String.Format("UPGRADE {0}$", upgradeCost);
                }
                else
                {
                    UpgradeButtons[i].Text = "UPGRADED";
                    UpgradeButtons[i].Enabled = false;
                }

                if (Globals.Players[gc.turn].money < upgradeCost)
                {
                    UpgradeButtons[i].Enabled = false;
                }


                UpgradeButtons[i].Bounds = new Rectangle(i * 130, 80, 120, 40);

                Console.WriteLine("i = {0}", i);
                UpgradeButtons[i].Click += (sender, e) => UpgradeClick(sender, e, i, upgradeCost);

            }

            this.Controls.AddRange(PropertyNames);
            this.Controls.AddRange(UpgradeButtons);

            this.BackColor = ColorTranslator.FromHtml(currentProperty.color);
        }
        
        public void UpgradeClick(object sender, EventArgs e,int index,int upgradeCost)
        {

            Console.WriteLine("UPGRADE COST OF {0} = {1}", Globals.Properties[groupMembers[index]].name, upgradeCost);

            Globals.Properties[groupMembers[index]].upgradeLevel += 1;
            Globals.Players[gc.turn].money -= upgradeCost;
            gc.playerScreen.Update();
        }

    }
}
