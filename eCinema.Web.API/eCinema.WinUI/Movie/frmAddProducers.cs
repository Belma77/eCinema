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
using eCInema.Models.Dtos.Movie;

namespace eCinema.WinUI
{
    public partial class frmAddProducers : Form
    {
        private APIservice service = new APIservice("Producers");
        MovieInsertDto _insert;
        MovieDetailsDto _movie;

        public frmAddProducers(MovieInsertDto insert)
        {
            InitializeComponent();
            _insert = insert;
            lblStep.Visible = true;
            btnSave.Visible = true;
            btnAdd.Visible = false;

        }

        public frmAddProducers(MovieDetailsDto movie)
        {
            InitializeComponent();
            _movie = movie;
            lblStep.Visible = false;
            btnSave.Visible = false;
            btnAdd.Visible = true;

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            if (Validate())
            {
                List<ProducerDto> list = new List<ProducerDto>();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    var producer = new ProducerDto();
                    producer.FirstName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    producer.LastName = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (producer != null)
                        list.Add(producer);

                }
                _insert.Producers = list;
                this.Hide();
                frmAddWriters frm = new frmAddWriters(_insert);
                frm.ShowDialog();
            }
        }

        private bool Validate()
        {
            return Helpers.Validator.Validate(dataGridView1, err, Helpers.AlertMessages.CastNotEmptyField);
        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                List<ProducerDto> list = new List<ProducerDto>();

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    var producer = new ProducerDto();
                    producer.FirstName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    producer.LastName = dataGridView1.Rows[i].Cells[1].Value.ToString();

                    if (producer != null)
                        list.Add(producer);
                }

                APIservice service = new APIservice("Producers");
                await service.AddToMovie<ProducerDto>(_movie.Id, list);
                this.Close();
            }
        }

    }
}