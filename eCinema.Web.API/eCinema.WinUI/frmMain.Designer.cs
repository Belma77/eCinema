namespace eCinema.WinUI
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.moviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllMoviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewMovieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleOfProjectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllSchedulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllReservationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesPerCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesPerMovieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moviesToolStripMenuItem,
            this.scheduleOfProjectionsToolStripMenuItem,
            this.reservationsToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(899, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // moviesToolStripMenuItem
            // 
            this.moviesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllMoviesToolStripMenuItem,
            this.addNewMovieToolStripMenuItem});
            this.moviesToolStripMenuItem.Name = "moviesToolStripMenuItem";
            this.moviesToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.moviesToolStripMenuItem.Text = "Movies";
            // 
            // showAllMoviesToolStripMenuItem
            // 
            this.showAllMoviesToolStripMenuItem.Name = "showAllMoviesToolStripMenuItem";
            this.showAllMoviesToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.showAllMoviesToolStripMenuItem.Text = "Show all movies";
            this.showAllMoviesToolStripMenuItem.Click += new System.EventHandler(this.showAllMoviesToolStripMenuItem_Click);
            // 
            // addNewMovieToolStripMenuItem
            // 
            this.addNewMovieToolStripMenuItem.Name = "addNewMovieToolStripMenuItem";
            this.addNewMovieToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.addNewMovieToolStripMenuItem.Text = "Add new";
            this.addNewMovieToolStripMenuItem.Click += new System.EventHandler(this.addNewMovieToolStripMenuItem_Click);
            // 
            // scheduleOfProjectionsToolStripMenuItem
            // 
            this.scheduleOfProjectionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllSchedulesToolStripMenuItem,
            this.addNewToolStripMenuItem});
            this.scheduleOfProjectionsToolStripMenuItem.Name = "scheduleOfProjectionsToolStripMenuItem";
            this.scheduleOfProjectionsToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.scheduleOfProjectionsToolStripMenuItem.Text = "Schedule of projections";
            // 
            // showAllSchedulesToolStripMenuItem
            // 
            this.showAllSchedulesToolStripMenuItem.Name = "showAllSchedulesToolStripMenuItem";
            this.showAllSchedulesToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.showAllSchedulesToolStripMenuItem.Text = "Show all schedules";
            this.showAllSchedulesToolStripMenuItem.Click += new System.EventHandler(this.showAllSchedulesToolStripMenuItem_Click);
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.addNewToolStripMenuItem.Text = "Add new ";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.addNewToolStripMenuItem_Click);
            // 
            // reservationsToolStripMenuItem
            // 
            this.reservationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllReservationsToolStripMenuItem,
            this.addNewToolStripMenuItem1});
            this.reservationsToolStripMenuItem.Name = "reservationsToolStripMenuItem";
            this.reservationsToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.reservationsToolStripMenuItem.Text = "Reservations";
            // 
            // showAllReservationsToolStripMenuItem
            // 
            this.showAllReservationsToolStripMenuItem.Name = "showAllReservationsToolStripMenuItem";
            this.showAllReservationsToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.showAllReservationsToolStripMenuItem.Text = "Show all reservations";
            this.showAllReservationsToolStripMenuItem.Click += new System.EventHandler(this.showAllReservationsToolStripMenuItem_Click);
            // 
            // addNewToolStripMenuItem1
            // 
            this.addNewToolStripMenuItem1.Name = "addNewToolStripMenuItem1";
            this.addNewToolStripMenuItem1.Size = new System.Drawing.Size(231, 26);
            this.addNewToolStripMenuItem1.Text = "Add new";
            this.addNewToolStripMenuItem1.Click += new System.EventHandler(this.addNewToolStripMenuItem1_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesPerCustomerToolStripMenuItem,
            this.salesPerMovieToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // salesPerCustomerToolStripMenuItem
            // 
            this.salesPerCustomerToolStripMenuItem.Name = "salesPerCustomerToolStripMenuItem";
            this.salesPerCustomerToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.salesPerCustomerToolStripMenuItem.Text = "Sales per Customer";
            this.salesPerCustomerToolStripMenuItem.Click += new System.EventHandler(this.salesPerCustomerToolStripMenuItem_Click);
            // 
            // salesPerMovieToolStripMenuItem
            // 
            this.salesPerMovieToolStripMenuItem.Name = "salesPerMovieToolStripMenuItem";
            this.salesPerMovieToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.salesPerMovieToolStripMenuItem.Text = "Sales per Movie";
            this.salesPerMovieToolStripMenuItem.Click += new System.EventHandler(this.salesPerMovieToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.Location = new System.Drawing.Point(12, 50);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(99, 28);
            this.lblWelcome.TabIndex = 6;
            this.lblWelcome.Text = "Welcome";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 527);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem moviesToolStripMenuItem;
        private ToolStripMenuItem scheduleOfProjectionsToolStripMenuItem;
        private ToolStripMenuItem reservationsToolStripMenuItem;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem salesPerCustomerToolStripMenuItem;
        private ToolStripMenuItem salesPerMovieToolStripMenuItem;
        private ToolStripMenuItem addNewMovieToolStripMenuItem;
        private ToolStripMenuItem addNewToolStripMenuItem;
        private ToolStripMenuItem addNewToolStripMenuItem1;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private Label lblWelcome;
        private ToolStripMenuItem showAllMoviesToolStripMenuItem;
        private ToolStripMenuItem showAllSchedulesToolStripMenuItem;
        private ToolStripMenuItem showAllReservationsToolStripMenuItem;
    }
}