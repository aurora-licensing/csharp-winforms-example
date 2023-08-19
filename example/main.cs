using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;
using Guna.UI2.WinForms;

namespace example
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            lbl6.Text = "LICENSE: " + login.license;

            login.aurora.CheckLicenseExpiry(login.license);
            if (login.aurora.info.valid == true) lbl1.Text = "EXPIRY: " + login.aurora.info.response;

            login.aurora.usedDate(login.license);
            if (login.aurora.info.valid == true) lb2.Text = "USED DATE: " + login.aurora.info.response;

            login.aurora.getHwid(login.license);
            if (login.aurora.info.valid == true) lb3.Text = "HWID: " +login.aurora.info.response;

            login.aurora.CheckLicenseSub(login.license);
            if (login.aurora.info.valid == true) lb4.Text = "SUBSCRIPTION: " + login.aurora.info.response;

            login.aurora.licenseNote(login.license);
            if (login.aurora.info.valid == true) lb5.Text = "NOTE: " + login.aurora.info.response;
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
