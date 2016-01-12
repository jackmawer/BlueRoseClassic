﻿namespace BlueRoseWinForms
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.playBtn = new System.Windows.Forms.Button();
            this.devBtn = new System.Windows.Forms.Button();
            this.freeSONewsBtn = new System.Windows.Forms.Button();
            this.brNewsBtn = new System.Windows.Forms.Button();
            this.fsoWeb = new System.Windows.Forms.WebBrowser();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dwnPrgBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(12, 526);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(75, 23);
            this.playBtn.TabIndex = 0;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // devBtn
            // 
            this.devBtn.Location = new System.Drawing.Point(93, 526);
            this.devBtn.Name = "devBtn";
            this.devBtn.Size = new System.Drawing.Size(75, 23);
            this.devBtn.TabIndex = 1;
            this.devBtn.Text = "Develop";
            this.devBtn.UseVisualStyleBackColor = true;
            this.devBtn.Click += new System.EventHandler(this.devBtn_Click);
            // 
            // freeSONewsBtn
            // 
            this.freeSONewsBtn.Location = new System.Drawing.Point(678, 526);
            this.freeSONewsBtn.Name = "freeSONewsBtn";
            this.freeSONewsBtn.Size = new System.Drawing.Size(94, 23);
            this.freeSONewsBtn.TabIndex = 2;
            this.freeSONewsBtn.Text = "FreeSO News";
            this.freeSONewsBtn.UseVisualStyleBackColor = true;
            this.freeSONewsBtn.Click += new System.EventHandler(this.freeSONewsBtn_Click);
            // 
            // brNewsBtn
            // 
            this.brNewsBtn.Location = new System.Drawing.Point(563, 526);
            this.brNewsBtn.Name = "brNewsBtn";
            this.brNewsBtn.Size = new System.Drawing.Size(109, 23);
            this.brNewsBtn.TabIndex = 3;
            this.brNewsBtn.Text = "Blue Rose News";
            this.brNewsBtn.UseVisualStyleBackColor = true;
            this.brNewsBtn.Click += new System.EventHandler(this.brNewsBtn_Click);
            // 
            // fsoWeb
            // 
            this.fsoWeb.Location = new System.Drawing.Point(12, 12);
            this.fsoWeb.MinimumSize = new System.Drawing.Size(20, 20);
            this.fsoWeb.Name = "fsoWeb";
            this.fsoWeb.Size = new System.Drawing.Size(760, 508);
            this.fsoWeb.TabIndex = 4;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(174, 526);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dwnPrgBar
            // 
            this.dwnPrgBar.Location = new System.Drawing.Point(255, 526);
            this.dwnPrgBar.Name = "dwnPrgBar";
            this.dwnPrgBar.Size = new System.Drawing.Size(302, 23);
            this.dwnPrgBar.TabIndex = 6;
            this.dwnPrgBar.Click += new System.EventHandler(this.dwnPrgBar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(99)))), ((int)(((byte)(168)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dwnPrgBar);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.fsoWeb);
            this.Controls.Add(this.brNewsBtn);
            this.Controls.Add(this.freeSONewsBtn);
            this.Controls.Add(this.devBtn);
            this.Controls.Add(this.playBtn);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Blue Rose";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button devBtn;
        private System.Windows.Forms.Button freeSONewsBtn;
        private System.Windows.Forms.Button brNewsBtn;
        private System.Windows.Forms.WebBrowser fsoWeb;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ProgressBar dwnPrgBar;
    }
}

