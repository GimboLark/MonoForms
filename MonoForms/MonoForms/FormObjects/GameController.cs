using System.Windows.Forms;
using System.Drawing;
using MonoForms.Utils;
using System;

namespace MonoForms.FormObjects
{
    // tüm oyunu yürüten game controller objesi
    public class GameController : Control
    {
        // image for the game board
        public PictureBox gameBoard;

        // zar control objesi
        public Dice dice;

        // sonraki tur butonu
        public Button nextRound;
        public Button closeGame;

        // kişilerin sırasını tuttsun
        public int sıra;

        // hamlenin düzgün tamamlanmadığını içerir
        // true olunca butonun rengi değişebilir
        public bool SonrakiTuraGecilebilir;

        public PlayerPawn[] pawns;

        public GameController()
        {

            // intilize nextRound button
            nextRound = new Button();
            nextRound.Text = "Next Round";
            nextRound.Bounds = new Rectangle(Globals.APP_WIDTH - 100, Globals.APP_HEIGHT - 55, 80, 25);

            this.Controls.Add(nextRound);

            // intilize closeGame button
            closeGame = new Button();
            closeGame.Text = "Close Game";
            closeGame.Bounds = new Rectangle(Globals.APP_WIDTH - 100, Globals.APP_HEIGHT - 35, 80, 25);
            closeGame.ForeColor = Color.White;
            closeGame.BackColor = Color.Red;

            this.Controls.Add(closeGame);


            // intilize gameboard background
            gameBoard = new PictureBox();
            gameBoard.BackgroundImage = Image.FromFile("../../Assets/board.jpg");
            gameBoard.BackgroundImageLayout = ImageLayout.Stretch;
            gameBoard.Bounds = new Rectangle(0, 0, Globals.APP_HEIGHT, Globals.APP_HEIGHT);

            // initlize dice 
            dice = new Dice(this);
            dice.Bounds = new Rectangle(800, 50, 110, 90);
            dice.BackColor = Color.Khaki;

            this.Controls.Add(dice);



            // init Pawns and update them once to set positions

            /*
            PawnInit();
            PawnUpdate();
            */

            // test pawn start
            Player player1 = new Player("name", "Ayakkabı", 0);
            Player player2 = new Player("name", "Gemi", 1);
            Player player3 = new Player("name", "Rende", 2);
            Player player4 = new Player("name", "Şapka", 3);

            Player[] players = new Player[] { player1, player2, player3, player4 };


            PlayerPawn pp1 = new PlayerPawn(player1);
            PlayerPawn pp2 = new PlayerPawn(player2);
            PlayerPawn pp3 = new PlayerPawn(player3);
            PlayerPawn pp4 = new PlayerPawn(player4);

            PlayerPawn[] pps = new PlayerPawn[] {pp1,pp2,pp3, pp4};

            int i = 0;

            foreach (PlayerPawn pp in pps)
            {
                int position = 10;

                int x = (int)((float)Globals.positions[position].Item1 / 1024 * 720) + Globals.offsets[players[i].turn].Item1;
                int y = (int)((float)Globals.positions[position].Item2 / 1024 * 720) + Globals.offsets[players[i++].turn].Item2;

                pp.Bounds = new Rectangle(x, y, 20, 20);

                if (i == 0)
                    pp.BackColor = Color.Red;
                if (i == 1)
                    pp.BackColor = Color.Yellow;
                if (i == 2)
                    pp.BackColor = Color.Blue;
                if (i == 3)
                    pp.BackColor = Color.Green;

                this.Controls.Add(pp);

            }
            // test pawn end


            // en altta olması için en son eklenmeli
            this.Controls.Add(gameBoard);

        }


        // pawns değerini günceller
        public void PawnInit()
        {
            for (int i = 0; i < Globals.PlayerCount; i++)
            {
                PlayerPawn pp = new PlayerPawn(Globals.Players[i]);

                pawns[i] = pp;

                this.Controls.Add(pawns[i]);
            }
        }

        public void NextRound_Click(object sender, EventArgs e)
        {
            if (SonrakiTuraGecilebilir)
            {
                sıra = (sıra + 1) % pawns.Length;
                SonrakiTuraGecilebilir = false;
                nextRound.BackColor = DefaultBackColor;
            }
            else
            {
                MessageBox.Show("Bir sonraki tura geçebilmek için hamleni yapman lazım");
            }
        }

        // updates pawns positions
        public void PawnUpdate()
        {
            int x, y, position;
            for (int i = 0; i < Globals.PlayerCount; i++)
            {
                position = Globals.Players[i].position;

                x = Globals.positions[position].Item1 + Globals.offsets[i].Item1;
                y = Globals.positions[position].Item2 + Globals.offsets[i].Item2;

                pawns[i].Bounds = new Rectangle(x,y,20,20);
            }
        }
    }

}
