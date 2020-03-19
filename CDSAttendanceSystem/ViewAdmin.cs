using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using CDSAttendanceSystem.Models;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace CDSAttendanceSystem
{
    public partial class CDS : KryptonForm
    {
        public CDS()
        {
            InitializeComponent();
        }

        private void ViewAdmin_Load(object sender, EventArgs e)
        {
            getAllAdmin();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void getAllAdmin()
        {
            using (MySqlConnection conn = new MySqlConnection(Utiles.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM admin";


                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    if (data.Rows.Count > 0)
                    {
                        List<AdminModel> admins = new List<AdminModel>();

                        foreach (DataRow row in data.Rows)
                        {
                            AdminModel admin = new AdminModel();
                            admin.Name = row["name"].ToString();
                            admin.StateCode = row["state_code"].ToString();
                            admin.Date_Added = row["created_at"].ToString();
                            admin.Last_Login = row["last_login"].ToString();
                            admin.Phone_Number = row["phone_number"].ToString();

                            admins.Add(admin);
                        }
                        adminModelBindingSource.DataSource = admins;

                    }
                    else
                    {
                        MessageBox.Show("No admin yet");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
