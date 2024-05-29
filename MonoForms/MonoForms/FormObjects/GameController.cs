﻿using System.Windows.Forms;
using System.Drawing;
using MonoForms.Utils;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

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
        public Button passProperty;
        public Button buyProperty;

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
            nextRound.Bounds = new Rectangle(Globals.APP_WIDTH - 200, Globals.APP_HEIGHT - 90, 100, 40);
            nextRound.Click += new EventHandler(NextRound_Click);


            this.Controls.Add(nextRound);

            // intilize closeGame button
            closeGame = new Button();
            closeGame.Text = "Close Game";
            closeGame.Bounds = new Rectangle(Globals.APP_WIDTH - 200, Globals.APP_HEIGHT - 40, 100, 40);
            closeGame.ForeColor = Color.White;
            closeGame.BackColor = Color.Red;
            closeGame.Click += new EventHandler(closeGame_Event);

            this.Controls.Add(closeGame);

            // intilize buyProperty button
            buyProperty = new Button();
            buyProperty.Text = "Buy";
            buyProperty.Bounds = new Rectangle(Globals.APP_WIDTH - 310, Globals.APP_HEIGHT - 40, 100, 40);
            buyProperty.ForeColor = Color.White;
            buyProperty.BackColor = Color.Green;
            buyProperty.Click += new EventHandler(BuyProperty_Click);

            this.Controls.Add(buyProperty);


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

            /*
            Console.WriteLine(Globals.Players == null);
            Console.WriteLine(Globals.PlayerCount);
            Console.WriteLine(Globals.Players.Length);
             */


            if (Globals.Players == null || Globals.PlayerCount != Globals.Players.Length || Globals.PlayerCount == 0 || Globals.Players.Length == 0)
            {
                Globals.Players = players;
                Globals.PlayerCount = 4;

                //pawns = pps;
            }
            for (int i = 0; i < Globals.PlayerCount; i++)
            {
                Globals.Players[i].previousPosition = Globals.Players[i].position;
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
            timer1.Interval = Globals.TIMER_TICK_LENGHT ; // 1 sn

            // init player screen must be init after players set
            playerScreen = new PlayerScreen(this);
            playerScreen.Bounds = new Rectangle(740, 20, PlayerScreen.WIDTH, PlayerScreen.HEIGHT);
            this.Controls.Add(playerScreen);


            // en altta olması için en son eklenmeli
            this.Controls.Add(gameBoard);

        }

        private void closeGame_Event(object sender, EventArgs e)
        {
            // Form2'yi aç
            Form1 form2 = new Form1();
            form2.Show();

            // Form1'i gizle
            this.Hide();
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

        public void NextRound_Click(object sender, EventArgs e)
        {
            Console.WriteLine("NEXT ROUND");

            Console.WriteLine("SIRA {0}", (turn + 1) % Globals.PlayerCount + 1);
            turn = (turn + 1) % Globals.PlayerCount;

            nextRound.Enabled = false;
            nextRound.BackColor = Color.DimGray;

            UpdateGameState();
        }
        private void BuyProperty_Click(object sender, EventArgs e)
        {
            BuyMenu buyMenu = new BuyMenu();
            buyMenu.Show();
        }

        public void UpdatePlayerPosition(int rollResult)
        {
            int lastPosition = Globals.Players[turn].position;
            int newPosition = (Globals.Players[turn].position + rollResult) % 40;

            Globals.Players[turn].position = newPosition;

            Console.WriteLine("OLD POS {0} NEW POS {1}", lastPosition, newPosition);

            int currentStep = (lastPosition + 1) % 40;

            dice.rollButton.Enabled = false;

            // Unsubscribe any existing event handler before subscribing
            nextRound.BackColor = Color.White;
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

                    nextRound.Enabled = true;
                    nextRound.BackColor = Color.MediumSpringGreen;
                    UpdateGameState(); // UPDATE GAME STATE
                }
            }
        }

        public void HandleLuck()
        {
            Luck luck = new Luck();
            luck = RandomLuck();

            MessageBox.Show($"{luck.name}\n{luck.text}");

            if (luck.type.ToString() == "GetMoney" || luck.type.ToString() == "LoseMoney")
                Globals.Players[turn].money += luck.price;
            else if (luck.type.ToString() != "EscapePrison")
                Globals.Players[turn].hasEscapeFromJailCard = true;
            else
                Globals.Players[turn].position = 10;
        }

        public void HandleComm()
        {
            Community comm = new Community();
            comm = RandomCommunity();

            MessageBox.Show($"{comm.name}\n{comm.text}");

            if (comm.type.ToString() != "Move")
                Globals.Players[turn].money += comm.price;
            else
                Globals.Players[turn].position = 10;
        }

        public void HandleGoToJail()
        {
            Globals.Players[turn].IN_JAIL = true;
            Globals.Players[turn].jailCounter = 3;

            Jail jailForm = new Jail(this);
            jailForm.Show();
        }

        public void EndRound()
        {
            while (true)
            {
                if (Globals.Players[turn].isBankrupt)
                    turn += 1;
                    if (turn == Globals.PlayerCount)
                        turn = 0;
                else
                    break;
            }

        }

        public bool HandleMoney()
        {
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        public void PlayerLostHandle()
        {
            if (Globals.Players[turn].money <= 0)
            {
                Globals.Players[turn].isBankrupt = true;

            }
        }

        /// <summary>
        /// Ana Update Fonksiyonu tüm durumları içerir
        /// </summary>
        public void UpdateGameState()
        {
            int previousPosition = Globals.Players[turn].previousPosition;
            int currentPosition = Globals.Players[turn].position;

            // 3 tekrarlı roll durumu
            if (Globals.Players[turn].HasConsecutiveSameRolls)
            {
                // same as goto jail
                HandleGoToJail();
                EndRound();
                return;
            }

            // check eligibility for pass money
            if (currentPosition < previousPosition)
            {
                // give money
                Globals.Players[turn].money += Globals.PASS_MONEY_GAIN;
                // update visuals
                playerScreen.Update(turn);
            }




            // check current position
            List<int> p_doNothing = new List<int>   {  0, 10, 20 };
            List<int> p_jail = new List<int>        { 30         };
            List<int> p_tax = new List<int>         {  4, 38     };
            List<int> p_luck = new List<int>        {  7, 22, 36 };
            List<int> p_comm = new List<int>        {  2, 17, 33 };


            bool currentPlayerLost = false;


            Console.WriteLine("CURRENT POS IN UPDATE GAME STATE {0}", currentPosition);

            if (p_doNothing.Contains(currentPosition)) //if 0, 10, 20 do nothing, baş,ziyaret,park
            {
                SonrakiTuraGecilebilir = true;
                EndRound();
            }
            else if (p_jail.Contains(currentPosition)) // if 30 kodes
            {
                Console.WriteLine("WENT TO JAIL");
                // same as goto jail
                HandleGoToJail();
                EndRound();
                return;
            }
            else if(p_tax.Contains(currentPosition)) // if 4 , 38 tax
            {
                // handle tax
                if(currentPosition == 4)  // gelir vergisi
                { 
                    if(Globals.Players[turn].money - Globals.TAX_DIFFICULTY * Globals.PASS_MONEY_GAIN > 0) // yeterli para varsa
                    {
                        Globals.Players[turn].money -= Globals.TAX_DIFFICULTY * Globals.PASS_MONEY_GAIN;
                    }
                    else // yeterli para yoksa
                    {
                        currentPlayerLost = HandleMoney();
                    }
                }
                else    // lüküs vergisi
                {
                    if (Globals.Players[turn].money - Globals.TAX_DIFFICULTY * Globals.PASS_MONEY_GAIN / 2 > 0) // yeterli para varsa
                    {
                        Globals.Players[turn].money -= Globals.TAX_DIFFICULTY * Globals.PASS_MONEY_GAIN / 2;
                    }
                    else // yeterli para yoksa
                    {
                        currentPlayerLost = HandleMoney();
                    }
                }

            }
            else if(p_luck.Contains(currentPosition))
            {
                HandleLuck();
            }
            else if (p_comm.Contains(currentPosition))
            {
                HandleComm();
            }
            else // satın alınabilir değerler
            {
                //Property currentProperty = Globals.Properties[currentPosition];

                // owned by current
                if (Globals.Players[turn].ownedProperties[currentPosition])
                {
                    bool upgradable = false;
                    //checks upgradability

                    if(upgradable)
                    {
                        // upgrade menu
                    }
                    else
                    {
                        // do nothing
                    }
                }
                else
                {

                    bool somebodyOwns = false;

                    for(int i = 0; i < Globals.PlayerCount; i++)
                        if (i != turn)
                            if (Globals.Players[i].ownedProperties[currentPosition])
                                somebodyOwns = true;

                    if(somebodyOwns) 
                    {
                        // open pay menu
                    }
                    else // not owned
                    {
                        // open buy menu
                    }
                }
            }

            if(currentPlayerLost)
            {
                PlayerLostHandle();
            }

            // update next round button , enable it

            nextRound.Enabled = true;
            nextRound.BackColor = Color.MediumSpringGreen;

        }

        public Luck RandomLuck()
        {
            Luck luck = new Luck();

            luck = Globals.LuckQueue.Dequeue();
            Globals.LuckQueue.Enqueue(luck);

            return luck;
        }

        public Community RandomCommunity()
        {
            Community community = new Community();

            community = Globals.CommunityQueue.Dequeue();
            Globals.CommunityQueue.Enqueue(community);

            return community;
        }
    }
}
