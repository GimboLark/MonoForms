using System;
using System.Drawing;
using System.Windows.Forms;

namespace MonoForms
{
    public partial class MainGame : Form
    {
        private int startingMoney;
        private int playerCount;
        private Random random = new Random();

        // Dinamik olarak oluşturulacak kontroller
        private Button buttonZarAt;
        private PictureBox pictureBoxZar1;
        private PictureBox pictureBoxZar2;
        private Label labelTotal;

        public MainGame(int startingMoney, int playerCount)
        {
            this.startingMoney = startingMoney;
            this.playerCount = playerCount;

            // Initialize the form and controls
            InitializeComponent();
            InitializeDynamicControls();
        }

        private void InitializeDynamicControls()
        {
            // Form ayarları
            this.Text = "MonoForms";
            this.Size = new Size(400, 300);

            // Button oluşturma ve ayarlama
            buttonZarAt = new Button();
            buttonZarAt.Text = "Zar At";
            buttonZarAt.Size = new Size(100, 50);
            buttonZarAt.Location = new Point(150, 200);
            buttonZarAt.Click += new EventHandler(buttonZarAt_Click);

            // İlk PictureBox oluşturma ve ayarlama
            pictureBoxZar1 = new PictureBox();
            pictureBoxZar1.Size = new Size(50, 50);
            pictureBoxZar1.Location = new Point(100, 100);
            pictureBoxZar1.BorderStyle = BorderStyle.FixedSingle;

            // İkinci PictureBox oluşturma ve ayarlama
            pictureBoxZar2 = new PictureBox();
            pictureBoxZar2.Size = new Size(50, 50);
            pictureBoxZar2.Location = new Point(200, 100);
            pictureBoxZar2.BorderStyle = BorderStyle.FixedSingle;

            // Label oluşturma ve ayarlama
            labelTotal = new Label();
            labelTotal.Size = new Size(100, 20);
            labelTotal.Location = new Point(150, 160);
            labelTotal.Text = "Toplam: ";

            // Kontrolleri forma ekleme
            this.Controls.Add(buttonZarAt);
            this.Controls.Add(pictureBoxZar1);
            this.Controls.Add(pictureBoxZar2);
            this.Controls.Add(labelTotal);
        }

        private void buttonZarAt_Click(object sender, EventArgs e)
        {
            // Zar atma butonu tıklandığında çalışacak kodlar
            int die1 = random.Next(1, 7); // 1 ile 6 arası rastgele sayı
            int die2 = random.Next(1, 7); // 1 ile 6 arası rastgele sayı

            // Zarların resimlerini ayarlar
            pictureBoxZar1.Image = Image.FromFile($"D:/görsel programlama/MonoForms/MonoForms/MonoForms/Assets/Die/die{die1}.jpg");
            pictureBoxZar2.Image = Image.FromFile($"D:/görsel programlama/MonoForms/MonoForms/MonoForms/Assets/Die/die{die2}.jpg");

            // Zarların toplamını hesapla ve göster
            int total = die1 + die2;
            labelTotal.Text = $"Toplam: {total}";
        }

        private void MainGame_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler buraya yazılır
        }
    }
}
