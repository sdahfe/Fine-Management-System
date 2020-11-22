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
    public partial class student_setting : Form
    {
        SqlConnection con = new SqlConnection();
        public student_setting()
        {
            InitializeComponent();
            try
            {
                con.ConnectionString = (@"Data Source=DESKTOP-0EGE15A;Initial Catalog=gpgc;Integrated Security=True");
                //con.Open();
                set();                
                show();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void set()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select section_name from sectiontbl", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t1_section.Items.Clear();
                t2_section.Items.Clear();
                t1_section.Items.Add("..Select..");
                t2_section.Items.Add("..Select..");
                while (dr.Read())
                {

                    t1_section.Items.Add(dr[0].ToString());
                    t2_section.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            cmd.CommandText = "select course_name from coursestbl";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t1_course.Items.Clear();
                t2_course.Items.Clear();
                t1_course.Items.Add("..Select..");
                t2_course.Items.Add("..Select..");
                while (dr.Read())
                {
                    if (dr[0].ToString() != "Compulsory")
                    {
                        t1_course.Items.Add(dr[0].ToString());
                        t2_course.Items.Add(dr[0].ToString());
                    }
                }
            }

            dr.Close();
            cmd.CommandText = "select class_name from classtbl";
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
               t1_class.Items.Clear();
               t2_class.Items.Clear();
                t2_class2.Items.Clear();
                t1_class.Items.Add("..Select..");
                t2_class.Items.Add("..Select..");
                t2_class2.Items.Add("..Select..");

                while (dr.Read())
                {
                    t1_class.Items.Add(dr[0].ToString());
                    t2_class.Items.Add(dr[0].ToString());
                    t2_class2.Items.Add(dr[0].ToString());
                }
            }

            dr.Close();
            cmd.CommandText = "select year from yeartbl";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t1_session.Items.Clear();
                t2_session.Items.Clear();
                t1_session.Items.Add("..Select..");
                t2_session.Items.Add("..Select..");
                while (dr.Read())
                {

                    t1_session.Items.Add(dr[0].ToString());
                    t2_session.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
           con.Close();
        }
        public void show()
        {
            try
            {
                //con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select studenttbl.roll_no,studenttbl.reg_no,studenttbl.student_name,studenttbl.email,studenttbl.password,classtbl.class_name, coursestbl.course_name,sectiontbl.section_name, session  from studenttbl,classtbl,coursestbl,sectiontbl where studenttbl.class_id=classtbl.class_id and studenttbl.course_id=coursestbl.course_id and studenttbl.section_id=sectiontbl.section_id;", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dr[5].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = dr[6].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = dr[7].ToString();
                    dataGridView1.Rows[n].Cells[8].Value = dr[8].ToString();
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                t1_rn.Text = (dataGridView1.Rows.Count + 1).ToString();
            }

        }
        public int cl_id(string c_n)
        {
            int id = 0;
            
            con.Open();
            SqlCommand cmd = new SqlCommand("select class_id from classtbl where class_name='" + c_n + "';", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                id = Convert.ToInt32(dr[0].ToString());
            }
            con.Close();
            return id;
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //admin_view av = new admin_view();
            //av.Show();
            //this.Hide();
            admin_view b = new admin_view();
            b.Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            admin_panel ap = new admin_panel();
            this.Hide();
            ap.ShowDialog();
            this.Close();
        }

        private void student_setting_Load(object sender, EventArgs e)
        {
            t1_s_email.Focus();
            t2_s_id.Focus();
            t4_s.Focus();
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            t1_course.SelectedIndex = 0;
            t1_session.SelectedIndex = 0;
            t2_session.SelectedIndex = 0;
            t1_section.SelectedIndex = 0;
            t1_class.SelectedIndex = 0;
            t2_section.SelectedIndex = 0;
            t2_course.SelectedIndex = 0;
            t2_class.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (t1_class.SelectedIndex == 0)
            {
                t1_class.BackColor = Color.Red;
                MessageBox.Show("Please Select Class!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_class.Focus();
                return;
            }
            if (t1_course.SelectedIndex == 0)
            {
                t1_course.BackColor = Color.Red;
                MessageBox.Show("Please Select Course!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_course.Focus();
                return;
            }
            if (t1_section.SelectedIndex == 0)
            {
                t1_section.BackColor = Color.Red;
                MessageBox.Show("Please Select Section", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_section.Focus();
                return;
            }
            if (t1_reg_no.Text == "")
            {
                t1_reg_no.BackColor = Color.Red;
                MessageBox.Show("Registration No. must be entered", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_reg_no.Focus();
                return;
            }
            if (t1_p.Text == "")
            {
                t1_p.BackColor = Color.Red;
                MessageBox.Show("Password  must be entered", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_p.Focus();
                return;
            }
            if (t1_roll_no.Text == "")
            {
                t1_roll_no.BackColor = Color.Red;
                MessageBox.Show("Roll No  must be entered", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_roll_no.Focus();
                return;
            }
            if (t1_s_name.Text == "")
            {
                t1_s_name.BackColor = Color.Red;
                MessageBox.Show("Name  must be entered", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_s_name.Focus();
                return;
            }
            if (t1_s_email.Text == "")
            {
                t1_s_email.BackColor = Color.Red;
                MessageBox.Show("Email  must be entered", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_s_email.Focus();
                return;
            }

            if (t1_session.SelectedIndex == 0)
            {
                t1_session.BackColor = Color.Red;
                MessageBox.Show("Please Select Session!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_session.Focus();
                return;
            }

            if (t1_session.SelectedIndex != 0 && t1_class.SelectedIndex!=0 && t1_section.SelectedIndex!=0 && t1_course.SelectedIndex!=0 &&t1_reg_no.Text!="" && t1_roll_no.Text!="" &&t1_s_name.Text != "" && t1_p.Text != "" && t1_s_email.Text != "")
            {
                try
                {
                    bool t1 = true;
                    bool t2 = true;
                    bool t3 = true;
                    for (int a = 0; a < dataGridView1.RowCount; a++)
                    {                        
                         // email duplication check
                        if (dataGridView1.Rows[a].Cells[3].Value.ToString() == t1_s_email.Text)
                            t1 = false;
                            
                            // roll no duplication check within same class
                        if (dataGridView1.Rows[a].Cells[0].Value.ToString() == t1_roll_no.Text && dataGridView1.Rows[a].Cells[5].Value.ToString() == t1_class.SelectedItem.ToString())
                            t2 = false;
                        if (dataGridView1.Rows[a].Cells[1].Value.ToString() == t1_reg_no.Text && dataGridView1.Rows[a].Cells[5].Value.ToString() == t1_class.SelectedItem.ToString())
                            t3 = false;
                    }
                    if (t1 && t2 && t3)
                    {
                        int cla_id = cl_id(t1_class.SelectedItem.ToString());
                        con.Open();
                        int c_id = 0, s_id = 0;
                        SqlCommand cmd = new SqlCommand("select coursestbl.course_id from coursestbl where course_name='" + t1_course.SelectedItem + "'", con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            c_id = Convert.ToInt32(dr[0].ToString());
                        }
                        dr.Close();
                        cmd.CommandText = "select sectiontbl.section_id from sectiontbl where section_name='" +t1_section.SelectedItem + "'";
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {

                            dr.Read();
                            s_id = Convert.ToInt32(dr[0].ToString());
                            // MessageBox.Show(dr[0].ToString());
                        }
                        dr.Close();

                        cmd = con.CreateCommand();
                        cmd.CommandText = "insert into studenttbl values(@email,@password,@student_name,@course_id,@section_id,@class_id,@roll_no,@reg_no, @session);";
                        cmd.Parameters.AddWithValue("@email", t1_s_email.Text);
                        cmd.Parameters.AddWithValue("@password", t1_p.Text);
                        cmd.Parameters.AddWithValue("@student_name", t1_s_name.Text);
                        cmd.Parameters.AddWithValue("@course_id",c_id);
                        cmd.Parameters.AddWithValue("@section_id", s_id);
                        cmd.Parameters.AddWithValue("@class_id", cla_id);
                        cmd.Parameters.AddWithValue("@roll_no",t1_roll_no.Text);
                        cmd.Parameters.AddWithValue("@reg_no", t1_reg_no.Text);
                        cmd.Parameters.AddWithValue("@session", t1_session.Text);
                        int n= cmd.ExecuteNonQuery();

                        if (n==0)
                            MessageBox.Show("Record is not added!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("New Record is added successfully!", "Record Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        t1_s_email.Text = "";
                        t1_s_name.Text = "";
                        t1_p.Text = "";
                        t1_roll_no.ResetText();
                        t1_reg_no.ResetText();
                        
                        con.Close();
                        show();
                    }
                    if(!t1)
                        MessageBox.Show("That Email already Exist.. Use Another");
                    if (!t2)
                        MessageBox.Show("That Roll No. already Exist for selected class..");
                    if (!t3)
                        MessageBox.Show("That Registration No. already Exist for selected class..");
                }
                catch (SqlException ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
                catch (FormatException ex2)
                {
                    con.Close();
                    MessageBox.Show(ex2.Message);
                }
            }
        }

        private void t1_sid_TextChanged(object sender, EventArgs e)
        {
            t1_s_email.BackColor = Color.White;
        }

        private void t1_un_TextChanged(object sender, EventArgs e)
        {
            t1_s_name.BackColor = Color.White;
        }

        private void t1_p_TextChanged(object sender, EventArgs e)
        {
            t1_p.BackColor = Color.White;
        }

        private void t2_tid_TextChanged(object sender, EventArgs e)
        {
            t2_s_id.BackColor = Color.White;
        }

        private void t4_s_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
 
                SqlDataAdapter sda = new SqlDataAdapter("select studenttbl.roll_no,studenttbl.reg_no,studenttbl.student_name,studenttbl.email,studenttbl.password,classtbl.class_name, coursestbl.course_name,sectiontbl.section_name  from studenttbl,classtbl,coursestbl,sectiontbl where studenttbl.class_id=classtbl.class_id and studenttbl.course_id = coursestbl.course_id and studenttbl.section_id = sectiontbl.section_id and student_name like '%" + t4_s.Text.ToString() + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dr[5].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = dr[6].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = dr[7].ToString();

                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static bool get_success = false;
        static int s_id_rec;
        private void button3_Click(object sender, EventArgs e)
        {
            bool t = true;
            get_success = false;
            if (t2_s_id.Text == "")
            {
                t2_s_id.BackColor = Color.Red;
                MessageBox.Show("Please Enter Student Roll No.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t2_s_id.Focus();
                return;
            }
            if (t2_class.SelectedIndex == 0)
            {
                t2_class.BackColor = Color.Red;
                MessageBox.Show("Please Select Class.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       return;
            }

            if (t2_s_id.Text != "" && t2_class.SelectedIndex!=0 )
            {
                for (int a = 0; a < dataGridView1.RowCount; a++)
                {
                    int comp = Convert.ToInt32(dataGridView1.Rows[a].Cells[0].Value);                    
                    if (comp == Convert.ToInt32(t2_s_id.Text) && dataGridView1.Rows[a].Cells[5].Value.ToString()==t2_class.SelectedItem.ToString())
                    {
                        t2_s_name.Text = dataGridView1.Rows[a].Cells[2].Value.ToString();
                        t2_p.Text = dataGridView1.Rows[a].Cells[4].Value.ToString();
                        t2_course.SelectedItem = dataGridView1.Rows[a].Cells[6].Value.ToString();
                        t2_section.SelectedItem = dataGridView1.Rows[a].Cells[7].Value.ToString();
                        t2_session.SelectedItem = dataGridView1.Rows[a].Cells[8].Value.ToString();
                        t2_rollno.Text = dataGridView1.Rows[a].Cells[0].Value.ToString();
                        t2_class2.SelectedItem = dataGridView1.Rows[a].Cells[5].Value.ToString();
                        t = false;
                        get_success = true;
                        s_id_rec = Convert.ToInt32(t2_s_id.Text);
                    }
                }
                if (t)
                {
                    t2_session.SelectedIndex = 0;
                    t2_rollno.Text = "";
                    t2_class2.SelectedIndex = 0;
                    t2_session.SelectedIndex = 0;
                    t2_s_name.Text = "";
                    t2_p.Text = "";
                    t2_course.SelectedIndex = 0;
                    t2_section.SelectedIndex = 0;
                    t2_class.SelectedIndex = 0;
                    MessageBox.Show("Record Not Found.");
                }
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (get_success)
            {
                if (t2_s_name.Text == "")
                {
                    t2_s_name.BackColor = Color.Red;
                    MessageBox.Show("User Name field must be filled!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    t2_s_name.Focus();
                    return;
                }
                if (t2_p.Text == "")
                {
                    t2_p.BackColor = Color.Red;
                    MessageBox.Show("Password must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    t2_p.Focus();
                    return;
                }
                if (t2_section.SelectedIndex == 0)
                {
                    t2_section.BackColor = Color.Red;
                    MessageBox.Show("Please Select Section!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    t2_section.Focus();
                    return;
                }
                if (t2_course.SelectedIndex == 0)
                {
                    t2_course.BackColor = Color.Red;
                    MessageBox.Show("Please Select Section!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    t2_course.Focus();
                    return;
                }
                if (t2_session.SelectedIndex == 0)
                {
                    t2_session.BackColor = Color.Red;
                    MessageBox.Show("Please Select Section!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    t2_session.Focus();
                    return;
                }
                if (t2_rollno.Text == "")
                {
                    t2_rollno.BackColor = Color.Red;
                    MessageBox.Show("Please Write Roll No!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    t2_rollno.Focus();
                    return;
                }
                if (t2_class2.SelectedIndex == 0)
                {
                    t2_class2.BackColor = Color.Red;
                    MessageBox.Show("Please Select Class!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    t2_class2.Focus();
                    return;
                }
                if (t2_class2.Text != "" && t2_rollno.Text != "" && t2_session.Text != "" && t2_s_name.Text != "" && t2_p.Text != "" && t2_s_id.Text != "" && s_id_rec== Convert.ToInt32(t2_s_id.Text))
                {
                    try
                    {
                        int clas = cl_id(t2_class.SelectedItem.ToString());

                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        int c_id = 0, s_id = 0;
                        SqlCommand cmd = new SqlCommand("select coursestbl.course_id from coursestbl where course_name='" + t2_course.SelectedItem + "'", con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            c_id = Convert.ToInt32(dr[0].ToString());
                        }
                        dr.Close();
                        cmd.CommandText = "select sectiontbl.section_id from sectiontbl where section_name='" + t2_section.SelectedItem + "'";
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            s_id = Convert.ToInt32(dr[0].ToString());
                            // MessageBox.Show(dr[0].ToString());
                        }
                        dr.Close();

                        cmd.CommandText = "update studenttbl set student_name='" + t2_s_name.Text + 
                            "',password='" + t2_p.Text + "' , course_id='"+c_id+
                            "', section_id='"+s_id+ "', session='" + t2_session.Text +
                            "', roll_no='" + t2_rollno.Text + "', class_id='" + cl_id(t2_class2.Text) +
                            "' where roll_no='" + 
                            Convert.ToInt32(t2_s_id.Text) + "' and class_id='"+clas+"'";
                                                
                        cmd.ExecuteNonQuery();
                        t2_s_id.Text = "";
                        t2_rollno.Text = "";
                        t2_class2.SelectedIndex = 0;
                        t2_session.SelectedIndex = 0;
                        t2_s_name.Text = "";
                        t2_p.Text = "";
                        t2_course.SelectedIndex = 0;
                        t2_section.SelectedIndex = 0;
                        t2_class.SelectedIndex = 0;
                        MessageBox.Show("Record Updated successfully!", "Record Modified", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        show();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (FormatException ex2)
                    {
                        MessageBox.Show(ex2.Message);
                    }
                }
                else
                {
                    t2_s_id.BackColor = Color.Red;
                    MessageBox.Show("Please Enter Correct Student ID!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    t2_s_id.Focus();
                   
                }
            }
            else
            {
                t2_s_id.BackColor = Color.Red;
                MessageBox.Show("First Get through Student ID!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t2_s_id.Focus();
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void t3_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t2_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t1_sid_KeyPress(object sender, KeyPressEventArgs e)
        {/*
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }*/
        }

        private void t2_un_TextChanged(object sender, EventArgs e)
        {
            t2_s_name.BackColor = Color.White;
        }

        private void t2_p_TextChanged(object sender, EventArgs e)
        {
            t2_p.BackColor = Color.White;
        }

        private void t3_id_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            t1_s_email.Focus();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (get_success)
            {
                int c = cl_id(t2_class.SelectedItem.ToString());
                con.Open();
                string qry = "delete from studenttbl where roll_no='" + Convert.ToInt32(t2_s_id.Text) + "' and class_id='"+c+"'";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();
                t2_s_id.Text = "";
                t2_s_name.Text = "";
                t2_p.Text = "";
                t2_course.SelectedIndex = 0;
                t2_section.SelectedIndex = 0;
                t2_class.SelectedIndex = 0;
                MessageBox.Show("Record Deleted successfully!", "Record Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                show();
            }else
                MessageBox.Show("Get The Record First!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            t2_class.BackColor = Color.White;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void t4_s_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t1_s_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t2_s_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t1_roll_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t1_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            t1_class.BackColor = Color.White;
        }

        private void t1_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            t1_course.BackColor = Color.White;
        }

        private void t1_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            t1_section.BackColor = Color.White;
        }

        private void t1_reg_no_TextChanged(object sender, EventArgs e)
        {
            t1_reg_no.BackColor = Color.White;
        }

        private void t1_roll_no_TextChanged(object sender, EventArgs e)
        {
            t1_roll_no.BackColor = Color.White;
        }

        private void t1_s_name_TextChanged(object sender, EventArgs e)
        {
            t1_s_name.BackColor = Color.White;
        }

        private void t2_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            t2_course.BackColor = Color.White;
        }

        private void t2_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            t2_section.BackColor = Color.White;
        }

        private void t1_session_SelectedIndexChanged(object sender, EventArgs e)
        {
            t1_session.BackColor = Color.White;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void t2_session_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        bool exit = true;
        private void student_setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                DialogResult d;
                d = MessageBox.Show("Are you sure", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    exit = false;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                } 
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            admin_view b = new admin_view();
            b.Show();
            this.Hide();
        }

        private void t1_rn_TextChanged(object sender, EventArgs e)
        {

        }
    }   
  
}