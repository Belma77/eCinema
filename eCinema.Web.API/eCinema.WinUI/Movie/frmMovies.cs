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
        public frmMovies()
        {
            InitializeComponent();
            
        }
       
        private async void frmMovies_Load(object sender, EventArgs e)
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
            var search = new MoviesSearchObject();
            search.Title=txtTitle.Text;
            search.PageNumber = pageNumber;
            search.PageSize=pageSize;
            var list = await _service.Get<List<MovieDetailsDto>>(search);
            dgvMovies.AutoGenerateColumns = false;
            if(list!= null)
            dgvMovies.DataSource = list;

        }


        private void dgvMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvMovies.SelectedRows[0].DataBoundItem as MovieDetailsDto;
            if(item != null)
            {
                this.Hide();
                frmMovieDetails frm = new frmMovieDetails(item.Id);
                frm.ShowDialog();
                this.Show();
                
            }          
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAddMovie frm = new frmAddMovie();
            frm.ShowDialog();
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            await LoadMovies();
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            pageNumber++;
            await LoadMovies();
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if(pageNumber>1)
            {
                pageNumber--;
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
    }
}