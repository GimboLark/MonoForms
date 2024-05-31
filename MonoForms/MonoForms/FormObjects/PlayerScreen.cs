using System.Windows.Forms;
using System.Drawing;
using MonoForms.Utils;

namespace MonoForms.FormObjects
{
    /// <summary>
    /// Player sayısı kadar playerlerin parasının ve adının gözüktüğü kısım
    /// Jail durumu ve aktif oyuncuyuda gösterir
    /// </summary>
    public class PlayerScreen : Control
    {
        public const int WIDTH = 10 + (PlayerScreenPart.WIDTH + 10) * 4;
        public const int HEIGHT = 10 + PlayerScreenPart.HEIGHT;

        public GameController parentController;

        public PlayerScreenPart[] playerScreenParts;


        public PlayerScreen(GameController gc)
        {
            
            this.BackColor = Color.DarkSlateGray;

            parentController = gc;

            playerScreenParts = new PlayerScreenPart[Globals.PlayerCount];

            for(int i = 0; i < Globals.PlayerCount; i++)
            {
                playerScreenParts[i] = new PlayerScreenPart(Globals.Players[i],this);

                playerScreenParts[i].Bounds = new Rectangle(5 + i * ( PlayerScreenPart.WIDTH + 10 ), 5, PlayerScreenPart.WIDTH, PlayerScreenPart.HEIGHT);

                this.Controls.Add(playerScreenParts[i]);
            }

        }
        

        /// <summary>
        /// Updates all player screen parts
        /// </summary>
        public void Update()
        {
            for (int i = 0; i < Globals.PlayerCount; i++)
            {
                if(parentController.turn == i)
                    playerScreenParts[i].Update(true);
                else
                    playerScreenParts[i].Update();
            }
        }

        /// <summary>
        /// Updates selected player screen parts
        /// </summary>
        public void Update(int playerIndex)
        {
            if (parentController.turn == playerIndex)
                playerScreenParts[playerIndex].Update(true);
            else
                playerScreenParts[playerIndex].Update();
        }
    }

    public class PlayerScreenPart : Control
    {
        public const int LABEL_WIDTH = 80;
        public const int LABEL_HEIGHT = 25;

        public const int WIDTH = LABEL_WIDTH + 20;
        public const int HEIGHT = 5 * 3 + LABEL_HEIGHT * 2;


        public Player player;
        public PlayerScreen parent;

        public Label nameLabel;
        public Label moneyLabel;

        public PictureBox jailBars;

        public PlayerScreenPart(Player player, PlayerScreen parent)
        {
            // should be uptop 
            
            this.player = player;
            this.parent = parent;

            // name label init
            nameLabel = new Label();
            nameLabel.Text = player.name;
            nameLabel.BackColor = Color.Transparent;
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;

            nameLabel.Font = new Font(nameLabel.Font.FontFamily, 12f, FontStyle.Bold);
            //nameLabel.Font.Bold = true;

            nameLabel.Bounds = new Rectangle(10, 5, WIDTH - 20, 25);

            this.Controls.Add(nameLabel);

            // money label init
            moneyLabel = new Label();
            moneyLabel.BackColor = Color.Transparent;
            moneyLabel.Font = new Font(moneyLabel.Font.FontFamily, 16f, moneyLabel.Font.Style);
            moneyLabel.TextAlign = ContentAlignment.MiddleCenter;

            string moneystr = string.Format("{0} $", player.money.ToString());
            moneyLabel.Text = moneystr;
            moneyLabel.Bounds = new Rectangle(10, 30, WIDTH - 20, 25);

            this.Controls.Add(moneyLabel);


            jailBars = new PictureBox();
            jailBars.BackColor = Color.Transparent;
            jailBars.Bounds = new Rectangle(0, 0, WIDTH, HEIGHT);
            jailBars.Image = Image.FromFile($"../../Assets/bars.png");
            jailBars.BackgroundImageLayout = ImageLayout.Stretch;
            jailBars.Hide();
            this.Controls.Add(jailBars);


            // set color
            if (player.turn == 0)
                this.BackColor = Color.OrangeRed;
            if (player.turn == 1)
                this.BackColor = Color.CornflowerBlue;
            if (player.turn == 2)
                this.BackColor = Color.LightGoldenrodYellow;
            if (player.turn == 3)
                this.BackColor = Color.GreenYellow;

        }

        public void Update(bool IsTurnPlayer = false)
        {
            string moneystr = string.Format("{0} $", player.money.ToString());
            moneyLabel.Text = moneystr;

            // if in jail show this
            if(player.IN_JAIL)
                jailBars.Show();
            else
                jailBars.Hide();

           if(IsTurnPlayer)
           {
                if (player.turn == 0)
                    this.BackColor = Color.OrangeRed;
                if (player.turn == 1)
                    this.BackColor = Color.CornflowerBlue;
                if (player.turn == 2)
                    this.BackColor = Color.LightGoldenrodYellow;
                if (player.turn == 3)
                    this.BackColor = Color.GreenYellow;
           }
           else
           {
                if (player.turn == 0)
                    this.BackColor = Color.FromArgb(99, 72, 72);
                if (player.turn == 1)
                    this.BackColor = Color.FromArgb(72, 78, 99);
                if (player.turn == 2)
                    this.BackColor = Color.FromArgb(99, 94, 72);
                if (player.turn == 3)
                    this.BackColor = Color.FromArgb(72, 99, 72);
            }

        }
    }

}
