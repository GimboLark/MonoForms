using MonoForms.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MonoForms.FormObjects
{
    public class GameSettingsController : Control
    {
        public Button goBack;
        public Button startGame;

        public Label playerCountlbl;
        public Label startMoney;
        public Label gameSettingsLbl;

        public TextBox startMoneyTxt;
        public ComboBox playerCountCbx;

        public List<string> playerNames = new List<string>();
        public List<string> playerPawns = new List<string>();

        public List<int> playerCountList = new List<int> {2,3,4};
        public GameSettingsController(Form1 form)
        {
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

            //Initialize startMoneyTxt TextBox
            startMoneyTxt = new TextBox();
            startMoneyTxt.Name = "startMoneyTxt";
            startMoneyTxt.Text = "1500";
            startMoneyTxt.Bounds = new Rectangle(130,170,90,40);
            this.Controls.Add(startMoneyTxt);

            //Initialize startMoney label
            startMoney = new Label();
            startMoney.Text = "Başlangıç Parası";
            startMoney.Bounds = new Rectangle(20, 170, 100, 25);
            startMoney.Font = new Font(startMoney.Font.FontFamily, 8f, FontStyle.Regular);
            startMoney.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(startMoney);

            //Initialize playerCount label
            playerCountlbl = new Label();
            playerCountlbl.Text = "Oyuncu Sayısı";
            playerCountlbl.Name = "playerCount";
            playerCountlbl.Bounds = new Rectangle(20, 130, 100, 25);
            playerCountlbl.Font = new Font(playerCountlbl.Font.FontFamily, 8f, FontStyle.Regular);
            playerCountlbl.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(playerCountlbl);

            //Initialize gameSettings label
            gameSettingsLbl = new Label();
            gameSettingsLbl.Text = "Ayarlar";
            gameSettingsLbl.Name = "Settings";
            gameSettingsLbl.Bounds = new Rectangle(230, 20, 100, 25);
            gameSettingsLbl.Font = new Font(gameSettingsLbl.Font.FontFamily, 12f, FontStyle.Bold);
            gameSettingsLbl.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(gameSettingsLbl);

            //Initialize playerCountCbx Cbx
            playerCountCbx = new ComboBox();
            playerCountCbx.Bounds = new Rectangle(130, 135, 90, 40);
            playerCountCbx.DataSource = playerCountList;
            playerCountCbx.Name = "playerCount";
            playerCountCbx.SelectedIndexChanged += new EventHandler(playerCountChanged);
            this.Controls.Add(playerCountCbx);
        }

        private void playerCountChanged(object sender, EventArgs e)
        {
            // seçilen oyuncu sayısı değiştiğinde
            if (playerCountCbx.SelectedItem != null)
            {
                // Convert.ToInt32 kullanarak seçilen öğeyi int'e dönüştürme
                int currentPlayerCount = Convert.ToInt32(playerCountCbx.SelectedItem);
                CreatePlayerControls(currentPlayerCount);
            }
        }

        private void goBackClick(object sender, EventArgs e)
        {
            // GameSettingsController'ın bulunduğu formu kapat
            GameSettings gameSettings = this.FindForm() as GameSettings;
            gameSettings?.Close();

            Form1 Form1 = new Form1();
            Form1.Show();
        }

        public void ClearExistingControls()
        {
            var controlsToRemove = this.Controls.OfType<Control>()
                .Where(c => c is Label lbl && lbl.Text.StartsWith("Oyuncu") && lbl.Name != "playerCount" ||
                            c is TextBox txt && txt.Name != "startMoneyTxt" ||
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
            cbxPawn.SelectedIndex = 0;
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
            try
            {
                int playerCount = Globals.PlayerCount;
                if (playerNames.Count == playerCount && playerPawns.Count == playerCount && playerCount != 0)
                {
                    int startMoney = Convert.ToInt32(startMoneyTxt.Text);
                    Globals.STARTING_MONEY = startMoney;
                    Globals.Players = new Player[playerCount];


                    for (int i = 0; i < playerCount; i++)
                    {
                        Player player = new Player(playerNames[i], playerPawns[i], i);
                        Globals.Players[i] = player;
                    }
                    // GameSettingsController'ın bulunduğu formu kapat
                    GameSettings gameSettings = this.FindForm() as GameSettings;
                    gameSettings?.Close();

                    MainGame mainGameForm = new MainGame(gameSettings);
                    mainGameForm.Show();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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