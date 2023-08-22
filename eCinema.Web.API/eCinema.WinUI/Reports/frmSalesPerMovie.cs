using eCInema.Models.Dtos.Movie;
using eCInema.Models.Dtos.Reservations;
using eCInema.Models.SearchObjects;
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

namespace eCinema.WinUI.Reports
{
    public partial class frmSalesPerMovie : Form
    {
        private APIservice service = new APIservice("Movies");
        private List<MovieSales> salesMovies = new List<MovieSales>();
        ReportDataSource rds=new ReportDataSource();
        private SalesPerMovieSearchObject search;
        public frmSalesPerMovie()
        {
            InitializeComponent();
        }
        private async Task LoadSalesPerMovie()
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                search = new SalesPerMovieSearchObject();
                search.Title=txtSearch.Text;
                salesMovies = await service.Get<List<MovieSales>>("Sales", search);
                
            }
            else
            {

                salesMovies = await service.Get<List<MovieSales>>("Sales");

            }
        }

        private async Task LoadReportData()
        {
            await LoadSalesPerMovie();
            rpvSalesMovie.LocalReport.ReportEmbeddedResource = "eCinema.WinUI.Reports.SalesPerMovie.rdlc";
            rpvSalesMovie.RefreshReport();
            rpvSalesMovie.LocalReport.DataSources.Clear();
            var salesTable = new dsMovie.SalesPerMovieDataTable();
            foreach (var sale in salesMovies)
            {
                var row = salesTable.NewSalesPerMovieRow();
                row.MovieId = sale.Movie.Id.ToString();
                row.Title = sale.Movie.Title;
                row.Sales = sale.Sales.ToString();
                salesTable.Rows.Add(row);

            }

            rds.Name = "dsMovie";
            rds.Value = salesTable;
            rpvSalesMovie.LocalReport.DataSources.Clear();
            rpvSalesMovie.LocalReport.DataSources.Add(rds);
            rpvSalesMovie.RefreshReport();
        }
        private async void frmSalesPerMovie_Load(object sender, EventArgs e)
        {
           await LoadReportData();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
    
            await LoadReportData();
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            await LoadReportData();   
        }
    }
}
