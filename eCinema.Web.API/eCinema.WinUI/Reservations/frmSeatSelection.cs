using eCinema.WinUI.Helpers;
using eCInema.Models.Dtos.Customer;
using eCInema.Models.Dtos.Reservations;
using eCInema.Models.Dtos.Schedules;
using eCInema.Models.Dtos.SchedulesSeats;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Label = System.Windows.Forms.Label;

namespace eCinema.WinUI.Reservations
{
    public partial class frmSeatSelection : Form
    {
        private APIservice _scheduleService = new APIservice("Schedule");
        private APIservice _reservationService = new APIservice("Reservation");

        private int _scheduleId;
        private GetSchedulesDto _schedule;
        private CustomerDto _customer;
        private ReservationStatusEnum _status;
        List<int> pickedSeats = new List<int>();
        List<int> alreadyReserved = new List<int>();
        bool seatSelected = false;
        
        public frmSeatSelection(GetSchedulesDto schedule, CustomerDto customer, ReservationStatusEnum status)
        {
            _schedule=schedule;
            _customer = customer;
            _status = status;
            InitializeComponent();

        }

        private void frmSeatSelection_Load(object sender, EventArgs e)
        {
            GenerateSeats();

        }


        void GenerateSeats()
        {
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int x = 10;
            int y = 63;
            Size s = new Size(25, 22);
            int column = 1;
            if (_schedule.ScheduleSeats != null)
            {
                alreadyReserved = _schedule.ScheduleSeats.Select(x => x.SeatId).ToList();
            }
            int id = 1;

            for (int i = 1; i <= _schedule.Hall.NumberOfRows; i++)
            {
                x = 15;
                var z = 1;
                Label l = new Label();
                l.Text = alpha[i-1].ToString();
                l.Location = new Point(x * z, y * column);
                l.Size = new Size(20, 20);
                l.Font = new Font("Segoe UI Semibold", 9);
                x = 40;
                Controls.Add(l);

                for (int j=1; j <= _schedule.Hall.NumberOfColumns; j++)
                {
                    Button b = new Button() { Location = new Point(x * (j + 1), y * column), Size = s };
                    b.BackColor = alreadyReserved.Contains(id) ? Color.LightGray :Color.Yellow;
                    b.Click += MyButton_Click;
                    Controls.Add(b);
                    b.Tag = id;
                    id++;

                    if(i == _schedule.Hall.NumberOfRows)
                    {
                        Label c = new Label();
                        c.Text = j.ToString();
                        c.Location = new Point(x * (j + 1), y * (column+1));
                        c.Size = new Size(25, 20);
                        c.Font = new Font("Segoe UI Semibold", 9);
                        Controls.Add(c);
                    }

                    if(i == _schedule.Hall.NumberOfRows && j == _schedule.Hall.NumberOfColumns)
                    {
                     
                        Button makeReservation = new Button() { Location = new Point(x * (j-1), y * (column+2)), Size = new Size(150, 35), Text="Add reservation" };
                        makeReservation.Click += makeReservation_Click;
                        makeReservation.Margin = new Padding(5, 5, 15, 15);
                        makeReservation.Font = new Font("Segoe UI Semibold", 9);
                        btnFree.Location = new Point(x * (j - 8), y * (column + 2));
                        lblFree.Location=new Point(x* (j -7), y * (column + 2));
                        btnTaken.Location = new Point(x * (j - 5), y * (column + 2));
                        lblTaken.Location= new Point(x * (j - 4), y * (column + 2));
                        Controls.Add(makeReservation);
                    }

                }
               
                column++;
            }
        }

        private async void makeReservation_Click(object? sender, EventArgs e)
        {
            if (seatSelected)
            {
                var reservation = new ReservationInsertDto();
                reservation.ScheduleId = _schedule.Id;
                reservation.NumberOfTickets = pickedSeats.Count;
                var schedulesSeats = new List<ScheduleSeatDto>();
                foreach (var seat in pickedSeats)
                {
                    var scheduleSeat = new ScheduleSeatDto();
                    scheduleSeat.ScheduleId = _schedule.Id;
                    scheduleSeat.SeatId = seat;
                    schedulesSeats.Add(scheduleSeat);

                }
                reservation.scheduleSeats = schedulesSeats;
                reservation.CustomerId = _customer.Id;
                reservation.Status = _status;


                await _reservationService.Post<ReservationDto>(reservation);
                MessageBox.Show(AlertMessages.SuccessfulyAdded);
                this.Close();

            }
            else
            {
                MessageBox.Show(AlertMessages.SeatsNotSelected);
            }
        }

        private void MyButton_Click(object? sender, EventArgs e)
        {

            var tag = ((Button)sender).Tag;
            var seatId = (int)tag;

            err.Clear();
            if (!Validate(seatId))
            {
                err.SetError((Button)sender, "Already taken");
            }

            if(pickedSeats.Contains(seatId))
            {
                pickedSeats.Remove(seatId);
                seatSelected = false;
                (sender as Button).BackColor = Color.Yellow;
            }
            else
            {
                pickedSeats.Add(seatId);
                seatSelected = true;
                (sender as Button).BackColor = Color.Red;
            }
        }

        private bool Validate(int seatId)
        {
            return !alreadyReserved.Contains(seatId) ? true : false;
        }
        
        }
    }


