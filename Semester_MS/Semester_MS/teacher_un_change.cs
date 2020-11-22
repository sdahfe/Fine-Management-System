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
    public partial class teacher_un_change : Form
    {
    
        public teacher_un_change()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            teacher_view tp = new teacher_view();
            this.Hide();
            tp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (t_id.Text == "")
            {
                t_id.BackColor = Color.Red;
                MessageBox.Show("Teacher ID field must be filled!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t_id.Focus();
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
            if (t_id.Text != "" && new_un.Text != "" && confirm_un.Text != "")
            {
                try
                {
                    if (state.Teacher_login_id == Convert.ToInt32(t_id.Text))
                    {
                        if (new_un.Text == confirm_un.Text)
                        {
                            state.con.Open();
                            string qry = "update teacher set user_name='" + new_un.Text + "'where teacher_id='" + Convert.ToInt32(t_id.Text) + "'";
                            SqlCommand cmd = new SqlCommand(qry, state.con);
                            cmd.ExecuteNonQuery();
                            state.con.Close();
                            t_id.Text = "";
                            new_un.Text = "";
                            confirm_un.Text = "";
                            MessageBox.Show("User Name Changed successfully!", "User Name Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            teacher_view tp = new teacher_view();
                            this.Hide();
                            tp.Show();
                        }
                        else
                        {
                            MessageBox.Show("User Name not matched.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Teacher ID Incorrect.");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void t_id_TextChanged(object sender, EventArgs e)
        {
            t_id.BackColor = Color.White;
        }

        private void t_id_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
