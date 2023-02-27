using eCInema.Models.Dtos.Movie;
using eCInema.Models.Dtos.Reservations;
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
        public frmSalesPerMovie()
        {
            InitializeComponent();
        }
        private async Task LoadSalesPerMovie()
        {
            salesMovies = await service.GetSales<List<MovieSales>>("Sales");
        }
        private async void frmSalesPerMovie_LoadAsync(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtSearch.Text))
            {
                rpvSalesMovie.RefreshReport();
                var filter =txtSearch.Text.ToLower();
                var data = salesMovies.Where(x => x.Movie.Title.ToLower().Contains(filter)).ToList();
                rpvSalesMovie.RefreshReport();
                rpvSalesMovie.LocalReport.DataSources.Clear();
                var salesTable = new dsMovie.SalesPerMovieDataTable();
                foreach (var sale in data)
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
        }
    }
}
