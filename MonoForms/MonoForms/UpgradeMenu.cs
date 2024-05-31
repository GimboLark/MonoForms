using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MonoForms.FormObjects;
using MonoForms.Utils;

namespace MonoForms
{
    public partial class UpgradeMenu : Form
    {
        public UpgradeMenuController umc;

        public GameController gc;

        public List<int> groupMembers;

        public UpgradeMenu(GameController gc, List<int> groupMembers)
        {
            this.gc = gc;
            this.groupMembers = groupMembers;
            InitializeComponent();
        }

        public void UpgradeMenu_Load(object sender, EventArgs e)
        {
            Console.WriteLine("UpgradeMenu_Load()");
            umc = new UpgradeMenuController(gc,groupMembers);
            umc.Bounds = new Rectangle(0, 0, 400, 400);
            this.Controls.Add(umc);
        }
    }
}
