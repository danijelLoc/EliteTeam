using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using EliteTeam.Controllers;
using EliteTeam.MemoryBasedDAL;
using EliteTeam.PresentationLayer;

namespace EliteTeam.AppStarter
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WindowFormsFactory _formsFactory = new WindowFormsFactory();

            MainFormController mainController = new MainFormController(_formsFactory, PlayerRepository.Shared);
            mainController.RunAll();
            /*Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/

        }
    }
}
