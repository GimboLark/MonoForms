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
            this.SuspendLayout();
            // 
            // playerCount
            // 
            this.playerCount.FormattingEnabled = true;
            this.playerCount.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            this.playerCount.Location = new System.Drawing.Point(155, 166);
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
            this.lblPlayerCount.Location = new System.Drawing.Point(26, 166);
            this.lblPlayerCount.Name = "lblPlayerCount";
            this.lblPlayerCount.Padding = new System.Windows.Forms.Padding(5);
            this.lblPlayerCount.Size = new System.Drawing.Size(106, 26);
            this.lblPlayerCount.TabIndex = 3;
            this.lblPlayerCount.Text = "Kullanıcı Sayısı";
            // 
            // lblStartingMoney
            // 
            this.lblStartingMoney.AutoSize = true;
            this.lblStartingMoney.Location = new System.Drawing.Point(26, 213);
            this.lblStartingMoney.Name = "lblStartingMoney";
            this.lblStartingMoney.Size = new System.Drawing.Size(109, 16);
            this.lblStartingMoney.TabIndex = 4;
            this.lblStartingMoney.Text = "Başlangıç Parası";
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MonoForms.Properties.Resources.background2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}