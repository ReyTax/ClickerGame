namespace ClickerGame.View
{
    partial class UCSave
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
            this.buttonSaveGame = new System.Windows.Forms.Button();
            this.labelSalvare = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSaveGame
            // 
            this.buttonSaveGame.BackgroundImage = global::View.Properties.Resources.savebutton;
            this.buttonSaveGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSaveGame.Location = new System.Drawing.Point(302, 150);
            this.buttonSaveGame.Name = "buttonSaveGame";
            this.buttonSaveGame.Size = new System.Drawing.Size(271, 250);
            this.buttonSaveGame.TabIndex = 0;
            this.buttonSaveGame.UseVisualStyleBackColor = true;
            this.buttonSaveGame.Click += new System.EventHandler(this.buttonSaveGame_Click);
            // 
            // labelSalvare
            // 
            this.labelSalvare.BackColor = System.Drawing.Color.Transparent;
            this.labelSalvare.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F);
            this.labelSalvare.ForeColor = System.Drawing.Color.YellowGreen;
            this.labelSalvare.Location = new System.Drawing.Point(363, 452);
            this.labelSalvare.Name = "labelSalvare";
            this.labelSalvare.Size = new System.Drawing.Size(153, 76);
            this.labelSalvare.TabIndex = 1;
            this.labelSalvare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::View.Properties.Resources.panelbackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.labelSalvare);
            this.Controls.Add(this.buttonSaveGame);
            this.DoubleBuffered = true;
            this.Name = "UCSave";
            this.Size = new System.Drawing.Size(870, 630);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveGame;
        private System.Windows.Forms.Label labelSalvare;
    }
}
