using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace example
{
    public partial class login : Form
    {
        public static Aurora aurora = new Aurora("app_name", "app_secret", "app_hash", "app_version", "https://aurora-licensing.pro/api/");

        public static string license;

        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            // Initialize the API by sending an initialization request
            aurora.connectApi();

            // Check if the initialization was successful
            if (!aurora.info.valid)
            {
                // If not successful, display the error message and exit
                MessageBox.Show(aurora.info.response, "App Initialization Failed");
                System.Threading.Thread.Sleep(1500);
                Environment.Exit(0);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Check the validity of the license
            aurora.CheckLicense(guna2TextBox1.Text);

            if (!aurora.info.valid)
            {
                // If the license check was unsuccessful, display the error message and exit
                MessageBox.Show(aurora.info.response, "Invalid License");
                System.Threading.Thread.Sleep(1500);
                return;
            }
            else
            {
                license = guna2TextBox1.Text;

                main main = new main();
                main.Show();
                this.Hide();

                // Send a webhook with provided information
                aurora.SendWebhook("Aurora", "https://uixdesign.xyz/data/assets/logo/favicon.png", "User Logged In", "License: " + license);
            }
        }
    }
}
