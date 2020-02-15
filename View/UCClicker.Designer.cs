namespace ClickerGame.View
{
    partial class UCClicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerGameLoop = new System.Windows.Forms.Timer(this.components);
            this.labelHit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerGameLoop
            // 
            this.timerGameLoop.Interval = 1000;
            this.timerGameLoop.Tick += new System.EventHandler(this.timerGameLoop_Tick);
            // 
            // labelHit
            // 
            this.labelHit.BackColor = System.Drawing.Color.Transparent;
            this.labelHit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F);
            this.labelHit.ForeColor = System.Drawing.Color.YellowGreen;
            this.labelHit.Location = new System.Drawing.Point(719, 599);
            this.labelHit.Name = "labelHit";
            this.labelHit.Size = new System.Drawing.Size(81, 31);
            this.labelHit.TabIndex = 10;
            this.labelHit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UCClicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::View.Properties.Resources.ballgamebackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.labelHit);
            this.DoubleBuffered = true;
            this.Name = "UCClicker";
            this.Size = new System.Drawing.Size(870, 630);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UCClicker_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerGameLoop;
        private System.Windows.Forms.Label labelHit;
    }
}
