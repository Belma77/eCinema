﻿using eCinema.WinUI.Helpers;
using eCInema.Data.Dtos;
using eCInema.Models.Dtos;
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
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace eCinema.WinUI
{
    public partial class frmAddMovie : Form
    {
        APIservice service = new APIservice("Movies");


        public frmAddMovie()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                MovieInsertDto movie = new MovieInsertDto();
                movie.Title = txtTitle.Text;
                movie.ReleaseYear = int.Parse(txtYear.Text);
                movie.Duration = int.Parse(txtYear.Text);
                movie.Country = cmbCountries.SelectedItem.ToString();
                movie.Synopsis = txtSynopsis.Text;
                movie.Poster = ImageHelper.FromImageToByte(pbPoster.Image);
                movie.Genres = new List<GenresDto>();
                foreach (var item in clbGenres.CheckedItems)
                {
                    movie.Genres.Add(item as GenresDto);
                }


                if (movie != null)
                {
                    //var result = await service.Post<MovieDetailsDto>(movie);
                    this.Hide();
                    frmAddDirectors frm = new frmAddDirectors(movie);
                    frm.ShowDialog();
                    this.Show();
                }
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pbPoster.Image =Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void frmAddMovie_Load(object sender, EventArgs e)
        {
            LoadGenres();
            LoadCountries();
        }

        private async void LoadGenres()
        {
            APIservice _service = new APIservice("Genres");
            var result=await _service.Get<List<GenresDto>>();
            clbGenres.DataSource = result;
            clbGenres.DisplayMember = "Genre";
            clbGenres.ValueMember = "Id";
            
        }

        private void LoadCountries()
        {
            cmbCountries.DataSource = ListOfCountries.CountryNames();
        }

        private bool Validate()
        {
            return
                Validator.Validate(txtTitle, err, AlertMessages.RequiredField) &&
                Validator.Validate(txtYear, err, AlertMessages.RequiredField) &&
                Validator.Validate(txtDuration, err, AlertMessages.RequiredField) &&
                Validator.Validate(cmbCountries, err, AlertMessages.RequiredField) &&
                Validator.Validate(clbGenres, err, AlertMessages.RequiredField)&&
                Validator.Validate(txtSynopsis, err, AlertMessages.RequiredField)&&
                Validator.Validate(pbPoster, err, AlertMessages.RequiredField);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnDirectors_Click(object sender, EventArgs e)
        {

        }

        private void clbGenres_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}