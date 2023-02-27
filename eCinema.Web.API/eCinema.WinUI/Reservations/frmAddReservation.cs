using eCinema.WinUI.Helpers;
using eCInema.Models.Dtos.Customer;
using eCInema.Models.Dtos.Movie;
using eCInema.Models.Dtos.Schedules;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using eCInema.Models.SearchObjects;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCinema.WinUI.Reservations
{
    public partial class frmAddReservation : Form
    {
        private APIservice service = new APIservice("Schedule");
        private APIservice customerService = new APIservice("Customer");
        private GetSchedulesDto schedule;
        private List<GetSchedulesDto> schedules;
        private List<CustomerDto>  customers;
        private CustomerDto  customer;
        private ReservationStatusEnum payStatus;
        bool isLoaded = false;

        public frmAddReservation()
        {
            InitializeComponent();
        }

       
        private void frmAddReservation_Load(object sender, EventArgs e)
        {
            cmbFirstName.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbFirstName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbLastName.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbLastName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            LoadCmb();

        }

        private async void  LoadCmb()
        {
            schedules = await service.Get<List<GetSchedulesDto>>();
            if (schedules != null)
            {
               
                cmbMovie.DataSource = schedules;
                cmbMovie.DisplayMember = "Movie";
                cmbMovie.ValueMember = "Id";   
            }

            var paymentStatus = new List<ReservationStatusEnum>() { ReservationStatusEnum.Booked, ReservationStatusEnum.Paid};
            cmbStatus.DataSource = paymentStatus;
        }

        private void cmbMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!isLoaded)
            {
                isLoaded = true;
            }
            else
            {
                schedule = cmbMovie.SelectedItem as GetSchedulesDto;
                cmbDate.DataSource = schedules.Where(x => x.Id == schedule.Id).Select(y => y.DateOnly).ToList();
                cmbTime.DataSource = schedules.Where(x => x.Id == schedule.Id).Select(x => x.TimeOnly).ToList();
                isLoaded= false;    
            }
        }

        private async void cmbFirstName_TextChanged(object sender, EventArgs e)
        {
            if (cmbFirstName.Text.Length > 2)
            {
                
                var search = new CustomerSearchObject();
                search.FirstName = cmbFirstName.Text;
                customers = await customerService.Get<List<CustomerDto>>(search);

                if(customers != null)
                {
                    cmbFirstName.DataSource = customers;
                    cmbFirstName.DisplayMember = "FirstName";
                }
            }
        }

        private async void cmbLastName_TextChanged(object sender, EventArgs e)
        {
            if (cmbLastName.Text.Length > 2)
            {
                cmbLastName.DataSource = customers;
                cmbLastName.DisplayMember = "LastName";

            }
        }

        private void btnSeats_Click(object sender, EventArgs e)
        {
            if(Validate())
            {
                frmSeatSelection frm = new frmSeatSelection(schedule.Id, customer, payStatus);
                frm.ShowDialog();
            }
        }

        private bool Validate()
        {
            return
            Validator.Validate(cmbFirstName, err, AlertMessages.RequiredField) &&
            Validator.Validate(cmbLastName, err, AlertMessages.RequiredField) &&
            Validator.Validate(cmbMovie, err, AlertMessages.RequiredField) &&
            Validator.Validate(cmbDate, err, AlertMessages.RequiredField) &&
            Validator.Validate(cmbTime, err, AlertMessages.RequiredField)&&
            Validator.Validate(cmbStatus, err, AlertMessages.RequiredField);

        }

        private void cmbFirstName_SelectedIndexChanged(object sender, EventArgs e)
        {
            customer = cmbFirstName.SelectedItem as CustomerDto;
        }

        private void cmbLastName_SelectedIndexChanged(object sender, EventArgs e)
        {
            customer = cmbLastName.SelectedItem as CustomerDto;
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            payStatus =(ReservationStatusEnum)cmbStatus.SelectedItem;
        }
    }
}
