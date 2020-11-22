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
    public partial class teacher_setting : Form
    {
        SqlConnection con = new SqlConnection();
        public teacher_setting()
        {
            InitializeComponent();
            try
            {
                //state.con.Open();
                con.ConnectionString = (@"Data Source=DESKTOP-0EGE15A;Initial Catalog=gpgc;Integrated Security=True");
                show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void show()
        {
            try
            {
                //state.con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from teachertbl", con);
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
                }
               //state.con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                t1_rn.Text = (dataGridView1.Rows.Count+1).ToString();
            }
        }

        private void teacher_setting_Load(object sender, EventArgs e)
        {

            t2_email.Focus();
            t3_email.Focus();
            t4_s.Focus();
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10.8F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;       
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin_view av = new admin_view();
            this.Hide();
            av.ShowDialog();
            this.Close();
        }

        

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            t2_p.BackColor = Color.White;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        static bool get_success =false;
        static int t_id;
        private void button3_Click(object sender, EventArgs e)
        {
           bool t = true;
            get_success = false;           
            if (t2_t_id.Text == "")
            {
                t2_t_id.BackColor = Color.Red;
                MessageBox.Show("Please ID. ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t2_t_id.Focus();
                return;
            }
            if (t2_t_id.Text != "")
            {
                for (int a = 0; a < dataGridView1.RowCount; a++)
                {
                    int comp = Convert.ToInt32(dataGridView1.Rows[a].Cells[0].Value.ToString());
                    // MessageBox.Show(comp);
                    if (comp ==Convert.ToInt32(t2_t_id.Text))
                    {
                        t2_t_name.Text = dataGridView1.Rows[a].Cells[3].Value.ToString();
                        t2_p.Text = dataGridView1.Rows[a].Cells[2].Value.ToString();
                        t2_email.Text= dataGridView1.Rows[a].Cells[1].Value.ToString();
                        t = false;
                        get_success = true;
                        t_id =Convert.ToInt32(t2_t_id.Text);
                    }
                }
                if (t)
                {
                    t2_p.Text = "";
                    t2_t_name.Text = "";
                    t2_email.ResetText();
                    MessageBox.Show("Record Not Found.");
             
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            t2_t_name.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            if (t1_email.Text == "")
            {
                t1_email.BackColor = Color.Red;
                MessageBox.Show("Email must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_email.Focus();
                return;
            }
            if (t1_tdp.Text == "")
            {
                t1_tdp.BackColor = Color.Red;
                MessageBox.Show("Password  must be entered", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_tdp.Focus();
                return;
            }
            if (t1_t_name.Text == "")
            {
                t1_t_name.BackColor = Color.Red;
                MessageBox.Show("Teacher Name field must be filled!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t1_t_name.Focus();
                return;
            }
            if (t1_email.Text != "" && t1_tdp.Text != "" && t1_t_name.Text != "")
            {
                try
                {
                    bool t = true;
                    for (int a = 0; a < dataGridView1.RowCount; a++)
                    {                   
                        if (dataGridView1.Rows[a].Cells[1].Value.ToString() == t1_email.Text)
                            t = false;
                    }
                    if (t)
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "insert into teachertbl values(@email,@password,@t_name);";
                        cmd.Parameters.Add("@email", t1_email.Text);
                        cmd.Parameters.Add("@password", t1_tdp.Text);
                        cmd.Parameters.Add("@t_name", t1_t_name.Text);
                        cmd.ExecuteNonQuery();
                        t1_email.Text = "";
                        t1_tdp.Text = "";
                        t1_t_name.Text = "";
                        MessageBox.Show("New Record is added successfully!", "Record Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        show();
                    }
                    else
                        MessageBox.Show("That Email already Exist.. Use Another");
                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message);
                }
                catch (FormatException ex2)
                {
                    con.Close();
                    MessageBox.Show(ex2.Message);
                }

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (get_success)
            {
                if (t2_email.Text == "")
                {
                    t2_email.BackColor = Color.Red;
                    MessageBox.Show("Email field must be filled!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    t2_email.Focus();
                    return;
                }
                if (t2_t_name.Text == "")
                {
                    t2_t_name.BackColor = Color.Red;
                    MessageBox.Show("Name field must be filled!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    t2_t_name.Focus();
                    return;
                }
                if (t2_p.Text == "")
                {
                    t2_p.BackColor = Color.Red;
                    MessageBox.Show("Password must be entered!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    t2_p.Focus();
                    return;
                }
                if (t2_email.Text!="" && t2_t_name.Text != "" && t2_p.Text != "" &&Convert.ToInt32(t2_t_id.Text)==t_id)
                {
                    bool t = true;
                    try
                    {                        
                        for (int a = 0; a < dataGridView1.RowCount; a++)
                        {
                            if (dataGridView1.Rows[a].Cells[1].Value.ToString() == t2_email.Text)
                                t = false;
                        }
                        if (t)
                        {
                            con.Open();
                            string qry = "update teachertbl set t_name='" + t2_t_name.Text + "',password='" + t2_p.Text + "', email='" + t2_email.Text + "' where teacher_id='" + t_id + "'";
                            SqlCommand cmd = new SqlCommand(qry, con);
                            cmd.ExecuteNonQuery();
                            t2_email.Text = "";
                            t2_t_name.Text = "";
                            t2_p.Text = "";
                            t2_t_id.ResetText();
                            MessageBox.Show("Record Updated successfully!", "Record Modified", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            con.Close();
                            show();
                        }
                        else
                            MessageBox.Show("Email Already exist use another!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    t2_t_id.BackColor = Color.Red;
                    MessageBox.Show("Enter Correct ID!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    t2_t_id.Focus();
                    
                }
            }
            else 
            {
                t2_email.BackColor = Color.Red;
                MessageBox.Show("First Get the Record!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t2_email.Focus();
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (t3_t_id.Text == "")
            {
                t3_t_id.BackColor = Color.Red;
                MessageBox.Show("Please Enter ID. ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t3_t_id.Focus();
                return;
            }
            if (t3_t_id.Text != "")
            {
                bool t = true;
                for (int a = 0; a < dataGridView1.RowCount; a++)
                {
                    int comp = Convert.ToInt32(dataGridView1.Rows[a].Cells[0].Value.ToString());
                  if (comp == Convert.ToInt32(t3_t_id.Text))
                    {    
                        t3_email.Text = dataGridView1.Rows[a].Cells[1].Value.ToString();
                        t3_un.Text = dataGridView1.Rows[a].Cells[3].Value.ToString();
                        t3_p.Text = dataGridView1.Rows[a].Cells[2].Value.ToString();
                        t = false;
                    }
                }
                if (t)
                {
                    t3_un.Text = "";
                    t3_p.Text = "";
                    t3_t_id.ResetText();
                    MessageBox.Show("Record Not Found.");
                }
            }
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //admin_panel adp = new admin_panel();
            //adp.Show();
            //this.Hide();
            admin_panel ap = new admin_panel();
            this.Hide();
            ap.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (t3_t_id.Text == "")
            {
                t3_t_id.BackColor = Color.Red;
                MessageBox.Show("Please Enter ID!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t3_t_id.Focus();
                return;
            }                      
            if (t3_t_id.Text != "")
            {
                try
                {
                    con.Open();
                    string qry = "delete from teachertbl where teacher_id='" +Convert.ToInt32(t3_t_id.Text) + "'";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.ExecuteNonQuery();                  
                    qry = "delete from subjectAssignedtbl where teacher_id='" + Convert.ToInt32(t3_t_id.Text) + "'";
                   cmd = new SqlCommand(qry, con);
                    cmd.ExecuteNonQuery();
                    t3_email.Text = "";
                    t3_un.Text = "";
                    t3_p.Text = "";
                    t3_t_id.ResetText();
                    MessageBox.Show("Record Deleted successfully!", "Record Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    show();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try {
                //con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from teachertbl where t_name like '%" + t4_s.Text.ToString() + "%'", con);
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
                }
                //con.Close();
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void t1_tun_TextChanged(object sender, EventArgs e)
        {
            t1_email.BackColor = Color.White;
        }

        private void t1_tdp_TextChanged(object sender, EventArgs e)
        {
            t1_tdp.BackColor = Color.White;
        }

        private void t2_tid_TextChanged(object sender, EventArgs e)
        {
            t2_email.BackColor = Color.White;
        }

        private void t3_id_TextChanged(object sender, EventArgs e)
        {
            t3_email.BackColor = Color.White;
        }

        private void t3_un_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void t3_p_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void t1_tid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t2_tid_KeyPress(object sender, KeyPressEventArgs e)
        {/*
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }*/
        }

        private void t3_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.SkyBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.SkyBlue;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Transparent;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.SkyBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.SkyBlue;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Transparent;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.SkyBlue;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Transparent;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            t3_email.Focus();
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            t3_email.Focus();
        }

        private void tabControl3_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void t1_rn_TextChanged(object sender, EventArgs e)
        {

        }

        private void t1_t_name_TextChanged(object sender, EventArgs e)
        {
            t1_t_name.BackColor = Color.White;
        }

        private void t1_t_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t4_s_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t2_t_id_TextChanged(object sender, EventArgs e)
        {
            t2_t_id.BackColor = Color.White;
        }

        private void t2_t_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void t3_t_id_TextChanged(object sender, EventArgs e)
        {
            t3_t_id.BackColor = Color.White;
        }
        bool exit = true;
        private void teacher_setting_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
