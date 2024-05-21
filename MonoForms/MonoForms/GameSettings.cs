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
        public Bitmap[] imageBitmaps;
        public bool[] imageAvailability;

        public NewPlayer[] players;

        public int currentPlayerCount;
        public int startingMoney;

        public GameSettings()
        {
            InitializeComponent(); 

            imageBitmaps = new Bitmap[6];
            imageAvailability = new bool[] {true,true,true,true,true,true};

            currentPlayerCount = 0;
            /*
            imageBitmaps[0] = new Bitmap("linktoimage");
            imageBitmaps[1] = new Bitmap("linktoimage");
            imageBitmaps[2] = new Bitmap("linktoimage");
            imageBitmaps[3] = new Bitmap("linktoimage");
            imageBitmaps[4] = new Bitmap("linktoimage");
            imageBitmaps[5] = new Bitmap("linktoimage");
            */

            // 
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
            MainGame mainGameForm = new MainGame(startingMoney, currentPlayerCount);
            mainGameForm.ShowDialog();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            int topMargin = 100; // Formun üst kenarından 100 piksel aşağıdan başlat
            int rightMargin = this.ClientSize.Width - 250; // Formun sağ kenarından 250 piksel içeriden başlat

            // Mevcut kontrolleri temizle
            foreach (Control control in this.Controls.OfType<Label>().ToList())
            {
                if (control.Text.StartsWith("Oyuncu"))
                    this.Controls.Remove(control);
            }
            foreach (Control control in this.Controls.OfType<TextBox>().ToList())
            {
                if (control.Name != "textBox1") // Başlangıç parası girişini silme
                    this.Controls.Remove(control);
            }
            foreach (Control control in this.Controls.OfType<PictureBox>().ToList())
            {
                this.Controls.Remove(control);
            }


            for (int i = 1; i <= currentPlayerCount; i++)
            {
                // Label oluştur
                Label lblPlayer = new Label();
                lblPlayer.Text = "Oyuncu " + i.ToString();
                lblPlayer.Bounds = new Rectangle(rightMargin, topMargin + (i - 1) * 50, 60, 20);
                this.Controls.Add(lblPlayer);

                // TextBox oluştur (Oyuncu adı için)
                TextBox txtPlayerName = new TextBox();
                txtPlayerName.Bounds = new Rectangle(rightMargin - 120, topMargin + (i - 1) * 50, 100, 20);
                this.Controls.Add(txtPlayerName);

                // PictureBox oluştur (Resim seçimi için)
        
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
