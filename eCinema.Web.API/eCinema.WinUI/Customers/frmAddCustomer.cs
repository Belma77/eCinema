using eCinema.WinUI.Helpers;
using eCInema.Models.Dtos.Customer;
using eCInema.Models.Dtos.Users;
using eCInema.Models.Enums;
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
    public partial class frmAddCustomer : Form
    {
        APIservice service = new APIservice("User");
        public frmAddCustomer()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if(Validate())
            {
                var insert = new UserInsertDto();
                insert.FirstName = txtFirstName.Text;
                insert.LastName = txtLastName.Text;
                insert.Phone = txtPhone.Text;
                insert.Email = txtEmail.Text;
                insert.CustomerType = (CustomerTypeEnum)cmbCustomer.SelectedItem;

                if (insert != null)
                  await service.Post<UserInsertDto>(insert);

                MessageBox.Show(AlertMessages.SuccessfulyAdded);
                this.Close();
            }
        }

        private void frmAddCustomer_Load(object sender, EventArgs e)
        {
            LoadCmb();
   
        }
        private void LoadCmb()
        {
            var list = Enum.GetValues<CustomerTypeEnum>();
            cmbCustomer.DataSource = list;
        }
    }
}
