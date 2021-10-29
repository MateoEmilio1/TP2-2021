using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MenuPrincipal(login.usr));
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
