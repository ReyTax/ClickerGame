namespace ClickerGame.View
{
    partial class UCExp
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
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelUserLevel = new System.Windows.Forms.Label();
            this.labelUserNextLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.BackColor = System.Drawing.Color.Transparent;
            this.labelUserName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.ForeColor = System.Drawing.Color.White;
            this.labelUserName.Location = new System.Drawing.Point(387, 157);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(418, 49);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "Loading";
            this.labelUserName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelUserLevel
            // 
            this.labelUserLevel.BackColor = System.Drawing.Color.Transparent;
            this.labelUserLevel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserLevel.ForeColor = System.Drawing.Color.YellowGreen;
            this.labelUserLevel.Location = new System.Drawing.Point(516, 296);
            this.labelUserLevel.Name = "labelUserLevel";
            this.labelUserLevel.Size = new System.Drawing.Size(277, 72);
            this.labelUserLevel.TabIndex = 1;
            this.labelUserLevel.Text = "Loading";
            this.labelUserLevel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelUserNextLevel
            // 
            this.labelUserNextLevel.BackColor = System.Drawing.Color.Transparent;
            this.labelUserNextLevel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserNextLevel.ForeColor = System.Drawing.Color.YellowGreen;
            this.labelUserNextLevel.Location = new System.Drawing.Point(505, 445);
            this.labelUserNextLevel.Name = "labelUserNextLevel";
            this.labelUserNextLevel.Size = new System.Drawing.Size(309, 49);
            this.labelUserNextLevel.TabIndex = 2;
            this.labelUserNextLevel.Text = "Loading";
            this.labelUserNextLevel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UCExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::View.Properties.Resources.panelPlayerBackground;
            this.Controls.Add(this.labelUserNextLevel);
            this.Controls.Add(this.labelUserLevel);
            this.Controls.Add(this.labelUserName);
            this.Name = "UCExp";
            this.Size = new System.Drawing.Size(870, 630);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelUserLevel;
        private System.Windows.Forms.Label labelUserNextLevel;
    }
}
