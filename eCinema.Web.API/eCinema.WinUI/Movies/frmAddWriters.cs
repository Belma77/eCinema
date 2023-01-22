﻿using eCInema.Models.Dtos;
using eCInema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eCinema.WinUI.Helpers;
using MediaBrowser.Model.Services;
using eCInema.Models.Dtos.Movies;

namespace eCinema.WinUI
{
    public partial class frmAddWriters : Form
    {
        private APIservice service = new APIservice("Writers");
        private int MovieId;
        private MovieInsertDto insert;
        private MovieDetailsDto _movie;

        public frmAddWriters(MovieDetailsDto movie)
        {
            InitializeComponent();
            _movie = movie;
            lblStep.Visible = false;
            btnBack.Visible = false;
            btnSave.Visible = false;
            btnAdd.Visible = true;

        }

        public frmAddWriters(MovieInsertDto insert)
        {
            this.insert = insert;
            InitializeComponent();
            lblStep.Visible = true;
            btnBack.Visible = true;
            btnSave.Visible = true;
            btnAdd.Visible = false;

        }

        private void frmAddWriters_Load(object sender, EventArgs e)
        {
            
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                List<WriterDto> list = new List<WriterDto>();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    var writer = new WriterDto();
                    writer.FirstName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    writer.LastName = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (writer != null)
                        list.Add(writer);

                }
               
               insert.Writers = list;

                this.Hide();
                frmAddActors frm = new frmAddActors(insert);
                frm.ShowDialog();
            }
        }

        private bool Validate()
        {
            return Validator.Validate(dataGridView1, errorProvider1, AlertMessages.NotEmptyField);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                List<WriterDto> list = new List<WriterDto>();

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    var writer = new WriterDto();
                    writer.FirstName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    writer.LastName = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (writer != null)
                        list.Add(writer);
                }

                APIservice service = new APIservice("Writers");
                await service.PostArray<WriterDto>(_movie.Id, list);
                this.Close();
            }
        }
    }
}
