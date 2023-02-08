using eCinema.WinUI._190036DataSetTableAdapters;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace eCinema.WinUI.Reports
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "eCinema.WinUI.Reports.Report1.rdlc";
            reportViewer1.RefreshReport();
            var rds = new ReportDataSource();         
            var tableAdapter = new ReservationsMoviesQueryTableAdapter();
            rds.Value = tableAdapter.GetData();
            rds.Name = "ID_190036DataSet";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
