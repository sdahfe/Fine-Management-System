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
      
    public partial class teacher_Login : Form
    {
        SqlConnection con = new SqlConnection();
        public teacher_Login()
        {
            InitializeComponent();
            con.ConnectionString = (@"Server = DESKTOP-0EGE15A;Initial Catalog=gpgc;Integrated Security=True");
            t_un.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.mainMenu = true;
            Program.panels = 0;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            authenticate();
        }

        private void t_un_KeyPress(object sender, EventArgs e)
        {
            authenticate();
        }

        private void authenticate()
        {
            if (t_un.Text == "")
            {
                t_un.BackColor = Color.Red;
                MessageBox.Show("User Name must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t_un.Focus();
                return;
            }
            if (t_p.Text == "")
            {
                t_p.BackColor = Color.Red;
                MessageBox.Show("Password must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t_p.Focus();
                return;
            }
            if (t_un.Text != "" && t_p.Text != "")
            {
                try
                {
                    bool ch = false;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from teachertbl", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {
                            if (dr[1].ToString() == t_un.Text && dr[2].ToString() == t_p.Text)
                            {
                                //MessageBox.Show("true");
                                state.Teacher_login_id = Convert.ToInt32(dr[0].ToString());
                                ch = true;
                            }
                        }

                    }
                    if (ch)
                    {
                        Program.authorized = true;
                        con.Close();
                        this.Close();
                    }
                    else
                    {
                        con.Close();
                        MessageBox.Show("Unauthorized..", "Autorization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("from back " + ex.Message);
                }
            }
        }
        private void t_un_TextChanged(object sender, EventArgs e)
        {
            t_un.BackColor = Color.White;
        }

        private void t_p_TextChanged(object sender, EventArgs e)
        {
            t_p.BackColor = Color.White;
        }

        private void teacher_Login_Activated(object sender, EventArgs e)
        {
            t_un.Focus();
        }

        private void t_un_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                authenticate();
        }

        private void t_p_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                authenticate();
        }
    }
}
