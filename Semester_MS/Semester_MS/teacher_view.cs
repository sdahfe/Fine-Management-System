using System;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Threading;

namespace Semester_MS
{
    public partial class teacher_view : Form
    {

        public teacher_view()
        {
            InitializeComponent();
            load_class();
            load_section();
            load_course();
            load_year();
        }

        public void load_year()
        {
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select year from yeartbl", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t1_year.Items.Clear();
                t2_year.Items.Clear();
                t3_year.Items.Clear();
                t4_year.Items.Clear();
                t5_year.Items.Clear();
                t6_year.Items.Clear();
                t7_year.Items.Clear();
                t8_year.Items.Clear();
                t9_year.Items.Clear();
                t3_year.Items.Add("........Year......");
                t4_year.Items.Add("........Year......");
                t5_year.Items.Add("........Year......");
                t1_year.Items.Add("........Year......");
                t2_year.Items.Add("........Year......");
                t6_year.Items.Add("........Year......");
                t7_year.Items.Add("........Year......");
                t8_year.Items.Add("........Year......");
                t9_year.Items.Add("........Year......");
                t1_year.SelectedIndex = 0;
                t2_year.SelectedIndex = 0;
                t3_year.SelectedIndex = 0;
                t4_year.SelectedIndex = 0;
                t5_year.SelectedIndex = 0;
                t6_year.SelectedIndex = 0;
                t7_year.SelectedIndex = 0;
                t8_year.SelectedIndex = 0;
                t9_year.SelectedIndex = 0;
                while (dr.Read())
                {
                    t1_year.Items.Add(dr[0].ToString());
                    t2_year.Items.Add(dr[0].ToString());
                    t3_year.Items.Add(dr[0].ToString());
                    t4_year.Items.Add(dr[0].ToString());
                    t5_year.Items.Add(dr[0].ToString());
                    t6_year.Items.Add(dr[0].ToString());
                    t7_year.Items.Add(dr[0].ToString());
                    t8_year.Items.Add(dr[0].ToString());
                    t9_year.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }
        public void load_section()
        {
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select distinct sectiontbl.section_name from sectiontbl , subjectAssignedtbl where subjectAssignedtbl.teacher_id='" + state.Teacher_login_id.ToString() + "' and subjectAssignedtbl.section_id=sectiontbl.section_id", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t3_select_section.Items.Clear();
                t4_select_section.Items.Clear();
                t5_select_section.Items.Clear();
                t6_section.Items.Clear();
                t7_section.Items.Clear();
                t8_section.Items.Clear();
                t9_section.Items.Clear();
                t3_select_section.Items.Add("........Select......");
                t4_select_section.Items.Add("........Select......");
                t5_select_section.Items.Add("........Select......");
                t6_section.Items.Add("........Select......");
                t7_section.Items.Add("........Select......");
                t8_section.Items.Add("........Select......");
                t9_section.Items.Add("........Select......");
                while (dr.Read())
                {

                    t3_select_section.Items.Add(dr[0].ToString());
                    t4_select_section.Items.Add(dr[0].ToString());
                    t5_select_section.Items.Add(dr[0].ToString());
                    t6_section.Items.Add(dr[0].ToString());
                    t7_section.Items.Add(dr[0].ToString());
                    t8_section.Items.Add(dr[0].ToString());
                    t9_section.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }

        public void load1_subject()
        {
            int c = class_id(t1_class.SelectedItem.ToString());
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select distinct subject_id from subjectAssignedtbl where teacher_id='" + state.Teacher_login_id + "' and class_id='" + c + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t1_select_subject.Items.Clear();
                t1_select_subject.Items.Add("........Select......");
                t1_select_subject.SelectedIndex = 0;
                while (dr.Read())
                {
                    t1_select_subject.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }
        public void load2_subject()
        {
            int c = class_id(t2_class.SelectedItem.ToString());
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select distinct subject_id from subjectAssignedtbl where teacher_id='" + state.Teacher_login_id + "' and class_id='" + c + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t2_select_subject.Items.Clear();
                t2_select_subject.Items.Add("........Select......");
                t2_select_subject.SelectedIndex = 0;
                while (dr.Read())
                {
                    t2_select_subject.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }
        public void load3_subject()
        {
            int c = class_id(t3_class.SelectedItem.ToString());
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select distinct subject_id from subjectAssignedtbl where teacher_id='" + state.Teacher_login_id + "' and class_id='" + c + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t3_select_subject.Items.Clear();
                t3_select_subject.Items.Add("........Select......");
                t3_select_subject.SelectedIndex = 0;
                while (dr.Read())
                {
                    t3_select_subject.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }
        public void load6_subject()
        {
            int c = class_id(t6_class.SelectedItem.ToString());
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select distinct subject_id from subjectAssignedtbl where teacher_id='" + state.Teacher_login_id + "' and class_id='" + c + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t6_subject.Items.Clear();
                t6_subject.Items.Add("........Select......");
                t6_subject.SelectedIndex = 0;
                while (dr.Read())
                {
                    t6_subject.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }
        public void load7_subject()
        {
            int c = class_id(t7_class.SelectedItem.ToString());
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select distinct subject_id from subjectAssignedtbl where teacher_id='" + state.Teacher_login_id + "' and class_id='" + c + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t7_subject.Items.Clear();
                t7_subject.Items.Add("........Select......");
                t7_subject.SelectedIndex = 0;
                while (dr.Read())
                {
                    t7_subject.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }
        public void load4_subject()
        {
            int c = class_id(t4_class.SelectedItem.ToString());
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select distinct subject_id from subjectAssignedtbl where teacher_id='" + state.Teacher_login_id + "' and class_id='" + c + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t4_select_subject.Items.Clear();
                t4_select_subject.Items.Add("........Select......");
                t4_select_subject.SelectedIndex = 0;
                while (dr.Read())
                {
                    t4_select_subject.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }
        public void load5_subject()
        {
            int c = class_id(t5_class.SelectedItem.ToString());
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select distinct subject_id from subjectAssignedtbl where teacher_id='" + state.Teacher_login_id + "' and class_id='" + c + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t5_select_subject.Items.Clear();
                t5_select_subject.Items.Add("........Select......");
                t5_select_subject.SelectedIndex = 0;
                while (dr.Read())
                {
                    t5_select_subject.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }
        public void load8_subject()
        {
            int c = class_id(t8_class.SelectedItem.ToString());
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select distinct subject_id from subjectAssignedtbl where teacher_id='" + state.Teacher_login_id + "' and class_id='" + c + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t8_subject.Items.Clear();
                t8_subject.Items.Add("........Select......");
                t8_subject.SelectedIndex = 0;
                while (dr.Read())
                {
                    t8_subject.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }

        public void load9_subject()
        {
            int c = class_id(t9_class.SelectedItem.ToString());
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select distinct subject_id from subjectAssignedtbl where teacher_id='" + state.Teacher_login_id + "' and class_id='" + c + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t9_subject.Items.Clear();
                t9_subject.Items.Add("........Select......");
                t9_subject.SelectedIndex = 0;
                while (dr.Read())
                {
                    t9_subject.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }
        public void load_class()
        {
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select distinct classtbl.class_name from classtbl, subjectAssignedtbl where subjectAssignedtbl.teacher_id='" + state.Teacher_login_id + "' and subjectAssignedtbl.class_id=classtbl.class_id ;", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t1_class.Items.Clear();
                t2_class.Items.Clear();
                t3_class.Items.Clear();
                t4_class.Items.Clear();
                t5_class.Items.Clear();
                t6_class.Items.Clear();
                t7_class.Items.Clear();
                t8_class.Items.Clear();
                t9_class.Items.Clear();
                t1_class.Items.Add("........Select......");
                t2_class.Items.Add("........Select......");
                t3_class.Items.Add("........Select......");
                t4_class.Items.Add("........Select......");
                t5_class.Items.Add("........Select......");
                t6_class.Items.Add("........Select......");
                t7_class.Items.Add("........Select......");
                t8_class.Items.Add("........Select......");
                t9_class.Items.Add("........Select......");
                t6_class.SelectedIndex = 0;
                t1_class.SelectedIndex = 0;
                t2_class.SelectedIndex = 0;
                t3_class.SelectedIndex = 0;
                t4_class.SelectedIndex = 0;
                t5_class.SelectedIndex = 0;
                t7_class.SelectedIndex = 0;
                t8_class.SelectedIndex = 0;
                t9_class.SelectedIndex = 0;

                while (dr.Read())
                {

                    t1_class.Items.Add(dr[0].ToString());
                    t2_class.Items.Add(dr[0].ToString());
                    t3_class.Items.Add(dr[0].ToString());
                    t4_class.Items.Add(dr[0].ToString());
                    t5_class.Items.Add(dr[0].ToString());
                    t6_class.Items.Add(dr[0].ToString());
                    t7_class.Items.Add(dr[0].ToString());
                    t8_class.Items.Add(dr[0].ToString());
                    t9_class.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }
        public void load_course()
        {
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select course_name from  coursestbl where course_id in (select subjecttbl.course_id from subjecttbl, subjectAssignedtbl where subjectAssignedtbl.teacher_id='" + state.Teacher_login_id + "' and subjectAssignedtbl.subject_id = subjecttbl.subject_id); ", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t3_select_course.Items.Clear();
                t4_select_course.Items.Clear();
                t5_select_course.Items.Clear();
                t3_select_course.Items.Add("........Select......");
                t4_select_course.Items.Add("........Select......");
                t5_select_course.Items.Add("........Select......");
                t3_select_course.SelectedIndex = 0;
                t4_select_course.SelectedIndex = 0;
                t5_select_course.SelectedIndex = 0;
                while (dr.Read())
                {
                    t3_select_course.Items.Add(dr[0].ToString());
                    t4_select_course.Items.Add(dr[0].ToString());
                    t5_select_course.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }
        public int class_id(string c_n)
        {
            int id = 0;

            if(state.con.State == ConnectionState.Closed)
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
        public string course_nametbl(int c_id)
        {
            string name = "";
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select course_name from coursestbl where course_id='" + c_id + "';", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                name = dr[0].ToString();
            }
            state.con.Close();
            return name;
        }
        public void load(int c_id, int s_id)
        {
            int clas = class_id(t3_class.SelectedItem.ToString());
            string t_l_d;
            string c_name = course_nametbl(c_id);
            state.con.Open();
            SqlCommand cmd1 = new SqlCommand("select * from lectureDeliveredtbl where teacher_id='" + state.Teacher_login_id + "' and month='" + t3_month.SelectedIndex + "' and year='" + t3_year.SelectedItem.ToString() + "' and subject_id='" + t3_select_subject.SelectedItem.ToString() + "' and class_id='" + clas + "'", state.con);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                t_l_d = dr[2].ToString();
                dr.Close();
                DataTable dt = new DataTable();
                if (c_name != "Compulsory")
                {
                    SqlDataAdapter sda = new SqlDataAdapter("select roll_no,student_name from studenttbl where course_id='" + c_id + "' and section_id='" + s_id + "' and class_id='" + clas + "'", state.con);
                    sda.Fill(dt);
                }
                else
                {
                    SqlDataAdapter sda = new SqlDataAdapter("select roll_no,student_name from studenttbl where section_id='" + s_id + "' and class_id='" + clas + "'", state.con);
                    sda.Fill(dt);
                }
                dataGridView1.Rows.Clear();
                foreach (DataRow dr1 in dt.Rows)
                {
                    // MessageBox.Show(state.section.ToString());
                    //  MessageBox.Show(dr[2].ToString() + "k");
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr1[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr1[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = t_l_d;
                    dataGridView1.Rows[n].Cells[3].Value = 0;
                    dataGridView1.Rows[n].Cells[4].Value = 0;
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
                MessageBox.Show("Please Go And Set Lecture Delivered in " + t3_month.SelectedItem, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            state.con.Close();

        }
        public int lec_delivered()
        {
            int clas = class_id(t6_class.SelectedItem.ToString());
            int t_l_d = 0;
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select lect from lectureDeliveredtbl where teacher_id='" + state.Teacher_login_id + "' and month='" + t6_month.SelectedIndex + "' and year='" + t6_year.SelectedItem.ToString() + "' and subject_id='" + t6_subject.SelectedItem.ToString() + "' and class_id='" + clas + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                t_l_d = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            state.con.Close();
            return t_l_d;
        }
        public int t7_lec_delivered()
        {
            int clas = class_id(t7_class.SelectedItem.ToString());
            int t_l_d = 0;
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select lect from lectureDeliveredtbl where teacher_id='" + state.Teacher_login_id + "' and month='" + t7_month.SelectedIndex + "' and year='" + t7_year.SelectedItem.ToString() + "' and subject_id='" + t7_subject.SelectedItem.ToString() + "' and class_id='" + clas + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                t_l_d = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            state.con.Close();
            return t_l_d;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var t_p = new teacher_Login();
            t_p.Show();
            this.Hide();
        }

        private void teacher_view_Load(object sender, EventArgs e)
        {
            if (state.con.State == ConnectionState.Closed)
                state.con.Open();

            string tName="";
            SqlCommand cmd = new SqlCommand("select t_name from teachertbl where teacher_id=" + state.Teacher_login_id, state.con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                tName = dr[0].ToString();
            }

            dr.Close();
            state.con.Close();

            teacher_id_show.Text = tName;
            //teacher_id_show.Text = state.Teacher_login_id.ToString();

            if (t1_class.Items.Count > 1)
            {
                t3_class.SelectedIndex = 1;
                t1_class.SelectedIndex = 1;
                t2_class.SelectedIndex = 1;
                t4_class.SelectedIndex = 1;
                t5_class.SelectedIndex = 1;
                t6_class.SelectedIndex = 1;
                t7_class.SelectedIndex = 1;
                t8_class.SelectedIndex = 1;
                t9_class.SelectedIndex = 1;
            }

            if (t3_select_section.Items.Count > 1)
            {
                t3_select_section.SelectedIndex = 1;
                t4_select_section.SelectedIndex = 1;
                t5_select_section.SelectedIndex = 1;
                t6_section.SelectedIndex = 1;
                t7_section.SelectedIndex = 1;
                t8_section.SelectedIndex = 1;
                t9_section.SelectedIndex = 1;
            }

            if (t3_select_course.Items.Count > 1)
            {
                t3_select_course.SelectedIndex = 1;
                t4_select_course.SelectedIndex = 1;
                t5_select_course.SelectedIndex = 1;
            }

            if (t3_select_subject.Items.Count > 1)
            {
                t1_select_subject.SelectedIndex = 1;
                t2_select_subject.SelectedIndex = 1;
                t3_select_subject.SelectedIndex = 1;
                t4_select_subject.SelectedIndex = 1;
                t5_select_subject.SelectedIndex = 1;
                t6_subject.SelectedIndex = 1;
                t7_subject.SelectedIndex = 1;
                t8_subject.SelectedIndex = 1;
                t9_subject.SelectedIndex = 1;
            }

            if (t1_month.Items.Count > 1)
            {
                t1_month.SelectedIndex = 1;
                t2_month.SelectedIndex = 1;
                t3_month.SelectedIndex = 1;
                t4_month.SelectedIndex = 1;
                t5_month.SelectedIndex = 1;
                t6_month.SelectedIndex = 1;
                t7_month.SelectedIndex = 1;
                t8_month.SelectedIndex = 1;
                t9_month.SelectedIndex = 1;
            }

            if (t1_year.Items.Count > 1)
            {
                t1_year.SelectedIndex = 1;
                t2_year.SelectedIndex = 1;
                t3_year.SelectedIndex = 1;
                t4_year.SelectedIndex = 1;
                t5_year.SelectedIndex = 1;
                t6_year.SelectedIndex = 1;
                t7_year.SelectedIndex = 1;
                t8_year.SelectedIndex = 1;
                t9_year.SelectedIndex = 1;
            }

            if (t5_orderby.Items.Count > 1)
            {
                t5_orderby.SelectedIndex = 1;
                t8_order.SelectedIndex = 1;
                t9_order.SelectedIndex = 1;
            }

            if (t5_cat.Items.Count > 1)
            {
                t5_cat.SelectedIndex = 1;
                t7_cat.SelectedIndex = 1;
                t8_cat.SelectedIndex = 1;
                t9_cat.SelectedIndex = 1;
            }

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGirdViewUpdate.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGirdViewUpdate.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGirdViewUpdate.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGirdViewUpdate.EnableHeadersVisualStyles = false;

            dataGridViewLoad.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridViewLoad.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewLoad.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGridViewLoad.EnableHeadersVisualStyles = false;

            dataGridViewManual1.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridViewManual1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewManual1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGridViewManual1.EnableHeadersVisualStyles = false;

            dataGridViewManual1Update.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridViewManual1Update.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewManual1Update.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGridViewManual1Update.EnableHeadersVisualStyles = false;

            dataGridViewManualReport.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridViewManualReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewManualReport.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGridViewManualReport.EnableHeadersVisualStyles = false;

            dgv_delete.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dgv_delete.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_delete.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Bold);
            dgv_delete.EnableHeadersVisualStyles = false;
        }

        private void changeUserNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            teacher_un_change un = new teacher_un_change();
            un.Show();
            this.Hide();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pas = new teacher_p_change();
            this.Hide();
            pas.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void select_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            t3_select_section.BackColor = Color.White;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public int courseID(string c_name)
        {
            int c_id = 0;
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select coursestbl.course_id from coursestbl where course_name='" + c_name + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                c_id = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            state.con.Close();
            return c_id;
        }
        public int sectionID(string s_name)
        {
            int s_id = 0;
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select sectiontbl.section_id from sectiontbl where section_name = '" + s_name + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                s_id = Convert.ToInt32(dr[0].ToString());
                // MessageBox.Show(dr[0].ToString());
            }
            dr.Close();
            state.con.Close();
            return s_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (t3_class.SelectedIndex == 0)
            {
                t3_class.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Class.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t3_select_course.SelectedIndex == 0)
            {
                t3_select_course.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Course.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t3_select_section.SelectedIndex == 0)
            {
                t3_select_section.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Section.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t3_select_subject.SelectedIndex == 0)
            {
                t3_select_subject.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Subject.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t3_month.SelectedIndex == 0)
            {
                t3_month.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Month.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t3_year.SelectedIndex == 0)
            {
                t3_year.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Year.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t3_class.SelectedIndex != 0 && t3_select_course.SelectedIndex != 0 && t3_select_section.SelectedIndex != 0 && t3_select_subject.SelectedIndex != 0 && t3_month.SelectedIndex != 0 && t3_year.SelectedIndex != 0)
            {
                int c_id = 0, s_id = 0;
                c_id = courseID(t3_select_course.SelectedItem.ToString());
                s_id = sectionID(t3_select_section.SelectedItem.ToString());
                state.con.Open();
              //  MessageBox.Show(c_id.ToString());
              //  MessageBox.Show(t3_select_subject.SelectedItem.ToString());
                SqlCommand cmd = new SqlCommand("select * from subjecttbl where course_id='" + c_id + "' and subject_id='" + t3_select_subject.SelectedItem.ToString() + "'", state.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                  //  MessageBox.Show("in");
                    dr.Close();
                    state.con.Close();
                    load(c_id, s_id);
                }
                else
                {

                    dr.Close();
                    /*
                       //  SqlCommand cmd1=new SqlCommand( "select course_name from  coursestbl where course_id in (select subjecttbl.course_id from subjecttbl, subjectAssignedtbl where subjectAssignedtbl.teacher_id='" + state.Teacher_login_id + "' and subjectAssignedtbl.subject_id='" + t3_select_subject.SelectedItem.ToString() + "' and subjectAssignedtbl.subject_id = subjecttbl.subject_id);",state.con);

                       dr = cmd.ExecuteReader();
                       if (dr.HasRows)
                       {
                           dr.Read();
                           if (dr[0].ToString() == "Compulsory")
                           {
                               dr.Close();
                               state.con.Close();
                               load(c_id, s_id);
                           }
                           else
                           {
                               dr.Close();
                               dataGridView1.Rows.Clear();*/
                    if (t3_select_course.SelectedItem.ToString() == "Compulsory")
                        MessageBox.Show(t3_select_subject.SelectedItem + "is not a " + t3_select_course.SelectedItem + " Subject." + Environment.NewLine + "Kindly select appropiate Course and Subject.");
                    else
                        MessageBox.Show(t3_select_course.SelectedItem + " doesn't offer " + t3_select_subject.SelectedItem + " Course." + Environment.NewLine + "Kindly select appropiate Course and Subject.");
                    dataGridView1.Rows.Clear();


                }
                dr.Close();
                state.con.Close();
            }
        }

        private void select_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            t3_select_subject.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (t1_class.SelectedIndex == 0)
            {
                t1_class.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Class.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t1_select_subject.SelectedIndex == 0)
            {
                t1_select_subject.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Subject.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t1_month.SelectedIndex == 0)
            {
                t1_month.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Month.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t1_year.SelectedIndex == 0)
            {
                t1_year.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Year.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t1_lect.Text == "")
            {
                t1_lect.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Enter Lectures Delivered.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                t1_lect.Focus();
                return;
            }
            if (t1_month.SelectedIndex == 1 || t1_month.SelectedIndex == 5 || t1_month.SelectedIndex == 7 || t1_month.SelectedIndex == 8 || t1_month.SelectedIndex == 10)
            {
                if (Convert.ToInt32(t1_lect.Text) > 27)
                {
                    MessageBox.Show(t1_lect.Text + " Lectures can't be delivered in " + t1_month.SelectedItem, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    t1_lect.ResetText();
                    return;
                }
            }
            if (t1_month.SelectedIndex == 2)
            {
                if (Convert.ToInt32(t1_lect.Text) > 24)
                {
                    MessageBox.Show(t1_lect.Text + " Lectures can't be delivered in " + t1_month.SelectedItem, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    t1_lect.ResetText();
                    return;
                }
            }
            if (t1_month.SelectedIndex == 3 || t1_month.SelectedIndex == 4 || t1_month.SelectedIndex == 11 || t1_month.SelectedIndex == 12)
            {
                if (Convert.ToInt32(t1_lect.Text) > 26)
                {
                    MessageBox.Show(t1_lect.Text + " Lectures can't be delivered in " + t1_month.SelectedItem, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    t1_lect.ResetText();
                    return;
                }
            }
            if (t1_month.SelectedIndex == 6 || t1_month.SelectedIndex == 9)
            {
                if (Convert.ToInt32(t1_lect.Text) > 25)
                {
                    MessageBox.Show(t1_lect.Text + " Lectures can't be delivered in " + t1_month.SelectedItem, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    t1_lect.ResetText();
                    return;
                }
            }
            if (t1_class.SelectedIndex != 0 && t1_select_subject.SelectedIndex != 0 && t1_month.SelectedIndex != 0 && t1_year.SelectedIndex != 0 && t1_lect.Text != "")
            {
                int c = class_id(t1_class.SelectedItem.ToString());
                state.con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from lectureDeliveredtbl where teacher_id='" + state.Teacher_login_id + "' and month='" + t1_month.SelectedIndex + "' and year='" + t1_year.SelectedItem.ToString() + "' and class_id='" + c + "' and subject_id='" + t1_select_subject.SelectedItem.ToString() + "'", state.con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("You Have Alread  Added Lect For this Months!" + Environment.NewLine + "You can go for update.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dr.Close();
                    //  SqlCommand cmd = new SqlCommand("insert into lectureDeliveredtbl set lect='" + Convert.ToInt32(t1_lect.Text) +"', date='"+t1_month.SelectedIndex+ "' where teacher_id='" + state.Teacher_login_id + "'", state.con);
                    SqlCommand cmd = state.con.CreateCommand();
                    cmd.CommandText = "insert into lectureDeliveredtbl values(@teacher_id,@lect,@month,@year,@class_id,@subject_id);";
                    cmd.Parameters.AddWithValue("@teacher_id", state.Teacher_login_id);
                    cmd.Parameters.AddWithValue("@lect", Convert.ToInt32(t1_lect.Text));
                    cmd.Parameters.AddWithValue("@month", t1_month.SelectedIndex);
                    cmd.Parameters.AddWithValue("@year", t1_year.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@class_id", c);
                    cmd.Parameters.AddWithValue("@subject_id", t1_select_subject.SelectedItem);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lect Delivery Coloumn Added Successfully!", "Record Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                state.con.Close();
                t1_lect.ResetText();
                t1_month.SelectedIndex = 1;
                t1_select_subject.SelectedIndex = 1;
                t1_class.SelectedIndex = 1;
                t1_year.SelectedIndex = 1;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void t1_lect_TextChanged(object sender, EventArgs e)
        {
            t1_lect.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int struckOff, fine1, fine2, fine3, fine4;
            int from1, from2, from3, from4;
            int to1, to2, to3, to4;
            generateFine(out struckOff, out fine1, out fine2, out fine3, out fine4, out from1, out from2, out from3, out from4, out to1, out to2, out to3, out to4);
            state.con.Open();
            SqlCommand cmd1 = new SqlCommand("select * from finetbl where teacher_id='" + state.Teacher_login_id + "' and month='" + t3_month.SelectedIndex + "' and year='" + t3_year.SelectedItem.ToString() + "' and subject_id='" + t3_select_subject.SelectedItem.ToString() + "' and section_name='" + t3_select_section.SelectedItem.ToString() + "' and course_name='" + t3_select_course.SelectedItem.ToString() + "' and class_name='" + t3_class.SelectedItem.ToString() + "'", state.con);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Close();
                dataGridView1.Rows.Clear();
                MessageBox.Show("You Have Alread Inserted Attendence For this Months!" + Environment.NewLine + "You can go for update Attendence.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dr.Close();
                for (int a = 0; a < dataGridView1.Rows.Count; a++)
                {
                    int P = 0, A = 0, L = 0, T = 0;
                    A = Convert.ToInt32(dataGridView1.Rows[a].Cells[3].Value);
                    L = Convert.ToInt32(dataGridView1.Rows[a].Cells[4].Value);
                    T = Convert.ToInt32(dataGridView1.Rows[a].Cells[2].Value);
                    P = T - (A + L);
                    SqlCommand cmd = state.con.CreateCommand();
                    cmd.CommandText = "insert into finetbl values(@s_id,@s_name,@t_id,@subject_id,@section_name,@month,@year,@lec_delivered,@presents,@absenties,@leaves,@status,@fine,@course_name,@class_name);";
                    cmd.Parameters.AddWithValue("@s_id", Convert.ToInt32(dataGridView1.Rows[a].Cells[0].Value));
                    cmd.Parameters.AddWithValue("@s_name", dataGridView1.Rows[a].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@t_id", state.Teacher_login_id);
                    cmd.Parameters.AddWithValue("@subject_id", t3_select_subject.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@section_name", t3_select_section.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@month", t3_month.SelectedIndex);
                    cmd.Parameters.AddWithValue("@year", t3_year.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@lec_delivered", T);
                    cmd.Parameters.AddWithValue("@presents", P);
                    cmd.Parameters.AddWithValue("@absenties", A);
                    cmd.Parameters.AddWithValue("@leaves", L);
                    if (A >= struckOff)
                    {
                        cmd.Parameters.AddWithValue("@status", "Struck Off");
                        cmd.Parameters.AddWithValue("@fine", 0);
                    }
                    else
                    {
                            if (A >= from1 && A <= to1)
                              {
                                cmd.Parameters.AddWithValue("@status", "Fined");
                                cmd.Parameters.AddWithValue("@fine", fine1);
                               }
                            else if (A >= from2 && A <= to2)
                            {
                                cmd.Parameters.AddWithValue("@status", "Fined");
                                cmd.Parameters.AddWithValue("@fine", fine2);
                            }
                            else if (A >= from3 && A <= to3)
                            {
                                cmd.Parameters.AddWithValue("@status", "Fined");
                                cmd.Parameters.AddWithValue("@fine", fine3);
                            }
                            else if (A >= from4 && A <= to4)
                            {
                                cmd.Parameters.AddWithValue("@status", "Fined");
                                cmd.Parameters.AddWithValue("@fine", fine4);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@status", "Nil");
                                cmd.Parameters.AddWithValue("@fine", 0);
                            }                        
                    }
                    cmd.Parameters.AddWithValue("@course_name", t3_select_course.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@class_name", t3_class.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();

                }
                dataGridView1.Rows.Clear();
                MessageBox.Show("Attendence Inserted Successfully!", "Attendence Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
             state.con.Close();
        } 
         

        private void t1_select_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            t1_select_subject.BackColor = Color.White;
        }

        private void t1_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            t1_month.BackColor = Color.White;
        }

        private void t2_select_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            t2_select_subject.BackColor = Color.White;
        }

        private void t2_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            t2_month.BackColor = Color.White;
        }

        private void t2_lect_TextChanged(object sender, EventArgs e)
        {
            t2_lect.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (t2_class.SelectedIndex == 0)
            {
                t2_class.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Class.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t2_select_subject.SelectedIndex == 0)
            {
                t2_select_subject.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Subject.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t2_month.SelectedIndex == 0)
            {
                t2_month.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Month.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t2_year.SelectedIndex == 0)
            {
                t2_year.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Year.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t2_class.SelectedIndex != 0 && t2_select_subject.SelectedIndex != 0 && t2_month.SelectedIndex != 0 && t2_year.SelectedIndex != 0)
            {
                int c = class_id(t2_class.SelectedItem.ToString());
                state.con.Open();
                SqlCommand cmd = new SqlCommand("select * from lectureDeliveredtbl where teacher_id ='" + state.Teacher_login_id + "' and month ='" + t2_month.SelectedIndex + "' and year='" + t2_year.SelectedItem.ToString() + "' and class_id='" + c + "' and subject_id='" + t2_select_subject.SelectedItem.ToString() + "'", state.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    t2_lect.Text = dr[2].ToString();
                }
                state.con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (t2_lect.Text == "")
            {
                t2_lect.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Enter Lectures Delivered.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                t2_lect.Focus();
                return;
            }
            if (t2_month.SelectedIndex == 1 || t2_month.SelectedIndex == 5 || t2_month.SelectedIndex == 7 || t2_month.SelectedIndex == 8 || t2_month.SelectedIndex == 10)
            {
                if (Convert.ToInt32(t2_lect.Text) > 27)
                {
                    MessageBox.Show(t2_lect.Text + " Lectures can't be delivered in " + t2_month.SelectedItem, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    t2_lect.ResetText();
                    return;
                }
            }
            if (t2_month.SelectedIndex == 2)
            {
                if (Convert.ToInt32(t2_lect.Text) > 24)
                {
                    MessageBox.Show(t2_lect.Text + " Lectures can't be delivered in " + t2_month.SelectedItem, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    t2_lect.ResetText();
                    return;
                }
            }
            if (t2_month.SelectedIndex == 3 || t2_month.SelectedIndex == 4 || t2_month.SelectedIndex == 11 || t2_month.SelectedIndex == 12)
            {
                if (Convert.ToInt32(t2_lect.Text) > 26)
                {
                    MessageBox.Show(t2_lect.Text + " Lectures can't be delivered in " + t2_month.SelectedItem, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    t2_lect.ResetText();
                    return;
                }
            }
            if (t2_month.SelectedIndex == 6 || t2_month.SelectedIndex == 9)
            {
                if (Convert.ToInt32(t2_lect.Text) > 25)
                {
                    MessageBox.Show(t2_lect.Text + " Lectures can't be delivered in " + t2_month.SelectedItem, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    t2_lect.ResetText();
                    return;
                }
            }
            if (t2_lect.Text != "")
            {
                int c = class_id(t2_class.SelectedItem.ToString());
                state.con.Open();
                SqlCommand cmd = new SqlCommand("update lectureDeliveredtbl set lect='" + Convert.ToInt32(t2_lect.Text) + "' where teacher_id='" + state.Teacher_login_id + "' and month='" + t2_month.SelectedIndex + "' and year='" + t2_year.SelectedItem.ToString() + "' and class_id='" + c + "' and subject_id='" + t2_select_subject.SelectedItem.ToString() + "'", state.con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Lect Delivery Coloumn updated Successfully!", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                state.con.Close();
                t2_lect.ResetText();
                t2_class.SelectedIndex = 0;
                t2_month.SelectedIndex = 0;
                t2_select_subject.SelectedIndex = 0;
                t2_year.SelectedIndex = 0;
            }
        }

        private void t3_select_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            t3_select_subject.BackColor = Color.White;
        }

        private void t3_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            t3_month.BackColor = Color.White;
        }

        private void t3_select_course_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            t3_select_course.BackColor = Color.White;
        }

        private void t4_select_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            t4_select_course.BackColor = Color.White;
        }

        private void t4_select_section_SelectedIndexChanged(object sender, EventArgs e)
        {

            t4_select_section.BackColor = Color.White;
        }

        private void t4_select_subject_SelectedIndexChanged(object sender, EventArgs e)
        {

            t4_select_subject.BackColor = Color.White;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void t4_month_SelectedIndexChanged(object sender, EventArgs e)
        {

            t4_month.BackColor = Color.White;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (t4_class.SelectedIndex == 0)
            {
                t4_class.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Class.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t4_select_section.SelectedIndex == 0)
            {
                t4_select_section.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Section.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t4_month.SelectedIndex == 0)
            {
                t4_month.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Month.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t4_year.SelectedIndex == 0)
            {
                t4_year.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Year.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t4_select_course.SelectedIndex == 0)
            {
                t4_select_course.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Course.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t4_select_subject.SelectedIndex == 0)
            {
                t4_select_subject.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Subject.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t4_class.SelectedIndex != 0 && t4_select_course.SelectedIndex != 0 && t4_select_section.SelectedIndex != 0 && t4_select_subject.SelectedIndex != 0 && t4_month.SelectedIndex != 0 && t4_year.SelectedIndex != 0)
            {
                int c_id = 0, s_id = 0;
                c_id = courseID(t4_select_course.SelectedItem.ToString());
                s_id = sectionID(t4_select_section.SelectedItem.ToString());
                state.con.Open();
                //  MessageBox.Show(c_id.ToString());
                //MessageBox.Show(t3_select_subject.SelectedItem.ToString());
                SqlCommand cmd = new SqlCommand("select * from subjecttbl where course_id='" + c_id + "' and subject_id='" + t4_select_subject.SelectedItem.ToString() + "'", state.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    //  MessageBox.Show("in");
                    dr.Close();
                    state.con.Close();
                    t3_load();
                }
                else
                {
                    dr.Close();
                    if (t4_select_course.SelectedItem.ToString() == "Compulsory")
                        MessageBox.Show(t4_select_subject.SelectedItem + "is not a " + t4_select_course.SelectedItem + " Subject." + Environment.NewLine + "Kindly select appropiate Course and Subject.");
                    else
                        MessageBox.Show(t4_select_course.SelectedItem + " doesn't offer " + t4_select_subject.SelectedItem + " Course." + Environment.NewLine + "Kindly select appropiate Course and Subject.");
                    dataGirdViewUpdate.Rows.Clear();
                }
                dr.Close();
                state.con.Close();
            }
        }
        public void t3_load()
        {
            state.con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("select * from finetbl where teacher_id='" + state.Teacher_login_id + "' and month='" + t4_month.SelectedIndex + "' and year='" + t4_year.SelectedItem.ToString() + "' and subject_id='" + t4_select_subject.SelectedItem.ToString() + "' and section_name='" + t4_select_section.SelectedItem.ToString() + "' and course_name='" + t4_select_course.SelectedItem.ToString() + "' and class_name='" + t4_class.SelectedItem.ToString() + "'", state.con);
            sda.Fill(dt);
            dataGirdViewUpdate.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGirdViewUpdate.Rows.Add();
                dataGirdViewUpdate.Rows[n].Cells[0].Value = dr[1].ToString();
                dataGirdViewUpdate.Rows[n].Cells[1].Value = dr[2].ToString();
                dataGirdViewUpdate.Rows[n].Cells[2].Value = dr[8].ToString();
                dataGirdViewUpdate.Rows[n].Cells[3].Value = dr[10].ToString();
                dataGirdViewUpdate.Rows[n].Cells[4].Value = dr[11].ToString();
            }
            if (dt.Rows.Count < 0)
            {
                dataGirdViewUpdate.Rows.Clear();
                MessageBox.Show("No Record Found For this Month", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            state.con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int struckOff, fine1, fine2, fine3, fine4;
            int from1, from2, from3, from4;
            int to1, to2, to3, to4;
            generateFine(out struckOff, out fine1, out fine2, out fine3, out fine4, out from1, out from2, out from3, out from4, out to1, out to2, out to3, out to4);
            state.con.Open();
            if (dataGirdViewUpdate.Rows.Count > 0)
            {
                for (int a = 0; a < dataGirdViewUpdate.Rows.Count; a++)
                {
                    int P = 0, A = 0, L = 0, T = 0, F = 0;
                    string st = "Nil";
                    A = Convert.ToInt32(dataGirdViewUpdate.Rows[a].Cells[3].Value);
                    L = Convert.ToInt32(dataGirdViewUpdate.Rows[a].Cells[4].Value);
                    T = Convert.ToInt32(dataGirdViewUpdate.Rows[a].Cells[2].Value);
                    P = T - (A + L);
                    if (A >= struckOff)
                    {
                        F = 0;
                        st = "Struck Off";
                    }
                    else
                    {
                            if (A >= from1 && A <= to1)
                            {
                                F = fine1;
                                st = "Fined";
                            }
                            else if (A >= from2 && A <= to2)
                            {
                                F = fine2;
                                st = "Fined";
                            }
                            else if (A >= from3 && A <= to3)
                            {
                                F = fine3;
                                st = "Fined";
                            }
                            else if (A >= from4 && A <= to4)
                            {
                                F = fine4;
                                st = "Fined";
                            }
                            else
                            {
                                F = 0;
                                st = "Nil";
                            }
                    }
                   SqlCommand cmd = new SqlCommand("update  finetbl set presents='" + P + "',absenties='" + A + "', leaves='" + L + "', status='" + st + "',fine='" + F + "' where s_id='" + dataGirdViewUpdate.Rows[a].Cells[0].Value + "'and teacher_id='" + state.Teacher_login_id + "' and month='" + t4_month.SelectedIndex + "' and year='" + t4_year.SelectedItem.ToString() + "' and subject_id='" + t4_select_subject.SelectedItem.ToString() + "' and section_name='" + t4_select_section.SelectedItem.ToString() + "' and course_name='" + t4_select_course.SelectedItem.ToString() + "' and class_name='" + t4_class.SelectedItem.ToString() + "'", state.con);
                    cmd.ExecuteNonQuery();
                }
                dataGirdViewUpdate.Rows.Clear();
                MessageBox.Show("Updated Successfull", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Get The Record First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            state.con.Close();
        }

        private void t5_select_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            t5_select_course.BackColor = Color.White;
        }

        private void t5_select_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            t5_select_section.BackColor = Color.White;
        }

        private void t5_select_subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            t5_select_subject.BackColor = Color.White;
        }

        private void t5_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            t5_month.BackColor = Color.White;
        }

        public void t5_load()
        {
            string order_by = "s_id";
            if (t5_orderby.SelectedIndex == 1)
                order_by = "presents";
            if (t5_orderby.SelectedIndex == 2)
                order_by = "absenties";
            if (t5_orderby.SelectedIndex == 3)
                order_by = "fine";
            string query = "";
            if (t5_cat.SelectedIndex == 0)
                query = "select finetbl.s_id,teachertbl.t_name ,subjecttbl.subject_name,finetbl.absenties,finetbl.leaves,finetbl.status,finetbl.fine  from finetbl , teachertbl, subjecttbl where finetbl.teacher_id='" + state.Teacher_login_id + "' and finetbl.month='" + t5_month.SelectedIndex + "'and finetbl.year='" + t5_year.SelectedItem.ToString() + "' and finetbl.subject_id='" + t5_select_subject.SelectedItem.ToString() + "' and finetbl.section_name='" + t5_select_section.SelectedItem.ToString() + "' and finetbl.course_name='" + t5_select_course.SelectedItem.ToString() + "' and class_name='" + t5_class.SelectedItem.ToString() + "' and finetbl.teacher_id=teachertbl.teacher_id and finetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
            if (t5_cat.SelectedIndex == 1)
                query = "select finetbl.s_id,teachertbl.t_name ,subjecttbl.subject_name,finetbl.absenties,finetbl.leaves,finetbl.status,finetbl.fine  from finetbl , teachertbl, subjecttbl where finetbl.teacher_id='" + state.Teacher_login_id + "' and finetbl.month='" + t5_month.SelectedIndex + "'and finetbl.year='" + t5_year.SelectedItem.ToString() + "' and finetbl.subject_id='" + t5_select_subject.SelectedItem.ToString() + "' and finetbl.section_name='" + t5_select_section.SelectedItem.ToString() + "' and finetbl.course_name='" + t5_select_course.SelectedItem.ToString() + "' and finetbl.status='Struck Off' and class_name='" + t5_class.SelectedItem.ToString() + "' and finetbl.teacher_id=teachertbl.teacher_id and finetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
            if (t5_cat.SelectedIndex == 2)
                query = "select finetbl.s_id,teachertbl.t_name ,subjecttbl.subject_name,finetbl.absenties,finetbl.leaves,finetbl.status,finetbl.fine  from finetbl , teachertbl, subjecttbl where finetbl.teacher_id='" + state.Teacher_login_id + "' and finetbl.month='" + t5_month.SelectedIndex + "'and finetbl.year='" + t5_year.SelectedItem.ToString() + "' and finetbl.subject_id='" + t5_select_subject.SelectedItem.ToString() + "' and finetbl.section_name='" + t5_select_section.SelectedItem.ToString() + "' and finetbl.course_name='" + t5_select_course.SelectedItem.ToString() + "' and finetbl.status='Fined' and class_name='" + t5_class.SelectedItem.ToString() + "' and finetbl.teacher_id=teachertbl.teacher_id and finetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
            state.con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(query, state.con);
            sda.Fill(dt);
            dataGridViewLoad.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridViewLoad.Rows.Add();
                dataGridViewLoad.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridViewLoad.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridViewLoad.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridViewLoad.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridViewLoad.Rows[n].Cells[4].Value = dr[4].ToString();
                if (dr[5].ToString() == "Fined")
                    dataGridViewLoad.Rows[n].Cells[5].Value = dr[6].ToString();
                else
                    dataGridViewLoad.Rows[n].Cells[5].Value = dr[5].ToString();
            }
            if (dt.Rows.Count < 0)
                MessageBox.Show("No Record Found For this Month", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            state.con.Close();
        }
        public void t8_load()
        {
            string query = "";
            string order_by = "roll_no";
            if (t8_order.SelectedIndex == 1)
                order_by = "presents";
            if (t8_order.SelectedIndex == 2)
                order_by = "absenties";
            if (t8_order.SelectedIndex == 3)
                order_by = "fine";
            if (t8_cat.SelectedIndex == 0)
                query = "select manualFinetbl.roll_no,teachertbl.t_name ,subjecttbl.subject_name,manualFinetbl.absenties,manualFinetbl.status,manualFinetbl.fine  from manualFinetbl , teachertbl, subjecttbl where manualFinetbl.teacher_id='" + state.Teacher_login_id + "' and manualFinetbl.month='" + t8_month.SelectedIndex + "'and manualFinetbl.year='" + t8_year.SelectedItem.ToString() + "' and manualFinetbl.subject_id='" + t8_subject.SelectedItem.ToString() + "' and manualFinetbl.section_name='" + t8_section.SelectedItem.ToString() + "' and manualFinetbl.class_name='" + t8_class.SelectedItem.ToString() + "' and manualFinetbl.teacher_id=teachertbl.teacher_id and manualFinetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
            if (t8_cat.SelectedIndex == 1)
                query = "select manualFinetbl.roll_no,teachertbl.t_name ,subjecttbl.subject_name,manualFinetbl.absenties,manualFinetbl.status,manualFinetbl.fine  from manualFinetbl , teachertbl, subjecttbl where manualFinetbl.teacher_id='" + state.Teacher_login_id + "' and manualFinetbl.month='" + t8_month.SelectedIndex + "'and manualFinetbl.year='" + t8_year.SelectedItem.ToString() + "' and manualFinetbl.subject_id='" + t8_subject.SelectedItem.ToString() + "' and manualFinetbl.section_name='" + t8_section.SelectedItem.ToString() + "' and manualFinetbl.class_name='" + t8_class.SelectedItem.ToString() + "' and manualFinetbl.status='Struck Off'  and manualFinetbl.teacher_id=teachertbl.teacher_id and manualFinetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
            if (t8_cat.SelectedIndex == 2)
                query = "select manualFinetbl.roll_no,teachertbl.t_name ,subjecttbl.subject_name,manualFinetbl.absenties,manualFinetbl.status,manualFinetbl.fine  from manualFinetbl , teachertbl, subjecttbl where manualFinetbl.teacher_id='" + state.Teacher_login_id + "' and manualFinetbl.month='" + t8_month.SelectedIndex + "'and manualFinetbl.year='" + t8_year.SelectedItem.ToString() + "' and manualFinetbl.subject_id='" + t8_subject.SelectedItem.ToString() + "' and manualFinetbl.section_name='" + t8_section.SelectedItem.ToString() + "' and manualFinetbl.class_name='" + t8_class.SelectedItem.ToString() + "' and manualFinetbl.status='Fined'  and manualFinetbl.teacher_id=teachertbl.teacher_id and manualFinetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
            state.con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(query, state.con);
            sda.Fill(dt);
            dataGridViewManualReport.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[4].ToString() != "Fined" || Convert.ToInt32(dr[5].ToString()) > 0)
                {
                    int n = dataGridViewManualReport.Rows.Add();
                    dataGridViewManualReport.Rows[n].Cells[0].Value = dr[0].ToString();
                    dataGridViewManualReport.Rows[n].Cells[1].Value = dr[1].ToString();
                    dataGridViewManualReport.Rows[n].Cells[2].Value = dr[2].ToString();
                    dataGridViewManualReport.Rows[n].Cells[3].Value = dr[3].ToString();
                    if (dr[4].ToString() == "Fined")
                        dataGridViewManualReport.Rows[n].Cells[4].Value = dr[5].ToString();
                    else
                        dataGridViewManualReport.Rows[n].Cells[4].Value = dr[4].ToString();
                }
            }
            if (dt.Rows.Count < 0)
            {
                dataGridViewManualReport.Rows.Clear();
                MessageBox.Show("No Record Found For this Month", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            state.con.Close();
        }

        public void t9_load()
        {
            string query = "";
            string order_by = "roll_no";
            if (t9_order.SelectedIndex == 1)
                order_by = "presents";
            if (t9_order.SelectedIndex == 2)
                order_by = "absenties";
            if (t9_order.SelectedIndex == 3)
                order_by = "fine";
            if (t9_cat.SelectedIndex == 0)
                query = "select manualFinetbl.roll_no,teachertbl.t_name ,subjecttbl.subject_name,manualFinetbl.absenties,manualFinetbl.status,manualFinetbl.fine  from manualFinetbl , teachertbl, subjecttbl where manualFinetbl.teacher_id='" + state.Teacher_login_id + "' and manualFinetbl.month='" + t9_month.SelectedIndex + "'and manualFinetbl.year='" + t9_year.SelectedItem.ToString() + "' and manualFinetbl.subject_id='" + t9_subject.SelectedItem.ToString() + "' and manualFinetbl.section_name='" + t9_section.SelectedItem.ToString() + "' and manualFinetbl.class_name='" + t9_class.SelectedItem.ToString() + "' and manualFinetbl.teacher_id=teachertbl.teacher_id and manualFinetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
            if (t9_cat.SelectedIndex == 1)
                query = "select manualFinetbl.roll_no,teachertbl.t_name ,subjecttbl.subject_name,manualFinetbl.absenties,manualFinetbl.status,manualFinetbl.fine  from manualFinetbl , teachertbl, subjecttbl where manualFinetbl.teacher_id='" + state.Teacher_login_id + "' and manualFinetbl.month='" + t9_month.SelectedIndex + "'and manualFinetbl.year='" + t9_year.SelectedItem.ToString() + "' and manualFinetbl.subject_id='" + t9_subject.SelectedItem.ToString() + "' and manualFinetbl.section_name='" + t9_section.SelectedItem.ToString() + "' and manualFinetbl.class_name='" + t9_class.SelectedItem.ToString() + "' and manualFinetbl.status='Struck Off'  and manualFinetbl.teacher_id=teachertbl.teacher_id and manualFinetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
            if (t9_cat.SelectedIndex == 2)
                query = "select manualFinetbl.roll_no,teachertbl.t_name ,subjecttbl.subject_name,manualFinetbl.absenties,manualFinetbl.status,manualFinetbl.fine  from manualFinetbl , teachertbl, subjecttbl where manualFinetbl.teacher_id='" + state.Teacher_login_id + "' and manualFinetbl.month='" + t9_month.SelectedIndex + "'and manualFinetbl.year='" + t9_year.SelectedItem.ToString() + "' and manualFinetbl.subject_id='" + t9_subject.SelectedItem.ToString() + "' and manualFinetbl.section_name='" + t9_section.SelectedItem.ToString() + "' and manualFinetbl.class_name='" + t9_class.SelectedItem.ToString() + "' and manualFinetbl.status='Fined'  and manualFinetbl.teacher_id=teachertbl.teacher_id and manualFinetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";

            if (state.con.State == ConnectionState.Closed)
                state.con.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(query, state.con);
            sda.Fill(dt);
            dgv_delete.Rows.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[4].ToString() != "Fined" || Convert.ToInt32(dr[5].ToString()) > 0)
                {
                    int n = dgv_delete.Rows.Add();
                    dgv_delete.Rows[n].Cells[0].Value = dr[0].ToString();
                    dgv_delete.Rows[n].Cells[1].Value = dr[1].ToString();
                    dgv_delete.Rows[n].Cells[2].Value = dr[2].ToString();
                    dgv_delete.Rows[n].Cells[3].Value = dr[3].ToString();
                    if (dr[4].ToString() == "Fined")
                        dgv_delete.Rows[n].Cells[4].Value = dr[5].ToString();
                    else
                        dgv_delete.Rows[n].Cells[4].Value = dr[4].ToString();
                }
            }
            if (dt.Rows.Count < 0)
            {
                dgv_delete.Rows.Clear();
                MessageBox.Show("No Record Found For this Month", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            state.con.Close();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (t5_class.SelectedIndex == 0)
            {
                t5_class.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Class.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t5_select_course.SelectedIndex == 0)
            {
                t5_select_course.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Course.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t5_select_section.SelectedIndex == 0)
            {
                t5_select_section.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Section.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t5_select_subject.SelectedIndex == 0)
            {
                t5_select_subject.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Subject.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t5_month.SelectedIndex == 0)
            {
                t5_month.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Month.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t5_year.SelectedIndex == 0)
            {
                t5_month.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Year.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t5_class.SelectedIndex != 0 && t5_select_course.SelectedIndex != 0 && t5_select_section.SelectedIndex != 0 && t5_select_subject.SelectedIndex != 0 && t5_month.SelectedIndex != 0 && t5_year.SelectedIndex != 0)
            {
                int c_id = 0, s_id = 0;
                c_id = courseID(t5_select_course.SelectedItem.ToString());
                s_id = sectionID(t5_select_section.SelectedItem.ToString());
                state.con.Open();
                SqlCommand cmd = new SqlCommand("select * from subjecttbl where course_id='" + c_id + "' and subject_id='" + t5_select_subject.SelectedItem.ToString() + "'", state.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    state.con.Close();
                    t5_load();
                }
                else
                {
                    dr.Close();
                    if (t5_select_course.SelectedItem.ToString() == "Compulsory")
                        MessageBox.Show(t5_select_subject.SelectedItem + "is not a " + t5_select_course.SelectedItem + " Subject." + Environment.NewLine + "Kindly select appropiate Course and Subject.");
                    else
                        MessageBox.Show(t5_select_course.SelectedItem + " doesn't offer " + t5_select_subject.SelectedItem + " Course." + Environment.NewLine + "Kindly select appropiate Course and Subject.");
                    dataGridViewLoad.Rows.Clear();
                }
                dr.Close();
                state.con.Close();
            }
        }



        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            teacher_Login tl = new teacher_Login();
            this.Hide();
            tl.ShowDialog();
            this.Close();
           // Program.authorized = false;
           // Program.panels = 0;
           //Program.mainMenu = true;
           //this.Close();
        }

        private void changePasswordToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
            {
                Application.Run(new teacher_p_change());
            })).Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (dataGridViewLoad.Rows.Count > 0)
            {
                if (t5_due_date.Text == "")
                {
                    t5_due_date.BackColor = Color.Red;
                    MessageBox.Show("Please Enter Fine Due Date");
                    t5_due_date.Focus();
                    return;
                }
                // if (t5_file_name.Text != "")
                //  {
                //    string path = Environment.CurrentDirectory + "/";
                //      Document doc = new Document(iTextSharp.text.PageSize.LEGAL, 0, 0, 0, 0);
                //    if (File.Exists(path + t5_file_name.Text.ToString()+".pdf"))
                //  {
                //     MessageBox.Show("Enter another File Name.");
                //   }
                //    else
                if (t5_due_date.Text != "")
                {
                    Document doc = new Document(iTextSharp.text.PageSize.LEGAL, 0, 0, 0, 0);
                    SaveFileDialog save = new SaveFileDialog();
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        using (Stream s = File.Open(save.FileName + ".pdf", FileMode.Create))
                        {
                            using (PdfWriter wri = PdfWriter.GetInstance(doc, s))
                            {
                                doc.Open();

                                doc.AddTitle("Fine List");
                                // creating font style
                                iTextSharp.text.Font h_font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE);

                                Paragraph p = new Paragraph("Fine List of " + t5_class.SelectedItem.ToString() + " Students " + t5_month.SelectedItem.ToString() + " " + t5_year.SelectedItem.ToString() + " " + "\n", h_font);
                                p.Alignment = Element.ALIGN_CENTER;

                                doc.Add(p);

                                h_font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                                Paragraph p2 = new Paragraph("Submission Of Fine Due Date : " + t5_due_date.Text.ToString() + "\n\n", h_font);
                                p2.Alignment = Element.ALIGN_CENTER;

                                doc.Add(p2);

                                PdfPTable table = new PdfPTable(dataGridViewLoad.Columns.Count);

                                //table header
                                for (int i = 0; i < dataGridViewLoad.Columns.Count; i++)
                                {
                                    table.AddCell(new Phrase(dataGridViewLoad.Columns[i].HeaderText));

                                }
                                table.HeaderRows = 1;

                                //addind rows 
                                for (int i = 0; i < dataGridViewLoad.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dataGridViewLoad.Columns.Count; j++)
                                    {
                                        if (dataGridViewLoad[j, i].Value != null)
                                        {
                                            table.AddCell(new Phrase(dataGridViewLoad[j, i].Value.ToString()));
                                        }
                                    }
                                }

                                doc.Add(table);
                                doc.Close();
                            }
                        }
                    }

                }
            }
            else
                MessageBox.Show("Get The Record First.");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (t5_class.SelectedIndex == 0)
            {
                t5_class.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Class.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t5_select_subject.SelectedIndex == 0)
            {
                t5_select_subject.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Subject.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t5_month.SelectedIndex == 0)
            {
                t5_month.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Month.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t5_year.SelectedIndex == 0)
            {
                t5_year.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Year.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t5_class.SelectedIndex != 0 && t5_select_subject.SelectedIndex != 0 && t5_month.SelectedIndex != 0 && t5_year.SelectedIndex != 0)
            {
                string order_by = "s_id";
                if (t5_orderby.SelectedIndex == 1)
                    order_by = "presents";
                if (t5_orderby.SelectedIndex == 2)
                    order_by = "absenties";
                if (t5_orderby.SelectedIndex == 3)
                    order_by = "fine";
                string query = "";
                if (t5_cat.SelectedIndex == 0)
                    query = "select finetbl.s_id,teachertbl.t_name ,subjecttbl.subject_name,finetbl.absenties,finetbl.leaves,finetbl.status,finetbl.fine  from finetbl , teachertbl, subjecttbl where finetbl.teacher_id='" + state.Teacher_login_id + "' and finetbl.month='" + t5_month.SelectedIndex + "' and finetbl.year='" + t5_year.SelectedItem.ToString() + "' and finetbl.subject_id='" + t5_select_subject.SelectedItem.ToString() + "' and class_name='" + t5_class.SelectedItem.ToString() + "' and finetbl.teacher_id=teachertbl.teacher_id and finetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
                if (t5_cat.SelectedIndex == 1)
                    query = "select finetbl.s_id,teachertbl.t_name ,subjecttbl.subject_name,finetbl.absenties,finetbl.leaves,finetbl.status,finetbl.fine  from finetbl , teachertbl, subjecttbl where finetbl.teacher_id='" + state.Teacher_login_id + "' and finetbl.month='" + t5_month.SelectedIndex + "' and finetbl.year='" + t5_year.SelectedItem.ToString() + "' and finetbl.subject_id='" + t5_select_subject.SelectedItem.ToString() + "' and class_name='" + t5_class.SelectedItem.ToString() + "' and finetbl.status='Struck Off' and finetbl.teacher_id=teachertbl.teacher_id and finetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
                if (t5_cat.SelectedIndex == 2)
                    query = "select finetbl.s_id,teachertbl.t_name ,subjecttbl.subject_name,finetbl.absenties,finetbl.leaves,finetbl.status,finetbl.fine  from finetbl , teachertbl, subjecttbl where finetbl.teacher_id='" + state.Teacher_login_id + "' and finetbl.month='" + t5_month.SelectedIndex + "' and finetbl.year='" + t5_year.SelectedItem.ToString() + "' and finetbl.subject_id='" + t5_select_subject.SelectedItem.ToString() + "' and class_name='" + t5_class.SelectedItem.ToString() + "' and finetbl.status='Fined' and finetbl.teacher_id=teachertbl.teacher_id and finetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
                state.con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, state.con);
                sda.Fill(dt);
                dataGridViewLoad.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridViewLoad.Rows.Add();
                    dataGridViewLoad.Rows[n].Cells[0].Value = dr[0].ToString();
                    dataGridViewLoad.Rows[n].Cells[1].Value = dr[1].ToString();
                    dataGridViewLoad.Rows[n].Cells[2].Value = dr[2].ToString();
                    dataGridViewLoad.Rows[n].Cells[3].Value = dr[3].ToString();
                    dataGridViewLoad.Rows[n].Cells[4].Value = dr[4].ToString();
                    if (dr[5].ToString() == "Fined")
                        dataGridViewLoad.Rows[n].Cells[5].Value = dr[6].ToString();
                    else
                        dataGridViewLoad.Rows[n].Cells[5].Value = dr[5].ToString();
                }
                if (dt.Rows.Count < 0)
                    MessageBox.Show("No Record Found For this Month", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                state.con.Close();
            }
        }

        private void Insert_Click(object sender, EventArgs e)
        {

        }

        private void t1_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            t1_class.BackColor = Color.White;
            if (t1_class.SelectedIndex == 0)
            {
                t1_select_subject.Items.Clear();
                t1_select_subject.Items.Add("..Select..");
                t1_select_subject.SelectedIndex = 0;
            }
            if (t1_class.SelectedIndex != 0)
                load1_subject();

        }

        private void t2_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            t2_class.BackColor = Color.White;
            if (t2_class.SelectedIndex == 0)
                t2_select_subject.SelectedIndex = 0;
            if (t2_class.SelectedIndex != 0)
                load2_subject();
        }

        private void t3_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            t3_class.BackColor = Color.White;
            if (t3_class.SelectedIndex == 0)
            {
                t3_select_subject.Items.Clear();
                t3_select_subject.Items.Add("..Select..");
                t3_select_subject.SelectedIndex = 0;
            }
            if (t3_class.SelectedIndex != 0)
            {
                load3_subject();

            }
        }

        private void t4_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            t4_class.BackColor = Color.White;
            if (t4_class.SelectedIndex == 0)
            {
                t4_select_subject.Items.Clear();
                t4_select_subject.Items.Add("..Select..");
                t4_select_subject.SelectedIndex = 0;
            }
            if (t4_class.SelectedIndex != 0)
            {
                load4_subject();

            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void t5_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            t5_class.BackColor = Color.White;
            if (t5_class.SelectedIndex == 0)
            {
                t5_select_subject.Items.Clear();
                t5_select_subject.Items.Add("..Select..");
                t5_select_subject.SelectedIndex = 0;
            }
            if (t5_class.SelectedIndex != 0)
            {
                load5_subject();

            }
        }

        private void dataGridViewLoad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void t1_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            t1_year.BackColor = Color.White;
        }

        private void t2_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            t2_year.BackColor = Color.White;
        }

        private void t3_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            t3_year.BackColor = Color.White;
        }

        private void t4_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            t4_year.BackColor = Color.White;
        }

        private void t5_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            t5_year.BackColor = Color.White;
        }

        private void t5_orderby_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void t5_due_date_TextChanged(object sender, EventArgs e)
        {
            t5_due_date.BackColor = Color.White;
        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void t6_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            t6_class.BackColor = Color.White;
            if (t6_class.SelectedIndex == 0)
            {
                t6_subject.Items.Clear();
                t6_subject.Items.Add("..Select..");
                t6_subject.SelectedIndex = 0;
            }
            if (t6_class.SelectedIndex != 0)
            {
                load6_subject();

            }
        }

        private void t6_subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            t6_subject.BackColor = Color.White;
        }

        private void t6_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            t6_section.BackColor = Color.White;
        }

        private void t6_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            t6_month.BackColor = Color.White;
        }

        private void t6_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            t6_year.BackColor = Color.White;
        }



        private void t6_r_start_TextChanged(object sender, EventArgs e)
        {
            t6_r_start.BackColor = Color.White;
        }

        private void t6_r_end_TextChanged(object sender, EventArgs e)
        {
            t6_r_end.BackColor = Color.White;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (t6_class.SelectedIndex == 0)
            {
                t6_class.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Class.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t6_subject.SelectedIndex == 0)
            {
                t6_subject.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Subject.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t6_section.SelectedIndex == 0)
            {
                t6_section.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Section.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t6_month.SelectedIndex == 0)
            {
                t6_month.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Month.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t6_year.SelectedIndex == 0)
            {
                t6_year.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Year.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t6_r_start.Text == "")
            {
                if (t6_rows.Text != "")
                {
                    dataGridViewManual1.Rows.Clear();
                    for (int a = 1; a <= Convert.ToInt32(t6_rows.Text); a++)
                    {
                        int n = dataGridViewManual1.Rows.Add();
                        dataGridViewManual1.Rows[n].Cells[0].Value = "";
                        dataGridViewManual1.Rows[n].Cells[1].Value = "";
                    }
                    return;
                }
                t6_r_start.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Enter Roll Start From or Total Rows", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                t6_r_start.Focus();
                return;
            }
            if (t6_r_end.Text == "")
            {
                t6_r_end.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Enter Roll End At or Total Rows", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                t6_r_end.Focus();
                return;
            }
            if (t6_class.SelectedIndex != 0 && t6_section.SelectedIndex != 0 && t6_subject.SelectedIndex != 0 && t6_month.SelectedIndex != 0 && t6_year.SelectedIndex != 0 && t6_r_start.Text != "" && t6_r_end.Text != "")
            {
                dataGridViewManual1.Rows.Clear();
                int start = Convert.ToInt32(t6_r_start.Text);
                int end = Convert.ToInt32(t6_r_end.Text);
                for (int a = start; a <= end; a++)
                {
                    int n = dataGridViewManual1.Rows.Add();
                    dataGridViewManual1.Rows[n].Cells[0].Value = a;
                    dataGridViewManual1.Rows[n].Cells[1].Value = 0;

                }
            }
        }

        private void dataGridViewManual1_CancelRowEdit(object sender, QuestionEventArgs e)
        {

        }

        private void dataGridViewManual1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void t1_lect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t2_lect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t6_r_start_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t6_r_end_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridViewManual1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(column1_KeyPress);
            if (dataGridViewManual1.CurrentCell.ColumnIndex == 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(column1_KeyPress);
                }
            }
            e.Control.KeyPress -= new KeyPressEventHandler(column2_KeyPress);
            if (dataGridViewManual1.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(column2_KeyPress);
                }
            }
        }
        private void column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void column2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void updatecolumn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void updatecolumn2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dataGridViewManual1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void generateFine(out int struckOff, out int fine1, out int fine2, out int fine3, out int fine4, out int from1, out int from2, out int from3, out int from4, out int to1, out int to2, out int to3, out int to4)
        {
            struckOff = fine1 = fine2 = fine3 = fine4 = from1 = from2 = from3 = from4 = to1 = to2 = to3 = to4 = 0;
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
                        from1 = Convert.ToInt32(dr[1].ToString());
                        to1 = Convert.ToInt32(dr[2].ToString());
                        fine1 = Convert.ToInt32(dr[3].ToString());
                        struckOff = Convert.ToInt32(dr[4].ToString());
                    }
                    if (count == 2)
                    {
                        from2 = Convert.ToInt32(dr[1].ToString());
                        to2 = Convert.ToInt32(dr[2].ToString());
                        fine2 = Convert.ToInt32(dr[3].ToString());
                    }
                    if (count == 3)
                    {
                        from3 = Convert.ToInt32(dr[1].ToString());
                        to3 = Convert.ToInt32(dr[2].ToString());
                        fine3 = Convert.ToInt32(dr[3].ToString());
                    }
                    if (count == 4)
                    {
                        from4 = Convert.ToInt32(dr[1].ToString());
                        to4 = Convert.ToInt32(dr[2].ToString());
                        fine4 = Convert.ToInt32(dr[3].ToString());
                    }
                    count++;
                }
            }
            state.con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int T = lec_delivered();
            if (T > 0)
            {
                int struckOff, fine1, fine2, fine3, fine4;
                int from1, from2, from3, from4;
                int to1, to2, to3, to4;
                generateFine(out struckOff, out fine1, out fine2, out fine3, out fine4, out from1, out from2, out from3, out from4, out to1, out to2, out to3, out to4);
                // MessageBox.Show("in1");
                state.con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from manualFinetbl where teacher_id='" + state.Teacher_login_id + "' and month='" + t6_month.SelectedIndex + "' and year='" + t6_year.SelectedItem.ToString() + "' and subject_id='" + t6_subject.SelectedItem.ToString() + "' and section_name='" + t6_section.SelectedItem.ToString() + "' and class_name='" + t6_class.SelectedItem.ToString() + "'", state.con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.HasRows)
                {
                    //  MessageBox.Show("in2");
                    dataGridViewManual1.Rows.Clear();
                    MessageBox.Show("You Have Alread Inserted Attendence For this Month!" + Environment.NewLine + "You can go for update Attendence.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //string query = "select roll_no,absenties from manualFinetbl where teacher_id='" + state.Teacher_login_id + "' and class_name='" + t6_class.SelectedItem.ToString() + "' and subject_id='" + t6_subject.SelectedItem.ToString() + "' and section_name='" + t6_section.SelectedItem.ToString() + "' and month='" + t6_month.SelectedIndex + "' and year='" + t6_year.SelectedItem.ToString() + "'";
                    //SqlCommand cmd2 = new SqlCommand(query, state.con);
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    for (int a = 0; a < dataGridViewManual1.Rows.Count; a++)
                    {
                        if (dataGridViewManual1.Rows[a].Cells[1].Value.ToString() != "" && Convert.ToInt32(dataGridViewManual1.Rows[a].Cells[1].Value) > 0)
                        {
                            int P = 0, A = 0, L = 0;
                            A = Convert.ToInt32(dataGridViewManual1.Rows[a].Cells[1].Value);
                            P = T - A;
                            SqlCommand cmd = state.con.CreateCommand();
                            cmd.CommandText = "insert into manualFinetbl values(@roll_no,@t_id,@subject_id,@class_name,@section_name,@month,@year,@lec_delivered,@presents,@absenties,@leaves,@status,@fine);";
                            cmd.Parameters.AddWithValue("@roll_no", Convert.ToInt32(dataGridViewManual1.Rows[a].Cells[0].Value));
                            cmd.Parameters.AddWithValue("@t_id", state.Teacher_login_id);
                            cmd.Parameters.AddWithValue("@subject_id", t6_subject.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@class_name", t6_class.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@section_name", t6_section.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@month", t6_month.SelectedIndex);
                            cmd.Parameters.AddWithValue("@year", t6_year.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@lec_delivered", T);
                            cmd.Parameters.AddWithValue("@presents", P);
                            cmd.Parameters.AddWithValue("@absenties", A);
                            cmd.Parameters.AddWithValue("@leaves", L);
                            if (A >= struckOff)
                            {
                                cmd.Parameters.AddWithValue("@status", "Struck Off");
                                cmd.Parameters.AddWithValue("@fine", 0);
                            }
                            else
                            {
                                if (A >= from1 && A <= to1)
                                {
                                    cmd.Parameters.AddWithValue("@status", "Fined");
                                    cmd.Parameters.AddWithValue("@fine", fine1);
                                 } 
                                else if (A >= from2 && A <= to2)
                                {
                                   cmd.Parameters.AddWithValue("@status", "Fined");
                                   cmd.Parameters.AddWithValue("@fine", fine2);
                                 }
                                else if (A >= from3 && A <= to3)
                                {
                                    cmd.Parameters.AddWithValue("@status", "Fined");
                                    cmd.Parameters.AddWithValue("@fine", fine3);
                                }
                                else if (A >= from4 && A <= to4)
                                { 
                                    cmd.Parameters.AddWithValue("@status", "Fined");
                                    cmd.Parameters.AddWithValue("@fine", fine4);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@status", "Nil");
                                    cmd.Parameters.AddWithValue("@fine", 0);
                                }
                             
                            }
                            cmd.ExecuteNonQuery();
                        }
                    }
                    dataGridViewManual1.Rows.Clear();
                    MessageBox.Show("Attendence Inserted Successfully!", "Attendence AddWithValueed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                state.con.Close();
            }
            else
            {
                dataGridViewManual1.Rows.Clear();
                MessageBox.Show("Go Set Lect Delivered in this month First!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
         
        private void t7_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            t7_class.BackColor = Color.White;
            if (t7_class.SelectedIndex == 0)
            {
                t7_subject.Items.Clear();
                t7_subject.Items.Add("..Select..");
                t7_subject.SelectedIndex = 0;
            }
            if (t7_class.SelectedIndex != 0)
            {
                load7_subject();

            }
        }

        private void t7_subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            t7_subject.BackColor = Color.White;
        }

        private void t7_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            t7_section.BackColor = Color.White;
        }

        private void t7_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            t7_month.BackColor = Color.White;
        }

        private void t7_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            t7_year.BackColor = Color.White;
        }

       

        private void button17_Click(object sender, EventArgs e)
        {
            if (t7_class.SelectedIndex == 0)
            {
                t7_class.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Class.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t7_subject.SelectedIndex == 0)
            {
                t7_subject.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Subject.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t7_section.SelectedIndex == 0)
            {
                t7_section.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Section.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t7_month.SelectedIndex == 0)
            {
                t7_month.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Month.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t7_year.SelectedIndex == 0)
            {
                t7_year.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Year.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            if (t7_class.SelectedIndex != 0 && t7_section.SelectedIndex != 0 && t7_subject.SelectedIndex != 0 && t7_month.SelectedIndex != 0 && t7_year.SelectedIndex != 0)
            {
                string query = "";
                if (t7_cat.SelectedIndex == 0)
                  query=  "select roll_no,absenties from manualFinetbl where teacher_id='" + state.Teacher_login_id + "' and class_name='" + t7_class.SelectedItem.ToString() + "' and subject_id='" + t7_subject.SelectedItem.ToString() + "' and section_name='" + t7_section.SelectedItem.ToString() + "' and month='" + t7_month.SelectedIndex + "' and year='" + t7_year.SelectedItem.ToString() + "'";  
               if (t7_cat.SelectedIndex == 1)
                    query = "select roll_no,absenties from manualFinetbl where teacher_id='" + state.Teacher_login_id + "' and class_name='" + t7_class.SelectedItem.ToString() + "' and subject_id='" + t7_subject.SelectedItem.ToString() + "' and section_name='" + t7_section.SelectedItem.ToString() + "' and month='" + t7_month.SelectedIndex + "' and year='" + t7_year.SelectedItem.ToString() + "' and status='Struck Off' ";
                if (t7_cat.SelectedIndex == 2)
                    query = "select roll_no,absenties from manualFinetbl where teacher_id='" + state.Teacher_login_id + "' and class_name='" + t7_class.SelectedItem.ToString() + "' and subject_id='" + t7_subject.SelectedItem.ToString() + "' and section_name='" + t7_section.SelectedItem.ToString() + "' and month='" + t7_month.SelectedIndex + "' and year='" + t7_year.SelectedItem.ToString() + "' and status='Fined' ";
                state.con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, state.con);
                sda.Fill(dt);
                dataGridViewManual1Update.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridViewManual1Update.Rows.Add();
                    dataGridViewManual1Update.Rows[n].Cells[0].Value = dr[0].ToString();
                    dataGridViewManual1Update.Rows[n].Cells[1].Value = dr[1].ToString();                    
                }
                if (dt.Rows.Count == 0)
                {
                    dataGridViewManual1Update.Rows.Clear();
                    MessageBox.Show("No Record Found For this Month", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                state.con.Close();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int T = t7_lec_delivered();
            int struckOff, fine1, fine2, fine3, fine4;
            int from1, from2, from3, from4;
            int to1, to2, to3, to4;
            generateFine(out struckOff, out fine1, out fine2, out fine3, out fine4, out from1, out from2, out from3, out from4, out to1, out to2, out to3, out to4);
            state.con.Open();
            if (dataGridViewManual1Update.Rows.Count > 0)
            {
               for (int a = 0; a < dataGridViewManual1Update.Rows.Count; a++)
                {
                    int P = 0, A = 0, F = 0;
                    string st = "Fined";
                    A = Convert.ToInt32(dataGridViewManual1Update.Rows[a].Cells[1].Value);          
                    P = T - (A );
                    if (A >= struckOff)
                    {
                        F = 0;
                        st = "Struck Off";
                    }
                    else
                    {
                        if (A >= from1 && A <= to1)
                        {
                            F = fine1;
                            st = "Fined";
                        }
                        else if (A >= from2 && A <= to2)
                        {
                            F = fine2;
                            st = "Fined";
                        }
                        else if (A >= from3 && A <= to3)
                        {
                            F = fine3;
                            st = "Fined";
                        }
                        else if (A >= from4 && A <= to4)
                        {
                            F = fine4;
                            st = "Fined";
                        }
                        else
                        {
                            F = 0;
                            st = "Nil";
                        }

                    }
                    SqlCommand cmd = new SqlCommand("update  manualFinetbl set presents='" + P + "',absenties='" + A + "', status='" + st + "',fine='" + F + "' where roll_no='" + dataGridViewManual1Update.Rows[a].Cells[0].Value + "'and teacher_id='" + state.Teacher_login_id + "' and month='" + t7_month.SelectedIndex + "' and year='" + t7_year.SelectedItem.ToString() + "' and subject_id='" + t7_subject.SelectedItem.ToString() + "' and section_name='" + t7_section.SelectedItem.ToString() + "' and class_name='" + t7_class.SelectedItem.ToString() + "'", state.con);
                    cmd.ExecuteNonQuery();
                }
                dataGridViewManual1Update.Rows.Clear();
                MessageBox.Show("Updated Successfull", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Get The Record First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            state.con.Close();
        }

        private void dataGridViewManual1Update_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(updatecolumn1_KeyPress);
            if (dataGridViewManual1Update.CurrentCell.ColumnIndex == 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(updatecolumn1_KeyPress);
                }
            }
            e.Control.KeyPress -= new KeyPressEventHandler(updatecolumn2_KeyPress);
            if (dataGridViewManual1Update.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(updatecolumn2_KeyPress);
                }
            }
        }

        private void t8_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            t8_class.BackColor = Color.White;
            if (t8_class.SelectedIndex == 0)
            {
                t8_subject.Items.Clear();
                t8_subject.Items.Add("..Select..");
                t8_subject.SelectedIndex = 0;
            }
            if (t8_class.SelectedIndex != 0)
            {
                load8_subject();

            }
        }

        private void t9_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            t9_class.BackColor = Color.White;
            if (t9_class.SelectedIndex == 0)
            {
                t9_subject.Items.Clear();
                t9_subject.Items.Add("..Select..");
                t9_subject.SelectedIndex = 0;
            }
            if (t9_class.SelectedIndex != 0)
            {
                load9_subject();

            }
        }

        private void t8_subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            t8_subject.BackColor = Color.White;
        }

