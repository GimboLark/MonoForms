public class NewPlayer : Control
    {
        Label label;
        TextBox textbox;
        PictureBox picturebox;

        public NewPlayer(int s�ra) {

            label = new Label();
            label.Text = s�ra.ToString();
            label.Bounds = new Rectangle(5,5,20,20);

            textbox = new TextBox();
            textbox.Bounds = new Rectangle(30, 5, 80, 20);
            
            picturebox = new PictureBox();
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