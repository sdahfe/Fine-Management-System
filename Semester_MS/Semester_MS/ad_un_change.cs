using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Semester_MS
{
    public partial class ad_un_change : Form
    {
        SqlConnection con = new SqlConnection();
        public ad_un_change()
        {
            InitializeComponent();
            con.ConnectionString = (@"Data Source=.\SQLEXPRESS;Initial Catalog=gpgc;Integrated Security=True");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ad_id.Text == "")
            {
                ad_id.BackColor = Color.Red;
                MessageBox.Show("Admin ID field must be filled!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ad_id.Focus();
                return;
            }
            if (new_un.Text == "")
            {
                new_un.BackColor = Color.Red;
                MessageBox.Show("Please Enter User Name!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new_un.Focus();
                return;
            }
            if (confirm_un.Text == "")
            {
                confirm_un.BackColor = Color.Red;
                MessageBox.Show("Please Fill Confirm User Name Field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                confirm_un.Focus();
                return;
            }
            if (ad_id.Text != "" && new_un.Text != "" && confirm_un.Text != "")
            {
                try
                {
                    if (state.Admin_login_id == Convert.ToInt32(ad_id.Text))
                    {
                        if (new_un.Text == confirm_un.Text)
                        {
                            con.Open();
                            string qry = "update admin set user_name='" + new_un.Text + "'where admin_id='" + Convert.ToInt32(ad_id.Text) + "'";
                            SqlCommand cmd = new SqlCommand(qry, con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            ad_id.Text = "";
                            new_un.Text = "";
                            confirm_un.Text = "";
                            MessageBox.Show("User Name Changed successfully!", "User Name Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            admin_view adp = new admin_view();
                            this.Hide();
                            adp.Show();
                        }
                        else
                        {
                            MessageBox.Show("User Name not matched.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Admin ID Incorrect.");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            admin_view adp = new admin_view();
            this.Hide();
            adp.Show();
        }

        private void ad_un_change_Load(object sender, EventArgs e)
        {

        }

        private void ad_id_TextChanged(object sender, EventArgs e)
        {
            ad_id.BackColor = Color.White;
        }

        private void ad_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void new_un_TextChanged(object sender, EventArgs e)
        {
           new_un.BackColor = Color.White;
        }

        private void confirm_un_TextChanged(object sender, EventArgs e)
        {
            confirm_un.BackColor = Color.White;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
