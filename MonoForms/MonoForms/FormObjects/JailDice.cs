using System.Windows.Forms;
using System.Drawing;
using System;
using MonoForms.Utils;

namespace MonoForms.FormObjects
{
    public class JailDice : Control
    {
        public GameController parentController;

        public int result1;
        public int result2;
        public bool isRollButtonClicked = false;

        public Button rollButton;

        public PictureBox pb1;
        public PictureBox pb2;

        public Random random;

       

        public JailDice(GameController controller)
        {
            parentController = controller;
            random = new Random();

            // Roll button
            rollButton = new Button();
            rollButton.Text = "Roll Dice";
            rollButton.Bounds = new Rectangle(0, 0, 90, 25);
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
            isRollButtonClicked = true;
            result1 = random.Next(1, 7); // 1 to 6
            result2 = random.Next(1, 7); // 1 to 6

            pb1.BackgroundImage = Image.FromFile($"../../Assets/Die/die{result1}.jpg");
            pb2.BackgroundImage = Image.FromFile($"../../Assets/Die/die{result2}.jpg");

            this.Refresh();
            Parent.Refresh();
            //parentController.SonrakiTuraGecilebilir = true;
            //parentController.nextRound.BackColor = Color.Green;

            int totalRollResult = result1 + result2;
            // zarı atan playera rollu kaydeder
            Globals.Players[parentController.turn].NewRoll((result1, result2));

            //Console.WriteLine("ZAR SONUCU:  {0}",totalRollResult);
            // JAIL EVENT
            if (result1 == result2)
            {
                MessageBox.Show("Aynı geldi");
                Globals.Players[parentController.turn].IN_JAIL = false;
                Form form = this.FindForm() as Jail;
                parentController.UpdatePlayerPosition(result1 + result2, true, form);
                parentController.SonrakiTuraGecilebilir = true;
            }
            else
            {
                MessageBox.Show("Farklı geldi");
                parentController.SonrakiTuraGecilebilir = true;
                Globals.Players[parentController.turn].jailCounter -= 1;
                if (Globals.Players[parentController.turn].jailCounter == 0)
                    Globals.Players[parentController.turn].IN_JAIL = false;

                Jail jail = this.FindForm() as Jail;
                jail?.Close();
            }
        }
    }
}
