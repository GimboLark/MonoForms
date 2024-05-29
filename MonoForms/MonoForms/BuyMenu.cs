using MonoForms.FormObjects;
using MonoForms.Utils;
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
    public partial class BuyMenu : Form
    {
        BuyMenuController controller;
        public BuyMenu()
        {
            InitializeComponent();
        }

        private void BuyMenu_Load(object sender, EventArgs e)
        {
            controller = new BuyMenuController();
            controller.Bounds = new Rectangle(0, 0, Globals.APP_WIDTH/4, Globals.APP_HEIGHT/2);
            this.Controls.Add(controller);
        }
    }
}
