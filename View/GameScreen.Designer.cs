namespace ClickerGame.View
{
    partial class GameScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.labelIncomePerTick = new System.Windows.Forms.Label();
            this.SaveGame = new System.Windows.Forms.Button();
            this.labelCurrentMoney = new System.Windows.Forms.Label();
            this.EXP = new System.Windows.Forms.Button();
            this.IncomeUpgrades = new System.Windows.Forms.Button();
            this.ClickUpgrades = new System.Windows.Forms.Button();
            this.ClickMenu = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panelExit = new System.Windows.Forms.Panel();
            this.ucSave1 = new ClickerGame.View.UCSave();
            this.ucExp1 = new ClickerGame.View.UCExp();
            this.ucIncomeUpgrades1 = new ClickerGame.View.UCIncomeUpgrades();
            this.ucCllickerUpgrades1 = new ClickerGame.View.UCCllickerUpgrades();
            this.ucClicker1 = new ClickerGame.View.UCClicker();
            this.panelMenu.SuspendLayout();
            this.panelExit.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMenu.BackgroundImage = global::View.Properties.Resources.gamemenu;
            this.panelMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMenu.Controls.Add(this.labelIncomePerTick);
            this.panelMenu.Controls.Add(this.SaveGame);
            this.panelMenu.Controls.Add(this.labelCurrentMoney);
            this.panelMenu.Controls.Add(this.EXP);
            this.panelMenu.Controls.Add(this.IncomeUpgrades);
            this.panelMenu.Controls.Add(this.ClickUpgrades);
            this.panelMenu.Controls.Add(this.ClickMenu);
            this.panelMenu.Location = new System.Drawing.Point(95, 95);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(210, 630);
            this.panelMenu.TabIndex = 0;
            // 
            // labelIncomePerTick
            // 
            this.labelIncomePerTick.BackColor = System.Drawing.Color.Transparent;
            this.labelIncomePerTick.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIncomePerTick.ForeColor = System.Drawing.Color.YellowGreen;
            this.labelIncomePerTick.Location = new System.Drawing.Point(37, 168);
            this.labelIncomePerTick.Name = "labelIncomePerTick";
            this.labelIncomePerTick.Size = new System.Drawing.Size(133, 25);
            this.labelIncomePerTick.TabIndex = 1;
            this.labelIncomePerTick.Text = "LOADING";
            this.labelIncomePerTick.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SaveGame
            // 
            this.SaveGame.BackColor = System.Drawing.Color.White;
            this.SaveGame.BackgroundImage = global::View.Properties.Resources.buttonsave;
            this.SaveGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveGame.Location = new System.Drawing.Point(26, 501);
            this.SaveGame.Name = "SaveGame";
            this.SaveGame.Size = new System.Drawing.Size(155, 85);
            this.SaveGame.TabIndex = 4;
            this.SaveGame.UseVisualStyleBackColor = false;
            this.SaveGame.Click += new System.EventHandler(this.SaveGame_Click);
            // 
            // labelCurrentMoney
            // 
            this.labelCurrentMoney.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentMoney.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelCurrentMoney.ForeColor = System.Drawing.Color.YellowGreen;
            this.labelCurrentMoney.Location = new System.Drawing.Point(37, 91);
            this.labelCurrentMoney.Name = "labelCurrentMoney";
            this.labelCurrentMoney.Size = new System.Drawing.Size(133, 25);
            this.labelCurrentMoney.TabIndex = 0;
            this.labelCurrentMoney.Text = "LOADING";
            this.labelCurrentMoney.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // EXP
            // 
            this.EXP.BackgroundImage = global::View.Properties.Resources.buttonPlayer;
            this.EXP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EXP.Location = new System.Drawing.Point(26, 407);
            this.EXP.Name = "EXP";
            this.EXP.Size = new System.Drawing.Size(155, 85);
            this.EXP.TabIndex = 3;
            this.EXP.UseVisualStyleBackColor = true;
            this.EXP.Click += new System.EventHandler(this.EXP_Click);
            // 
            // IncomeUpgrades
            // 
            this.IncomeUpgrades.BackgroundImage = global::View.Properties.Resources.idleShop;
            this.IncomeUpgrades.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IncomeUpgrades.Location = new System.Drawing.Point(106, 311);
            this.IncomeUpgrades.Name = "IncomeUpgrades";
            this.IncomeUpgrades.Size = new System.Drawing.Size(75, 90);
            this.IncomeUpgrades.TabIndex = 2;
            this.IncomeUpgrades.UseVisualStyleBackColor = true;
            this.IncomeUpgrades.Click += new System.EventHandler(this.IncomeUpgrades_Click);
            // 
            // ClickUpgrades
            // 
            this.ClickUpgrades.BackgroundImage = global::View.Properties.Resources.clickShop;
            this.ClickUpgrades.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClickUpgrades.Location = new System.Drawing.Point(25, 311);
            this.ClickUpgrades.Name = "ClickUpgrades";
            this.ClickUpgrades.Size = new System.Drawing.Size(75, 90);
            this.ClickUpgrades.TabIndex = 1;
            this.ClickUpgrades.UseVisualStyleBackColor = true;
            this.ClickUpgrades.Click += new System.EventHandler(this.ClickUpgrades_Click);
            // 
            // ClickMenu
            // 
            this.ClickMenu.BackColor = System.Drawing.SystemColors.Control;
            this.ClickMenu.BackgroundImage = global::View.Properties.Resources.playbutton;
            this.ClickMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClickMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClickMenu.Location = new System.Drawing.Point(26, 213);
            this.ClickMenu.Name = "ClickMenu";
            this.ClickMenu.Size = new System.Drawing.Size(155, 92);
            this.ClickMenu.TabIndex = 0;
            this.ClickMenu.UseVisualStyleBackColor = false;
            this.ClickMenu.Click += new System.EventHandler(this.ClickMenu_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImage = global::View.Properties.Resources.exitlogin;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.Location = new System.Drawing.Point(1223, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(45, 45);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panelExit
            // 
            this.panelExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelExit.BackgroundImage")));
            this.panelExit.Controls.Add(this.ucSave1);
            this.panelExit.Controls.Add(this.ucExp1);
            this.panelExit.Controls.Add(this.ucIncomeUpgrades1);
            this.panelExit.Controls.Add(this.ucCllickerUpgrades1);
            this.panelExit.Controls.Add(this.ucClicker1);
            this.panelExit.Location = new System.Drawing.Point(330, 95);
            this.panelExit.Name = "panelExit";
            this.panelExit.Size = new System.Drawing.Size(870, 630);
            this.panelExit.TabIndex = 3;
            // 
            // ucSave1
            // 
            this.ucSave1.BackColor = System.Drawing.SystemColors.Control;
            this.ucSave1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucSave1.BackgroundImage")));
            this.ucSave1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucSave1.Location = new System.Drawing.Point(0, 0);
            this.ucSave1.Name = "ucSave1";
            this.ucSave1.Size = new System.Drawing.Size(870, 630);
            this.ucSave1.TabIndex = 4;
            // 
            // ucExp1
            // 
            this.ucExp1.BackgroundImage = global::View.Properties.Resources.panelPlayerBackground;
            this.ucExp1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucExp1.Location = new System.Drawing.Point(0, 0);
            this.ucExp1.Name = "ucExp1";
            this.ucExp1.Size = new System.Drawing.Size(870, 630);
            this.ucExp1.TabIndex = 3;
            // 
            // ucIncomeUpgrades1
            // 
            this.ucIncomeUpgrades1.BackgroundImage = global::View.Properties.Resources.passiveupgradepanelbackground;
            this.ucIncomeUpgrades1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucIncomeUpgrades1.Location = new System.Drawing.Point(0, 0);
            this.ucIncomeUpgrades1.Name = "ucIncomeUpgrades1";
            this.ucIncomeUpgrades1.Size = new System.Drawing.Size(870, 630);
            this.ucIncomeUpgrades1.TabIndex = 2;
            // 
            // ucCllickerUpgrades1
            // 
            this.ucCllickerUpgrades1.BackgroundImage = global::View.Properties.Resources.clickerupgradepanelbackground;
            this.ucCllickerUpgrades1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucCllickerUpgrades1.Location = new System.Drawing.Point(0, 0);
            this.ucCllickerUpgrades1.Name = "ucCllickerUpgrades1";
            this.ucCllickerUpgrades1.Size = new System.Drawing.Size(870, 630);
            this.ucCllickerUpgrades1.TabIndex = 1;
            // 
            // ucClicker1
            // 
            this.ucClicker1.BackgroundImage = global::View.Properties.Resources.ballgamebackground;
            this.ucClicker1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucClicker1.Location = new System.Drawing.Point(0, 0);
            this.ucClicker1.Name = "ucClicker1";
            this.ucClicker1.Size = new System.Drawing.Size(870, 630);
            this.ucClicker1.TabIndex = 0;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::View.Properties.Resources.gamescreenclicker;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panelExit);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameScreen";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameScreen_MouseDown);
            this.panelMenu.ResumeLayout(false);
            this.panelExit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button SaveGame;
        private System.Windows.Forms.Button EXP;
        private System.Windows.Forms.Button IncomeUpgrades;
        private System.Windows.Forms.Button ClickUpgrades;
        private System.Windows.Forms.Button ClickMenu;
        private System.Windows.Forms.Button buttonExit;
        public System.Windows.Forms.Label labelIncomePerTick;
        public System.Windows.Forms.Label labelCurrentMoney;
        private System.Windows.Forms.Panel panelExit;
        public View.UCSave ucSave1;
        public View.UCExp ucExp1;
        public View.UCIncomeUpgrades ucIncomeUpgrades1;
        public View.UCCllickerUpgrades ucCllickerUpgrades1;
        public View.UCClicker ucClicker1;
    }
}