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
            frm.ShowDialog();

        }

        private void scheduleOfProjectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSchedule frm=new frmSchedule();
            frm.ShowDialog();
        }
    }
}
