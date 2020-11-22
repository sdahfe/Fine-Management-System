using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semester_MS
{
    static class Program
    {
        public static bool mainMenu = true;
        public static bool authorized = false;
        public static byte panels;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //state.Admin_login_id = 1;
            //Application.Run(new admin_view());

            //state.Teacher_login_id = 3;
            //Application.Run(new teacher_view());

            //state.Student_login_id = 3;
            //Application.Run(new student_view());

            while (mainMenu)
            {
                Application.Run(new MM());

                switch (panels)
                {
                    case 1:
                        Application.Run(new admin_panel());
                        if (authorized)
                            Application.Run(new admin_view());
                        break;
                    case 2:
                        Application.Run(new teacher_Login());
                        if (authorized)
                            Application.Run(new teacher_view());
                        break;
                    case 3:
                        Application.Run(new student_login());
                        if (authorized)
                            Application.Run(new student_view());
                        break;
                }
            }
        }
    }
}
