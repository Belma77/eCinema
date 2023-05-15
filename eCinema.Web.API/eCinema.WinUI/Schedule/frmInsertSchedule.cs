using eCinema.WinUI.Helpers;
using eCInema.Models.Dtos.Halls;
using eCInema.Models.Dtos.Movie;
using eCInema.Models.Dtos.Schedules;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eCinema.WinUI.ScheduleForms
{
    public partial class frmInsertSchedule : Form
    {
        APIservice service = new APIservice("Schedule");
        List<MovieDetailsDto> listOfMovies=new List<MovieDetailsDto>();
        APIservice moviesService = new APIservice("Movies");
        public frmInsertSchedule()
        {
            InitializeComponent();
        }

        private async void frmInsertSchedule_Load(object sender, EventArgs e)
        { 
            await LoadCmbs();
        }

        private async Task LoadHalls()
        {
            APIservice hallService = new APIservice("Hall");
            var halls= await hallService.Get<List<HallDto>>();
            cbHall.DataSource = halls.Select(x=>x.NoOfHall).ToList();
        }

        private async Task LoadCmbs()
        {
            await LoadHalls();
            await LoadMovies();
        }

        private async Task LoadMovies()
        {
            var search = new MoviesSearchObject();
            search.PageSize = null;
            listOfMovies = await moviesService.Get<List<MovieDetailsDto>>(search);
            var list = listOfMovies.Select(x => x.Title).ToList();
            if (list != null)
                cmbMovies.DataSource = list;
        }


        private bool Validate()
        {
            var startTime = dtStartTime.Value;
            var endTime = dtEndTime.Value;
            if (endTime <= startTime)
            {
                err.SetError(dtEndTime, AlertMessages.EndTimeNotValid);
                return false;
            }


            return Validator.Validate(cmbMovies, err, AlertMessages.RequiredField) &&
                Validator.Validate(dtpDate, err, AlertMessages.RequiredField) &&
                Validator.Validate(dtStartTime, err, AlertMessages.RequiredField) &&
                Validator.Validate(dtEndTime, err, AlertMessages.RequiredField) &&
                Validator.Validate(cbHall, err, AlertMessages.RequiredField);
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                var insert = new ScheduleInsertDto();
                var title = cmbMovies.SelectedItem.ToString();
                insert.Title = title;
                insert.StartTime = dtStartTime.Value;
                insert.EndTime = dtEndTime.Value;
                insert.Date = dtpDate.Value;
                insert.NoHall = int.Parse(cbHall.SelectedItem.ToString());
                await service.Post<GetSchedulesDto>(insert);
                MessageBox.Show(AlertMessages.SuccessfulyAdded);
                this.Close();
            }
        }

       
    }
}
