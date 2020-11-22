using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace Semester_MS
{
    public partial class student_view : Form
    {
        public student_view()
        {
            InitializeComponent();
            load_info();
            load_year();
            
        }
        public void load_info()
        {
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select studenttbl.reg_no,studenttbl.roll_no,studenttbl.s_id,studenttbl.student_name,studenttbl.email, classtbl.class_name,coursestbl.course_name,sectiontbl.section_name, session  from studenttbl , coursestbl,sectiontbl,classtbl where studenttbl.s_id='"+state.Student_login_id+"' and studenttbl.class_id=classtbl.class_id and studenttbl.course_id=coursestbl.course_id and studenttbl.section_id=sectiontbl.section_id;", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                reg_no.Text = dr[0].ToString();
                roll_no.Text= dr[1].ToString();
                s_id.Text= dr[2].ToString();
                name.Text= dr[3].ToString(); 
                email.Text= dr[4].ToString();
                class_name.Text= dr[5].ToString();
                course.Text= dr[6].ToString();
                section.Text= dr[7].ToString();
                session.Text = dr[8].ToString() + " - ";
                session.Text += (dr[5].ToString().Contains("Year")) ? Convert.ToInt32(dr[8].ToString())+2: Convert.ToInt32(dr[8].ToString()) + 4;
            }
            state.con.Close();
        }
        public void load_attendence(bool allMonths=false)
        {
        
            state.con.Open();
            string query = "select subjecttbl.subject_name, teachertbl.t_name, manualFinetbl.lec_delivered," +
                "manualFinetbl.presents,manualFinetbl.absenties,manualFinetbl.leaves," +
                "manualFinetbl.status, manualFinetbl.fine, month, year " +
                "from manualFinetbl,teachertbl,subjecttbl " +
                "where  manualFinetbl.class_name='" + class_name.Text.ToString() + "' " +
                "and manualFinetbl.roll_no='" + Convert.ToInt32(roll_no.Text) + "' ";
            //"and manualFinetbl.section_name='" + section.Text.ToString()+"' "+
            query += (!allMonths) ? "and manualFinetbl.month='" + month.SelectedIndex + "' "+
                                    "and manualFinetbl.year='" + year.SelectedItem.ToString() + "' ":"";
            query += "and manualFinetbl.teacher_id=teachertbl.teacher_id " +
                "and manualFinetbl.subject_id=subjecttbl.subject_id; ";

            SqlCommand cmd = new SqlCommand(query, state.con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dataGridView.Rows.Clear();
               while(dr.Read())
                {
                    int n = dataGridView.Rows.Add();
                    dataGridView.Rows[n].Cells[0].Value = dr[0].ToString();
                    dataGridView.Rows[n].Cells[1].Value = dr[1].ToString();
                    dataGridView.Rows[n].Cells[2].Value = dr[2].ToString();
                    dataGridView.Rows[n].Cells[3].Value = dr[3].ToString();
                    dataGridView.Rows[n].Cells[4].Value = dr[4].ToString();
                    dataGridView.Rows[n].Cells[5].Value = dr[5].ToString();
                    dataGridView.Rows[n].Cells[7].Value = dr[8].ToString();

                    if (allMonths)
                        dataGridView.Rows[n].Cells[8].Value = dr[9].ToString();
                    else
                        dataGridView.Rows[n].Cells[8].Value = year.Text;

                    dataGridView.Rows[n].Cells[7].Value = dr[8].ToString();

                    if (dr[6].ToString() == "Fined")
                    {
                        dataGridView.Rows[n].Cells[6].Value = dr[7].ToString();
                    }
                    else
                        dataGridView.Rows[n].Cells[6].Value = dr[6].ToString();  
                         
                }               
            }
            else
            {
                dataGridView.Rows.Clear();
                MessageBox.Show("No Record Found Yet");              
            }
            state.con.Close();
        }
        public void load_year()
        {
            state.con.Open();
            SqlCommand cmd = new SqlCommand("select * from yeartbl;", state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {               
                while (dr.Read())
                {
                    year.Items.Add(dr[1].ToString());
                }
            }
            dr.Close();
            state.con.Close();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.authorized = false;
            Program.panels = 0;
            Program.mainMenu = true;
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(delegate
            {
                Application.Run(new student_p_change());
            }));
            t.Start();
            t.Join();
        }

        private void student_view_Load(object sender, EventArgs e)
        {
            month.SelectedIndex = 0;
            year.SelectedIndex = 0;

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Aerial", 10.8F, FontStyle.Bold);
            dataGridView.EnableHeadersVisualStyles = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void month_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(month.SelectedIndex!=0 && year.SelectedIndex != 0)
            {
            //    MessageBox.Show("calling");
                load_attendence();
            }
        }

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (month.SelectedIndex != 0 && year.SelectedIndex != 0)
            {
            //    MessageBox.Show("calling");
                load_attendence();
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reg_no_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (month.SelectedIndex != 0 && year.SelectedIndex != 0)
            {
                //    MessageBox.Show("calling");
                load_attendence();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //if (year.SelectedIndex == 0)
            //    MessageBox.Show("Choose Year");
            //else
                load_attendence(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (month.SelectedIndex != 0 && year.SelectedIndex != 0)
                load_attendence();
            else
                MessageBox.Show("Choose Month and Year");
        }
    }
}
