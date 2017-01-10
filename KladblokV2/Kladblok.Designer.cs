namespace KladblokV2
{
    partial class Kladblok
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kladblok));
            this.startMenuStrip = new System.Windows.Forms.MenuStrip();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Textbox = new System.Windows.Forms.RichTextBox();
            this.ConsoleCheck = new System.Windows.Forms.CheckBox();
            this.SnSLogo = new System.Windows.Forms.PictureBox();
            this.editMenuStrip = new System.Windows.Forms.MenuStrip();
            this.BackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_Textbox = new System.Windows.Forms.RichTextBox();
            this.AutoSave = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.QuestionButt = new System.Windows.Forms.Button();
            this.TRT_Label = new System.Windows.Forms.Label();
            this.startMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SnSLogo)).BeginInit();
            this.editMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // startMenuStrip
            // 
            this.startMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.startMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditToolStripMenuItem});
            this.startMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.startMenuStrip.Name = "startMenuStrip";
            this.startMenuStrip.Size = new System.Drawing.Size(484, 24);
            this.startMenuStrip.TabIndex = 0;
            this.startMenuStrip.Text = "Menu";
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.EditToolStripMenuItem.Text = "Edit";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // Textbox
            // 
            this.Textbox.AcceptsTab = true;
            this.Textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Textbox.BackColor = System.Drawing.SystemColors.Control;
            this.Textbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Textbox.DetectUrls = false;
            this.Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Textbox.Location = new System.Drawing.Point(12, 27);
            this.Textbox.Name = "Textbox";
            this.Textbox.ReadOnly = true;
            this.Textbox.Size = new System.Drawing.Size(460, 572);
            this.Textbox.TabIndex = 1;
            this.Textbox.TabStop = false;
            this.Textbox.Tag = "";
            this.Textbox.Text = "";
            this.Textbox.WordWrap = false;
            // 
            // ConsoleCheck
            // 
            this.ConsoleCheck.AutoSize = true;
            this.ConsoleCheck.Checked = true;
            this.ConsoleCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ConsoleCheck.Location = new System.Drawing.Point(46, 4);
            this.ConsoleCheck.Name = "ConsoleCheck";
            this.ConsoleCheck.Size = new System.Drawing.Size(64, 17);
            this.ConsoleCheck.TabIndex = 75;
            this.ConsoleCheck.Text = "Console";
            this.ConsoleCheck.UseVisualStyleBackColor = true;
            this.ConsoleCheck.CheckedChanged += new System.EventHandler(this.ConsoleCheck_CheckedChanged);
            // 
            // SnSLogo
            // 
            this.SnSLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SnSLogo.BackgroundImage")));
            this.SnSLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SnSLogo.Location = new System.Drawing.Point(453, 4);
            this.SnSLogo.Name = "SnSLogo";
            this.SnSLogo.Size = new System.Drawing.Size(20, 20);
            this.SnSLogo.TabIndex = 76;
            this.SnSLogo.TabStop = false;
            // 
            // editMenuStrip
            // 
            this.editMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.editMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackToolStripMenuItem,
            this.chooseColorToolStripMenuItem,
            this.backgroundColorToolStripMenuItem});
            this.editMenuStrip.Location = new System.Drawing.Point(0, 24);
            this.editMenuStrip.Name = "editMenuStrip";
            this.editMenuStrip.Size = new System.Drawing.Size(484, 24);
            this.editMenuStrip.TabIndex = 78;
            this.editMenuStrip.Text = "Menu";
            this.editMenuStrip.Visible = false;
            // 
            // BackToolStripMenuItem
            // 
            this.BackToolStripMenuItem.Name = "BackToolStripMenuItem";
            this.BackToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.BackToolStripMenuItem.Text = "Back";
            this.BackToolStripMenuItem.Click += new System.EventHandler(this.BackToolStripMenuItem_Click);
            // 
            // chooseColorToolStripMenuItem
            // 
            this.chooseColorToolStripMenuItem.Name = "chooseColorToolStripMenuItem";
            this.chooseColorToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.chooseColorToolStripMenuItem.Text = "Choose Color";
            this.chooseColorToolStripMenuItem.Click += new System.EventHandler(this.chooseColorToolStripMenuItem_Click);
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.backgroundColorToolStripMenuItem.Text = "Background Color";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
            // 
            // Edit_Textbox
            // 
            this.Edit_Textbox.AcceptsTab = true;
            this.Edit_Textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Edit_Textbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Edit_Textbox.DetectUrls = false;
            this.Edit_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Edit_Textbox.Location = new System.Drawing.Point(12, 27);
            this.Edit_Textbox.Name = "Edit_Textbox";
            this.Edit_Textbox.Size = new System.Drawing.Size(460, 572);
            this.Edit_Textbox.TabIndex = 77;
            this.Edit_Textbox.Text = "";
            this.Edit_Textbox.Visible = false;
            this.Edit_Textbox.WordWrap = false;
            // 
            // AutoSave
            // 
            this.AutoSave.Enabled = true;
            this.AutoSave.Interval = 1000;
            this.AutoSave.Tick += new System.EventHandler(this.AutoSave_Tick);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            // 
            // QuestionButt
            // 
            this.QuestionButt.Location = new System.Drawing.Point(427, 4);
            this.QuestionButt.Name = "QuestionButt";
            this.QuestionButt.Size = new System.Drawing.Size(20, 20);
            this.QuestionButt.TabIndex = 79;
            this.QuestionButt.Text = "?";
            this.QuestionButt.UseVisualStyleBackColor = true;
            this.QuestionButt.Click += new System.EventHandler(this.QuestionButt_Click);
            // 
            // TRT_Label
            // 
            this.TRT_Label.AutoSize = true;
            this.TRT_Label.Location = new System.Drawing.Point(116, 5);
            this.TRT_Label.Name = "TRT_Label";
            this.TRT_Label.Size = new System.Drawing.Size(28, 13);
            this.TRT_Label.TabIndex = 80;
            this.TRT_Label.Text = "Text";
            // 
            // Kladblok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 611);
            this.Controls.Add(this.TRT_Label);
            this.Controls.Add(this.QuestionButt);
            this.Controls.Add(this.SnSLogo);
            this.Controls.Add(this.editMenuStrip);
            this.Controls.Add(this.Edit_Textbox);
            this.Controls.Add(this.ConsoleCheck);
            this.Controls.Add(this.Textbox);
            this.Controls.Add(this.startMenuStrip);
            this.MainMenuStrip = this.startMenuStrip;
            this.Name = "Kladblok";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kladblok";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Kladblok_FormClosing);
            this.Load += new System.EventHandler(this.Kladblok_Load);
            this.startMenuStrip.ResumeLayout(false);
            this.startMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SnSLogo)).EndInit();
            this.editMenuStrip.ResumeLayout(false);
            this.editMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SnSLogo;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        public System.Windows.Forms.MenuStrip startMenuStrip;
        private System.Windows.Forms.RichTextBox Textbox;
        private System.Windows.Forms.CheckBox ConsoleCheck;
        public System.Windows.Forms.MenuStrip editMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem BackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
        private System.Windows.Forms.RichTextBox Edit_Textbox;
        private System.Windows.Forms.Timer AutoSave;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button QuestionButt;
        private System.Windows.Forms.Label TRT_Label;
    }
}

