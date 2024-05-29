using MonoForms.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonoForms.FormObjects
{
    public class BuyMenuController : Control
    {
        public Property property;
        public Player player;

        public Label propertyNameLabel;
        public Label propertyPriceLabel;

        public Button backButton;

        public BuyMenuController()
        {
            // intilize backButton button
            backButton = new Button();
            backButton.Text = "Close Game";
            backButton.Bounds = new Rectangle(0, 0, 100, 40);
            backButton.ForeColor = Color.White;
            backButton.BackColor = Color.Red;
            backButton.Click += new EventHandler(backButton_Click);

            this.Controls.Add(backButton);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            BuyMenu buyMenu = this.FindForm() as BuyMenu;
            buyMenu?.Close();
        }
    }
}
