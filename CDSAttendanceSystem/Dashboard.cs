using CDSAttendanceSystem.Models;
using ComponentFactory.Krypton.Toolkit;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDSAttendanceSystem
{
    public partial class Dashboard : KryptonForm
    {
        Form1 form;
        public Dashboard(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Close();
        }  

        private void Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void viewAdminBtn_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CDS view = new CDS();

            view.ShowDialog();
        }
    }

}
