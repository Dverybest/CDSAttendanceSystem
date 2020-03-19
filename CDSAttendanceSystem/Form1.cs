using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MaterialSkin.Controls;
using MaterialSkin;
using MySql.Data.MySqlClient;

namespace CDSAttendanceSystem
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
            // Create a material theme manager and add the form to manage (this)
            //MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            //// Configure color schema
            //materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
            //    Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

       
        private void verifyLogin(string stateCode, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(Utiles.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM admin WHERE state_code = '" + stateCode+"' AND password = '"+password+"'";
                    

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    
                    if (data.Rows.Count == 1)
                    {
                        updateLogin(conn,data.Rows[0]);
                    }
                    else
                    {
                        MessageBox.Show("invalid login details");
                    }
                  
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void updateLogin(MySqlConnection conn, DataRow dataRow)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                var time = DateTime.Now;
                string query = "UPDATE `admin` SET `last_login` ='"+time.ToString()+"' WHERE `admin`.`id` = " + dataRow["id"];
                
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            Dashboard dashboard = new Dashboard(this);
            this.Hide();
            dashboard.Show();
          
    }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string stateCode = txtStateCode.Text;
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(stateCode) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                verifyLogin(stateCode, password);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
