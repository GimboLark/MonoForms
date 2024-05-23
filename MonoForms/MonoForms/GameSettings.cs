using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonoForms.Utils;

namespace MonoForms
{
    
    

    partial class GameSettings : Form
    {
        private Form previousForm;
        public Bitmap[] imageBitmaps;
        public bool[] imageAvailability;

        public NewPlayer[] players;

        public int currentPlayerCount;
        public int startingMoney;

        public GameSettings(Form previousForm)
        {
            InitializeComponent();

            //imageBitmaps = new Bitmap[6];
            //imageAvailability = new bool[] {true,true,true,true,true,true};

            //currentPlayerCount = 0;
            ///*
            //imageBitmaps[0] = new Bitmap("linktoimage");
            //imageBitmaps[1] = new Bitmap("linktoimage");
            //imageBitmaps[2] = new Bitmap("linktoimage");
            //imageBitmaps[3] = new Bitmap("linktoimage");
            //imageBitmaps[4] = new Bitmap("linktoimage");
            //imageBitmaps[5] = new Bitmap("linktoimage");
            //*/

            //// 
            ///private Form previousForm;
            this.previousForm = previousForm;
        }

        private void playerCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            // seçilen oyuncu sayısı değiştiğinde
            if (playerCount.SelectedItem != null)
            {
                // Convert.ToInt32 kullanarak seçilen öğeyi int'e dönüştürme
                currentPlayerCount = Convert.ToInt32(playerCount.SelectedItem);
                CreatePlayerControls(currentPlayerCount);
                Console.WriteLine("Seçilen oyuncu sayısı: " + currentPlayerCount);
            } 
            
        }

        private void lblPlayerCount_Click(object sender, EventArgs e)
        {

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            // Form2'yi aç
            MainGame form2 = new MainGame(this);
            form2.Show();

            // Form1'i gizle
            this.Hide();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Form1 form2 = new Form1();
            form2.Show();

            // Form1'i gizle
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (int.TryParse(textBox1.Text, out parsedValue))
            {
                startingMoney = parsedValue;
            }
            else
            {
                // Kullanıcı doğru bir tam sayı girmedikçe bir uyarı mesajı göster
                MessageBox.Show("Lütfen geçerli bir tam sayı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreatePlayerControls(int currentPlayerCount)
        {
            List<string> pawns = new List<string> { "Ayakkabı", "Araba", "Şapka", "Ütü", "Rende", "Gemi" };
            int topMargin = 100;
            int rightMargin = this.ClientSize.Width - 350;

            Label pawnType = new Label
            {
                Text = "Piyon Seçiniz",
                Bounds = new Rectangle(rightMargin + 250, topMargin - 25, 80, 20)
            };
            this.Controls.Add(pawnType);

            ClearExistingControls();

            for (int i = 1; i <= currentPlayerCount; i++)
            {
                AddPlayerControls(i, rightMargin, topMargin, pawns);
            }
        }

        private void ClearExistingControls()
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

        private void AddPlayerControls(int playerIndex, int rightMargin, int topMargin, List<string> pawns)
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

        private void UpdatePawnImage(ComboBox cbxPawn, int playerIndex)
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

        private void GameSettings_Load(object sender, EventArgs e)
        {

        }
    }

    public class NewPlayer : Control
    {
        Label label;
        TextBox textbox;
        PictureBox picturebox;

        public int index;

        public NewPlayer(int sıra) {

            label = new Label();
            label.Text = sıra.ToString();
            label.Bounds = new Rectangle(10,10,20,20);

            textbox = new TextBox();
            textbox.Bounds = new Rectangle(40, 10, 80, 20);
            
            picturebox = new PictureBox();
            picturebox.Bounds = new Rectangle(130, 5, 30 ,30);
            picturebox.Click += new EventHandler(UpdateImage);

            this.Controls.Add(label);
            this.Controls.Add(textbox);
            this.Controls.Add(picturebox);
        }

        public void UpdateImage(object sender, EventArgs e) {
            // 6 images 

            // get un used images
            

        }
    }
}
