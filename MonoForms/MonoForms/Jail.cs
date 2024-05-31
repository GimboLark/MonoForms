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
    public partial class Jail : Form
    {
        public GameController Controller;

        JailDice jailDice;
        Button PayButton = new Button();
        Button UseLuckCard = new Button();


        public Jail(GameController gameController)
        {
            Controller = gameController;
            InitializeComponent();
        }

        private void Jail_Load(object sender, EventArgs e)
        {

            JailDice jd = new JailDice(Controller);
            jd.Bounds = new Rectangle(20, 20, 120, 100);
            jd.BackColor = Color.Chartreuse;
            this.Controls.Add(jd);

            // Ödeme Butonunu ayarla

            PayButton.Text = string.Format("{0}$ Öde",Globals.JAIL_PRICE);
            PayButton.Size = new Size(100, 50); // Buton boyutunu ayarla
            PayButton.Location = new Point(20, 130); // Buton konumunu ayarla
            PayButton.Click += new EventHandler(Button2_Click);
            if (Globals.Players[Controller.turn].money < Globals.JAIL_PRICE)
                PayButton.Enabled = false;
            this.Controls.Add(PayButton);

            Console.WriteLine("JAIL_LOAD PLAYER HAS ESCAPE FROM JAIL CARD {0}", Globals.Players[Controller.turn].hasEscapeFromJailCard);


            Button button3 = new Button();
            button3.Text = "Şans Kartını Kullan";
            button3.Size = new Size(100, 50);
            button3.Location = new Point(20, 190);
            if (!Globals.Players[Controller.turn].hasEscapeFromJailCard)
                button3.Enabled = false;
            button3.Click += new EventHandler(Button3_Click);
            this.Controls.Add(button3);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Globals.Players[Controller.turn].IN_JAIL = false;
            Globals.Players[Controller.turn].money -= Globals.JAIL_PRICE;
            Globals.Players[Controller.turn].jailCounter = 0;
            Controller.SonrakiTuraGecilebilir = true;
            
            // bi önceki turne verme denemesi
            Controller.turn = (Controller.turn - 1) % Globals.PlayerCount;

            Jail jail = this.FindForm() as Jail;
            jail.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Globals.Players[Controller.turn].IN_JAIL = false;
            Globals.Players[Controller.turn].money -= Globals.JAIL_PRICE;
            Globals.Players[Controller.turn].jailCounter = 0;
            Controller.SonrakiTuraGecilebilir = true;

            // bi önceki turne verme denemesi
            Controller.turn = (Controller.turn - 1) % Globals.PlayerCount;

            Jail jail = this.FindForm() as Jail;
            jail.Close();
        }
    }
}
