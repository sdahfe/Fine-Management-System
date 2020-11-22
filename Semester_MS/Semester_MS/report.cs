using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Semester_MS
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
            set();
        }

        public void set()
        {
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select * from classtbl", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    t_class.Items.Add(dr[1].ToString());
                    t2_class.Items.Add(dr[1].ToString());
                    t3_class.Items.Add(dr[1].ToString());
                }
            }
            dr.Close();
            cmd.CommandText = "select * from yeartbl";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t_year.Items.Clear();
                t2_year.Items.Clear();
                t3_year.Items.Clear();
                t_year.Items.Add("........Year......");
                t2_year.Items.Add("........Year......");
                t3_year.Items.Add("........Year......");
                t_year.SelectedIndex = 0;
                t2_year.SelectedIndex = 0;
                t3_year.SelectedIndex = 0;
                while (dr.Read())
                {
                    t_year.Items.Add(dr[1].ToString());
                    t2_year.Items.Add(dr[1].ToString());
                    t3_year.Items.Add(dr[1].ToString());
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
        public void load_subject()
        {
            int c = class_id(t_class.SelectedItem.ToString());
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select * from subjecttbl where class_id='" + c + "'", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    select_subject.Items.Add(dr[0].ToString());
                }
            }
            dr.Close();
            state.con.Close();
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

        private void report_Load(object sender, EventArgs e)
        {
            t_class.SelectedIndex = 1;
            select_subject.SelectedIndex = 0;
            month.SelectedIndex = 1;
            t_year.SelectedIndex = 1;
            orderby.SelectedIndex = 1;
            t1_cat.SelectedIndex = 1;
            t2_class.SelectedIndex = 1;

            t2_month.SelectedIndex = 1;
            t2_year.SelectedIndex = 1;
            t2_order.SelectedIndex = 1;
            t2_cat.SelectedIndex = 1;

            t3_class.SelectedIndex = 1;
            t3_month.SelectedIndex = 1;
            t3_year.SelectedIndex = 1;

            dataGridViewReport.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridViewReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewReport.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGridViewReport.EnableHeadersVisualStyles = false;

            dataGridViewManualReport.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridViewManualReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewManualReport.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGridViewManualReport.EnableHeadersVisualStyles = false;

            dataGridViewSearch.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridViewSearch.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewSearch.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGridViewSearch.EnableHeadersVisualStyles = false;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.clearVirtualtbl();
            this.Close();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void t2_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            t2_class.BackColor = Color.White;
        }

        private void t2_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            t2_month.BackColor = Color.White;
        }

        private void t2_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            t2_year.BackColor = Color.White;
        }

        private void t2_order_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void t2_due_date_TextChanged(object sender, EventArgs e)
        {
            t2_due_date.BackColor = Color.White;
        }

        public void fillVirtualtbl(DataRow dr)
        {

            SqlCommand cmd = state.con.CreateCommand();
            cmd.CommandText = "insert into virtualtbl values(@roll_no,@t_name,@subject_name,@absenties,@status,@fine);";
            cmd.Parameters.AddWithValue("@roll_no", Convert.ToInt32(dr[0].ToString()));
            cmd.Parameters.AddWithValue("@t_name", dr[1].ToString());
            cmd.Parameters.AddWithValue("@subject_name", dr[2].ToString());
            cmd.Parameters.AddWithValue("@absenties", Convert.ToInt32(dr[3].ToString()));
            cmd.Parameters.AddWithValue("@status", dr[4].ToString());
            cmd.Parameters.AddWithValue("@fine", Convert.ToInt32(dr[5].ToString()));
            cmd.ExecuteNonQuery();

        }
        public void struckoff(DataRow dr)
        {
            if (dr[4].ToString() != "Fined")
            {
                SqlCommand cmd = new SqlCommand("insert into sorttbl values(@roll_no,@t_name,@subject_name,@absenties,@status,@fine);", state.con);
                cmd.Parameters.AddWithValue("@roll_no", Convert.ToInt32(dr[0].ToString()));
                cmd.Parameters.AddWithValue("@t_name", dr[1].ToString());
                cmd.Parameters.AddWithValue("@subject_name", dr[2].ToString());
                cmd.Parameters.AddWithValue("@absenties", Convert.ToInt32(dr[3].ToString()));
                cmd.Parameters.AddWithValue("@status", dr[4].ToString());
                cmd.Parameters.AddWithValue("@fine", Convert.ToInt32(dr[5].ToString()));
                cmd.ExecuteNonQuery();
            }

        }
        public void fine_to_final()
        {
            state.con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("select distinct roll_no from virtualtbl; ", state.con);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SqlCommand cmd = new SqlCommand("select * from virtualtbl where roll_no ='" + Convert.ToInt32(dr[0].ToString()) + "' and  fine in (select  max(fine)  from virtualtbl where roll_no ='" + Convert.ToInt32(dr[0].ToString()) + "' group by roll_no) ", state.con);
                    SqlDataReader dr2 = cmd.ExecuteReader();
                    if (dr2.HasRows)
                    {
                        dr2.Read();
                        cmd.CommandText = "insert into finaltbl values(@roll_no,@t_name,@subject_name,@absenties,@status,@fine);";
                        cmd.Parameters.AddWithValue("@roll_no", Convert.ToInt32(dr2[1].ToString()));
                        cmd.Parameters.AddWithValue("@t_name", dr2[2].ToString());
                        cmd.Parameters.AddWithValue("@subject_name", dr2[3].ToString());
                        cmd.Parameters.AddWithValue("@absenties", Convert.ToInt32(dr2[4].ToString()));
                        cmd.Parameters.AddWithValue("@status", dr2[5].ToString());
                        cmd.Parameters.AddWithValue("@fine", Convert.ToInt32(dr2[6].ToString()));
                        dr2.Close();
                        cmd.ExecuteNonQuery();
                    }

                }
            }
            state.con.Close();
        }
        public string monthName(int no)
        {
            if (no == 1)
                return "January";
            else if (no == 2)
                return "February";
            else if (no == 3)
                return "March";
            else if (no == 4)
                return "April";
            else if (no == 5)
                return "May";
            else if (no == 6)
                return "June";
            else if (no == 7)
                return "July";
            else if (no == 8)
                return "August";
            else if (no == 9)
                return "September";
            else if (no == 10)
                return "October";
            else if (no == 11)
                return "November";
            else if (no == 12)
                return "December";
            else
                return "Error";
        }
        public void searchGird(int no)
        {
            string query = "";
            if(no==1)
            query = "select manualFinetbl.roll_no,teachertbl.t_name ,subjecttbl.subject_name,manualFinetbl.month,manualFinetbl.absenties,manualFinetbl.status,manualFinetbl.fine  from manualFinetbl , teachertbl, subjecttbl where manualFinetbl.roll_no='" + Convert.ToInt64(t3_roll.Text) + "' and manualFinetbl.year='" + t3_year.SelectedItem.ToString() + "' and manualFinetbl.month= '"+t3_month.SelectedIndex+"' and manualFinetbl.class_name='" + t3_class.SelectedItem.ToString() + "' and manualFinetbl.teacher_id=teachertbl.teacher_id and manualFinetbl.subject_id= subjecttbl.subject_id";
            if (no == 2)
            query = "select manualFinetbl.roll_no,teachertbl.t_name ,subjecttbl.subject_name,manualFinetbl.month,manualFinetbl.absenties,manualFinetbl.status,manualFinetbl.fine  from manualFinetbl , teachertbl, subjecttbl where manualFinetbl.roll_no='" + Convert.ToInt64(t3_roll.Text) + "' and manualFinetbl.year='" + t3_year.SelectedItem.ToString() + "' and manualFinetbl.class_name='" + t3_class.SelectedItem.ToString() + "' and manualFinetbl.teacher_id=teachertbl.teacher_id and manualFinetbl.subject_id= subjecttbl.subject_id";

            state.con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(query, state.con);
            sda.Fill(dt);
            dataGridViewSearch.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridViewSearch.Rows.Add();
                dataGridViewSearch.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridViewSearch.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridViewSearch.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridViewSearch.Rows[n].Cells[3].Value = monthName(Convert.ToInt32(dr[3].ToString()));
                dataGridViewSearch.Rows[n].Cells[4].Value = dr[4].ToString();
                if (dr[5].ToString() == "Fined")
                    dataGridViewSearch.Rows[n].Cells[5].Value = dr[6].ToString();
                else
                    dataGridViewSearch.Rows[n].Cells[5].Value = dr[5].ToString();

            }

            state.con.Close();
        }
        public void struck_to_final()
        {
            state.con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("select * from sorttbl; ", state.con);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SqlCommand cmd = new SqlCommand("select * from finaltbl where roll_no ='" + Convert.ToInt32(dr[1].ToString()) + "'", state.con);
                    SqlDataReader dr2 = cmd.ExecuteReader();
                    if (dr2.HasRows)
                    {
                        dr2.Read();
                        cmd.CommandText = "update finaltbl set t_name='" + dr[2].ToString() + "', subject_name='" + dr[3].ToString() + "', absenties='" + Convert.ToInt32(dr[4].ToString()) + "', status='" + dr[5].ToString() + "', fine='" + Convert.ToInt32(dr[6].ToString()) + "' where roll_no='" + Convert.ToInt32(dr[1].ToString()) + "';";
                        dr2.Close();
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        dr2.Close();
                        cmd.CommandText = "insert into finaltbl values(@roll_no,@t_name,@subject_name,@absenties,@status,@fine);";
                        cmd.Parameters.AddWithValue("@roll_no", Convert.ToInt32(dr[1].ToString()));
                        cmd.Parameters.AddWithValue("@t_name", dr[2].ToString());
                        cmd.Parameters.AddWithValue("@subject_name", dr[3].ToString());
                        cmd.Parameters.AddWithValue("@absenties", Convert.ToInt32(dr[4].ToString()));
                        cmd.Parameters.AddWithValue("@status", dr[5].ToString());
                        cmd.Parameters.AddWithValue("@fine", Convert.ToInt32(dr[6].ToString()));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            state.con.Close();
        }
        public void load()
        {
            string query = "";
            string order_by = "roll_no";
            if (t2_order.SelectedIndex == 1)
                order_by = "absenties";
            if (t2_order.SelectedIndex == 2)
                order_by = "fine";
            if (t2_cat.SelectedIndex == 0)
                query = "select * from finaltbl order by " + order_by + ";";
            if (t2_cat.SelectedIndex == 1)
                query = "select * from finaltbl where status='Struck Off' order by " + order_by + ";";
            if (t2_cat.SelectedIndex == 2)
                query = "select * from finaltbl where status='Fined' order by " + order_by + ";";
            state.con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(query, state.con);
            sda.Fill(dt);
            dataGridViewManualReport.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridViewManualReport.Rows.Add();
                dataGridViewManualReport.Rows[n].Cells[0].Value = dr[1].ToString();
                dataGridViewManualReport.Rows[n].Cells[1].Value = dr[2].ToString();
                dataGridViewManualReport.Rows[n].Cells[2].Value = dr[3].ToString();
                dataGridViewManualReport.Rows[n].Cells[3].Value = dr[4].ToString();
                if (dr[5].ToString() == "Fined")
                    dataGridViewManualReport.Rows[n].Cells[4].Value = dr[6].ToString();
                else
                    dataGridViewManualReport.Rows[n].Cells[4].Value = dr[5].ToString();

            }

            state.con.Close();
        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (t2_class.SelectedIndex == 0)
            {
                t2_class.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Class.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           /* if (t2_month.SelectedIndex == 0)
            {
                t2_month.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Month.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/
            if (t2_year.SelectedIndex == 0)
            {
                t2_year.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Year.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t2_class.SelectedIndex != 0 && t2_year.SelectedIndex != 0)
            {
                state.clearVirtualtbl();
                string query = "";
                string order_by = "roll_no";
                if (t2_order.SelectedIndex == 1)
                    order_by = "absenties";
                if (t2_order.SelectedIndex == 2)
                    order_by = "fine";
                if (t2_cat.SelectedIndex == 0)
                {
                    query = "select manualFinetbl.roll_no AS [Roll No],teachertbl.t_name AS [Prof. Name]," +
                          "subjecttbl.subject_name AS Subject,manualFinetbl.absenties AS Absentees,"+
                          "manualFinetbl.status AS Status," +
                          "manualFinetbl.fine AS Fine from manualFinetbl , teachertbl, subjecttbl " +
                          "where manualFinetbl.year='" + t2_year.SelectedItem.ToString() +
                          "' and manualFinetbl.class_name='" + t2_class.SelectedItem.ToString() +
                          "' and manualFinetbl.teacher_id=teachertbl.teacher_id " +
                          "and manualFinetbl.subject_id= subjecttbl.subject_id ";
                          if (t2_month.SelectedIndex != 0)
                          {
                        query += "and manualFinetbl.month='" + t2_month.SelectedIndex + " '";
                           }
                    query+= "order by " + order_by + ";";
                }
                if (t2_cat.SelectedIndex == 1)
                {
                    query = "select manualFinetbl.roll_no AS [Roll No],teachertbl.t_name AS [Prof. Name]," +
                          "subjecttbl.subject_name AS Subject,manualFinetbl.absenties AS Absentees," +
                          "manualFinetbl.status AS Status," +
                          "manualFinetbl.fine AS Fine  from manualFinetbl , " +
                        "teachertbl, subjecttbl where " +
                        "manualFinetbl.year='" + t2_year.SelectedItem.ToString() + "' ";

                    if (t2_month.SelectedIndex != 0)
                    {
                        query += "and manualFinetbl.month='" + t2_month.SelectedIndex + " '";
                    }

                    query += " and manualFinetbl.class_name='" + t2_class.SelectedItem.ToString() +
                             "' and manualFinetbl.status='Struck Off' " +
                             " and manualFinetbl.teacher_id=teachertbl.teacher_id and " +
                             " manualFinetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
                }
                if (t2_cat.SelectedIndex == 2)
                {
                    query = "select manualFinetbl.roll_no AS [Roll No],teachertbl.t_name AS [Prof. Name]," +
                          "subjecttbl.subject_name AS Subject,manualFinetbl.absenties AS Absentees," +
                          "manualFinetbl.status AS Status," +
                          "manualFinetbl.fine AS Fine  from manualFinetbl , " +
                        "teachertbl, subjecttbl where " +
                        " manualFinetbl.year='" + t2_year.SelectedItem.ToString() + "' ";

                    if (t2_month.SelectedIndex != 0)
                    {
                        query += "and manualFinetbl.month='" + t2_month.SelectedIndex + " '";
                    }

                    query += " and manualFinetbl.class_name='" + t2_class.SelectedItem.ToString() +
                             "' and manualFinetbl.status='Fined' " +
                             " and manualFinetbl.teacher_id=teachertbl.teacher_id and " +
                             " manualFinetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
                }
                state.con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, state.con);
                sda.Fill(dt);

                if (dataGridViewManualReport.DataSource != null)
                {
                    dataGridViewManualReport.DataSource = null;
                    dataGridViewManualReport.Rows.Clear();
                }
                //foreach (DataRow dr in dt.Rows)
                //{

                //    if (dr[4].ToString() != "Clear" || Convert.ToInt32(dr[5].ToString()) > 0)
                //    {
                //        if (dr[4].ToString() == "Clear")
                //        {
                //            fillVirtualtbl(dr);
                //        }
                //        else
                //            struckoff(dr);
                //    }
                //}

                if (dt.Rows.Count < 0)
                {
                    dataGridViewManualReport.Rows.Clear();
                    MessageBox.Show("No Record Found For this Month", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                state.con.Close();
                if (dt.Rows.Count > 0)
                {
                    //fine_to_final();
                    //struck_to_final();
                    //load();

                    dataGridViewManualReport.DataSource = dt;
                }
            }
        }


        private void t_class_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            t_class.BackColor = Color.White;
            if (t_class.SelectedIndex == 0)
            {
                select_subject.Items.Clear();
                select_subject.Items.Add("..Select..");
                select_subject.SelectedIndex = 0;
            }
            if (t_class.SelectedIndex != 0)
            {
                select_subject.Items.Clear();
                select_subject.Items.Add("..Select..");
                select_subject.SelectedIndex = 0;
                load_subject();

            }
        }

        private void select_subject_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            select_subject.BackColor = Color.White;
        }

        private void month_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            month.BackColor = Color.White;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (t_class.SelectedIndex == 0)
            {
                t_class.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Class.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (select_subject.SelectedIndex == 0)
            {
                select_subject.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Subject.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (month.SelectedIndex == 0)
            {
                month.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Month.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t_year.SelectedIndex == 0)
            {
                t_year.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Year.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t_class.SelectedIndex != 0 && select_subject.SelectedIndex != 0 && month.SelectedIndex != 0 && t_year.SelectedIndex != 0)
            {
                string query = "";
                string order_by = "s_id";
                if (orderby.SelectedIndex == 1)
                    order_by = "presents";
                if (orderby.SelectedIndex == 2)
                    order_by = "absenties";
                if (orderby.SelectedIndex == 3)
                    order_by = "fine";
                if (t1_cat.SelectedIndex == 0)
                    query = "select finetbl.s_id,teachertbl.t_name ,subjecttbl.subject_name,finetbl.absenties,finetbl.leaves,finetbl.status,finetbl.fine  from finetbl , teachertbl, subjecttbl where finetbl.month='" + month.SelectedIndex + "' and finetbl.year='" + t_year.SelectedItem.ToString() + "' and finetbl.subject_id='" + select_subject.SelectedItem.ToString() + "' and finetbl.teacher_id=teachertbl.teacher_id and finetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
                if (t1_cat.SelectedIndex == 1)
                    query = "select finetbl.s_id,teachertbl.t_name ,subjecttbl.subject_name,finetbl.absenties,finetbl.leaves,finetbl.status,finetbl.fine  from finetbl , teachertbl, subjecttbl where finetbl.month='" + month.SelectedIndex + "' and finetbl.year='" + t_year.SelectedItem.ToString() + "' and finetbl.subject_id='" + select_subject.SelectedItem.ToString() + "' and finetbl.status='Struck Off' and finetbl.teacher_id=teachertbl.teacher_id and finetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
                if (t1_cat.SelectedIndex == 2)
                    query = "select finetbl.s_id,teachertbl.t_name ,subjecttbl.subject_name,finetbl.absenties,finetbl.leaves,finetbl.status,finetbl.fine  from finetbl , teachertbl, subjecttbl where finetbl.month='" + month.SelectedIndex + "' and finetbl.year='" + t_year.SelectedItem.ToString() + "' and finetbl.subject_id='" + select_subject.SelectedItem.ToString() + "' and finetbl.status='Fined' and finetbl.teacher_id=teachertbl.teacher_id and finetbl.subject_id= subjecttbl.subject_id order by " + order_by + ";";
                state.con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, state.con);
                sda.Fill(dt);
                dataGridViewReport.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridViewReport.Rows.Add();
                    dataGridViewReport.Rows[n].Cells[0].Value = dr[0].ToString();
                    dataGridViewReport.Rows[n].Cells[1].Value = dr[1].ToString();
                    dataGridViewReport.Rows[n].Cells[2].Value = dr[2].ToString();
                    dataGridViewReport.Rows[n].Cells[3].Value = dr[3].ToString();
                    dataGridViewReport.Rows[n].Cells[4].Value = dr[4].ToString();
                    if (dr[5].ToString() == "Fined")
                        dataGridViewReport.Rows[n].Cells[5].Value = dr[6].ToString();
                    else
                        dataGridViewReport.Rows[n].Cells[5].Value = dr[5].ToString();
                }
                if (dt.Rows.Count < 0)
                    MessageBox.Show("No Record Found For this Month", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                state.con.Close();

            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {

        }

        private void due_date_TextChanged_1(object sender, EventArgs e)
        {
            due_date.BackColor = Color.White;
        }



        private void t_year_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            t_year.BackColor = Color.White;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewReport.Rows.Count > 0)
            {
                if (due_date.Text == "")
                {
                    due_date.BackColor = Color.Red;
                    MessageBox.Show("Please Enter Fine Due Date");
                    due_date.Focus();
                    return;
                }
                if (due_date.Text != "")
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

                                Paragraph p = new Paragraph("Fine List of " + t_class.SelectedItem.ToString() + " Students " + month.SelectedItem.ToString() + " " + t_year.SelectedItem.ToString() + " " + "\n", h_font);
                                p.Alignment = Element.ALIGN_CENTER;

                                doc.Add(p);

                                h_font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                                Paragraph p2 = new Paragraph("Submission Of Fine Due Date : " + due_date.Text.ToString() + "\n\n", h_font);
                                p2.Alignment = Element.ALIGN_CENTER;

                                doc.Add(p2);

                                PdfPTable table = new PdfPTable(dataGridViewReport.Columns.Count);

                                //table header
                                for (int i = 0; i < dataGridViewReport.Columns.Count; i++)
                                {
                                    table.AddCell(new Phrase(dataGridViewReport.Columns[i].HeaderText));

                                }
                                table.HeaderRows = 1;

                                //addind rows 
                                for (int i = 0; i < dataGridViewReport.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dataGridViewReport.Columns.Count; j++)
                                    {
                                        if (dataGridViewReport[j, i].Value != null)
                                        {
                                            table.AddCell(new Phrase(dataGridViewReport[j, i].Value.ToString()));
                                        }
                                    }
                                }

                                doc.Add(table);
                                doc.Close();
                            }
                        }

                    }
                }
                dataGridViewReport.Rows.Clear();
            }
            else
                MessageBox.Show("Get The Record First.");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (dataGridViewManualReport.Rows.Count > 0)
            {
                if (t2_due_date.Text == "")
                {
                    t2_due_date.BackColor = Color.Red;
                    MessageBox.Show("Please Enter Fine Due Date");
                    t2_due_date.Focus();
                    return;
                }
                if (t2_due_date.Text != "")
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

                                Paragraph p = new Paragraph("Fine List of " + t2_class.SelectedItem.ToString() + " Students " + t2_month.SelectedItem.ToString() + " " + t2_year.SelectedItem.ToString() + " " + "\n", h_font);
                                p.Alignment = Element.ALIGN_CENTER;

                                doc.Add(p);

                                h_font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                                Paragraph p2 = new Paragraph("Submission Of Fine Due Date : " + t2_due_date.Text.ToString() + "\n\n", h_font);
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
                dataGridViewManualReport.Rows.Clear();
            }
            else
                MessageBox.Show("Get The Record First.");
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            t3_roll.BackColor = Color.White;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (t3_roll.Text == "")
            {
                t3_roll.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Enter Roll No.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t3_class.SelectedIndex == 0)
            {
                t3_class.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Class.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t3_year.SelectedIndex == 0)
            {
                t3_year.BackColor = Color.OrangeRed;
                MessageBox.Show("Please Select Year.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (t3_roll.Text != "" && t3_class.SelectedIndex != 0 && t3_month.SelectedIndex != 0 && t3_year.SelectedIndex != 0)
            {
                searchGird(1);
            }
            else if (t3_roll.Text != "" && t3_class.SelectedIndex != 0 && t3_year.SelectedIndex != 0)
            {
                searchGird(2);
            }
        }

        private void t3_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            t3_class.BackColor = Color.White;
        }

        private void t3_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            t3_month.BackColor = Color.White;
        }

        private void t3_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            t3_year.BackColor = Color.White;
        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void t2_cat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}