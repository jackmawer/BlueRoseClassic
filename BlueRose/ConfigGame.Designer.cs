namespace BlueRoseApp
{
    partial class ConfigGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigGame));
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.fsoLogo = new System.Windows.Forms.PictureBox();
            this.setRes = new System.Windows.Forms.Button();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.configStatus = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.fsoLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(12, 75);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(40, 20);
            this.heightTextBox.TabIndex = 0;
            // 
            // fsoLogo
            // 
            this.fsoLogo.Image = ((System.Drawing.Image)(resources.GetObject("fsoLogo.Image")));
            this.fsoLogo.Location = new System.Drawing.Point(40, 12);
            this.fsoLogo.Name = "fsoLogo";
            this.fsoLogo.Size = new System.Drawing.Size(55, 55);
            this.fsoLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fsoLogo.TabIndex = 19;
            this.fsoLogo.TabStop = false;
            // 
            // setRes
            // 
            this.setRes.Location = new System.Drawing.Point(12, 101);
            this.setRes.Name = "setRes";
            this.setRes.Size = new System.Drawing.Size(107, 23);
            this.setRes.TabIndex = 20;
            this.setRes.Text = "Set Resolution";
            this.setRes.UseVisualStyleBackColor = true;
            this.setRes.Click += new System.EventHandler(this.setRes_Click);
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(78, 75);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(41, 20);
            this.widthTextBox.TabIndex = 21;
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(58, 82);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(14, 13);
            this.xLabel.TabIndex = 22;
            this.xLabel.Text = "X";
            // 
            // configStatus
            // 
            this.configStatus.Location = new System.Drawing.Point(0, 130);
            this.configStatus.Name = "configStatus";
            this.configStatus.Size = new System.Drawing.Size(131, 22);
            this.configStatus.TabIndex = 23;
            this.configStatus.Text = "statusStrip1";
            // 
            // ConfigGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(131, 152);
            this.Controls.Add(this.configStatus);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.setRes);
            this.Controls.Add(this.fsoLogo);
            this.Controls.Add(this.heightTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigGame";
            this.Text = "Configure";
            this.Load += new System.EventHandler(this.ConfigGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fsoLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.PictureBox fsoLogo;
        private System.Windows.Forms.Button setRes;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.StatusStrip configStatus;
    }
}