        private void t8_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            t8_month.BackColor = Color.White;
        }

        private void t8_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            t8_year.BackColor = Color.White;
        }

        private void t8_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            t8_section.BackColor = Color.White;
        }

        private void t8_file_TextChanged(object sender, EventArgs e)
        {
            t8_due_date.BackColor = Color.White;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (t8_class.SelectedIndex == 0)
            {
                t8_class.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Class.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            if (t8_section.SelectedIndex == 0)
            {
                t8_section.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Section.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t8_subject.SelectedIndex == 0)
            {
                t8_subject.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Subject.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t8_month.SelectedIndex == 0)
            {
                t8_month.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Month.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t8_year.SelectedIndex == 0)
            {
                t8_year.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Year.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t8_class.SelectedIndex != 0 && t8_section.SelectedIndex != 0 && t8_subject.SelectedIndex != 0 && t8_month.SelectedIndex != 0 && t8_year.SelectedIndex != 0)
            {
                t8_load();                
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (dataGridViewManualReport.Rows.Count > 0)
            {
                if (t8_due_date.Text == "")
                {
                    t8_due_date.BackColor = Color.Red;
                    MessageBox.Show("Please Enter Fine Due Date");
                    t8_due_date.Focus();
                    return;
                }               
                if (t8_due_date.Text != "")
                {
                    Document doc = new Document(iTextSharp.text.PageSize.LEGAL, 0, 0, 0, 0);
                    SaveFileDialog save = new SaveFileDialog();
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        using (Stream s = File.Open(save.FileName + ".pdf", FileMode.Create))
                        {
                            using (PdfWriter wri = PdfWriter.GetInstance(doc, s))
                            {
                                doc.Open();

                                doc.AddTitle("Fine List");
                                // creating font style
                                iTextSharp.text.Font h_font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE);

                                Paragraph p = new Paragraph("Fine List of " + t8_class.SelectedItem.ToString() + " Students " + t8_month.SelectedItem.ToString() + " " + t8_year.SelectedItem.ToString() + " " + "\n", h_font);
                                p.Alignment = Element.ALIGN_CENTER;

                                doc.Add(p);

                                h_font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                                Paragraph p2 = new Paragraph("Submission Of Fine Due Date : " + t8_due_date.Text.ToString() + "\n\n", h_font);
                                p2.Alignment = Element.ALIGN_CENTER;

                                doc.Add(p2);

                                PdfPTable table = new PdfPTable(dataGridViewManualReport.Columns.Count);

                                //table header
                                for (int i = 0; i < dataGridViewManualReport.Columns.Count; i++)
                                {
                                    table.AddCell(new Phrase(dataGridViewManualReport.Columns[i].HeaderText));

                                }
                                table.HeaderRows = 1;

                                //addind rows 
                                for (int i = 0; i < dataGridViewManualReport.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dataGridViewManualReport.Columns.Count; j++)
                                    {
                                        if (dataGridViewManualReport[j, i].Value != null)
                                        {
                                            table.AddCell(new Phrase(dataGridViewManualReport[j, i].Value.ToString()));
                                        }
                                    }
                                }

                                doc.Add(table);
                                doc.Close();
                            }
                        }
                    }

                }
            }
            else
                MessageBox.Show("Get The Record First.");
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(t3_column4_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(t3_column4_KeyPress);
                }
            }
            e.Control.KeyPress -= new KeyPressEventHandler(t3_column5_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(t3_column5_KeyPress);
                }
            }
        }
        private void t3_column4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void t3_column5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void t4_column4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void t4_column5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void dataGirdViewUpdate_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(t4_column4_KeyPress);
            if (dataGirdViewUpdate.CurrentCell.ColumnIndex == 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(t4_column4_KeyPress);
                }
            }
            e.Control.KeyPress -= new KeyPressEventHandler(t4_column5_KeyPress);
            if (dataGirdViewUpdate.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(t4_column5_KeyPress);
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (t9_class.SelectedIndex == 0)
            {
                t9_class.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Class.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t9_section.SelectedIndex == 0)
            {
                t9_section.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Section.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t9_subject.SelectedIndex == 0)
            {
                t9_subject.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Subject.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t9_month.SelectedIndex == 0)
            {
                t9_month.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Month.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t9_year.SelectedIndex == 0)
            {
                t9_year.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Year.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t9_class.SelectedIndex != 0 && t9_section.SelectedIndex != 0 && t9_subject.SelectedIndex != 0 && t9_month.SelectedIndex != 0 && t9_year.SelectedIndex != 0)
            {
                t9_load();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (t9_class.SelectedIndex == 0)
            {
                t9_class.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Class.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t9_section.SelectedIndex == 0)
            {
                t9_section.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Section.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t9_subject.SelectedIndex == 0)
            {
                t9_subject.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Subject.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t9_month.SelectedIndex == 0)
            {
                t9_month.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Month.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t9_year.SelectedIndex == 0)
            {
                t9_year.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Year.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t9_class.SelectedIndex != 0 && t9_section.SelectedIndex != 0 && t9_subject.SelectedIndex != 0 && t9_month.SelectedIndex != 0 && t9_year.SelectedIndex != 0)
            {
                deleteMonthlyAttendance();
            }
        }

        private void deleteMonthlyAttendance()
        {
            string message = "Do you want to delete the attendance for the selected month?";
            string title = "Delete Attendance";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if(state.con.State == ConnectionState.Closed)
                    state.con.Open();

                SqlCommand cmd = new SqlCommand($"DELETE FROM manualFinetbl WHERE subjecttbl.subject_id = {t9_subject.SelectedIndex};", state.con);

                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Selected Month's Attendance Deleted", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        bool exit = true;
        private void teacher_view_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                DialogResult d;
                d = MessageBox.Show("Are you sure to Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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

        private void dataGridViewManualReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void teacher_id_show_Click(object sender, EventArgs e)
        {

        }
    }
}
