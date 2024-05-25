using System.Windows.Forms;
using System.Drawing;
using System;
using MonoForms.Utils;

namespace MonoForms.FormObjects
{
    public class Dice : Control
    {
        public GameController parentController;


        public Button rollButton;

        public PictureBox pb1;
        public PictureBox pb2;

        public Random random;

        public Dice(GameController controller)
        {
            parentController = controller;
            random = new Random();

            // Roll button
            rollButton = new Button();
            rollButton.Text = "Roll Dice";
            rollButton.Bounds = new Rectangle(10, 10, 90, 25);
            rollButton.Click += new EventHandler(RollDice_Click);

            // Result labels
            pb1 = new PictureBox();
            pb1.BackgroundImage = Image.FromFile($"../../Assets/Die/die1.jpg");
            pb1.BackgroundImageLayout = ImageLayout.Stretch;
            pb1.Bounds = new Rectangle(10, 40, 40, 40); 

            pb2 = new PictureBox();
            pb2.BackgroundImage = Image.FromFile($"../../Assets/Die/die1.jpg");
            pb2.BackgroundImageLayout = ImageLayout.Stretch;
            pb2.Bounds = new Rectangle(60, 40, 40, 40);

            this.Controls.Add(rollButton);
            this.Controls.Add(pb1);
            this.Controls.Add(pb2);
        }

        public void RollDice_Click(object sender, EventArgs e)
        {
            int rollResult1 = random.Next(1, 7); // 1 to 6
            int rollResult2 = random.Next(1, 7); // 1 to 6

            pb1.BackgroundImage = Image.FromFile($"../../Assets/Die/die{rollResult1}.jpg");
            pb2.BackgroundImage = Image.FromFile($"../../Assets/Die/die{rollResult2}.jpg");

            this.Refresh();
            Parent.Refresh();
            //parentController.SonrakiTuraGecilebilir = true;
            //parentController.nextRound.BackColor = Color.Green;

            int totalRollResult = rollResult1 + rollResult2;

            // zarı atan playera rollu kaydeder
            Globals.Players[parentController.turn].NewRoll((rollResult1, rollResult2));

            //Console.WriteLine("ZAR SONUCU:  {0}",totalRollResult);
            
            parentController.timer1.Start();
            // zar sonucuna göre güncellemek için gameController update fonk çağrılır
            parentController.UpdatePlayerPosition(totalRollResult);
        }

        
    }
}
