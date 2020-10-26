namespace Donnatello
{
    partial class Donnatello
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Donnatello));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PaintBox = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MultiCommands = new System.Windows.Forms.RichTextBox();
            this.CommandLine = new System.Windows.Forms.TextBox();
            this.RunButton = new System.Windows.Forms.Button();
            this.StatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaintBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveProgramToolStripMenuItem,
            this.resetProgramToolStripMenuItem,
            this.closeWindowToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // saveProgramToolStripMenuItem
            // 
            this.saveProgramToolStripMenuItem.Name = "saveProgramToolStripMenuItem";
            this.saveProgramToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveProgramToolStripMenuItem.Text = "Save Program";
            // 
            // resetProgramToolStripMenuItem
            // 
            this.resetProgramToolStripMenuItem.Name = "resetProgramToolStripMenuItem";
            this.resetProgramToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.resetProgramToolStripMenuItem.Text = "Reset Program";
            // 
            // closeWindowToolStripMenuItem
            // 
            this.closeWindowToolStripMenuItem.Name = "closeWindowToolStripMenuItem";
            this.closeWindowToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.closeWindowToolStripMenuItem.Text = "Close Window";
            // 
            // PaintBox
            // 
            this.PaintBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PaintBox.Location = new System.Drawing.Point(346, 42);
            this.PaintBox.Name = "PaintBox";
            this.PaintBox.Size = new System.Drawing.Size(442, 358);
            this.PaintBox.TabIndex = 1;
            this.PaintBox.TabStop = false;
            this.PaintBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBox_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MultiCommands
            // 
            this.MultiCommands.Location = new System.Drawing.Point(12, 42);
            this.MultiCommands.Name = "MultiCommands";
            this.MultiCommands.Size = new System.Drawing.Size(314, 321);
            this.MultiCommands.TabIndex = 3;
            this.MultiCommands.Text = "";
            // 
            // CommandLine
            // 
            this.CommandLine.Location = new System.Drawing.Point(12, 380);
            this.CommandLine.Name = "CommandLine";
            this.CommandLine.Size = new System.Drawing.Size(223, 20);
            this.CommandLine.TabIndex = 4;
            this.CommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandLine_KeyDown);
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(251, 380);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 5;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            // 
            // StatusBar
            // 
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(45, 17);
            this.StatusBar.Text = "STATUS";
            this.StatusBar.TextChanged += new System.EventHandler(this.StatusBar_TextChanged);
            // 
            // Donnatello
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.CommandLine);
            this.Controls.Add(this.MultiCommands);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.PaintBox);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Donnatello";
            this.Text = "Donatello Graphics";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaintBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.PictureBox PaintBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.RichTextBox MultiCommands;
        private System.Windows.Forms.TextBox CommandLine;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem saveProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeWindowToolStripMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel StatusBar;
    }
}

