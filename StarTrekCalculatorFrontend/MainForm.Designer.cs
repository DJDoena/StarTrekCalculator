namespace DoenaSoft.STC
{
    partial class MainForm
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
            if(disposing && (components != null))
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
            this.WarpButton = new System.Windows.Forms.Button();
            this.StardateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WarpButton
            // 
            this.WarpButton.Location = new System.Drawing.Point(12, 12);
            this.WarpButton.Name = "WarpButton";
            this.WarpButton.Size = new System.Drawing.Size(132, 23);
            this.WarpButton.TabIndex = 0;
            this.WarpButton.Text = "Warp Calculator";
            this.WarpButton.UseVisualStyleBackColor = true;
            this.WarpButton.Click += new System.EventHandler(this.OnWarpButtonClick);
            // 
            // StardateButton
            // 
            this.StardateButton.Location = new System.Drawing.Point(12, 41);
            this.StardateButton.Name = "StardateButton";
            this.StardateButton.Size = new System.Drawing.Size(132, 23);
            this.StardateButton.TabIndex = 1;
            this.StardateButton.Text = "Stardate Calculator";
            this.StardateButton.UseVisualStyleBackColor = true;
            this.StardateButton.Click += new System.EventHandler(this.OnStardateButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(156, 75);
            this.Controls.Add(this.StardateButton);
            this.Controls.Add(this.WarpButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Star Trek Calculator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button WarpButton;
        private System.Windows.Forms.Button StardateButton;
    }
}

