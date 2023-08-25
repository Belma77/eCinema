using eCInema.Models;
using eCInema.Models.Dtos.Movie;
using eCInema.Models.SearchObjects;
using Flurl.Http;

namespace eCinema.WinUI
{
    public partial class frmMovies : Form
    {
        private APIservice _service { get; set; } =new APIservice("Movies");
        int pageSize = 10;
        int pageNumber = 1;
        bool isLoaded=false;

        private List<MovieDetailsDto> searchList=new List<MovieDetailsDto>();
        private MoviesSearchObject search=new MoviesSearchObject();
        public frmMovies()
        {
           
            InitializeComponent();
            
            
        }
       
        private async void frmMovies_LoadAsync(object sender, EventArgs e)
        {
            await LoadMovies();
            LoadCmb();
        }

        private void LoadCmb()
        {
            cmbPageSize.DataSource = _service.ItemsPerPage;
        }

        public async Task LoadMovies()
        {
            btnNext.Enabled = true;
            if(pageNumber==1)
            {
                btnPrevious.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = true;
            }
            var search = new MoviesSearchObject();
            search.Title=txtTitle.Text;
            search.PageNumber = pageNumber;
            search.PageSize=pageSize;
            var movies = await _service.Get<List<MovieDetailsDto>>(search);
            dgvMovies.AutoGenerateColumns = false;
            if (movies != null)
            {
                dgvMovies.DataSource = movies;
                if(movies.Count<pageSize)
                {
                    btnNext.Enabled = false;
                }
            }

        }


        private async void dgvMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvMovies.SelectedRows[0].DataBoundItem as MovieDetailsDto;
            if(item != null)
            {
                frmMovieDetails frm = new frmMovieDetails(item.Id);
                this.Hide();
                frm.ShowDialog();
                this.Show();
                await LoadMovies();
                
            }          
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAddMovie frm = new frmAddMovie();
            frm.ShowDialog();
            this.Show();
        }


        private async void btnNext_Click(object sender, EventArgs e)
        {
            
                pageNumber++;
                await LoadMovies();
                btnPrevious.Enabled = true;

        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if(pageNumber>1)
            {
                pageNumber--;
                btnNext.Enabled = true;
                await LoadMovies();
            }
        }

        private async void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!isLoaded)
            {
                isLoaded = true;
            }
            else
            {
                pageSize=int.Parse(cmbPageSize.SelectedItem.ToString());
                await LoadMovies();
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            await LoadMovies();
           
        }

        

       
    }
}