namespace BCS31_Automata
{
    partial class FrmMainParent
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
            this.menuParentStrip1 = new System.Windows.Forms.MenuStrip();
            this.automatonSimulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuParentStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuParentStrip1
            // 
            this.menuParentStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automatonSimulatorToolStripMenuItem,
            this.usersManualToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuParentStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuParentStrip1.Name = "menuParentStrip1";
            this.menuParentStrip1.Size = new System.Drawing.Size(1014, 24);
            this.menuParentStrip1.TabIndex = 1;
            this.menuParentStrip1.Text = "menuStrip1";
            // 
            // automatonSimulatorToolStripMenuItem
            // 
            this.automatonSimulatorToolStripMenuItem.Name = "automatonSimulatorToolStripMenuItem";
            this.automatonSimulatorToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.automatonSimulatorToolStripMenuItem.Text = "Automaton Simulator";
            this.automatonSimulatorToolStripMenuItem.Click += new System.EventHandler(this.menuStripClicked);
            // 
            // usersManualToolStripMenuItem
            // 
            this.usersManualToolStripMenuItem.Name = "usersManualToolStripMenuItem";
            this.usersManualToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.usersManualToolStripMenuItem.Text = "User\'s Manual";
            this.usersManualToolStripMenuItem.Click += new System.EventHandler(this.menuStripClicked);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.menuStripClicked);
            // 
            // FrmMainParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 473);
            this.Controls.Add(this.menuParentStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuParentStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMainParent";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COMS102 Final Project";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuParentStrip1.ResumeLayout(false);
            this.menuParentStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuParentStrip1;
        private System.Windows.Forms.ToolStripMenuItem automatonSimulatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}