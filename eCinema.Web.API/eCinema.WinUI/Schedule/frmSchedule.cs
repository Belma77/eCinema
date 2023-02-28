using eCinema.WinUI.Helpers;
using eCInema.Models.Dtos.Halls;
using eCInema.Models.Dtos.Schedules;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using MediaBrowser.Model.Services;
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

namespace eCinema.WinUI.ScheduleForms
{
    public partial class frmSchedule : Form
    {
        private APIservice service = new APIservice("Schedule");
        private bool dateChanged=false;
        private bool timeChanged = false;
        private int pageNumber = 1;
        private int pageSize = 10;
        private bool isLoaded = false;
        public frmSchedule()
        {
            InitializeComponent();
        }

        private async void frmSchedule_Load(object sender, EventArgs e)
        {
            await LoadSchedules();
            LoadCmb();
        }

        private void LoadCmb()
        {
            cmbPageSize.DataSource = service.ItemsPerPage;
        }

        private async Task LoadSchedules()
        {
            var search = new ScheduleSearchObject();
            search.Title = txtTitle.Text;

            if (dateChanged)
            {
                search.Date = dtmDate.Value;
                dateChanged = false;
            }

            if (timeChanged)
            {
                search.StartTime = dtmTime.Value;
                timeChanged = false;
            }

            search.PageNumber = pageNumber;
            search.PageSize = pageSize;
            var schedules=await service.Get<List<GetSchedulesDto>>(search);

            if(schedules != null)
            {
                dgvSchedules.AutoGenerateColumns = false;
                dgvSchedules.DataSource = schedules;
                
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            frmInsertSchedule frm = new frmInsertSchedule();
            frm.ShowDialog();
            await LoadSchedules();
        }

        private async void dgvSchedules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            var schedule = dgvSchedules.SelectedRows[0].DataBoundItem as GetSchedulesDto;
           
                if (schedule != null)
                {
                    if (MessageBox.Show(AlertMessages.Delete, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (schedule != null)
                        {
                            await service.Delete(schedule.Id);
                            await LoadSchedules();

                        }
                    }

            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if ((dgvSchedules.Rows[e.RowIndex].DataBoundItem != null) &&
                (dgvSchedules.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(
                             dgvSchedules.Rows[e.RowIndex].DataBoundItem,
                             dgvSchedules.Columns[e.ColumnIndex].DataPropertyName
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

        private async void txtTitle_TextChanged(object sender, EventArgs e)
        {
           await  LoadSchedules();

        }

        private async void dtmDate_ValueChanged(object sender, EventArgs e)
        {
            dateChanged = true;
            await LoadSchedules();         
        }

        private async void cmbHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadSchedules();
        }

        private async void dtmTime_ValueChanged(object sender, EventArgs e)
        {
            timeChanged = true;
            await LoadSchedules();
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pageNumber > 1)
            {
                pageNumber--;
                await LoadSchedules();
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            pageNumber++;
            await LoadSchedules();
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
                await LoadSchedules();
            }
        }
    }
}

