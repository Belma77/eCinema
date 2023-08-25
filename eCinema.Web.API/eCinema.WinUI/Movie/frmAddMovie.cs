using eCinema.WinUI.Helpers;
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
using eCInema.Models.Dtos.Movie;
using eCInema.Models.Dtos.Genres;

namespace eCinema.WinUI
{
    public partial class frmAddMovie : Form
    {
        APIservice service = new APIservice("Movies");

        public frmAddMovie()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                MovieInsertDto movie = new MovieInsertDto();
                movie.Title = txtTitle.Text;
                movie.ReleaseYear = int.Parse(txtYear.Text);
                movie.Duration = int.Parse(txtDuration.Text);
                movie.Country = cmbCountries.SelectedItem.ToString();
                movie.Synopsis = txtSynopsis.Text;
                movie.Poster = ImageHelper.FromImageToByte(pbPoster.Image);
                movie.Genres = new List<GenresDto>();
                foreach (var item in clbGenres.CheckedItems)
                {
                    movie.Genres.Add(item as GenresDto);
                }
                frmAddDirectors frm = new frmAddDirectors(movie);
                Close();
                frm.ShowDialog();
                
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                try
                {
                    pbPoster.Image = Image.FromFile(openFileDialog1.FileName);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(AlertMessages.ImageLoadingFailed, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

            if(
                Validator.Validate(txtTitle, err, AlertMessages.RequiredField) &&
                Validator.Validate(txtYear, err, AlertMessages.RequiredField) &&
                Validator.Validate(txtDuration, err, AlertMessages.RequiredField) &&
                Validator.Validate(cmbCountries, err, AlertMessages.RequiredField) &&
                Validator.Validate(clbGenres, err, AlertMessages.RequiredField) &&
                Validator.Validate(txtSynopsis, err, AlertMessages.RequiredField) &&
                Validator.Validate(pbPoster, err, AlertMessages.RequiredField))
            {
                int result;
                if (!int.TryParse(txtYear.Text, out result))
                {
                    err.SetError(txtYear, AlertMessages.OnlyNumbersAllowed);
                    return false;
                }
                else if (int.Parse(txtYear.Text) > DateTime.Now.Year)
                {
                    err.SetError(txtYear, AlertMessages.InvalidReleaseYear);
                    return false;
                }
                else if (!int.TryParse(txtDuration.Text, out result))
                {
                    err.SetError(txtDuration, AlertMessages.OnlyNumbersAllowed);
                    return false;
                }
                else if (int.Parse(txtDuration.Text)>240)
                {
                    err.SetError(txtDuration, AlertMessages.InvalidDuration);
                    return false;
                }

                else
                {
                    err.Clear();
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

    }
}
