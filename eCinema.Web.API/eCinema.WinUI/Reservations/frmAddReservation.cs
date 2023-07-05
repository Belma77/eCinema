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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eCinema.WinUI.Reservations
{
    public partial class frmAddReservation : Form
    {
        private APIservice scheduleService = new APIservice("Schedule");
        private APIservice customerService = new APIservice("Customer");
        private APIservice movieService = new APIservice("Movies");
        private GetSchedulesDto schedule;
        private List<GetSchedulesDto> schedules;
        private List<CustomerDto>  customers;
        private CustomerDto  customer;
        private MovieDetailsDto movie;
        private ReservationStatusEnum payStatus;
        bool isLoaded = false;
        public frmAddReservation()
        {
            InitializeComponent();
        }
   
        private async void frmAddReservation_LoadAsync(object sender, EventArgs e)
        {          
            await LoadCmb();
        }

        private async Task  LoadCmb()
        {
            schedules = await scheduleService.Get<List<GetSchedulesDto>>("Distinct");
            customers = await customerService.Get<List<CustomerDto>>();

            if (customers != null)
            {
                cmbFirstName.SelectedIndex = -1;
                cmbFirstName.DisplayMember = "FirstName";
                cmbFirstName.DataSource = customers.ToList();
                cmbFirstName.SelectedIndex = -1;

            }

            if (schedules != null)
            {
                var list = schedules.ToList();
                cmbMovie.DataSource = list;
                cmbMovie.DisplayMember = "Movie";
                cmbMovie.ValueMember = "Id";
            }

            var paymentStatus = new List<ReservationStatusEnum>() { ReservationStatusEnum.Booked, ReservationStatusEnum.Paid};
            cmbStatus.DataSource = paymentStatus;
          
        }

        private async void cmbMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!isLoaded)
            {
                isLoaded = true;
            }
            else
            {
                if (cmbMovie.SelectedIndex != -1)
                {
                    schedule = cmbMovie.SelectedItem as GetSchedulesDto;
                    var filter = new ScheduleSearchObject();
                    filter.Title = schedule.Movie.Title;
                    schedules = await scheduleService.Get<List<GetSchedulesDto>>(filter);

                    if (schedules != null)
                    {
                        cmbDate.DataSource = schedules.Select(x => x.DateOnly).Distinct().ToList();
                    }
                }
            }
        }


       
       
        private async void btnSeats_Click(object sender, EventArgs e)
        {
            if(Validate())
            {
                var search = new ScheduleSearchObject();
                var movie = cmbMovie.SelectedItem as GetSchedulesDto;
                search.Title = movie.Movie.Title;
                search.StartTime = cmbTime.SelectedItem.ToString();
                var dateonly = cmbDate.SelectedItem.ToString();
                var selected=schedules.Where(x=>x.Movie.Title.Equals(movie.Movie.Title)&&x.DateOnly.Equals(dateonly)&&x.TimeOnly.Equals(search.StartTime)).First();
                var getId = await scheduleService.GetById<GetSchedulesDto>(selected.Id, "Seats");
                frmSeatSelection frm = new frmSeatSelection(getId, customer, payStatus);
                this.Close();
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
           
                if (cmbFirstName.SelectedIndex != -1)
                {
                customer = cmbFirstName.SelectedItem as CustomerDto;
                cmbLastName.DisplayMember = "LastName";
                cmbLastName.DataSource = customers.Where(x => x.FirstName == customer?.FirstName).ToList();
                }
            
        }

        private void cmbLastName_SelectedIndexChanged(object sender, EventArgs e)
        {
            customer = cmbLastName.SelectedItem as CustomerDto;
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            payStatus =(ReservationStatusEnum)cmbStatus.SelectedItem;
        }

        private void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDate.SelectedItem != null)
            {
                var date = cmbDate.SelectedItem.ToString();
                var list = schedules.Where(x => x.DateOnly.Equals(date)).Select(x => x.TimeOnly).ToList();
                cmbTime.DataSource = list;
            }
        }
    }
}
