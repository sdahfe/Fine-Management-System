using iText.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Org.BouncyCastle.Crypto.Tls;

namespace Semester_MS
{
    public partial class admin_view : Form
    {
        
        public admin_view()
        {
            InitializeComponent();
            set();
        }

        public void set()
        {

            state.con.Open();
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-0EGE15A;Initial Catalog=gpgc;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from classtbl",state.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    t2_class.Items.Add(dr[1].ToString());
                }
            }
            dr.Close();
            cmd.CommandText = "select * from yeartbl";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                t2_year.Items.Clear();
                t2_year.Items.Add("........Year......");
                t2_year.SelectedIndex = 0;
                while (dr.Read())
                {
                    t2_year.Items.Add(dr[1].ToString());
                }
            }
            state.con.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Are you sure", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                Application.Exit();
            }
            //Program.mainMenu = false;
            //Program.panels = 0;
            //this.Close();
        }

      

        private void admin_view_Load(object sender, EventArgs e)
        {
            admin_id_show.Text = state.Admin_login_id.ToString();

            t2_cat.SelectedIndex = 0;
            t2_class.SelectedIndex = 0;
            t2_month.SelectedIndex = 0;
            t2_order.SelectedIndex = 0;
            t2_year.SelectedIndex = 0;
            t2_due_date.Text = DateTime.Today.ToShortDateString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }


        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(delegate
            {
                Application.Run(new admin_ch_pass());
            }));
            t.Start();
            t.Join();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Are you sure", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                admin_panel ap = new admin_panel();
                this.Hide();
                ap.ShowDialog();
                this.Close();
            }
            //admin_panel ap = new admin_panel();
            //ap.Show();
            //this.Hide();
            
        }
       
        private void label3_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
            {
                Application.Run(new teacher_setting());
            })).Start();
        }
       
        private void label4_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
            {
                Application.Run(new student_setting());
            })).Start();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
            {
                Application.Run(new report());
            })).Start();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
            {
                Application.Run(new general_setting());
            })).Start();
        }
        bool cancel = true;
        private void admin_view_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.mainMenu = false;
            //this.Close();
            /*if (cancel)
            {
                DialogResult d;
                d = MessageBox.Show("Are you sure", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                { 
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                } 
            }*/
        }
        //this button is for general sitting in admin view panel
        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
            {
                Application.Run(new general_setting());
                //this.Close();
            })).Start();
            this.Close();
        }
        //this button is for teacher sitting in admin view panel
        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
            {
                Application.Run(new teacher_setting());
            })).Start();
            this.Close();
        }
        //this button is for student sitting in admin view panel
        private void button3_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
            {
                Application.Run(new student_setting());
            })).Start();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(delegate
            {
                Application.Run(new report());
            }));
            t.Start();
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }
      
        private void button15_Click_1(object sender, EventArgs e)
        {

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
                        iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LEGAL, 0, 0, 0, 0);
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
                                            h_font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                                            table.AddCell(new Phrase(dataGridViewManualReport.Columns[i].HeaderText, h_font));

                                        }
                                        table.HeaderRows = 1;

                                        //addind rows 
                                        for (int i = 0; i < dataGridViewManualReport.Rows.Count; i++)
                                        {
                                            for (int j = 0; j < dataGridViewManualReport.Columns.Count; j++)
                                            {

                                                if (dataGridViewManualReport[j, i].Value != null)
                                                {
                                                    if (j == 0)
                                                    {
                                                        h_font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                                                        table.AddCell(new Phrase(dataGridViewManualReport[j, i].Value.ToString(), h_font));
                                                        j++;
                                                    }
                                                    //h_font = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
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
                    //dataGridViewManualReport.Rows.Clear();
                }
                else
                    MessageBox.Show("Get The Record First.");
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
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
                          "subjecttbl.subject_name AS Subject,manualFinetbl.absenties AS Absentees," +
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
                    query += "order by " + order_by + ";";
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
               // SqlConnection con = new SqlConnection("Data Source=DESKTOP-0EGE15A;Initial Catalog=gpgc;Integrated Security=True");
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

        private void t2_due_date_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void admin_view_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btn_unique_Click(object sender, EventArgs e)
        {
            getAttendance();

            //int rollno = (int)dt.Rows[0][0];
            //for(int i =1; i<)
            
        }
        private void getAttendance()
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
                string order_by = "roll_no, Absentees desc";
                if (t2_order.SelectedIndex == 1)
                    order_by = "absenties desc, roll_no";
                if (t2_order.SelectedIndex == 2)
                    order_by = "fine dese , roll_no";
                if (t2_cat.SelectedIndex == 0)
                {
                    query = "select distinct manualFinetbl.roll_no AS [Roll No],teachertbl.t_name AS [Prof. Name]," +
                          "subjecttbl.subject_name AS Subject,manualFinetbl.absenties AS Absentees," +
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
                    query += "order by " + order_by + ";";
                }
                if (t2_cat.SelectedIndex == 1)
                {
                    query = "select distinct manualFinetbl.roll_no AS [Roll No],teachertbl.t_name AS [Prof. Name]," +
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
                    query = "select distinct manualFinetbl.roll_no AS [Roll No],teachertbl.t_name AS [Prof. Name]," +
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
                // SqlConnection con = new SqlConnection("Data Source=DESKTOP-0EGE15A;Initial Catalog=gpgc;Integrated Security=True");
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
                    DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
                    columnHeaderStyle.BackColor = Color.Aqua;
                    columnHeaderStyle.Font = new System.Drawing.Font("Vendana", 10, FontStyle.Bold);
                    dataGridViewManualReport.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
        
                      }
                   }
                }

        private void t4_s_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //state.con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from manualFinetbl where roll_no = '" + SearchBox.Text.ToString() + "'",state.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
               // dataGridViewManualReport.DataSource = null;
                
                dataGridViewManualReport.Rows.Clear();
               // dataGridViewManualReport.Refresh();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridViewManualReport.Rows.Add();
                    dataGridViewManualReport.Rows[n].Cells[0].Value = dr[0].ToString();
                    dataGridViewManualReport.Rows[n].Cells[1].Value = dr[1].ToString();
                    dataGridViewManualReport.Rows[n].Cells[2].Value = dr[2].ToString();
                    dataGridViewManualReport.Rows[n].Cells[3].Value = dr[3].ToString();
                    dataGridViewManualReport.Rows[n].Cells[4].Value = dr[4].ToString();
                    dataGridViewManualReport.Rows[n].Cells[5].Value = dr[5].ToString();
                }
                state.con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
        }
    

