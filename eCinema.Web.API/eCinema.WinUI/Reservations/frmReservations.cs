using eCinema.WinUI.Helpers;
using eCinema.WinUI.Reservations;
using eCInema.Models.Dtos.Reservations;
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
        public frmReservations()
        {
            InitializeComponent();
        }

        private async void frmReservations_Load(object sender, EventArgs e)
        {
            await LoadReservations();
        }

        private async Task LoadReservations()
        {
            var search = new ReservationSearchObject();
            search.CustomerName = txtFirstName.Text;
            search.Movie = txtMovie.Text;

            var res = await service.Get<List<ReservationDto>>(search);
            dgvReservations.AutoGenerateColumns = false;
            dgvReservations.DataSource = res;
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

        private async void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            await LoadReservations();
        }

        private async void txtLastName_TextChanged(object sender, EventArgs e)
        {
            await LoadReservations();
        }

        private async void txtMovie_TextChanged(object sender, EventArgs e)
        {
            await LoadReservations();
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var data = dgvReservations.SelectedRows[0].DataBoundItem as ReservationDto;

            if (data != null)
            {
                if (data.Status == ReservationStatusEnum.Canceled)
                    MessageBox.Show(AlertMessages.AlreadyCanceled);

                else if (MessageBox.Show(AlertMessages.Cancel, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (data.Status != ReservationStatusEnum.Canceled)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddReservation frm = new frmAddReservation();
            frm.ShowDialog();
        }
    }
}
