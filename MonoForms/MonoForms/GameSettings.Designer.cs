namespace MonoForms
{
    partial class GameSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playerCount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPlayerCount = new System.Windows.Forms.Label();
            this.lblStartingMoney = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playerCount
            // 
            this.playerCount.FormattingEnabled = true;
            this.playerCount.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            this.playerCount.Location = new System.Drawing.Point(172, 166);
            this.playerCount.Name = "playerCount";
            this.playerCount.Size = new System.Drawing.Size(121, 24);
            this.playerCount.TabIndex = 0;
            this.playerCount.SelectedIndexChanged += new System.EventHandler(this.playerCount_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(360, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ayarlar";
            // 
            // lblPlayerCount
            // 
            this.lblPlayerCount.AutoSize = true;
            this.lblPlayerCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPlayerCount.Location = new System.Drawing.Point(26, 167);
            this.lblPlayerCount.Name = "lblPlayerCount";
            this.lblPlayerCount.Padding = new System.Windows.Forms.Padding(6);
            this.lblPlayerCount.Size = new System.Drawing.Size(117, 30);
            this.lblPlayerCount.TabIndex = 3;
            this.lblPlayerCount.Text = "Kullanıcı Sayısı";
            this.lblPlayerCount.Click += new System.EventHandler(this.lblPlayerCount_Click);
            // 
            // lblStartingMoney
            // 
            this.lblStartingMoney.AutoSize = true;
            this.lblStartingMoney.Location = new System.Drawing.Point(26, 213);
            this.lblStartingMoney.Name = "lblStartingMoney";
            this.lblStartingMoney.Padding = new System.Windows.Forms.Padding(5);
            this.lblStartingMoney.Size = new System.Drawing.Size(119, 26);
            this.lblStartingMoney.TabIndex = 4;
            this.lblStartingMoney.Text = "Başlangıç Parası";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 213);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 22);
            this.textBox1.TabIndex = 5;
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.Green;
            this.btnStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStartGame.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStartGame.Location = new System.Drawing.Point(329, 363);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(157, 51);
            this.btnStartGame.TabIndex = 6;
            this.btnStartGame.Text = "Oyuna Başla";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.BackgroundImage = global::MonoForms.Properties.Resources.goBack;
            this.btnGoBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGoBack.Location = new System.Drawing.Point(29, 26);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(31, 23);
            this.btnGoBack.TabIndex = 7;
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MonoForms.Properties.Resources.background2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblStartingMoney);
            this.Controls.Add(this.lblPlayerCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playerCount);
            this.Name = "GameSettings";
            this.Text = "GameSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox playerCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPlayerCount;
        private System.Windows.Forms.Label lblStartingMoney;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnGoBack;
    }
}