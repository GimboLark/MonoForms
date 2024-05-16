using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonoForms
{
    public partial class MainGame : Form
    {
        private int startingMoney;
        private int playerCount;
        private Random random = new Random();
        public MainGame(int startingMoney, int playerCount)
        {
            InitializeComponent();
            this.startingMoney = startingMoney;
            this.playerCount = playerCount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zar atma butonu
            // İki zar için rastgele sayılar üret
            int die1 = random.Next(1, 7); // 1 ile 6 arası rastgele sayı
            int die2 = random.Next(1, 7); // 1 ile 6 arası rastgele sayı

            pictureBox2.Image = Image.FromFile($"D:/görsel programlama/MonoForms/MonoForms/MonoForms/Assets/Die/die{die1}.jpg"); // Bilgisayarımdaki dosya yolları bozuk olduğu için kendi bilgisayarımda çalışan halini ekledim.
            pictureBox3.Image = Image.FromFile($"D:/görsel programlama/MonoForms/MonoForms/MonoForms/Assets/Die/die{die2}.jpg");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //zar1 için pb
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //zar2 için pb
        }
    }
}
