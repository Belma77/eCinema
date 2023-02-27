using eCinema.WinUI.Helpers;
using eCInema.Models;
using eCInema.Models.Dtos.Movie;
using eCInema.Models.Entities;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCinema.WinUI
{
    public partial class frmMovieDetails : Form
    {
        MovieDetailsDto _movie;
        APIservice _service = new APIservice("Movies");
        int id;

        public frmMovieDetails(int id)
        {
            InitializeComponent();
            this.id=id;   
        }

        private async Task GetMovieById(int id)
        {
            _movie = await _service.GetById<MovieDetailsDto>(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();          
        }

        private async void MovieDetailsForm_Load(object sender, EventArgs e)
        {
             await LoadMovieDetails();
        }

        private async Task LoadMovieDetails()
        {
            await GetMovieById(id);

            if (_movie != null)
            {
                txtTitle.Text = _movie.Title;
                txtYear.Text = _movie.ReleaseYear.ToString();
                txtDuration.Text = _movie.Duration.ToString();
                txtCountry.Text = _movie.Country;

                var genres = _movie.MoviesGenres?.Select(x => (x?.Genre.Genre)).ToList();
                cmbGenres.DataSource = genres;
                cmbGenres.DisplayMember = "Genre";

                var directors = _movie.DirectorsMovies?.Select(x => (x.Director.FirstName + " " + x.Director.LastName)).ToList();
                cmbDirectors.DataSource = directors;

                var producers = _movie.ProducersMovies?.Select(x => (x?.Producer?.FirstName + " " + x?.Producer?.LastName)).ToList();
                cmbProducers.DataSource = producers;

                var writers = _movie.WritersMovies?.Select(x => (x?.Writer?.FirstName + " " + x?.Writer?.LastName)).ToList();
                cmbWriters.DataSource = writers;

                var actors = _movie.ActorsMovies?.Select(x => (x?.Actor?.FirstName + " " + x?.Actor?.LastName)).ToList();
                cmbActors.DataSource = actors;

                if (_movie.Poster != null && _movie.Poster.Length>1)
                    pbPoster.Image = ImageHelper.FromByteToImage(_movie.Poster);
                else
                {
                    pbPoster.Image = null;
                }

            }
        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {

            await _service.Delete(_movie.Id);
            this.Hide();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEditMovie frm =new frmEditMovie(_movie.Id);
            frm.ShowDialog();
            LoadMovieDetails();
            this.Show();
        }

       
    }
}
