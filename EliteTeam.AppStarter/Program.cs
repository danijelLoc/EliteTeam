using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EliteTeam.Controllers;
using EliteTeam.Model;
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
            WindowsFormsFactory _formsFactory = new WindowsFormsFactory();
            MainController mainController = new MainController(_formsFactory,
                PlayerRepository.Shared,
                ClubRepository.Shared,
                MatchResultRepository.Shared);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainForm(mainController));
        }
    }
}
