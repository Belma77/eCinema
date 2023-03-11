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
   
        private void frmAddReservation_Load(object sender, EventArgs e)
        {          
            LoadCmb();
        }

        private async void  LoadCmb()
        {
            schedules = await scheduleService.Get<List<GetSchedulesDto>>();
            if (schedules != null)
            {
                var list = schedules.DistinctBy(x=>x.Movie.Title).ToList();
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
                schedule = cmbMovie.SelectedItem as GetSchedulesDto;
                movie = await movieService.GetById<MovieDetailsDto>(schedule.Movie.Id);
                if (movie != null)
                {
                    cmbDate.DataSource = movie.Schedules.Select(x=>x.Date.Date).Distinct().ToList();
                }
            }
        }

        private async void cmbFirstName_TextChanged(object sender, EventArgs e)
        {
            if (cmbFirstName.Text.Length > 2&&cmbFirstName.DataSource==null)
            {
                
                var search = new CustomerSearchObject();
                search.FirstName = cmbFirstName.Text;
                customers = await customerService.Get<List<CustomerDto>>(search);

                if(customers != null)
                {
                    cmbFirstName.DataSource=customers;
                    cmbFirstName.DisplayMember = "FirstName";
                }
            }
        }

        private async void cmbLastName_TextChanged(object sender, EventArgs e)
        {
            if (cmbLastName.Text.Length > 2)
            {
                if (cmbFirstName.SelectedItem != null)
                {
                var firstName = cmbFirstName.SelectedItem as CustomerDto;
                cmbLastName.DataSource = customers.Where(x => x.FirstName == firstName?.FirstName).ToList();
                }

                else
                {
                    var search = new CustomerSearchObject();
                    search.LastName = cmbLastName.Text;
                    customers = await customerService.Get<List<CustomerDto>>(search);

                    if (customers != null)
                    {
                        cmbLastName.DataSource = customers;
                    }
                }
                cmbLastName.DisplayMember = "LastName";

            }
        }

        private async void btnSeats_Click(object sender, EventArgs e)
        {
            if(Validate())
            {
                var search = new ScheduleSearchObject();
                var movie = cmbMovie.SelectedItem as GetSchedulesDto;
                search.Title = movie.Movie.Title;
                search.Date = (DateTime)cmbDate.SelectedItem;
                search.StartTime = cmbTime.SelectedItem.ToString();
                var schedule = await scheduleService.Get<List<GetSchedulesDto>>(search);
                var id = schedule.Select(x => x.Id).FirstOrDefault();
                frmSeatSelection frm = new frmSeatSelection(id, customer, payStatus);
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

        private void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDate.SelectedItem != null)
            {
                var date = (DateTime)cmbDate.SelectedItem;
                var datelist = movie.Schedules.Where(x => x.Date.Date.ToShortDateString() == date.Date.ToShortDateString()).ToList();
                var list = datelist.Select(x => x.StartTime.ToShortTimeString()).ToList();
                cmbTime.DataSource = list;
            }
        }
    }
}
