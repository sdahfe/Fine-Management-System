using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Semester_MS
{
    public partial class student_login : Form
    {
        SqlConnection con = new SqlConnection();
        public student_login()
        {
            InitializeComponent();
            con.ConnectionString = (@"Data Source=.\SQLEXPRESS;Initial Catalog=gpgc;Integrated Security=True");
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

        private void authenticate()
        {
            if (s_n.Text == "")
            {
                s_n.BackColor = Color.Red;
                MessageBox.Show("Email must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                s_n.Focus();
                return;
            }
            if (s_p.Text == "")
            {
                s_p.BackColor = Color.Red;
                MessageBox.Show("Password must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                s_p.Focus();
                return;
            }
            if (s_n.Text != "" && s_p.Text != "")
            {
                try
                {
                    bool ch = false;
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select * from studenttbl", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {

                        for (int a = 0; a < dt.Rows.Count; a++)
                        {
                            // MessageBox.Show("ok");
                            if (dt.Rows[a][1].ToString() == s_n.Text && dt.Rows[a][2].ToString() == s_p.Text)
                            {
                                ch = true;
                                state.Student_login_id = Convert.ToInt32(dt.Rows[a][0].ToString());

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
                        Program.authorized = false;
                        MessageBox.Show("Unauthorized..", "Autorization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void student_login_Load(object sender, EventArgs e)
        {

        }

        private void s_n_TextChanged(object sender, EventArgs e)
        { 
            s_n.BackColor = Color.White;
        }

        private void s_p_TextChanged(object sender, EventArgs e)
        {
            s_p.BackColor = Color.White;
        }

        private void s_n_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                authenticate();
        }

        private void s_p_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                authenticate();
        }
    }
}
