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

        public int currentPlayerCount;
        public int startingMoney;

        GameSettingsController controller;
        Form1 form1;

        public GameSettings(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }
        private void GameSettings_Load(object sender, EventArgs e)
        {
            this.Width = Globals.SETTINGS_WIDTH / 2;
            this.Height = Globals.SETTINGS_HEIGHT / 2 + 40;

            // game settings controller oluşturulur tüm işlemler burada oluşacak
            controller = new GameSettingsController(form1);
            controller.Bounds = new Rectangle(0, 0, Globals.SETTINGS_WIDTH / 2, Globals.SETTINGS_HEIGHT / 2);
            controller.BackgroundImage = Image.FromFile("../../Assets/background2.jpg");
            controller.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(controller);
        }
    }
}
