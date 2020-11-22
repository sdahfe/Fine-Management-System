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
    public partial class student_p_change : Form
    {
        public student_p_change()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (new_p.Text == "")
            {
                new_p.BackColor = Color.Red;
                MessageBox.Show("Please Enter new password!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new_p.Focus();
                return;
            }
            if (confirm_p.Text == "")
            {
                confirm_p.BackColor = Color.Red;
                MessageBox.Show("Please Fill Confirm Confirm Password Field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                confirm_p.Focus();
                return;
            }
            if (s_id.Text != "" && new_p.Text != "" && confirm_p.Text != "")
            {
                try
                {
                    if (state.Student_login_id == Convert.ToInt32(s_id.Text))
                    {
                        if (new_p.Text == confirm_p.Text)
                        {
                            state.con.Open();
                            string qry = "update studenttbl set password='" + new_p.Text + "'where s_id='" + Convert.ToInt64(s_id.Text) + "'";
                            SqlCommand cmd = new SqlCommand(qry, state.con);
                            cmd.ExecuteNonQuery();
                            state.con.Close();
                            s_id.Text = "";
                            new_p.Text = "";
                            confirm_p.Text = "";
                            MessageBox.Show("Password Changed Successfully!", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var s_l = new student_view();
                            this.Hide();
                            s_l.Show();
                        }
                        else
                        {
                            MessageBox.Show("Password not matched.");
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

        private void new_p_TextChanged(object sender, EventArgs e)
        {
            new_p.BackColor = Color.White;
        }

        private void confirm_p_TextChanged(object sender, EventArgs e)
        {
            confirm_p.BackColor = Color.White;
        }
    }
}
