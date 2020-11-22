using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Semester_MS
{
    public partial class MM : Form
    {
        public MM() //Main Manu class constrator
        {
            InitializeComponent(); // This is required method for designer
        }
        
        //This function will exit application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Are you sure", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                Application.Exit();
            }
            //this.Close();
        }

        private void start_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.mainMenu = false;
           /* DialogResult d;
            d = MessageBox.Show("Welcome to C# Corner", "Learn C#", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                Application.Exit();
            }*/

        }
        //Picture box for adminsitrator
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Program.panels = 1;
            this.Close();
        }
        //Picture box for Professor 
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Program.panels = 2;
            this.Close();
        }
        //Picture box for Student
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Program.panels = 3;
            this.Close();
        }
        //this code is for keypress events for adminsitrator,Professor and Student
        private void MM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.F1)
            {
                Program.panels = 1;
                this.Close();
            }
            else if (e.KeyChar == (char)Keys.F2)
            {
                Program.panels = 1;
                this.Close();
            }
            else if (e.KeyChar == (char)Keys.F3)
            {
                Program.panels = 1;
                this.Close();
            }
        }
        //This button is for adminsitrator satting
        private void button1_Click(object sender, EventArgs e)
        {
            Program.panels = 1;
            this.Close();
            
        }
        //This button is for Professor satting
        private void button2_Click(object sender, EventArgs e)
        {
            Program.panels = 2;
            this.Close();
        }
        //This button is for student satting
        private void button3_Click(object sender, EventArgs e)
        {
            Program.panels = 3;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MM_Load(object sender, EventArgs e)
        {
            Program.mainMenu = false;
        }

        private void MM_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void MM_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Welcome to C# Corner", "Learn C#", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
