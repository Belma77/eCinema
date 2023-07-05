using eCinema.WinUI.Helpers;
using eCInema.Models;
using eCInema.Models.Dtos.Genres;
using eCInema.Models.Dtos.Movie;
using eCInema.Models.Entities;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCinema.WinUI
{
    public partial class frmEditMovie : Form
    {

        MovieDetailsDto movie;
        int id;
        APIservice _service=new APIservice("Movies");

        private List<GenresDto> genres = new List<GenresDto>();

        public frmEditMovie(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private async void frmEditMovie_Load(object sender, EventArgs e)
        {
            await LoadMovie();
            await LoadGenres();
        }

        private async Task GetMovieById(int id)
        {
            movie = await _service.GetById<MovieDetailsDto>(id);
        }

        private async Task LoadMovie()
        {
           await GetMovieById(id);

            if (movie!=null)
            {             
                txtTitle.Text = movie.Title;
                txtYear.Text = movie.ReleaseYear.ToString();
                txtDuration.Text = movie.Duration.ToString();
                cmbCountry.DataSource = ListOfCountries.CountryNames();
                cmbCountry.Text = movie.Country;
                txtSynopsis.Text = movie?.Synopsis;
                pbPoster.Image =movie.Poster.Length>1?ImageHelper.FromByteToImage(movie?.Poster):null;
                LoadCastClb();
            }
        }

        private void LoadCastClb()
        {
            var producers = movie?.ProducersMovies?.Select(x => x?.Producer).ToList();
            clbProducers.DataSource = producers;
            for (int i = 0; i < producers?.Count; i++)
            {
                clbProducers.SetItemChecked(i, true);
            }

            var directors = movie?.DirectorsMovies?.Select(x => x?.Director).ToList();
            clbDirectors.DataSource = directors;
            for (int i = 0; i < directors?.Count; i++)
            {
                clbDirectors.SetItemChecked(i, true);
            }

            var writers = movie?.WritersMovies?.Select(x => x?.Writer).ToList();
            clbWriters.DataSource = writers;
            for (int i = 0; i < writers?.Count; i++)
            {
                clbWriters.SetItemChecked(i, true);
            }

            var actors = movie?.ActorsMovies?.Select(x => x?.Actor).ToList();
            clbActors.DataSource = actors;
            for (int i = 0; i < actors?.Count; i++)
            {
                clbActors.SetItemChecked(i, true);
            }
        }

        private async Task LoadGenres()
        {
            APIservice _service = new APIservice("Genres");
            genres = await _service.Get<List<GenresDto>>();

            if(genres!=null)
            clbGenres.DataSource = genres;
            clbGenres.DisplayMember = "Genre";
            clbGenres.ValueMember = "Id";

            var moviesGenres = movie?.MoviesGenres?.Select(x=>x.Genre).ToList();
            if (moviesGenres != null)
            {
                foreach (var movie in moviesGenres)
                {
                    clbGenres.SetItemChecked(clbGenres.Items.IndexOf(movie), true);
                }
            }
            
        }


        private async void Save_Click(object sender, EventArgs e)
        {

            if(ValidateControls())
            {

                var update = new MovieUpdateDto();
                update.Title = txtTitle.Text;
                update.ReleaseYear = int.Parse(txtYear.Text);
                update.Duration = int.Parse(txtDuration.Text);
                update.Country = cmbCountry.SelectedItem.ToString();
                update.Synopsis = txtSynopsis.Text;
                update.Poster = ImageHelper.FromImageToByte(pbPoster.Image);
                var result = await _service.Put<MovieUpdateDto>(movie.Id, update);
                await RemoveDirectorsMovies();
                await RemoveProducersMovies();
                await RemoveActorsMovies();
                await RemoveWritersMovies();
                await UpdateGenres();
                MessageBox.Show("Succesfully edited movie");
                this.Close();
            }
            
        }

        private bool ValidateControls()
        {
            if (Validator.Validate(txtTitle, err, AlertMessages.RequiredField) &&
                Validator.Validate(txtYear, err, AlertMessages.RequiredField) &&
                Validator.Validate(txtDuration, err, AlertMessages.RequiredField) &&
                Validator.Validate(cmbCountry, err, AlertMessages.RequiredField) &&
                Validator.Validate(txtSynopsis, err, AlertMessages.RequiredField) &&
                Validator.Validate(pbPoster, err, AlertMessages.RequiredField) &&
                Validator.Validate(clbGenres, err, AlertMessages.GenresNotValid) &&
                Validator.Validate(clbDirectors, err, AlertMessages.DirectorsNotValid) &&
                Validator.Validate(clbWriters, err, AlertMessages.WritersNotValid) &&
                Validator.Validate(clbActors, err, AlertMessages.ActorsNotValid) &&
                Validator.Validate(clbProducers, err, AlertMessages.ProducersNotValid))
            {
                int result;
                if (!int.TryParse(txtYear.Text, out result))
                {
                    err.SetError(txtYear, AlertMessages.OnlyNumbersAllowed);
                    return false;
                }

                else if (!int.TryParse(txtDuration.Text, out result))
                {
                    err.SetError(txtDuration, AlertMessages.OnlyNumbersAllowed);
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

        private async Task UpdateGenres()
        {
            var genres = clbGenres.Items.Cast<GenresDto>();
            var movieGenres = movie?.MoviesGenres?.Select(x=>x.Genre).ToList();
            var checkList = clbGenres.CheckedItems;
            var addItems = new List<GenresDto>();
            var removeItems = new List<GenresDto>();

            foreach (var item in genres)
            {
                if (checkList.Contains(item) && (!movieGenres.Contains(item)))
                    addItems.Add(item);

                else if (movieGenres.Contains(item)&&(!checkList.Contains(item)))
                    removeItems.Add(item);
            }

            if(addItems.Count>0)
            {               
                APIservice genresService = new APIservice("Genres");
                await genresService.AddToMovie<GenresDto>(movie.Id, addItems);
            }

            if(removeItems.Count>0)
            {
                var list = new List<MoviesGenresUpdateDto>();

                foreach(var item in removeItems)
                {
                    var addMoviesGenres = new MoviesGenresUpdateDto();
                    addMoviesGenres.MovieId=movie.Id;
                    addMoviesGenres.Genre=item;
                    list.Add(addMoviesGenres);
                }

                APIservice genresService = new APIservice("Genres");
                await genresService.DeleteFromMovie(list);
            }
        }

        private void clbDirectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            var items = new List<DirectorsMoviesDto>();
            foreach(var item in clbDirectors.CheckedItems)
            {
                items.Add(item as DirectorsMoviesDto);
            }
        }

        private async Task RemoveDirectorsMovies()
        {
            var directors = clbDirectors.Items.Cast<DirectorDto>();
            var checkList = clbDirectors.CheckedItems;
            var addItem = new List<DirectorDto>();
            foreach (var item in directors)
            {
                if (!checkList.Contains(item))
                {
                    addItem.Add(item);
                }
            }

            if (addItem.Count > 1)
            {
                List<DirectorsMoviesDto> removeItems = new List<DirectorsMoviesDto>();  
                
                foreach (var item in addItem)
                {
                    var directorMovies = new DirectorsMoviesDto();
                    directorMovies.MovieId = movie.Id;
                    directorMovies.Director = item;
                    removeItems.Add(directorMovies);
                }

                APIservice _service = new APIservice("Directors");
                await _service.DeleteFromMovie(removeItems);
            }
            
            
        }

        private async Task RemoveProducersMovies()
        {
            var addItem = new List<ProducerDto>();
            var producers = clbProducers.Items.Cast<ProducerDto>();
            var chekced = clbProducers.CheckedItems;
            foreach (var item in producers)
            {
                if (!chekced.Contains(item))
                {
                    addItem.Add(item);
                }
            }

            if (addItem.Count > 0)
            {
                List<ProducersMoviesDto> removeItems = new List<ProducersMoviesDto>();

                foreach (var item in addItem)
                {
                    var producersMovies = new ProducersMoviesDto();
                    producersMovies.MovieId = movie.Id;
                    producersMovies.Producer = item;
                    removeItems.Add(producersMovies);
                }

                APIservice service = new APIservice("Producers");
                await service.DeleteFromMovie(removeItems);
            }

        }

        private async Task RemoveWritersMovies()
        {
            var writers = clbWriters.Items.Cast<WriterDto>();
            var chekced = clbWriters.CheckedItems;
            var addItem = new List<WriterDto>();
            foreach (var item in writers)
            {
                if (!chekced.Contains(item))
                {
                    addItem.Add(item);
                }
            }

            if (addItem.Count > 0)
            {
                List<WritersMoviesDto> removeItems = new List<WritersMoviesDto>();

                foreach (var item in addItem)
                {
                    var writerMovies = new WritersMoviesDto();
                    writerMovies.MovieId = movie.Id;
                    writerMovies.Writer = item;
                    removeItems.Add(writerMovies);
                }

                APIservice _service = new APIservice("Writers");
                await _service.DeleteFromMovie(removeItems);
            }

        }

        private async Task RemoveActorsMovies()
        {
            var writers = clbActors.Items.Cast<ActorDto>();
            var chekced = clbActors.CheckedItems;
            var list = clbActors.CheckedItems;
            var addItem = new List<ActorDto>();
            foreach (var item in writers)
            {
                if (!chekced.Contains(item))
                {
                    addItem.Add(item);
                }
            }

            if (addItem.Count > 0)
            {
                List<ActorsMoviesDto> removeItems = new List<ActorsMoviesDto>();

                foreach (var item in addItem)
                {
                    var writerMovies = new ActorsMoviesDto();
                    writerMovies.MovieId = movie.Id;
                    writerMovies.Actor = item;
                    removeItems.Add(writerMovies);
                }

                APIservice service = new APIservice("Actors");
                await service.DeleteFromMovie(removeItems);
            }

        }

        private async void btnEditWriters_Click(object sender, EventArgs e)
        {
            frmAddWriters frm = new frmAddWriters(movie);
            frm.ShowDialog();
            await LoadMovie();

        }
        private async void btnDirectors_Click(object sender, EventArgs e)
        {
            frmAddDirectors frm = new frmAddDirectors(movie);
            frm.ShowDialog();
            await LoadMovie();
        }

        private async void btnEditActors_Click(object sender, EventArgs e)
        {
            frmAddActors frm = new frmAddActors(movie);
            frm.ShowDialog();
            await LoadMovie();
        }

        private async void btnProducers_Click(object sender, EventArgs e)
        {
            frmAddProducers frm = new frmAddProducers(movie);
            frm.ShowDialog();
            await LoadMovie();

        }

        private void pbPoster_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pbPoster.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

      
    }
}
