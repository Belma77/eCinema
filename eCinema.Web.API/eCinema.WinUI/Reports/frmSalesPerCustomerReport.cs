using eCInema.Models.Dtos.Reservations;
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
        public frmSalesPerCustomerReport()
        {
            InitializeComponent();
        }

        private async Task LoadSales()
        {
            sales = await service.GetSales<List<SalesPerCustomer>>("ByCustomer");
        }

        private async void frmSalesPerCustomerReport_LoadAsync(object sender, EventArgs e)
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
                row.Sales = sale.Sales.ToString();
                salesTable.Rows.Add(row);

            }

            rds.Name = "dsSales";
            rds.Value = salesTable;
            rpvSales.LocalReport.DataSources.Clear();
            rpvSales.LocalReport.DataSources.Add(rds);
            rpvSales.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                rpvSales.RefreshReport();
                rpvSales.LocalReport.DataSources.Clear();
                var rds = new ReportDataSource();
                var salesTable = new dsSales.SalesPerCustomerDataTable();
                var filter = txtSearch.Text.ToLower();
                var data = sales.Where(x => x.Customer.FirstName.ToLower().Contains(filter) || x.Customer.LastName.ToLower().Contains(filter));
                foreach (var sale in data)
                {
                    var row = salesTable.NewSalesPerCustomerRow();
                    row.CustomerId = sale.Customer.Id.ToString();
                    row.FirstName = sale.Customer.FirstName;
                    row.LastName = sale.Customer.LastName;
                    row.Sales = sale.Sales.ToString();
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
}
