﻿namespace MyNotes.UserControls
{
    partial class MyTreeUC
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
            this.myTreeView = new MyNotes.UserControls.MyTreeView();
            this.SuspendLayout();
            // 
            // myTreeView
            // 
            this.myTreeView.BackColor = System.Drawing.SystemColors.Window;
            this.myTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTreeView.ImeMode = System.Windows.Forms.ImeMode.On;
            this.myTreeView.Location = new System.Drawing.Point(0, 0);
            this.myTreeView.Name = "myTreeView";
            this.myTreeView.Size = new System.Drawing.Size(522, 845);
            this.myTreeView.TabIndex = 0;
            // 
            // MyTreeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myTreeView);
            this.Name = "MyTreeUC";
            this.Size = new System.Drawing.Size(522, 845);
            this.ResumeLayout(false);

        }

        #endregion

        private MyTreeView myTreeView;
    }
}