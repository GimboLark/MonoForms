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
            currentPlayerCount = (int) playerCount.SelectedItem;
            
            
        }

        private void lblPlayerCount_Click(object sender, EventArgs e)
        {

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            new MainGame().ShowDialog();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
