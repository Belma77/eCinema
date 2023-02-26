using eCinema.WinUI.Helpers;
using eCInema.Models.Dtos.Customer;
using eCInema.Models.Dtos.LoyaltyCard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCinema.WinUI.LoyalClub
{
    public partial class frmLoyalClub : Form
    {
        private CustomerDto _customer;
        private APIservice _service= new APIservice("LoyaltyClub");
        public frmLoyalClub(CustomerDto customer)
        {
            _customer = customer;
            InitializeComponent();
        }

        private void frmLoyalClub_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            if(_customer!=null)
            {
                txtFirst.Text = _customer.FirstName;
                txtLast.Text = _customer.LastName;
                txtEmail.Text = _customer.Email;    
                txtPhone.Text = _customer.Phone;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if(Validated())
            {
                var loyalty = new LoyalCardInsertDto();
                loyalty.FirstName=txtFirst.Text;
                loyalty.LastName = txtLast.Text;
                loyalty.Email = txtEmail.Text;
                loyalty.Phone = txtPhone.Text;
                loyalty.City=txtCity.Text;  
                loyalty.IdentificationNumber = txtId.Text;
                loyalty.CustomerId = _customer.Id;
                await _service.Post<LoyalCardDto>(loyalty);
                MessageBox.Show(AlertMessages.SuccessfulyAdded);
                this.Close();
            }
        }

        private bool Validated()
        {
            int result;
            if(!int.TryParse(txtPhone.Text, out result))
            {
                err.SetError(txtPhone, AlertMessages.OnlyNumbersAllowed);
                return false;
            }
            Regex emailRegxExpression;
            if (txtEmail.Text.Trim() != string.Empty)
            {
                emailRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!emailRegxExpression.IsMatch(txtEmail.Text.Trim()))
                {
                    err.SetError(txtEmail, AlertMessages.EmailFormat);
                    return false;
                }
            }
            return Validator.Validate(txtFirst, err, AlertMessages.RequiredField) &&
                Validator.Validate(txtLast, err, AlertMessages.RequiredField) &&
                Validator.Validate(txtEmail, err, AlertMessages.RequiredField) &&
                Validator.Validate(txtPhone, err, AlertMessages.RequiredField) &&
                Validator.Validate(txtCity, err, AlertMessages.RequiredField) &&
                Validator.Validate(txtId, err, AlertMessages.RequiredField);

        }
    }
}
