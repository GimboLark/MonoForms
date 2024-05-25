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
            this.lblPlayerCount = new System.Windows.Forms.Label();
            this.lblStartingMoney = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gamesettingslbl = new System.Windows.Forms.Label();
            this.playerCountCbx = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            // gamesettingslbl
            // 
            this.gamesettingslbl.AutoSize = true;
            this.gamesettingslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gamesettingslbl.Location = new System.Drawing.Point(335, 24);
            this.gamesettingslbl.Name = "gamesettingslbl";
            this.gamesettingslbl.Size = new System.Drawing.Size(74, 25);
            this.gamesettingslbl.TabIndex = 7;
            this.gamesettingslbl.Text = "Ayarlar";
            // 
            // playerCountCbx
            // 
            this.playerCountCbx.FormattingEnabled = true;
            this.playerCountCbx.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            this.playerCountCbx.Location = new System.Drawing.Point(172, 167);
            this.playerCountCbx.Name = "playerCountCbx";
            this.playerCountCbx.Size = new System.Drawing.Size(121, 24);
            this.playerCountCbx.TabIndex = 8;
            this.playerCountCbx.SelectedIndexChanged += new System.EventHandler(this.playerCountCbx_SelectedIndexChanged);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.playerCountCbx);
            this.Controls.Add(this.gamesettingslbl);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblStartingMoney);
            this.Controls.Add(this.lblPlayerCount);
            this.Name = "GameSettings";
            this.Text = "GameSettings";
            this.Load += new System.EventHandler(this.GameSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPlayerCount;
        private System.Windows.Forms.Label lblStartingMoney;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label gamesettingslbl;
        private System.Windows.Forms.ComboBox playerCountCbx;
    }
}