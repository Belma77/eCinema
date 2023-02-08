using eCinema.WinUI.Customers;
using eCinema.WinUI.Reports;
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

        private void moviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMovies frm=new frmMovies();
            frm.MdiParent = this;
            frm.Show();

        }

        private void scheduleOfProjectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSchedule frm=new frmSchedule();
            frm.MdiParent = this;
            frm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReservations frm = new frmReservations();
            frm.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
