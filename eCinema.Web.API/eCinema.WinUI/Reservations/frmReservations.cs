using eCinema.WinUI.Helpers;
using eCinema.WinUI.Reservations;
using eCInema.Models.Dtos.Reservations;
using eCInema.Models.Dtos.Schedules;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCinema.WinUI
{
    public partial class frmReservations : Form
    {
        private APIservice service = new APIservice("Reservation");
        int pageNumber = 1;
        int pageSize = 10;

        bool isLoaded = false;
        ReservationSearchObject search = new ReservationSearchObject();
        public frmReservations()
        {
            InitializeComponent();
        }

        private async void frmReservations_Load(object sender, EventArgs e)
        {
            await LoadReservations();
            LoadCmb();
        }

        private void LoadCmb()
        {
            cmbPageSize.DataSource = service.ItemsPerPage;
        }

        private async Task LoadReservations()
        {
            btnNext.Enabled = true;
            if (pageNumber==1)
            {
                btnPrevious.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = true;
            }
            search.CustomerName = txtFirstName.Text;
            search.Movie = txtMovie.Text;
            search.PageNumber = pageNumber;
            search.PageSize = pageSize;
            var res = await service.Get<List<ReservationDto>>(search);
            dgvReservations.AutoGenerateColumns = false;
            if (res != null)
            {
                dgvReservations.DataSource = res;
                if (res.Count < pageSize)
                {
                    btnNext.Enabled = false;
                }
            }
        }

        private async Task Search()
        {
            pageNumber = 1;
            await LoadReservations();
            
            
        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvReservations.Rows[e.RowIndex].DataBoundItem != null) &&
               (dgvReservations.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(
                 dgvReservations.Rows[e.RowIndex].DataBoundItem,
                 dgvReservations.Columns[e.ColumnIndex].DataPropertyName
                 );
            }
        }

        private string BindProperty(object property, string propertyName)
        {
            string retValue = "";

            if (propertyName.Contains("."))
            {
                PropertyInfo[] arrayProperties;
                string leftPropertyName;

                leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));
                arrayProperties = property.GetType().GetProperties();

                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                          propertyInfo.GetValue(property, null),
                          propertyName.Substring(propertyName.IndexOf(".") + 1));
                        break;
                    }
                }
            }
            else
            {
                Type propertyType;
                PropertyInfo propertyInfo;

                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }

            return retValue;
        }

       
        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var data = dgvReservations.SelectedRows[0].DataBoundItem as ReservationDto;

            if (data != null)
            {
                if (data.Status == ReservationStatusEnum.Canceled)
                    MessageBox.Show(AlertMessages.AlreadyCanceled, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if(data.Status==ReservationStatusEnum.Paid)
                {
                    MessageBox.Show(AlertMessages.ReservationAlreadyPaid, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (MessageBox.Show(AlertMessages.Cancel, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (data.Status != ReservationStatusEnum.Canceled && data.Status!=ReservationStatusEnum.Paid)
                    {
                        var update = new ReservationUpdateDto();
                        update.Status = ReservationStatusEnum.Canceled;
                        await service.Put<ReservationDto>(data.Id, update);
                        MessageBox.Show(AlertMessages.SuccessfulyCanceled);
                        await LoadReservations();

                    }
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddReservation frm = new frmAddReservation();
            frm.ShowDialog();
            await LoadReservations();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if(pageNumber>1)
            {
                pageNumber--;
                await LoadReservations();
                btnNext.Enabled = true;

            }
        }

        private async void btnNext_ClickAsync(object sender, EventArgs e)
        {
                
                pageNumber++;
                await LoadReservations();
                btnPrevious.Enabled = true;

        }

        private async void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
            {
                isLoaded = true;
            }
            else
            {
                pageSize = int.Parse(cmbPageSize.SelectedItem.ToString());
                await LoadReservations();
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await Search();
        }
    }
}
