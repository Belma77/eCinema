using eCinema.WinUI.Helpers;
using eCinema.WinUI.LoyalClub;
using eCInema.Models.Dtos.Customer;
using eCInema.Models.Dtos.Users;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCinema.WinUI.Customers
{
    public partial class frmCustomers : Form
    {
        private APIservice service = new APIservice("Customer");
        int pageSize = 10;
        int pageNumber=1;
        bool isLoaded = false;
        public frmCustomers()
        {
            InitializeComponent();
        }

        private async void frmCustomers_Load(object sender, EventArgs e)
        {
            await LoadCustomers();
            LoadCmb();
        }

        private void LoadCmb()
        {
            cmbPageSize.DataSource = service.ItemsPerPage;
        }

        private async Task LoadCustomers()
        {
            btnNext.Enabled = true;
            if(pageNumber==1)
            {
                btnPrevoius.Enabled = false;
            }
            else
            {
                btnPrevoius.Enabled = true;
            }
            var search = new CustomerSearchObject();
            search.Name = txtName.Text;
            search.PageNumber = pageNumber;
            search.PageSize = pageSize;
            var customers = await service.Get<List<CustomerDto>>(search);
            dgvCustomers.AutoGenerateColumns = false;
            if (customers != null)
            {
                dgvCustomers.DataSource = customers.ToList();
                if(customers.Count<pageSize)
                {
                    btnNext.Enabled = false;
                }    
            }


        }

        private async void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var data = dgvCustomers.SelectedRows[0].DataBoundItem as CustomerDto;
            
            if (e.ColumnIndex == 5)
            {
                if (data.CustomerType == eCInema.Models.Enums.CustomerTypeEnum.Premium)
                    MessageBox.Show("Customer already added to loyalty club!");
                
                else
                {
                    frmLoyalClub frm = new frmLoyalClub(data);
                    frm.ShowDialog();
                    await LoadCustomers();
                }
            }  
            
            if (e.ColumnIndex == 6)
                {   
                if (data != null)
                {
                    if (MessageBox.Show(AlertMessages.Delete, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        await service.Delete(data.Id);
                        await LoadCustomers();

                    }
                }
            }
        }


        private async void btnNext_Click(object sender, EventArgs e)
        {
            pageNumber++;
            await LoadCustomers();
            btnPrevoius.Enabled = true;
        }

        private async void btnPrevoius_Click(object sender, EventArgs e)
        {
            if(pageNumber>1)
            {
                pageNumber--;
                await LoadCustomers();
                btnNext.Enabled = true;
            }
        }

        private async void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!isLoaded)
            {
                isLoaded = true;
            }
            else
            {
                pageSize = int.Parse(cmbPageSize.SelectedItem.ToString());
                await LoadCustomers();
            }
        }

        private async void txtSearch_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            await LoadCustomers();
        }
    }
}
