using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonoForms.FormObjects;
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

        GameSettingsController controller;

        public GameSettings(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }
        private void GameSettings_Load(object sender, EventArgs e)
        {
            this.Width = Globals.APP_WIDTH/2;
            this.Height = Globals.APP_HEIGHT / 2 + 40;

            // game settings controller oluşturulur tüm işlemler burada oluşacak
            controller = new GameSettingsController();
            controller.Bounds = new Rectangle(0, 0, Globals.APP_WIDTH/2, Globals.APP_HEIGHT/2);
            controller.BackgroundImage = Image.FromFile("../../Assets/background2.jpg");
            controller.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(controller);
        }
        private void playerCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            // seçilen oyuncu sayısı değiştiğinde
            if (playerCount.SelectedItem != null)
            {
                // Convert.ToInt32 kullanarak seçilen öğeyi int'e dönüştürme
                currentPlayerCount = Convert.ToInt32(playerCount.SelectedItem);
                controller.CreatePlayerControls(currentPlayerCount);
                Console.WriteLine("Seçilen oyuncu sayısı: " + currentPlayerCount);
            } 
            
        }

        private void lblPlayerCount_Click(object sender, EventArgs e)
        {

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            MainGame form2 = new MainGame(this);
            form2.Show();

            this.Hide();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Form1 form2 = new Form1();
            form2.Show();

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

        public void UpdateImage(object sender, EventArgs e) 
        {        

        }
    }
}
