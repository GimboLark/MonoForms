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
        public Label resultLabel1;
        public Label resultLabel2;
        public Random random;

        public Dice(GameController controller)
        {
            parentController = controller;
            random = new Random();

            // Roll button
            rollButton = new Button();
            rollButton.Text = "Roll Dice";
            rollButton.Bounds = new Rectangle(10, 10, 80, 25); // Top-left corner within Dice control
            rollButton.Click += new EventHandler(RollDice_Click);

            // Result labels
            resultLabel1 = new Label();
            resultLabel1.Text = "Dice 1: ";
            resultLabel1.Bounds = new Rectangle(10, 45, 80, 25); // Below the roll button

            resultLabel2 = new Label();
            resultLabel2.Text = "Dice 2: ";
            resultLabel2.Bounds = new Rectangle(10, 70, 80, 25); // Below the first result label

            this.Controls.Add(rollButton);
            this.Controls.Add(resultLabel1);
            this.Controls.Add(resultLabel2);
        }

        public void RollDice_Click(object sender, EventArgs e)
        {
            int rollResult1 = random.Next(1, 7); // 1 to 6
            int rollResult2 = random.Next(1, 7); // 1 to 6
            resultLabel1.Text = "Dice 1: " + rollResult1.ToString();
            resultLabel2.Text = "Dice 2: " + rollResult2.ToString();

            parentController.SonrakiTuraGecilebilir = true;
            parentController.nextRound.BackColor = Color.Green;

            int totalRollResult = rollResult1 + rollResult2;
            UpdatePlayerPosition(totalRollResult);
        }

        public void UpdatePlayerPosition(int rollResult)
        {
            // Get the current player
            Player currentPlayer = Globals.Players[parentController.sıra];

            // Update the player's position
            currentPlayer.position = (currentPlayer.position + rollResult) % Globals.positions.Length;

            // Update the pawn positions
            parentController.PawnUpdate();
        }
    }
}
