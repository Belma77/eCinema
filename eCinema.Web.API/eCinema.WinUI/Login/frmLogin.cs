﻿using eCInema.Models.Dtos.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCinema.WinUI.Login
{
    public partial class frmLogin : Form
    {
        private readonly APIservice service = new APIservice("User");

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIservice.Username = txtUsername.Text;
            APIservice.Password = txtPassword.Text;
           
            try
            {
                var result = await service.Get<dynamic>();
                frmMain frm = new frmMain();
                frm.ShowDialog();
                this.Close();
            }

            catch (Exception ex)
            {
                
            }
        }
    }
}
