using eCInema.Models.Dtos.Reservations;
using eCInema.Models.SearchObjects;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
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
    public partial class frmSalesPerCustomerReport : Form
    {
        private APIservice service = new APIservice("Reservation");
        List<SalesPerCustomer> sales = new List<SalesPerCustomer>();
        SalesByCustomerSearchObject? search = null;
        public frmSalesPerCustomerReport()
        {
            InitializeComponent();
        }

        private async Task LoadSales()
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                search = new SalesByCustomerSearchObject();
                search.Name = txtSearch.Text;
                sales = await service.Get<List<SalesPerCustomer>>("ByCustomer", search);

            }
            else
            {
                sales = await service.Get<List<SalesPerCustomer>>("ByCustomer");

            }
        }

        private async void frmSalesPerCustomerReport_Load(object sender, EventArgs e)
        {
            await LoadReportData();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            
            await LoadReportData();
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            await LoadReportData();
        }

        private async Task LoadReportData()
        {
            await LoadSales();
            rpvSales.LocalReport.ReportEmbeddedResource = "eCinema.WinUI.Reports.SalesPerCustomer.rdlc";
            rpvSales.RefreshReport();
            rpvSales.LocalReport.DataSources.Clear();
            var rds = new ReportDataSource();
            var salesTable = new dsSales.SalesPerCustomerDataTable();
            foreach (var sale in sales)
            {
                var row = salesTable.NewSalesPerCustomerRow();
                row.CustomerId = sale.Customer.Id.ToString();
                row.FirstName = sale.Customer.FirstName;
                row.LastName = sale.Customer.LastName;
                row.Sales = sale.Sales.ToString("0.00");
                salesTable.Rows.Add(row);

            }

            rds.Name = "dsSales";
            rds.Value = salesTable;
            rpvSales.LocalReport.DataSources.Clear();
            rpvSales.LocalReport.DataSources.Add(rds);
            rpvSales.RefreshReport();
        }
    }
}
