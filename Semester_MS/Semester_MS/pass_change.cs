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
    public partial class admin_ch_pass : Form
    {
        SqlConnection con = new SqlConnection();
        public admin_ch_pass()
        {
            InitializeComponent();
            try
            {
                con.ConnectionString = (@"Data Source=.\SQLEXPRESS;Initial Catalog=gpgc;Integrated Security=True");

              
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            confirm_pass.BackColor = Color.White;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
            if (new_pass.Text == "")
            {
                new_pass.BackColor = Color.Red;
                MessageBox.Show("Please Enter New Password!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new_pass.Focus();
                return;
            }
            if (confirm_pass.Text == "")
            {
                confirm_pass.BackColor = Color.Red;
                MessageBox.Show("Please Fill Confirm Password Field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                confirm_pass.Focus();
                return;
            }
            if (ad_id.Text != "" && new_pass.Text != "" && confirm_pass.Text != "")
            {
                try
                {
                    if (state.Admin_login_id == Convert.ToInt32(ad_id.Text))
                    {
                        if (new_pass.Text == confirm_pass.Text)
                        {
                            con.Open();
                            string qry = "update admin set password='" + new_pass.Text + "'where admin_id='" + Convert.ToInt32(ad_id.Text) + "'";
                            SqlCommand cmd = new SqlCommand(qry, con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            ad_id.Text = "";
                            new_pass.Text = "";
                            confirm_pass.Text = "";
                            MessageBox.Show("Password Changed successfully!", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            admin_view adp = new admin_view();
                            this.Hide();
                            adp.Show();
                        }
                        else
                        {
                            MessageBox.Show("Password not matched.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Admin ID incorrect.");
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
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.SkyBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.SkyBlue;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Transparent;
        }

        private void admin_ch_pass_Load(object sender, EventArgs e)
        {

        }

        private void new_pass_TextChanged(object sender, EventArgs e)
        {
            new_pass.BackColor = Color.White;
        }

        private void ad_id_TextChanged(object sender, EventArgs e)
        {
            ad_id.BackColor = Color.White;
        }
    }
}
