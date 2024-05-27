using MonoForms.FormObjects;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MonoForms.Utils;

namespace MonoForms
{
    public partial class MainGame : Form
    {
        private Form previousForm;
        GameController gc;
        public MainGame(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }

        private void MainGame_Load(object sender, EventArgs e)
        {
            this.Width = Globals.APP_WIDTH;
            this.Height = Globals.APP_HEIGHT + 40;// + 40 burda yukardaki isim kısmı ve kapatma falan şeylerini dahil ettiği için

            this.FormBorderStyle = FormBorderStyle.FixedSingle;


            // game controller oluşturulur tüm işlemler burada oluşacak
            gc = new GameController();
            gc.Bounds = new Rectangle(0, 0, Globals.APP_WIDTH, Globals.APP_HEIGHT);
            this.Controls.Add(gc);
            gc.closeGame.Click += new EventHandler(closeGameEvent);
        }

        private void closeGameEvent(object sender, EventArgs e)
        {
            // Form2'yi aç
            Form1 form2 = new Form1();
            form2.Show();

            // Form1'i gizle
            this.Hide();
        }
    }
}
