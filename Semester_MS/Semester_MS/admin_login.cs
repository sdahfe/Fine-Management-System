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
    public partial class admin_panel : Form
    {
        static  SqlConnection con = new SqlConnection();//making connection with database
        public admin_panel()
        {
            InitializeComponent();
            try
            {
                //Here taking connection string
                con.ConnectionString = (@"Data Source=DESKTOP-0EGE15A;Initial Catalog=gpgc;Integrated Security=True"); 
                admin_password.Focus();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Textbox1 is for UserName or Email
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            admin_name.BackColor = Color.White;
        }
        //button1 is Login button in form
        private void button1_Click(object sender, EventArgs e)
        {
            authenticate(); //Authenticate function is created for checking the authentication of User
        }
        //Here is authenticate function which check that user is authentic or not
        private void authenticate()
        {
            if (admin_name.Text == "") //Here name of user is checked
            {
                admin_name.BackColor = Color.Red;// if name is incorrect then text field become red
                MessageBox.Show("User Name must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                admin_name.Focus();//this commend will focus on the admin name text field with admin login form is open
                return;
            }
            if (admin_password.Text == "")//Here Password us checked
            {
                admin_password.BackColor = Color.Red;// if password is incorrect then text fild become red
                MessageBox.Show("Password must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                admin_password.Focus();
                return;
            }
            if (admin_name.Text != "" && admin_password.Text != "")//Here password and User name or Email given by user is checked
            {
                try
                {
                    bool ch = false;
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select * from admin", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int a = 0; a < dt.Rows.Count; a++)
                        {
                            if (dt.Rows[a][1].ToString() == admin_name.Text && dt.Rows[a][2].ToString() == admin_password.Text)
                            {
                                ch = true;
                                state.Admin_login_id = Convert.ToInt32(dt.Rows[a][0].ToString());
                                //  MessageBox.Show(s.Admin_login_id.ToString());
                            }
                        }

                    }

                    if (ch)
                    {
                        //  MessageBox.Show("Authorized..");
                        Program.authorized = true;
                        con.Close();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Unauthorized..", "Autorization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //button is for cancel the login process
        private void button2_Click(object sender, EventArgs e)
        {
            //Program.mainMenu = true;
            //Program.panels = 0;
            //this.Close();
            MM mm = new MM();
            this.Hide();
            mm.ShowDialog();
            this.Close();
        }
        //password text for writing password
        private void password_TextChanged(object sender, EventArgs e)
        {
            admin_password.BackColor = Color.White;
        }
        
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.SkyBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.SkyBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
        }
        //This function will making the keyPress event on Enter key
        private void admin_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
              //  authenticate();
        }
        //This function will making the keyPress event on Enter key
        private void admin_password_KeyPress(object sender, KeyPressEventArgs e)
        {
           // if (e.KeyChar == (char)Keys.Enter)
               // authenticate();
        }

        private void admin_panel_Load(object sender, EventArgs e)
        {

        }

        private void admin_name_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                Focus_adminname();
            }
        }
        private void Focus_adminname()
        {
            if(admin_name.TextLength > 0)
            {
                admin_password.Focus();
            }
            else
            {
                admin_name.Focus();
            }
        }

        private void admin_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Focus_adminpassword();
            }
        }
        private void Focus_adminpassword()
        {
            if (admin_name.TextLength > 0)
            {
                button1.Focus();
                authenticate();
            }
            else
            {
                admin_password.Focus();
            }
        }
    }
}
