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
    public partial class HandlePlayerMoney : Form
    {
        public GameController Controller;
        public static DataGridView dataGridView;
        public Label playerName;

        public HandlePlayerMoney(GameController gc)
        {
            Controller = gc;
            InitializeComponent();
        }

        private void HandlePlayerMoney_Load(object sender, EventArgs e)
        {
            playerName = new Label();
            playerName.Text = Globals.Players[Controller.turn].name;
            playerName.Bounds = new Rectangle(80, 10, 150, 50);
            playerName.Font = new Font(playerName.Font.FontFamily, 12f, FontStyle.Bold);
            playerName.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(playerName);

            // initializing datagrid
            dataGridView = new DataGridView();
            dataGridView.ColumnCount = 4;
            dataGridView.Columns[0].Name = "Color";
            dataGridView.Columns[1].Name = "Property Name";
            dataGridView.Columns[2].Name = "Price";
            dataGridView.Columns[3].Name = "Upgrade Level";
            dataGridView.Bounds = new Rectangle(20, 80, 400, 200);
            dataGridView.CellClick += DataGridView_CellClick;
            this.Controls.Add(dataGridView);

            // Fill the DataGridView with sample data
            FillDataGridView();

            // Update cell colors
            UpdateCellColors();
        }

        private void FillDataGridView()
        {
            foreach (var property in Globals.Properties)
            {
                int rowIndex = dataGridView.Rows.Add();
                dataGridView.Rows[rowIndex].Cells[0].Value = property.color;
                dataGridView.Rows[rowIndex].Cells[1].Value = property.name;
                dataGridView.Rows[rowIndex].Cells[2].Value = property.price;
                dataGridView.Rows[rowIndex].Cells[3].Value = property.upgradeLevel;
            }
        }

        private void UpdateCellColors()
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                string colorStr = Globals.Properties[Globals.Players[Controller.turn].position].color;
                dataGridView.Rows[i].Cells[0].Style.BackColor = ColorTranslator.FromHtml(colorStr);
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Remove previous button if it exists
            var previousButton = this.Controls.OfType<Button>().FirstOrDefault(btn => btn.Name == "SatButton");
            if (previousButton != null)
            {
                this.Controls.Remove(previousButton);
            }

            // Create new button next to the clicked cell
            Button button = new Button();
            button.Name = "SatButton";
            button.BackColor = Color.Red;
            button.Bounds = new Rectangle(dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Right + 5,
                                          dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Top, 50, 25);
            button.Text = "Sat";
            button.Click += (s, ev) => SatButton_Click(s, ev, e.RowIndex);

            this.Controls.Add(button);
            button.BringToFront();
        }

        private void SatButton_Click(object sender, EventArgs e, int rowIndex)
        {
            string propertyName = dataGridView.Rows[rowIndex].Cells[1].Value.ToString();

            DialogResult result = MessageBox.Show($"{propertyName} arazisini satmak istiyor musunuz?", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int propertyPrice = Convert.ToInt32(dataGridView.Rows[rowIndex].Cells[2].Value);
                Globals.Players[Controller.turn].money += propertyPrice;
                Controller.propertyOwners[Globals.Players[Controller.turn].position] = -1;
                dataGridView.Rows.Remove(dataGridView.Rows[rowIndex]);
                MessageBox.Show($"{propertyName} satıldı!");
            }
        }
    }
}
