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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCinema.WinUI
{
    public partial class frmAddActors : Form
    {
        APIservice service = new APIservice("Movies");
        int MovieId;
        MovieInsertDto _insert;
        MovieDetailsDto _movie;

        public frmAddActors(MovieDetailsDto movie)
        {
            InitializeComponent();
            _movie = movie;
            lblStep.Visible = false;
            btnSave.Visible = false;
            btnAdd.Visible = true;

        }

        public frmAddActors(MovieInsertDto insert)
        {
            InitializeComponent();
            _insert = insert;
            lblStep.Visible = true;
            btnSave.Visible = true;
            btnAdd.Visible = false;

        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }

        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                List<ActorDto> list = new List<ActorDto>();

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    var actor = new ActorDto();
                    actor.FirstName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    actor.LastName = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (actor != null)
                        list.Add(actor);


                }

                _insert.Actors = list;

                await service.Post<MovieInsertDto>(_insert);
                MessageBox.Show(AlertMessages.SuccessfulyAdded);
                this.Close();
            }

        }

        private bool Validate()
        {
            return Validator.Validate(dataGridView1, err, AlertMessages.CastNotEmptyField);
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                List<ActorDto> list = new List<ActorDto>();

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    var actor = new ActorDto();
                    actor.FirstName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    actor.LastName = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (actor != null)
                        list.Add(actor);
                }

                APIservice service = new APIservice("Actors");
                await service.AddToMovie<ActorDto>(_movie.Id, list);
                this.Close();
            }
        }

        
    }
}
