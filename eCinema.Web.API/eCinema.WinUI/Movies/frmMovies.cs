using eCInema.Models;
using eCInema.Models.Dtos;
using Flurl.Http;

namespace eCinema.WinUI
{
    public partial class frmMovies : Form
    {
        private APIservice _service { get; set; } =new APIservice("Movies");

        public frmMovies()
        {
            InitializeComponent();
            
        }
       
        private async void frmMovies_Load(object sender, EventArgs e)
        {
           await LoadMovies();
        }

        public async Task LoadMovies()
        {
            var list = await _service.Get<List<MovieDetailsDto>>();
            dgvMovies.AutoGenerateColumns = false;
            if(list!= null)
            dgvMovies.DataSource = list;

        }

        private async void moviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await LoadMovies();
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
    }
}