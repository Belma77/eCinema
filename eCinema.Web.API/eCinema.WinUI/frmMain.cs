using eCinema.WinUI.Customers;
using eCinema.WinUI.Reports;
using eCinema.WinUI.Reservations;
using eCinema.WinUI.ScheduleForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCinema.WinUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salesPerCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesPerCustomerReport frm = new frmSalesPerCustomerReport();
            frm.ShowDialog();
        }

        private void salesPerMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesPerMovie frm= new frmSalesPerMovie();
            frm.ShowDialog();
        }

        private void addNewMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddMovie frm = new frmAddMovie();
            frm.ShowDialog();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInsertSchedule frm = new frmInsertSchedule();
            frm.ShowDialog();
        }

        private void addNewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddReservation frm = new frmAddReservation();
            frm.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Restart();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var username = APIservice.Username;
            lblWelcome.Text = "Welcome " + username;
        }
       
        private void showAllMoviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMovies frm = new frmMovies();
            frm.MdiParent = this;
            frm.Show();
        }

        private void showAllSchedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                frmSchedule frm = new frmSchedule();
                frm.MdiParent = this;
                frm.Show();
            
        }

        private void showAllReservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReservations frm = new frmReservations();
            frm.ShowDialog();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

       
    }
}
