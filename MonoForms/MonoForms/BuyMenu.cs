using MonoForms.FormObjects;
using MonoForms.Utils;
using System;
using System.CodeDom;
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
        private Button buyButton;
        private Button skipButton;
        private Label cityNameLabel;
        private Label cityPriceLabel;
        private Label houseCostLabel;
        private Label hotelCostLabel;
        private Panel colorPanel;
        private Property cityData;

        BuyMenuController controller;
        GameController gc;

        public BuyMenu(GameController gc)
        {

            this.gc = gc;
            InitializeComponent();
        }

        private void BuyMenu_Load(object sender, EventArgs e)
        {
            controller = new BuyMenuController();
            controller.Bounds = new Rectangle(0, 0, Globals.APP_WIDTH/4, Globals.APP_HEIGHT/2);
            //this.Controls.Add(controller);

            this.Text = "City Form";
            this.Size = new Size(400, 300);

            Console.WriteLine(Globals.Properties == null || Globals.Properties.Length > 0);
            cityData = Globals.Properties[Globals.Players[gc.turn].position];

            // Buy Button

            buyButton = new Button();
            buyButton.Text = "Buy";
            buyButton.Location = new Point(200, 220);
            buyButton.Size = new Size(80, 30);
            buyButton.Click += BuyButton_Click;

            if ( Globals.Players[gc.turn].money < cityData.price)
            {
                buyButton.Enabled = false;
            }


            // Skip Button
            skipButton = new Button();
            skipButton.Text = "Skip";
            skipButton.Location = new Point(300, 220);
            skipButton.Size = new Size(80, 30);
            skipButton.Click += SkipButton_Click;

            // City Name Label
            cityNameLabel = new Label();
            cityNameLabel.Text = "City: " + cityData.name;
            cityNameLabel.Location = new Point(20, 20);
            cityNameLabel.Size = new Size(200, 20);

            // City Price Label
            cityPriceLabel = new Label();
            cityPriceLabel.Text = "Price: $" + cityData.price.ToString();
            cityPriceLabel.Location = new Point(20, 50);
            cityPriceLabel.Size = new Size(200, 20);

            // House Cost Label
            houseCostLabel = new Label();
            houseCostLabel.Text = "House Cost: $" + cityData.house_cost.ToString();
            houseCostLabel.Location = new Point(20, 80);
            houseCostLabel.Size = new Size(200, 20);

            // Hotel Cost Label
            hotelCostLabel = new Label();
            hotelCostLabel.Text = "Hotel Cost: $" + cityData.hotel_cost.ToString();
            hotelCostLabel.Location = new Point(20, 110);
            hotelCostLabel.Size = new Size(200, 20);

            // Color Panel
            colorPanel = new Panel();
            colorPanel.Size = new Size(100, 100);
            colorPanel.Location = new Point(20, 150);
            colorPanel.BackColor = ColorTranslator.FromHtml(cityData.color);


            // Add controls to the form
            this.Controls.Add(buyButton);
            this.Controls.Add(skipButton);
            this.Controls.Add(cityNameLabel);
            this.Controls.Add(cityPriceLabel);
            this.Controls.Add(houseCostLabel);
            this.Controls.Add(hotelCostLabel);
            this.Controls.Add(colorPanel);
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {

            MessageBox.Show("You Bought");
            Globals.Players[gc.turn].money -= cityData.price;
            gc.playerScreen.Update(gc.turn);

            gc.propertyOwners[Globals.Players[gc.turn].position] = gc.turn;

            {
                foreach (int i in gc.propertyOwners)
                {
                    Console.Write("{0} ",i);
                }
                Console.WriteLine();
            }

            Form form = FindForm() as Form;
            form.Close();

        }

        private void SkipButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Skipped");

            Form form = FindForm() as Form;
            form.Close();
        }
    }
}
