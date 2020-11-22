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
    public partial class student_un_change : Form
    {
        public student_un_change()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var u_l = new student_view();
            this.Hide();
            u_l.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (s_id.Text == "")
            {
                s_id.BackColor = Color.Red;
                MessageBox.Show("Student ID field must be filled!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                s_id.Focus();
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
            if (s_id.Text != "" && new_un.Text != "" && confirm_un.Text != "")
            {
                try
                {
                    if (state.Student_login_id == Convert.ToInt32(s_id.Text))
                    {
                        if (new_un.Text == confirm_un.Text)
                        {
                            state.con.Open();
                            string qry = "update student set s_name='" + new_un.Text + "'where s_id='" + Convert.ToInt64(s_id.Text) + "'";
                            SqlCommand cmd = new SqlCommand(qry, state.con);
                           cmd.ExecuteNonQuery();
                         
                            state.con.Close();
                            s_id.Text = "";
                            new_un.Text = "";
                            confirm_un.Text = "";
                            MessageBox.Show("User Name Changed successfully!", "User Name Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var s_l = new student_view();
                            this.Hide();
                            s_l.Show();
                        }
                        else
                        {
                            MessageBox.Show("User Name not matched.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Student ID Incorrect.");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void s_id_TextChanged(object sender, EventArgs e)
        {
            s_id.BackColor = Color.White;
        }

        private void new_un_TextChanged(object sender, EventArgs e)
        {
            new_un.BackColor = Color.White;
        }

        private void confirm_un_TextChanged(object sender, EventArgs e)
        {
            confirm_un.BackColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
