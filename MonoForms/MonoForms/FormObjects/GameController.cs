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
        public int turn;

        // hamlenin düzgün tamamlanmadığını içerir
        // true olunca butonun rengi değişebilir
        public bool SonrakiTuraGecilebilir;

        public PlayerPawn[] pawns = new PlayerPawn[4];

        public PlayerScreen playerScreen;

        public Timer timer1;

        public GameController()
        {

            // intilize nextRound button
            nextRound = new Button();
            nextRound.Text = "Next Round";
            nextRound.Bounds = new Rectangle(Globals.APP_WIDTH - 100, Globals.APP_HEIGHT - 55, 80, 25);
            nextRound.Click += new EventHandler(NextRound_Click);


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
            dice.Bounds = new Rectangle(740, 200, 110, 90);
            dice.BackColor = Color.Khaki;

            this.Controls.Add(dice);


            // SETS PLAYER DATA IF ITS NULL OR WRONGLY SET
            // --------------------------------------------------------------------
            Player player1 = new Player("Player 1", "Ayakkabı", 0);
            Player player2 = new Player("Player 2", "Gemi",     1);
            Player player3 = new Player("Player 3", "Rende",    2);
            Player player4 = new Player("Player 4", "Şapka",    3);

            Player[] players = new Player[] { player1, player2, player3, player4 };

            if (Globals.Players == null || Globals.PlayerCount != Globals.Players.Length)
            {
                Globals.Players = players;
                Globals.PlayerCount = 4;

                //pawns = pps;
            }
            // --------------------------------------------------------------------

            // init Pawns and update them once
            PawnInit();
            PawnUpdate();

            // set turn to first player
            turn = 0;

            // yazyo
            SonrakiTuraGecilebilir = true;


            // init timer
            timer1 = new Timer();
            timer1.Interval = 500; // 1 sn

            // init player screen must be init after players set
            playerScreen = new PlayerScreen(this);
            playerScreen.Bounds = new Rectangle(740, 20, PlayerScreen.WIDTH, PlayerScreen.HEIGHT);
            this.Controls.Add(playerScreen);


            // en altta olması için en son eklenmeli
            this.Controls.Add(gameBoard);

        }


        // pawns değerini günceller
        public void PawnInit()
        {
            pawns = new PlayerPawn[Globals.PlayerCount];

            for (int i = 0; i < Globals.PlayerCount; i++)
            {
                //string stra = String.Format("{0} {1} {2}", Globals.Players[i].name, Globals.Players[i].imageName, Globals.Players[i].turn);
                //MessageBox.Show(stra);


                pawns[i] = new PlayerPawn(Globals.Players[i]);

                pawns[i].Bounds = new Rectangle(20, 20, 20, 20);

                if (i == 0)
                    pawns[i].BackColor = Color.Red;
                if (i == 1)
                    pawns[i].BackColor = Color.Yellow;
                if (i == 2)
                    pawns[i].BackColor = Color.Blue;
                if (i == 3)
                    pawns[i].BackColor = Color.Green;

                this.Controls.Add(pawns[i]);


            }
        }

        public void NextRound_Click(object sender, EventArgs e)
        {
            Console.WriteLine("NEXT ROUND");

            if (SonrakiTuraGecilebilir)
            {
                Console.WriteLine("SIRA {0}", (turn + 1) % 4 + 1);

                turn = (turn + 1) % 4;
                //SonrakiTuraGecilebilir = false;
                //nextRound.BackColor = DefaultBackColor;
            }
            else
            {
                //MessageBox.Show("Bir sonraki tura geçebilmek için hamleni yapman lazım");
            }
        }

        // updates pawns positions
        public void PawnUpdate()
        {
            int x, y, position;
            for (int i = 0; i < Globals.PlayerCount; i++)
            {
                position = Globals.Players[i].position;

                x = (int)((float)Globals.positions[position].Item1 / 1024 * 720) + Globals.offsets[i].Item1;
                y = (int)((float)Globals.positions[position].Item2 / 1024 * 720) + Globals.offsets[i].Item2;

                pawns[i].Bounds = new Rectangle(x,y,20,20);
            }
        }

        public void UpdatePlayerPosition(int rollResult)
        {

            int lastPosition = Globals.Players[turn].position;
            int newPosition = (Globals.Players[turn].position + rollResult) % 40;

            Globals.Players[turn].position = newPosition;

            Console.WriteLine("OLD POS {0} NEW POS {1}",lastPosition, newPosition);

            int xa = 0;
            int ya = 0;

            //int counter = 0;

            int currentStep = (lastPosition + 1) % 40;

            dice.rollButton.Enabled = false;

            // bu 1 sn yede 1 çağrılmasını sağlar
            timer1.Tick -= Timer_Tick;

            timer1.Tick += Timer_Tick;
            timer1.Start();


            void Timer_Tick(object sender, EventArgs e)
            {
                if (currentStep != (newPosition + 1) % 40)
                {
                    Console.WriteLine(currentStep);
                    int x = (int)((float)Globals.positions[currentStep].Item1 / 1024 * 720) + Globals.offsets[turn].Item1;
                    int y = (int)((float)Globals.positions[currentStep].Item2 / 1024 * 720) + Globals.offsets[turn].Item2;

                    pawns[turn].Bounds = new Rectangle(x, y, 20, 20);

                    this.Refresh();
                    currentStep = (currentStep + 1) % 40;
                }
                else
                {
                    dice.rollButton.Enabled = true;
                    timer1.Stop();
                    timer1.Tick -= Timer_Tick; // Unsubscribe event handler
                    
                }
            }

            //timer1.Stop();

            // TODO : CALL MAIN MOVE FUNCTION
            // UpdateGameState()

        }

        public void UpdateGameState()
        {
            int previousPosition = Globals.Players[turn].previousPosition;
            int currentPosition = Globals.Players[turn].position;

            // check eligibility for pass money

            if (true)
            {
                // give money
                // update visuals
            }
            else
            {
                // do nothing
            }

            // check current position
            if(true) //if 0, 10, 20 do nothing, baş,ziyaret,park
            {

            }
            else if (true) // if 30 kodes
            {

            }
            else if(true) // if 4 , 38 tax
            {

            }
            else if(true) // if kamu 2, 17, 33 ; şans 7, 22, 36
            {
                if(true) // kamu
                {

                }
                else // şans
                {

                }
            }
            else // satın alınabilir değerler
            {
                
            }

            SonrakiTuraGecilebilir = true;

            // update next round button , enable it
        }
    }

}
