using System.Windows.Forms;
using System.Drawing;
using System;
using MonoForms.Utils;
using System.Collections.Generic;
using System.Data;

namespace MonoForms.FormObjects
{


    public class OwnedProperties : Control
    {
        public const int WIDTH = 480;
        public const int HEIGHT = 400;

        public GameController gc;

        public DataGridView dg;
        public int[] index = new int[Globals.PlayerCount];


        public OwnedProperties(GameController gc)
        {
            dg = new DataGridView();
            dg.Bounds = new Rectangle(0,0,WIDTH,HEIGHT);

            dg.ColumnCount = Globals.PlayerCount;
            dg.RowCount = 15;

            for (int i = 0; i < Globals.PlayerCount; i++)
            {
                dg.Columns[i].Width = 100;
                dg.Columns[i].Name = Globals.Players[i].name;
            }

            this.Controls.Add(dg);
        }

        public void AddProperty(int i ,int id)
        {
            string str = Globals.Properties[id].color;
            dg.Rows[index[i]].Cells[i].Style.BackColor = ColorTranslator.FromHtml(str);
            dg.Rows[index[i]++].Cells[i].Value = Globals.Properties[id].nameUpdated;
        }
    }
}
