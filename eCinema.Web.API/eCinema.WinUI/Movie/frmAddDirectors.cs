using eCinema.WinUI.Helpers;
using eCInema.Models.Dtos;
using eCInema.Models.Dtos.Movie;
using eCInema.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCinema.WinUI
{
    public partial class frmAddDirectors : Form
    {
        MovieInsertDto? insert=null;
        MovieDetailsDto _movie=null;
        APIservice service = new APIservice("Movies");

        public frmAddDirectors(MovieInsertDto insert)
        {
            this.insert = insert;
            InitializeComponent();
            lblStep.Visible = true;
            btnSave.Visible = true;
            btnAdd.Visible = false;

        }

        public frmAddDirectors(MovieDetailsDto movie)
        {
            InitializeComponent();
            _movie = movie;
            btnAdd.Visible = true;
            lblStep.Visible = false;
            btnSave.Visible = false;
        }

        private async void frmAddDirectors_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            
        }

        private  async void btnSave_Click(object sender, EventArgs e)
        {

            if (insert != null)
            {
                if (Validate())
                {
                    List<DirectorDto> list = new List<DirectorDto>();

                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        var director = new DirectorDto();
                        director.FirstName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        director.LastName = dataGridView1.Rows[i].Cells[1].Value.ToString();

                        if (director != null)
                            list.Add(director);

                    }

                    insert.Directors = new List<DirectorDto>(list);
                    this.Hide();
                    frmAddProducers frm = new frmAddProducers(insert);
                    frm.ShowDialog();
                }
            }
            else if (_movie != null)
            {
                List<DirectorDto> list = new List<DirectorDto>();

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    var director = new DirectorDto();
                    director.FirstName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    director.LastName = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (director != null)
                        list.Add(director);
                }

                APIservice service = new APIservice("Directors");
                await service.AddToMovie<DirectorDto>(_movie.Id, list);
            }
            
        }

        private bool Validate()
        {
            return Validator.Validate(dataGridView1, errorProvider1, AlertMessages.CastNotEmptyField);
        }

         private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {

                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
            
         }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                List<DirectorDto> list = new List<DirectorDto>();

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    var director = new DirectorDto();
                    director.FirstName = dataGridView1?.Rows?[i]?.Cells[0]?.Value.ToString();
                    director.LastName = dataGridView1?.Rows?[i]?.Cells[1]?.Value.ToString();

                    if (director != null)
                        list.Add(director);
                }

                APIservice service = new APIservice("Directors");
                await service.AddToMovie<DirectorDto>(_movie.Id, list);
                this.Close();

            }
        }
    }
}
