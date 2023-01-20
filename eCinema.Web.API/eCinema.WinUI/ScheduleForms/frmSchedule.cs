using eCinema.WinUI.Helpers;
using eCInema.Models.Dtos.Schedule;
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

namespace eCinema.WinUI.ScheduleForms
{
    public partial class frmSchedule : Form
    {
        private APIservice service = new APIservice("Schedule");

        public frmSchedule()
        {
            InitializeComponent();
        }

        private async void frmSchedule_Load(object sender, EventArgs e)
        {
            await LoadSchedules();
        }

        private async Task LoadSchedules()
        {
            var schedules=await service.Get<List<GetSchedulesDto>>();

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
            if (MessageBox.Show(AlertMessages.Delete) == DialogResult.OK)
            {
                if (schedule != null)
                {
                    await service.Delete(schedule.Id);
                    await LoadSchedules();
                    
                }
            }
        }
    }
}
