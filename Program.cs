using System;
using System.Windows.Forms;

namespace jandm_pos
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start with your login form
            Application.Run(new Forms.LoginForm());
        }
    }
}
