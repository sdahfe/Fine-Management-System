namespace Semester_MS
{
    partial class admin_view
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.admin_id_show = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.General_Setting = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewManualReport = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.btn_unique = new System.Windows.Forms.Button();
            this.label45 = new System.Windows.Forms.Label();
            this.button15 = new System.Windows.Forms.Button();
            this.t2_cat = new System.Windows.Forms.ComboBox();
            this.button14 = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.t2_year = new System.Windows.Forms.ComboBox();
            this.t2_month = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.t2_order = new System.Windows.Forms.ComboBox();
            this.t2_class = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.t2_due_date = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.General_Setting.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManualReport)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.changePasswordToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1004, 27);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(45, 23);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem1
            // 
            this.changePasswordToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.changePasswordToolStripMenuItem1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePasswordToolStripMenuItem1.Name = "changePasswordToolStripMenuItem1";
            this.changePasswordToolStripMenuItem1.Size = new System.Drawing.Size(70, 23);
            this.changePasswordToolStripMenuItem1.Text = "&Setting";
            this.changePasswordToolStripMenuItem1.Click += new System.EventHandler(this.changePasswordToolStripMenuItem1_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.changePasswordToolStripMenuItem.Text = "&Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.logoutToolStripMenuItem.Text = "&Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(878, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Admin ID :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // admin_id_show
            // 
            this.admin_id_show.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.admin_id_show.AutoSize = true;
            this.admin_id_show.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_id_show.Location = new System.Drawing.Point(962, 4);
            this.admin_id_show.Name = "admin_id_show";
            this.admin_id_show.Size = new System.Drawing.Size(16, 18);
            this.admin_id_show.TabIndex = 11;
            this.admin_id_show.Text = "0";
            this.admin_id_show.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 102);
            this.button1.TabIndex = 0;
            this.button1.Text = "General Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Location = new System.Drawing.Point(148, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 102);
            this.button2.TabIndex = 1;
            this.button2.Text = "Teacher Settings";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.Location = new System.Drawing.Point(296, 0);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 102);
            this.button3.TabIndex = 2;
            this.button3.Text = "Student Settings";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 102);
            this.panel1.TabIndex = 21;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.General_Setting);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1004, 582);
            this.tabControl1.TabIndex = 22;
            // 
            // General_Setting
            // 
            this.General_Setting.Controls.Add(this.panel1);
            this.General_Setting.Location = new System.Drawing.Point(4, 22);
            this.General_Setting.Margin = new System.Windows.Forms.Padding(2);
            this.General_Setting.Name = "General_Setting";
            this.General_Setting.Padding = new System.Windows.Forms.Padding(2);
            this.General_Setting.Size = new System.Drawing.Size(996, 556);
            this.General_Setting.TabIndex = 0;
            this.General_Setting.Text = "General";
            this.General_Setting.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewManualReport);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(996, 556);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Report";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewManualReport
            // 
            this.dataGridViewManualReport.AllowUserToAddRows = false;
            this.dataGridViewManualReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManualReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewManualReport.Location = new System.Drawing.Point(2, 109);
            this.dataGridViewManualReport.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewManualReport.Name = "dataGridViewManualReport";
            this.dataGridViewManualReport.RowTemplate.Height = 24;
            this.dataGridViewManualReport.Size = new System.Drawing.Size(992, 445);
            this.dataGridViewManualReport.TabIndex = 103;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.SearchBox);
            this.panel2.Controls.Add(this.btn_unique);
            this.panel2.Controls.Add(this.label45);
            this.panel2.Controls.Add(this.button15);
            this.panel2.Controls.Add(this.t2_cat);
            this.panel2.Controls.Add(this.button14);
            this.panel2.Controls.Add(this.label34);
            this.panel2.Controls.Add(this.label46);
            this.panel2.Controls.Add(this.t2_year);
            this.panel2.Controls.Add(this.t2_month);
            this.panel2.Controls.Add(this.label42);
            this.panel2.Controls.Add(this.t2_order);
            this.panel2.Controls.Add(this.t2_class);
            this.panel2.Controls.Add(this.label44);
            this.panel2.Controls.Add(this.label43);
            this.panel2.Controls.Add(this.t2_due_date);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(992, 107);
            this.panel2.TabIndex = 102;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(434, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 104;
            this.label2.Text = "Search by Name";
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(434, 72);
            this.SearchBox.Multiline = true;
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(175, 27);
            this.SearchBox.TabIndex = 103;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // btn_unique
            // 
            this.btn_unique.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_unique.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_unique.Location = new System.Drawing.Point(620, 0);
            this.btn_unique.Margin = new System.Windows.Forms.Padding(2);
            this.btn_unique.Name = "btn_unique";
            this.btn_unique.Size = new System.Drawing.Size(124, 107);
            this.btn_unique.TabIndex = 102;
            this.btn_unique.Text = "Unique";
            this.btn_unique.UseVisualStyleBackColor = true;
            this.btn_unique.Click += new System.EventHandler(this.btn_unique_Click);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(162, 53);
            this.label45.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(68, 16);
            this.label45.TabIndex = 101;
            this.label45.Text = "Category";
            // 
            // button15
            // 
            this.button15.Dock = System.Windows.Forms.DockStyle.Right;
            this.button15.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.Location = new System.Drawing.Point(744, 0);
            this.button15.Margin = new System.Windows.Forms.Padding(2);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(124, 107);
            this.button15.TabIndex = 76;
            this.button15.Text = "Generate PDF";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click_1);
            // 
            // t2_cat
            // 
            this.t2_cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t2_cat.FormattingEnabled = true;
            this.t2_cat.Items.AddRange(new object[] {
            "........Both......",
            ".struck OFF.",
            ".....FINED......"});
            this.t2_cat.Location = new System.Drawing.Point(154, 75);
            this.t2_cat.Margin = new System.Windows.Forms.Padding(2);
            this.t2_cat.Name = "t2_cat";
            this.t2_cat.Size = new System.Drawing.Size(111, 24);
            this.t2_cat.TabIndex = 100;
            // 
            // button14
            // 
            this.button14.Dock = System.Windows.Forms.DockStyle.Right;
            this.button14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.Location = new System.Drawing.Point(868, 0);
            this.button14.Margin = new System.Windows.Forms.Padding(2);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(124, 107);
            this.button14.TabIndex = 78;
            this.button14.Text = "Get Attendance";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click_1);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(292, 6);
            this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(101, 16);
            this.label34.TabIndex = 99;
            this.label34.Text = "Select Session";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(153, 6);
            this.label46.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(93, 16);
            this.label46.TabIndex = 95;
            this.label46.Text = "Select Month";
            // 
            // t2_year
            // 
            this.t2_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t2_year.FormattingEnabled = true;
            this.t2_year.Items.AddRange(new object[] {
            "Years"});
            this.t2_year.Location = new System.Drawing.Point(295, 26);
            this.t2_year.Margin = new System.Windows.Forms.Padding(2);
            this.t2_year.Name = "t2_year";
            this.t2_year.Size = new System.Drawing.Size(134, 24);
            this.t2_year.TabIndex = 92;
            // 
            // t2_month
            // 
            this.t2_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t2_month.FormattingEnabled = true;
            this.t2_month.Items.AddRange(new object[] {
            "Months",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.t2_month.Location = new System.Drawing.Point(154, 26);
            this.t2_month.Margin = new System.Windows.Forms.Padding(2);
            this.t2_month.Name = "t2_month";
            this.t2_month.Size = new System.Drawing.Size(111, 24);
            this.t2_month.TabIndex = 91;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(14, 6);
            this.label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(85, 16);
            this.label42.TabIndex = 98;
            this.label42.Text = "Select Class";
            // 
            // t2_order
            // 
            this.t2_order.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t2_order.FormattingEnabled = true;
            this.t2_order.Items.AddRange(new object[] {
            "Roll No.",
            "Absents",
            "Fine"});
            this.t2_order.Location = new System.Drawing.Point(2, 75);
            this.t2_order.Margin = new System.Windows.Forms.Padding(2);
            this.t2_order.Name = "t2_order";
            this.t2_order.Size = new System.Drawing.Size(120, 24);
            this.t2_order.TabIndex = 93;
            // 
            // t2_class
            // 
            this.t2_class.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t2_class.FormattingEnabled = true;
            this.t2_class.Items.AddRange(new object[] {
            "..Select.."});
            this.t2_class.Location = new System.Drawing.Point(2, 28);
            this.t2_class.Margin = new System.Windows.Forms.Padding(2);
            this.t2_class.Name = "t2_class";
            this.t2_class.Size = new System.Drawing.Size(120, 24);
            this.t2_class.TabIndex = 90;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(14, 53);
            this.label44.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(65, 16);
            this.label44.TabIndex = 96;
            this.label44.Text = "Order By";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(308, 55);
            this.label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(85, 19);
            this.label43.TabIndex = 97;
            this.label43.Text = "Due Date";
            // 
            // t2_due_date
            // 
            this.t2_due_date.Location = new System.Drawing.Point(295, 80);
            this.t2_due_date.Margin = new System.Windows.Forms.Padding(2);
            this.t2_due_date.Name = "t2_due_date";
            this.t2_due_date.Size = new System.Drawing.Size(134, 20);
            this.t2_due_date.TabIndex = 94;
            this.t2_due_date.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.t2_due_date_ControlAdded);
            // 
            // admin_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1004, 609);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.admin_id_show);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "admin_view";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin View";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.admin_view_FormClosing);
            this.Load += new System.EventHandler(this.admin_view_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.admin_view_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.General_Setting.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManualReport)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label admin_id_show;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage General_Setting;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.ComboBox t2_cat;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.ComboBox t2_year;
        private System.Windows.Forms.ComboBox t2_month;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ComboBox t2_order;
        private System.Windows.Forms.ComboBox t2_class;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox t2_due_date;
        private System.Windows.Forms.DataGridView dataGridViewManualReport;
        private System.Windows.Forms.Button btn_unique;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label label2;
    }
}