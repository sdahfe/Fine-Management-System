using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Semester_MS
{
    public partial class teacher_p_change : Form
    {
        public teacher_p_change()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void t_id_TextChanged(object sender, EventArgs e)
        {
            t_id.BackColor = Color.White;
        }

        private void new_pass_TextChanged(object sender, EventArgs e)
        {
            new_pass.BackColor = Color.White;
        }

        private void confirm_pass_TextChanged(object sender, EventArgs e)
        {
            confirm_pass.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changePassword();
        }

        private void changePassword()
        {
            if (t_id.Text == "")
            {
                t_id.BackColor = Color.Red;
                MessageBox.Show("Teacher ID field must be filled!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t_id.Focus();
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
            if (!confirm_pass.Text.Equals(new_pass.Text))
            {
                confirm_pass.BackColor = Color.Red;
                MessageBox.Show("Confirm Password Doesn't Match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                confirm_pass.Focus();
                return;
            }

            if (t_id.Text != "" && new_pass.Text != "" && confirm_pass.Text != "")
            {
                try
                {
                    if (new_pass.Text == confirm_pass.Text)
                    {
                        state.con.Open();
                        string qry = "update teachertbl set password='" + new_pass.Text + "'where teacher_id='" + state.Teacher_login_id + "'";
                        SqlCommand cmd = new SqlCommand(qry, state.con);
                        if (cmd.ExecuteNonQuery() > 0)
                            MessageBox.Show("Password Changed successfully!", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Error Changing Password", "Password Unchanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        state.con.Close();
                        t_id.Text = "";
                        new_pass.Text = "";
                        confirm_pass.Text = "";

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password not matched.");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }



            }
        }

        private void teacher_p_change_Load(object sender, EventArgs e)
        {
            if (state.con.State == ConnectionState.Closed)
                state.con.Open();

            SqlCommand cmd = new SqlCommand("select email from teachertbl where teacher_id=" + state.Teacher_login_id, state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                t_id.Text = dr[0].ToString();
            }
            dr.Close();
            state.con.Close();
            
        }

        private void new_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                changePassword();
        }

        private void confirm_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                changePassword();
        }
    }
}
