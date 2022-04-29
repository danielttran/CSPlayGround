namespace PowerPoint
{
    partial class PowerPointHelperForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.okBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.selectBackgroundColorBtn = new System.Windows.Forms.Button();
            this.selectFontColorBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fontSizeTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fontNameTb = new System.Windows.Forms.TextBox();
            this.clearTextBtn = new System.Windows.Forms.Button();
            this.SavePpBtn = new System.Windows.Forms.Button();
            this.ppContentTb = new System.Windows.Forms.RichTextBox();
            this.boldFontCb = new System.Windows.Forms.CheckBox();
            this.noSpaceAndNewLineCb = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AllowDrop = true;
            this.tabPage1.Controls.Add(this.okBtn);
            this.tabPage1.Controls.Add(this.clearBtn);
            this.tabPage1.Controls.Add(this.listView);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Join PPTX Files";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(709, 391);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(628, 391);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 1;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // listView
            // 
            this.listView.AllowDrop = true;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.Dock = System.Windows.Forms.DockStyle.Left;
            this.listView.Location = new System.Drawing.Point(3, 3);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(619, 416);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.List;
            this.listView.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.listView.DragOver += new System.Windows.Forms.DragEventHandler(this.listView_DragOver);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.noSpaceAndNewLineCb);
            this.tabPage2.Controls.Add(this.boldFontCb);
            this.tabPage2.Controls.Add(this.selectBackgroundColorBtn);
            this.tabPage2.Controls.Add(this.selectFontColorBtn);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.fontSizeTb);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.fontNameTb);
            this.tabPage2.Controls.Add(this.clearTextBtn);
            this.tabPage2.Controls.Add(this.SavePpBtn);
            this.tabPage2.Controls.Add(this.ppContentTb);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Create PPTX File";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // selectBackgroundColorBtn
            // 
            this.selectBackgroundColorBtn.Location = new System.Drawing.Point(628, 225);
            this.selectBackgroundColorBtn.Name = "selectBackgroundColorBtn";
            this.selectBackgroundColorBtn.Size = new System.Drawing.Size(113, 23);
            this.selectBackgroundColorBtn.TabIndex = 12;
            this.selectBackgroundColorBtn.Text = "Background Color";
            this.selectBackgroundColorBtn.UseVisualStyleBackColor = true;
            this.selectBackgroundColorBtn.Click += new System.EventHandler(this.selectBackgroundColorBtn_Click);
            // 
            // selectFontColorBtn
            // 
            this.selectFontColorBtn.Location = new System.Drawing.Point(628, 192);
            this.selectFontColorBtn.Name = "selectFontColorBtn";
            this.selectFontColorBtn.Size = new System.Drawing.Size(113, 23);
            this.selectFontColorBtn.TabIndex = 11;
            this.selectFontColorBtn.Text = "Font Color";
            this.selectFontColorBtn.UseVisualStyleBackColor = true;
            this.selectFontColorBtn.Click += new System.EventHandler(this.selectFontColorBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(628, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Font Size";
            // 
            // fontSizeTb
            // 
            this.fontSizeTb.Location = new System.Drawing.Point(628, 101);
            this.fontSizeTb.Name = "fontSizeTb";
            this.fontSizeTb.Size = new System.Drawing.Size(156, 23);
            this.fontSizeTb.TabIndex = 5;
            this.fontSizeTb.Text = "60";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(628, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Font name";
            // 
            // fontNameTb
            // 
            this.fontNameTb.Location = new System.Drawing.Point(628, 43);
            this.fontNameTb.Name = "fontNameTb";
            this.fontNameTb.Size = new System.Drawing.Size(156, 23);
            this.fontNameTb.TabIndex = 3;
            this.fontNameTb.Text = "Tahoma";
            // 
            // clearTextBtn
            // 
            this.clearTextBtn.Location = new System.Drawing.Point(628, 391);
            this.clearTextBtn.Name = "clearTextBtn";
            this.clearTextBtn.Size = new System.Drawing.Size(75, 23);
            this.clearTextBtn.TabIndex = 2;
            this.clearTextBtn.Text = "Clear";
            this.clearTextBtn.UseVisualStyleBackColor = true;
            this.clearTextBtn.Click += new System.EventHandler(this.clearTextBtn_Click);
            // 
            // SavePpBtn
            // 
            this.SavePpBtn.Location = new System.Drawing.Point(709, 391);
            this.SavePpBtn.Name = "SavePpBtn";
            this.SavePpBtn.Size = new System.Drawing.Size(75, 23);
            this.SavePpBtn.TabIndex = 1;
            this.SavePpBtn.Text = "Save";
            this.SavePpBtn.UseVisualStyleBackColor = true;
            this.SavePpBtn.Click += new System.EventHandler(this.SavePpBtn_Click);
            // 
            // ppContentTb
            // 
            this.ppContentTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ppContentTb.Dock = System.Windows.Forms.DockStyle.Left;
            this.ppContentTb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ppContentTb.Location = new System.Drawing.Point(3, 3);
            this.ppContentTb.Name = "ppContentTb";
            this.ppContentTb.Size = new System.Drawing.Size(619, 416);
            this.ppContentTb.TabIndex = 0;
            this.ppContentTb.Text = "";
            // 
            // boldFontCb
            // 
            this.boldFontCb.AutoSize = true;
            this.boldFontCb.Location = new System.Drawing.Point(628, 134);
            this.boldFontCb.Name = "boldFontCb";
            this.boldFontCb.Size = new System.Drawing.Size(77, 19);
            this.boldFontCb.TabIndex = 13;
            this.boldFontCb.Text = "Bold Font";
            this.boldFontCb.UseVisualStyleBackColor = true;
            // 
            // noSpaceAndNewLineCbx
            // 
            this.noSpaceAndNewLineCb.AutoSize = true;
            this.noSpaceAndNewLineCb.Location = new System.Drawing.Point(628, 163);
            this.noSpaceAndNewLineCb.Name = "noSpaceAndNewLineCbx";
            this.noSpaceAndNewLineCb.Size = new System.Drawing.Size(146, 19);
            this.noSpaceAndNewLineCb.TabIndex = 14;
            this.noSpaceAndNewLineCb.Text = "Remove Spaces, Enters";
            this.noSpaceAndNewLineCb.UseVisualStyleBackColor = true;
            // 
            // PowerPointHelperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "PowerPointHelperForm";
            this.Text = "Power Point Helper";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPage1;
        private ListView listView;
        private TabPage tabPage2;
        private Button okBtn;
        private Button clearBtn;
        private RichTextBox ppContentTb;
        private Button clearTextBtn;
        private Button SavePpBtn;
        private Label label2;
        private TextBox fontSizeTb;
        private Label label1;
        private TextBox fontNameTb;
        private Button selectFontColorBtn;
        private Button selectBackgroundColorBtn;
        private CheckBox noSpaceAndNewLineCb;
        private CheckBox boldFontCb;
    }
}