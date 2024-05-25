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
    public class GameSettingsController : Control
    {
        public Button goBack;
        public Button startGame;

        public Label playerCount;
        public Label startMoney;

        public TextBox startMoneyTxt;

        Form1 form1;
        GameSettings gameSettings;

        public List<string> playerNames = new List<string>();
        public List<string> playerPawns = new List<string>();

        public List<int> playerCountList = new List<int> {2,3,4};
        public GameSettingsController(Form1 form)
        {
            form1 = form;
            // Initialize goBack Button
            goBack = new Button();
            goBack.BackgroundImage = Image.FromFile("../../Assets/goback.png");
            goBack.BackgroundImageLayout = ImageLayout.Stretch;
            goBack.Bounds = new Rectangle(30,20,30,20);
            goBack.Click += new EventHandler(goBackClick);
            this.Controls.Add(goBack);

            // Initialize startGame Button
            startGame = new Button();
            startGame.BackColor = Color.Green;
            startGame.ForeColor = Color.White;
            startGame.Text = "Oyuna Başla";
            startGame.Bounds = new Rectangle(220, 300, 155, 50);
            startGame.Click += new EventHandler(startGameClick);
            this.Controls.Add(startGame);
        }

        private void goBackClick(object sender, EventArgs e)
        {
            form1 = new Form1();
            form1.Show();
            this.Hide();
        }

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
            Globals.PlayerCount = currentPlayerCount;
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
                Name = "txtPlayerName" + playerIndex,
                Bounds = new Rectangle(rightMargin + 70, topMargin + (playerIndex - 1) * 50, 100, 20)
            };
            txtPlayerName.Leave += (sender, e) => 
            {
                UpdatePlayerName(txtPlayerName,playerIndex);
            };
            this.Controls.Add(txtPlayerName);

            ComboBox cbxPawn = new ComboBox
            {
                Bounds = new Rectangle(rightMargin + 200, topMargin + (playerIndex - 1) * 50, 75, 20),
                DataSource = new List<string>(pawns),
                Name = "comboBox" + playerIndex
            };
            cbxPawn.SelectedIndexChanged += (sender, e) => {
                playerPawns.Add(cbxPawn.SelectedValue.ToString());
                UpdatePawnImage(cbxPawn, playerIndex);
            };
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
        public void startGameClick(object sender, EventArgs e)
        {
            int playerCount = Globals.PlayerCount;
            Globals.Players = new Player[playerCount];

            for (int i = 0; i < playerCount; i++)
            {
                Player player = new Player(playerNames[i], playerPawns[i],i);
                Globals.Players[i] = player;
            }

            gameSettings = new GameSettings(form1);
            MainGame mainGame = new MainGame(gameSettings);
            mainGame.Show();

            gameSettings.Close();
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
        public void UpdatePlayerName(TextBox textBox,int playerIndex)
        {
            string selectedPawn = textBox.Text;
            
            TextBox text = this.Controls.OfType<TextBox>().FirstOrDefault(p => p.Name == $"txtPlayerName{playerIndex}");

            if (text != null)
            {
                playerNames.Add(text.Text);
                text.Refresh();
            }
        }
    }
}