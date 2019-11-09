namespace BoardingPlanner
{
    partial class MDIPatent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIPatent));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mastersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importLeaveDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewPlanningsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPlanningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOnLeaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mastersToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1073, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mastersToolStripMenuItem
            // 
            this.mastersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importDataToolStripMenuItem,
            this.importLeaveDataToolStripMenuItem});
            this.mastersToolStripMenuItem.Name = "mastersToolStripMenuItem";
            this.mastersToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.mastersToolStripMenuItem.Text = "Imports";
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            this.importDataToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.importDataToolStripMenuItem.Text = "Planning Data";
            this.importDataToolStripMenuItem.Click += new System.EventHandler(this.importDataToolStripMenuItem_Click);
            // 
            // importLeaveDataToolStripMenuItem
            // 
            this.importLeaveDataToolStripMenuItem.Name = "importLeaveDataToolStripMenuItem";
            this.importLeaveDataToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.importLeaveDataToolStripMenuItem.Text = "Leave Data";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewPlanningsToolStripMenuItem,
            this.createPlanningToolStripMenuItem,
            this.viewOnLeaveToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.viewToolStripMenuItem.Text = "Operations";
            // 
            // viewPlanningsToolStripMenuItem
            // 
            this.viewPlanningsToolStripMenuItem.Name = "viewPlanningsToolStripMenuItem";
            this.viewPlanningsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.viewPlanningsToolStripMenuItem.Text = "Create Planning";
            this.viewPlanningsToolStripMenuItem.Click += new System.EventHandler(this.viewPlanningsToolStripMenuItem_Click);
            // 
            // createPlanningToolStripMenuItem
            // 
            this.createPlanningToolStripMenuItem.Name = "createPlanningToolStripMenuItem";
            this.createPlanningToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.createPlanningToolStripMenuItem.Text = "View Plannings";
            this.createPlanningToolStripMenuItem.Click += new System.EventHandler(this.createPlanningToolStripMenuItem_Click);
            // 
            // viewOnLeaveToolStripMenuItem
            // 
            this.viewOnLeaveToolStripMenuItem.Name = "viewOnLeaveToolStripMenuItem";
            this.viewOnLeaveToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.viewOnLeaveToolStripMenuItem.Text = "View on Leave";
            this.viewOnLeaveToolStripMenuItem.Click += new System.EventHandler(this.viewOnLeaveToolStripMenuItem_Click);
            // 
            // MDIPatent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 418);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDIPatent";
            this.Text = "On Board Planner";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mastersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewPlanningsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importLeaveDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createPlanningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewOnLeaveToolStripMenuItem;
    }
}

