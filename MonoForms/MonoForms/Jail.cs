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
        public Jail(GameController gameController)
        {
            Controller = gameController;
            InitializeComponent();
        }

        private void Jail_Load(object sender, EventArgs e)
        {
            Button button1 = new Button();
            button1.Text = "Zar Atın";
            button1.Size = new Size(100, 50); // Buton boyutunu ayarla
            button1.Location = new Point(50, 50); // Buton konumunu ayarla
            button1.Click += new EventHandler(Button1_Click);
            this.Controls.Add(button1);

            // Buton2 oluştur ve ayarla
            Button button2 = new Button();
            button2.Text = "$250 Ödeyin";
            button2.Size = new Size(100, 50); // Buton boyutunu ayarla
            button2.Location = new Point(50, 120); // Buton konumunu ayarla
            button2.Click += new EventHandler(Button2_Click);
            this.Controls.Add(button2);

            Button button3 = new Button();
            button3.Text = "Şans Kartını Kullan";
            button3.Size = new Size(100, 50);
            button3.Location = new Point(50, 190);
            if (Globals.Players[Controller.turn].hasEscapeFromJailCard)
                button3.Visible = true;
            button3.Click += new EventHandler(Button3_Click);
            this.Controls.Add(button3);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Zar At butonuna tıklandığında yapılacak işlemler
            Dice dice = new Dice(Controller);
            if (dice.isRollButtonClicked)
            {
                if (dice.result1 == dice.result2)
                {
                    MessageBox.Show("Aynı geldi");
                    Globals.Players[Controller.turn].IN_JAIL = false;
                    Controller.UpdatePlayerPosition(dice.result1 + dice.result2);
                    Controller.SonrakiTuraGecilebilir = true;
                }
                else
                {
                    Controller.SonrakiTuraGecilebilir = true;
                    Globals.Players[Controller.turn].jailCounter -= 1;
                    if (Globals.Players[Controller.turn].jailCounter == 0)
                        Globals.Players[Controller.turn].IN_JAIL = false;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Dice dice = new Dice(Controller);
            if (dice.isRollButtonClicked) 
            { 
                Globals.Players[Controller.turn].IN_JAIL = false;
                Globals.Players[Controller.turn].money -= 250;
                Globals.Players[Controller.turn].jailCounter = 0;
                Controller.UpdatePlayerPosition(dice.result1+dice.result2);
                Controller.SonrakiTuraGecilebilir = true;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Dice dice = new Dice(Controller); 
            if (dice.isRollButtonClicked)
            {
                Globals.Players[Controller.turn].IN_JAIL = false;
                Globals.Players[Controller.turn].hasEscapeFromJailCard = false;
                Globals.Players[Controller.turn].jailCounter = 0;
                Controller.UpdatePlayerPosition(dice.result1 + dice.result2);
                Controller.SonrakiTuraGecilebilir = true;
            }
        }
    }
}
