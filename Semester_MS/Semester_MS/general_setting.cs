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
    public partial class general_setting : Form
    {
        public general_setting()
        {
            InitializeComponent();
            set();
            load_year();
            load_course();
            load_section();
            load_class();
            Load_subject();
            fine();
        }

        public void fine()
        {
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select * from fineCriteriatbl ", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                int count = 1;
                while (dr.Read())
                {
                    if (count == 1)
                    {
                        t7_1_from.Text = dr[1].ToString();
                        t7_1_to.Text = dr[2].ToString();
                        t7_1_fine.Text = dr[3].ToString();
                        t7_struck_absent.Text = dr[4].ToString();
                    }
                    if (count == 2)
                    {
                        t7_2_from.Text = dr[1].ToString();
                        t7_2_to.Text = dr[2].ToString();
                        t7_2_fine.Text = dr[3].ToString();
                    }
                    if (count == 3)
                    {
                        t7_3_from.Text = dr[1].ToString();
                        t7_3_to.Text = dr[2].ToString();
                        t7_3_fine.Text = dr[3].ToString();
                    }
                    if (count == 4)
                    {
                        t7_4_from.Text = dr[1].ToString();
                        t7_4_to.Text = dr[2].ToString();
                        t7_4_fine.Text = dr[3].ToString();
                    }
                    count++;
                }
            }
            state.con.Close();
        }
        public void set()
        {
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select section_name from sectiontbl", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t3_section.Items.Clear();
                t4_section.Items.Clear();
                t3_section.Items.Add("..Select..");
                t4_section.Items.Add("..Select..");
                t3_section.SelectedIndex = 0;
                t4_section.SelectedIndex = 0;
                while (dr.Read())
                {
                    t3_section.Items.Add(dr[0].ToString());
                    t4_section.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            cmd.CommandText = "select subject_id from subjecttbl";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t4_s_code.Items.Clear();
                t4_s_code.Items.Add("..Select..");
                t4_s_code.SelectedIndex = 0;
                while (dr.Read())
                {
                    t4_s_code.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            cmd.CommandText = "select course_name from coursestbl";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t1_sub_cat.Items.Clear();
                t2_sub_cat.Items.Clear();
                t1_sub_cat.Items.Add("..Select..");
                t2_sub_cat.Items.Add("..Select..");
                t1_sub_cat.SelectedIndex = 0;
                t2_sub_cat.SelectedIndex = 0;
                while (dr.Read())
                {
                    t1_sub_cat.Items.Add(dr[0].ToString());
                    t2_sub_cat.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            cmd.CommandText = "select class_name from classtbl";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t1_class.Items.Clear();
                t3_class.Items.Clear();
                t1_class.Items.Add("..Select..");
                t3_class.Items.Add("..Select..");
                t1_class.SelectedIndex = 0;
                t3_class.SelectedIndex = 0;
                while (dr.Read())
                {
                    t1_class.Items.Add(dr[0].ToString());
                    t3_class.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }
        public void load_year()
        {
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select * from yeartbl;", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dataGridViewYear.Rows.Clear();
                while (dr.Read())
                {
                    int n = dataGridViewYear.Rows.Add();
                    dataGridViewYear.Rows[n].Cells[0].Value = dr[0].ToString();
                    dataGridViewYear.Rows[n].Cells[1].Value = dr[1].ToString();
                }
            }
            dr.Close();
            state.con.Close();
        }
        public void load_subject()
        {
            int c = class_id(t3_class.SelectedItem.ToString());
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select * from subjecttbl where class_id='" + c + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                t3_sub_code.Items.Clear();
                t3_sub_code.Items.Add("..Select..");
                t3_sub_code.SelectedIndex = 0;
                while (dr.Read())
                {
                    t3_sub_code.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }
        public void load_course()
        {
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select * from coursestbl", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dataGridViewCourse.Rows.Clear();
                while (dr.Read())
                {
                    int n = dataGridViewCourse.Rows.Add();
                    dataGridViewCourse.Rows[n].Cells[0].Value = dr[0].ToString();
                    dataGridViewCourse.Rows[n].Cells[1].Value = dr[1].ToString();
                }
            }
            dr.Close();
            state.con.Close();
        }
        public void load_class()
        {
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select * from classtbl", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dataGridViewClass.Rows.Clear();
                while (dr.Read())
                {
                    int n = dataGridViewClass.Rows.Add();
                    dataGridViewClass.Rows[n].Cells[0].Value = dr[0].ToString();
                    dataGridViewClass.Rows[n].Cells[1].Value = dr[1].ToString();
                }
            }
            dr.Close();
            state.con.Close();
        }
        public void load_section()
        {
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select * from sectiontbl", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dataGridViewSection.Rows.Clear();
                while (dr.Read())
                {
                    int n = dataGridViewSection.Rows.Add();
                    dataGridViewSection.Rows[n].Cells[0].Value = dr[0].ToString();
                    dataGridViewSection.Rows[n].Cells[1].Value = dr[1].ToString();
                }
            }
            dr.Close();
            state.con.Close();
        }
        private void Load_subject()
        {
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select * from subjecttbl", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dataGridViewsubject.Rows.Clear();
                while (dr.Read())
                {
                    int n = dataGridViewsubject.Rows.Add();
                    dataGridViewsubject.Rows[n].Cells[0].Value = dr[0].ToString();
                    dataGridViewsubject.Rows[n].Cells[1].Value = dr[1].ToString();
                }
            }
            state.con.Close();
        }
        public int class_id(string c_n)
        {
            int id = 0;
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select class_id from classtbl where class_name='" + c_n + "';", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                id = Convert.ToInt32(dr[0].ToString());
            }
            state.con.Close();
            return id;
        }
        public int course_id(string c_name)
        {
            int id = 0;
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select course_id from coursestbl where course_name='" + c_name + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                id = Convert.ToInt32(dr[0].ToString());
            }
            state.con.Close();
            return id;
        }
        public string course_name(int id)
        {
            string name = "";
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select course_name from coursestbl where course_id='" + id + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                name = dr[0].ToString();
            }
            state.con.Close();
            return name;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
            //Program.mainMenu = false;
            // Program.panels = 1;
            //this.Close();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin_view b = new admin_view();
            b.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (t1_sub_id.Text == "")
            {
                t1_sub_id.BackColor = Color.Red;
                MessageBox.Show("Subject ID must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_sub_id.Focus();
                return;
            }
            if (t1_sub_name.Text == "")
            {
                t1_sub_name.BackColor = Color.Red;
                MessageBox.Show("Subject Name must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_sub_name.Focus();
                return;
            }
            if (t1_sub_cat.SelectedIndex == 0)
            {
                t1_sub_cat.BackColor = Color.Red;
                MessageBox.Show("Please Select Subject Categor!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_sub_cat.Focus();
                return;
            }
            if (t1_class.SelectedIndex == 0)
            {
                t1_class.BackColor = Color.Red;
                MessageBox.Show("Please Select Class Categor!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_class.Focus();
                return;
            }
            if (t1_sub_id.Text != "" && t1_sub_name.Text != "" && t1_sub_cat.SelectedIndex != 0 && t1_class.SelectedIndex != 0)
            {
                int c_id = course_id(t1_sub_cat.SelectedItem.ToString());
                int cl_id = class_id(t1_class.SelectedItem.ToString());
                //MessageBox.Show(c_id.ToString());
                state.con.Open();
                SqlCommand cmd = new SqlCommand("select * from subjecttbl where subject_id='" + t1_sub_id.Text + "'", state.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Subject ID Alread Assigned to Some Subject!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    cmd.CommandText = "insert into subjecttbl values(@subject_id,@subject_name,@course_id,@class_id);";
                    cmd.Parameters.Add("@subject_id", t1_sub_id.Text);
                    cmd.Parameters.Add("@subject_name", t1_sub_name.Text);
                    cmd.Parameters.Add("@course_id", c_id);
                    cmd.Parameters.Add("@class_id", cl_id);
                    cmd.ExecuteNonQuery();
                    t1_sub_id.Text = "";
                    t1_sub_name.Text = "";
                    MessageBox.Show("New Subbect is added successfully!", "Subject Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                state.con.Close();
                set();
            }
        }

        private void t1_sub_id_TextChanged(object sender, EventArgs e)
        {
            t1_sub_id.BackColor = Color.White;
        }

        private void t1_sub_name_TextChanged(object sender, EventArgs e)
        {
            t1_sub_name.BackColor = Color.White;
        }

        private void t1_sub_cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            t1_sub_cat.BackColor = Color.White;
        }

        private void general_setting_Load(object sender, EventArgs e)
        {
            t1_sub_cat.SelectedIndex = 0;
            t1_class.SelectedIndex = 0;

            t2_sub_cat.SelectedIndex = 0;

            t3_section.SelectedIndex = 0;
            t3_sub_code.SelectedIndex = 0;
            t3_class.SelectedIndex = 0;

            t4_s_code.SelectedIndex = 0;
            t4_section.SelectedIndex = 0;

            dataGridViewsubject.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridViewsubject.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewsubject.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGridViewsubject.EnableHeadersVisualStyles = false;


            dataGridViewClass.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridViewClass.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewClass.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGridViewClass.EnableHeadersVisualStyles = false;

            dataGridViewCourse.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridViewCourse.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewCourse.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGridViewCourse.EnableHeadersVisualStyles = false;

            dataGridViewSection.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridViewSection.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewSection.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGridViewSection.EnableHeadersVisualStyles = false;

            dataGridViewYear.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridViewYear.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewYear.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGridViewYear.EnableHeadersVisualStyles = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (t2_sub_id.Text == "")
            {
                t2_sub_id.BackColor = Color.Red;
                MessageBox.Show("Subject ID must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t2_sub_id.Focus();
                return;
            }
            if (t2_sub_id.Text != "")
            {
                int id = 0;
                state.con.Open();
                SqlCommand cmd = new SqlCommand("select * from subjecttbl where subject_id='" + t2_sub_id.Text.ToString() + "'", state.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    t2_sub_name.Text = dr[1].ToString();
                    id = Convert.ToInt32(dr[2].ToString());
                    dr.Close();
                    state.con.Close();
                    t2_sub_cat.SelectedIndex = t1_sub_cat.FindStringExact(course_name(id));
                }
                else
                    MessageBox.Show("No Record Found!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                state.con.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (t2_sub_id.Text != "" && t2_sub_id.Text != "" && t2_sub_cat.SelectedIndex != 0)
            {
                int id = course_id(t2_sub_cat.SelectedItem.ToString());
                state.con.Open();
                SqlCommand cmd = new SqlCommand("update  subjecttbl set subject_name='" + t2_sub_name.Text + "', course_id='" + id + "' where subject_id='" + t2_sub_id.Text.ToString() + "'", state.con);
                cmd.ExecuteNonQuery();
                t2_sub_cat.SelectedIndex = 0;
                t2_sub_id.ResetText();
                t2_sub_name.ResetText();
                MessageBox.Show("Record Updated!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                state.con.Close();
            }
            else
                MessageBox.Show("Get Record First!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (t2_sub_id.Text != "" && t2_sub_id.Text != "" && t2_sub_cat.SelectedIndex != 0)
            {
                state.con.Open();
                SqlCommand cmd = new SqlCommand("delete from  subjecttbl where subject_id='" + t2_sub_id.Text.ToString() + "'", state.con);
                cmd.ExecuteNonQuery();
                t2_sub_cat.SelectedIndex = 0;
                t2_sub_id.ResetText();
                t2_sub_name.ResetText();
                MessageBox.Show("Record Deleted!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                state.con.Close();
            }
            else
                MessageBox.Show("Get Record First!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (t3_teach_id.Text == "")
            {
                t3_teach_id.BackColor = Color.Red;
                MessageBox.Show("Teacher ID must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t3_teach_id.Focus();
                return;
            }
            if (t3_sub_code.SelectedIndex == 0)
            {
                t3_sub_code.BackColor = Color.Red;
                MessageBox.Show("Please Select Subject Code!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t3_sub_code.Focus();
                return;
            }
            if (t3_class.SelectedIndex == 0)
            {
                t3_class.BackColor = Color.Red;
                MessageBox.Show("Please Select Class.!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t3_class.Focus();
                return;
            }
            if (t3_section.SelectedIndex == 0)
            {
                t3_section.BackColor = Color.Red;
                MessageBox.Show("Please Select Section.!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t3_section.Focus();
                return;
            }
            if (t3_teach_id.Text != "" && t3_sub_code.SelectedIndex != 0 && t3_class.SelectedIndex != 0 && t3_section.SelectedIndex != 0)
            {
                int cl_id = class_id(t3_class.SelectedItem.ToString());
                int s_id = 0;
                state.con.Open();
                SqlCommand cmd = new SqlCommand("select section_id from sectiontbl where section_name='" + t3_section.SelectedItem.ToString() + "' ", state.con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                s_id = Convert.ToInt32(dr[0].ToString());
                dr.Close();
                cmd.CommandText = "select * from subjectAssignedtbl where subject_id='" + t3_sub_code.SelectedItem.ToString() + "' and section_id='" + s_id + "'";
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Subject for this section Alread Assigned to Some teacher!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    cmd.CommandText = "insert into subjectAssignedtbl values(@teacher_id,@section_id,@subject_id,@class_id);";
                    cmd.Parameters.Add("@teacher_id", t3_teach_id.Text);
                    cmd.Parameters.Add("@section_id", s_id);
                    cmd.Parameters.Add("@subject_id", t3_sub_code.SelectedItem.ToString());
                    cmd.Parameters.Add("@class_id", cl_id);
                    cmd.ExecuteNonQuery();
                    t3_teach_id.Text = "";
                    t3_sub_code.SelectedIndex = 0;
                    t3_section.SelectedIndex = 0;
                    t3_class.SelectedIndex = 0;
                    MessageBox.Show("Subject is Assigned successfully!", "Subject Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                state.con.Close();

            }
        }
        static int sec_id = 0;
        private void button7_Click(object sender, EventArgs e)
        {
            if (t4_t_id.Text == "")
            {
                t4_t_id.BackColor = Color.Red;
                MessageBox.Show("Teacher ID must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t4_t_id.Focus();
                return;
            }
            if (t4_s_code.SelectedIndex == 0)
            {
                t4_s_code.BackColor = Color.Red;
                MessageBox.Show("Please Select Subject Code!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (t4_section.SelectedIndex == 0)
            {
                t4_section.BackColor = Color.Red;
                MessageBox.Show("Please Select Section.!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (t4_t_id.Text != "" && t4_s_code.SelectedIndex != 0 && t4_section.SelectedIndex != 0)
            {
                sec_id = 0;
                state.con.Open();
                SqlCommand cmd = new SqlCommand("select section_id from sectiontbl where section_name='" + t4_section.SelectedItem.ToString() + "' ", state.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    sec_id = Convert.ToInt32(dr[0].ToString());
                }

                dr.Close();
                cmd.CommandText = "select * from subjectAssignedtbl where teacher_id='" + t4_t_id.Text + "' and subject_id='" + t4_s_code.SelectedItem.ToString() + "' and section_id='" + sec_id + "'";
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Record Found!" + Environment.NewLine + "Press Delete Button to Delete that record.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("No Record Found!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                state.con.Close();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (sec_id != 0 && t4_section.SelectedIndex != 0 && t4_s_code.SelectedIndex != 0 && t4_t_id.Text != "")
            {
                state.con.Open();
                SqlCommand cmd = new SqlCommand("delete from subjectAssignedtbl where teacher_id='" + t4_t_id.Text + "' and subject_id='" + t4_s_code.SelectedItem.ToString() + "' and section_id='" + sec_id + "'", state.con);
                cmd.ExecuteNonQuery();
                t4_section.SelectedIndex = 0;
                t4_s_code.SelectedIndex = 0;
                t4_t_id.ResetText();
                sec_id = 0;
                MessageBox.Show("Record Deleted!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                state.con.Close();
            }
            else
                MessageBox.Show("Get Record First!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (t7_1_from.Text == "")
            {
                t7_1_from.BackColor = Color.Red;
                MessageBox.Show("Please enter Section 1 From field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t7_1_from.Focus();
                return;
            }
            if (t7_1_to.Text == "")
            {
                t7_1_to.BackColor = Color.Red;
                MessageBox.Show("Please enter Section 1 To field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t7_1_to.Focus();
                return;
            }
            if (t7_1_fine.Text == "")
            {
                t7_1_fine.BackColor = Color.Red;
                MessageBox.Show("Please enter Section 1 Fine field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t7_1_fine.Focus();
                return;
            }
            if (t7_2_from.Text == "")
            {
                t7_2_from.BackColor = Color.Red;
                MessageBox.Show("Please enter Section 2 From field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t7_2_from.Focus();
                return;
            }
            if (t7_2_to.Text == "")
            {
                t7_2_to.BackColor = Color.Red;
                MessageBox.Show("Please enter Section 2 To field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t7_2_to.Focus();
                return;
            }
            if (t7_2_fine.Text == "")
            {
                t7_2_fine.BackColor = Color.Red;
                MessageBox.Show("Please enter Section 2 Fine field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t7_2_fine.Focus();
                return;
            }
            if (t7_3_from.Text == "")
            {
                t7_3_from.BackColor = Color.Red;
                MessageBox.Show("Please enter Section 3 From field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t7_3_from.Focus();
                return;
            }
            if (t7_3_to.Text == "")
            {
                t7_3_to.BackColor = Color.Red;
                MessageBox.Show("Please enter Section 3 To field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t7_3_to.Focus();
                return;
            }
            if (t7_3_fine.Text == "")
            {
                t7_3_fine.BackColor = Color.Red;
                MessageBox.Show("Please enter Section 3 Fine field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t7_3_fine.Focus();
                return;
            }
            if (t7_4_from.Text == "")
            {
                t7_4_from.BackColor = Color.Red;
                MessageBox.Show("Please enter Section 4 From field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t7_4_from.Focus();
                return;
            }
            if (t7_4_to.Text == "")
            {
                t7_4_to.BackColor = Color.Red;
                MessageBox.Show("Please enter Section 4 To field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t7_4_to.Focus();
                return;
            }
            if (t7_4_fine.Text == "")
            {
                t7_4_fine.BackColor = Color.Red;
                MessageBox.Show("Please enter Section 4 Fine field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t7_4_fine.Focus();
                return;
            }
            if (t7_struck_absent.Text == "")
            {
                t7_struck_absent.BackColor = Color.Red;
                MessageBox.Show("struck Off On Absent must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t7_struck_absent.Focus();
                return;
            }
            if (t7_1_from.Text != "" && t7_1_to.Text != "" && t7_1_fine.Text != "" && t7_2_from.Text != "" && t7_2_to.Text != "" && t7_2_fine.Text != "" && t7_3_from.Text != "" && t7_3_to.Text != "" && t7_3_fine.Text != "" && t7_4_from.Text != "" && t7_4_to.Text != "" && t7_4_fine.Text != "" && t7_struck_absent.Text != "")
            {
                state.con.Open();
                SqlCommand cmd = new SqlCommand("delete from fineCriteriatbl", state.con);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into fineCriteriatbl values(@from,@to,@fineOnPerAbsent,@struckOffOn)";
                cmd.Parameters.Add("@from", t7_1_from.Text);
                cmd.Parameters.Add("@to", t7_1_to.Text);
                cmd.Parameters.Add("@fineOnPerAbsent", t7_1_fine.Text);
                cmd.Parameters.Add("@struckOffOn", t7_struck_absent.Text);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into fineCriteriatbl values(@2from,@2to,@2fineOnPerAbsent,@2struckOffOn)";
                cmd.Parameters.Add("@2from", t7_2_from.Text);
                cmd.Parameters.Add("@2to", t7_2_to.Text);
                cmd.Parameters.Add("@2fineOnPerAbsent", t7_2_fine.Text);
                cmd.Parameters.Add("@2struckOffOn", t7_struck_absent.Text);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into fineCriteriatbl values(@3from,@3to,@3fineOnPerAbsent,@3struckOffOn)";
                cmd.Parameters.Add("@3from", t7_3_from.Text);
                cmd.Parameters.Add("@3to", t7_3_to.Text);
                cmd.Parameters.Add("@3fineOnPerAbsent", t7_3_fine.Text);
                cmd.Parameters.Add("@3struckOffOn", t7_struck_absent.Text);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into fineCriteriatbl values(@4from,@4to,@4fineOnPerAbsent,@4struckOffOn)";
                cmd.Parameters.Add("@4from", t7_4_from.Text);
                cmd.Parameters.Add("@4to", t7_4_to.Text);
                cmd.Parameters.Add("@4fineOnPerAbsent", t7_4_fine.Text);
                cmd.Parameters.Add("@4struckOffOn", t7_struck_absent.Text);
                cmd.ExecuteNonQuery();
                //  t7_1_from.ResetText();
                // t7_1_to.ResetText();
                //  t7_1_fine.ResetText();
                // t7_2_from.ResetText();
                // t7_2_to.ResetText();
                // t7_2_fine.ResetText();
                // t7_3_from.ResetText();
                //t7_3_to.ResetText();
                // t7_3_fine.ResetText();
                // t7_4_from.ResetText();
                // t7_4_to.ResetText();
                //  t7_4_fine.ResetText();
                //  t7_struck_absent.ResetText();               
                MessageBox.Show("Inserted/Updated!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                state.con.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (t5_c_name.Text == "")
            {
                t5_c_name.BackColor = Color.Red;
                MessageBox.Show("Course Name must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t5_c_name.Focus();
                return;
            }
            if (t5_c_name.Text != "")
            {
                state.con.Open();
                SqlCommand cmd = new SqlCommand("select * from coursestbl where course_name='" + t5_c_name.Text + "'", state.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    state.con.Close();
                    MessageBox.Show("Course Name Already Exists.!", "Subject Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dr.Close();
                    cmd.CommandText = "insert into coursestbl values(@course_name)";
                    cmd.Parameters.Add("@course_name", t5_c_name.Text);
                    cmd.ExecuteNonQuery();
                    t5_c_name.Text = "";
                    MessageBox.Show("New Course is added successfully!", "Subject Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                state.con.Close();
                load_course();
                set();
            }

        }

        private void t2_sub_cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            t2_sub_cat.BackColor = Color.White;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (t6_s_name.Text == "")
            {
                t6_s_name.BackColor = Color.Red;
                MessageBox.Show("Section Name must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t6_s_name.Focus();
                return;
            }
            if (t6_s_name.Text != "")
            {
                state.con.Open();
                SqlCommand cmd = new SqlCommand("select * from sectiontbl where section_name='" + t6_s_name.Text + "'", state.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    state.con.Close();
                    MessageBox.Show("Course Name Already Exists.!", "Subject Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dr.Close();
                    cmd.CommandText = "insert into sectiontbl values(@section_name)";
                    cmd.Parameters.Add("@section_name", t6_s_name.Text);
                    cmd.ExecuteNonQuery();
                    t6_s_name.Text = "";
                    MessageBox.Show("New Section is added successfully!", "Subject Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                state.con.Close();
                load_section();
                set();
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (t8_class_name.Text == "")
            {
                t8_class_name.BackColor = Color.Red;
                MessageBox.Show("Class Name must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t8_class_name.Focus();
                return;
            }
            if (t8_class_name.Text != "")
            {
                state.con.Open();
                SqlCommand cmd = new SqlCommand("select * from classtbl where class_name='" + t8_class_name.Text + "'", state.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    state.con.Close();
                    MessageBox.Show("Class Name Already Exists.!", "Class Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dr.Close();
                    cmd.CommandText = "insert into classtbl values(@class_name)";
                    cmd.Parameters.Add("@class_name", t8_class_name.Text);
                    cmd.ExecuteNonQuery();
                    t8_class_name.Text = "";
                    MessageBox.Show("New Class is added successfully!", "Subject Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                state.con.Close();
                load_class();
                set();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void t3_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            t3_class.BackColor = Color.White;
            if (t3_class.SelectedIndex == 0)
            {
                t3_sub_code.Items.Clear();
                t3_sub_code.Items.Add("..Select..");
                t3_sub_code.SelectedIndex = 0;
            }
            if (t3_class.SelectedIndex != 0)
            {
                load_subject();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (t9_year.Text == "")
            {
                t9_year.BackColor = Color.Red;
                MessageBox.Show("Year must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t9_year.Focus();
                return;
            }
            if (t9_year.Text != "")
            {
                state.con.Open();
                SqlCommand cmd = new SqlCommand("select * from yeartbl where year='" + t9_year.Text + "'", state.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    state.con.Close();
                    MessageBox.Show("That Year Already Exists.!", "Class Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dr.Close();
                    cmd.CommandText = "insert into yeartbl values(@year)";
                    cmd.Parameters.Add("@year", t9_year.Text);
                    cmd.ExecuteNonQuery();
                    t9_year.Text = "";
                    MessageBox.Show("New Year is added successfully!", "Subject Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                state.con.Close();
                load_year();
                set();
            }
        }

        private void t1_sub_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t2_sub_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t3_teach_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t4_t_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t8_class_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }*/
        }

        private void t5_c_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t9_year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar == 106)
            {
                e.Handled = true;
            }
        }

        private void t7_fine_absent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t7_struck_absent_KeyPress(object sender, KeyPressEventArgs e)
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

        private void t2_sub_id_TextChanged(object sender, EventArgs e)
        {
            t2_sub_id.BackColor = Color.White;
        }

        private void t2_sub_name_TextChanged(object sender, EventArgs e)
        {
            t2_sub_name.BackColor = Color.White;
        }

        private void t3_teach_id_TextChanged(object sender, EventArgs e)
        {
            t3_teach_id.BackColor = Color.White;
        }

        private void t3_sub_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            t3_sub_code.BackColor = Color.White;
        }

        private void t3_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            t3_section.BackColor = Color.White;
        }

        private void t4_t_id_TextChanged(object sender, EventArgs e)
        {
            t4_t_id.BackColor = Color.White;
        }

        private void t4_s_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            t4_s_code.BackColor = Color.White;
        }

        private void t4_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            t4_section.BackColor = Color.White;
        }

        private void t8_class_name_TextChanged(object sender, EventArgs e)
        {
            t8_class_name.BackColor = Color.White;
        }

        private void t5_c_name_TextChanged(object sender, EventArgs e)
        {
            t5_c_name.BackColor = Color.White;
        }

        private void t6_s_name_TextChanged(object sender, EventArgs e)
        {
            t6_s_name.BackColor = Color.White;
        }

        private void t9_year_TextChanged(object sender, EventArgs e)
        {
            t9_year.BackColor = Color.White;
        }



        private void t7_struck_absent_TextChanged(object sender, EventArgs e)
        {
            t7_struck_absent.BackColor = Color.White;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            t7_1_from.BackColor = Color.White;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t7_1_to_TextChanged(object sender, EventArgs e)
        {
            t7_1_to.BackColor = Color.White;
        }

        private void t7_1_fine_TextChanged(object sender, EventArgs e)
        {
            t7_1_fine.BackColor = Color.White;
        }

        private void t7_2_from_TextChanged(object sender, EventArgs e)
        {
            t7_2_from.BackColor = Color.White;
        }

        private void t7_2_to_TextChanged(object sender, EventArgs e)
        {
            t7_2_to.BackColor = Color.White;
        }

        private void t7_2_fine_TextChanged(object sender, EventArgs e)
        {
            t7_2_fine.BackColor = Color.White;
        }

        private void t7_3_from_TextChanged(object sender, EventArgs e)
        {
            t7_3_from.BackColor = Color.White;
        }

        private void t7_3_to_TextChanged(object sender, EventArgs e)
        {
            t7_3_to.BackColor = Color.White;
        }

        private void t7_3_fine_TextChanged(object sender, EventArgs e)
        {
            t7_3_fine.BackColor = Color.White;
        }

        private void t7_4_from_TextChanged(object sender, EventArgs e)
        {
            t7_4_from.BackColor = Color.White;
        }

        private void t7_4_to_TextChanged(object sender, EventArgs e)
        {
            t7_4_to.BackColor = Color.White;
        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {

        }

        private void t7_4_fine_TextChanged(object sender, EventArgs e)
        {
            t7_4_fine.BackColor = Color.White;
        }

        private void general_setting_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        bool exit = true;
        private void general_setting_FormClosed(object sender, FormClosingEventArgs e)
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

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from subjecttbl where subject_name like '%" + textBox1.Text.ToString() + "%'", state.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            // dataGridViewManualReport.DataSource = null;
            dataGridViewsubject.Rows.Clear();
            //dataGridViewsubject.Refresh();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridViewsubject.Rows.Add();
                dataGridViewsubject.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridViewsubject.Rows[n].Cells[1].Value = dr[1].ToString();
            }
            state.con.Close();
        }
    }
}