namespace MyNotes
{
    partial class App
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DataAccess.UserData.UserData userData1 = new DataAccess.UserData.UserData();
            DataAccess.UserData.UserData userData2 = new DataAccess.UserData.UserData();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myEdit = new MyNotes.UserControls.MyEditAreaUC();
            this.myTree = new MyNotes.UserControls.MyTreeUC();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.vacuumDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vacuumDatabaseToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // myEdit
            // 
            this.myEdit.AllowDrop = true;
            this.myEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.myEdit.BackColor = System.Drawing.SystemColors.Control;
            this.myEdit.Data = userData1;
            this.myEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myEdit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.myEdit.Location = new System.Drawing.Point(0, 0);
            this.myEdit.Margin = new System.Windows.Forms.Padding(4);
            this.myEdit.Name = "myEdit";
            this.myEdit.Size = new System.Drawing.Size(530, 426);
            this.myEdit.TabIndex = 0;
            // 
            // myTree
            // 
            this.myTree.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.myTree.BackColor = System.Drawing.SystemColors.Control;
            this.myTree.Data = userData2;
            this.myTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTree.ImeMode = System.Windows.Forms.ImeMode.On;
            this.myTree.Location = new System.Drawing.Point(0, 0);
            this.myTree.Name = "myTree";
            this.myTree.Size = new System.Drawing.Size(266, 426);
            this.myTree.TabIndex = 1;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.myTree);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.myEdit);
            this.splitContainer.Size = new System.Drawing.Size(800, 426);
            this.splitContainer.SplitterDistance = 266;
            this.splitContainer.TabIndex = 2;
            // 
            // vacuumDatabaseToolStripMenuItem
            // 
            this.vacuumDatabaseToolStripMenuItem.Name = "vacuumDatabaseToolStripMenuItem";
            this.vacuumDatabaseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vacuumDatabaseToolStripMenuItem.Text = "Vacuum Database";
            this.vacuumDatabaseToolStripMenuItem.Click += new System.EventHandler(this.vacuumDatabaseToolStripMenuItem_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "App";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyNotes";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private UserControls.MyEditAreaUC myEdit;
        private UserControls.MyTreeUC myTree;
        private SplitContainer splitContainer;
        private ToolStripMenuItem vacuumDatabaseToolStripMenuItem;
    }
}