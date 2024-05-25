using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonoForms.FormObjects
{
    public class GameSettingsController : Control
    {
        public void ClearExistingControls()
        {
            var controlsToRemove = this.Controls.OfType<Control>()
                .Where(c => c is Label lbl && lbl.Text.StartsWith("Oyuncu") ||
                            c is TextBox txt && txt.Name != "textBox1" ||
                            c is ComboBox cbx && cbx.Name != "playerCount" ||
                            c is PictureBox)
                .ToList();

            foreach (var control in controlsToRemove)
            {
                this.Controls.Remove(control);
            }
        }
        public void CreatePlayerControls(int currentPlayerCount)
        {
            List<string> pawns = new List<string> { "Ayakkabı", "Araba", "Şapka", "Ütü", "Rende", "Gemi" };
            int topMargin = 100;
            int rightMargin = this.ClientSize.Width - 380;

            Label pawnType = new Label
            {
                Text = "Piyon Seçiniz",
                Bounds = new Rectangle(rightMargin + 220, topMargin - 25, 80, 20)
            };
            this.Controls.Add(pawnType);

            ClearExistingControls();

            for (int i = 1; i <= currentPlayerCount; i++)
            {
                AddPlayerControls(i, rightMargin, topMargin, pawns);
            }
        }
        public void AddPlayerControls(int playerIndex, int rightMargin, int topMargin, List<string> pawns)
        {
            Label lblPlayer = new Label
            {
                Text = "Oyuncu " + playerIndex,
                Bounds = new Rectangle(rightMargin, topMargin + (playerIndex - 1) * 50, 60, 20)
            };
            this.Controls.Add(lblPlayer);

            TextBox txtPlayerName = new TextBox
            {
                Bounds = new Rectangle(rightMargin + 70, topMargin + (playerIndex - 1) * 50, 100, 20)
            };
            this.Controls.Add(txtPlayerName);

            ComboBox cbxPawn = new ComboBox
            {
                Bounds = new Rectangle(rightMargin + 200, topMargin + (playerIndex - 1) * 50, 75, 20),
                DataSource = new List<string>(pawns),
                Name = "comboBox" + playerIndex
            };
            cbxPawn.SelectedIndexChanged += (sender, e) => UpdatePawnImage(cbxPawn, playerIndex);
            this.Controls.Add(cbxPawn);

            PictureBox pcBox = new PictureBox
            {
                Name = "pictureBox" + playerIndex,
                Bounds = new Rectangle(rightMargin + 300, topMargin + (playerIndex - 1) * 50, 30, 30),
                BackgroundImage = Image.FromFile($"../../Assets/Pawn/Ayakkabı.png"),
                BackgroundImageLayout = ImageLayout.Stretch
            };
            this.Controls.Add(pcBox);
        }
        public void UpdatePawnImage(ComboBox cbxPawn, int playerIndex)
        {
            string selectedPawn = cbxPawn.SelectedItem.ToString();
            string imagePath = $"../../Assets/Pawn/{selectedPawn}.png";
            PictureBox pcBox = this.Controls.OfType<PictureBox>().FirstOrDefault(p => p.Name == $"pictureBox{playerIndex}");

            if (pcBox != null)
            {
                pcBox.BackgroundImage = Image.FromFile(imagePath);
                pcBox.Refresh();
            }
        }
    }
}
