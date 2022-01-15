using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EliteTeam
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
            Squad squad1 = RandomPlayerFactory.GetRandomSquad();
            Squad squad2 = RandomPlayerFactory.GetRandomSquad();
            Manager manager1 = new Manager("Danijel", 23);
            Manager manager2 = new Manager("Paulo", 23);
            Club homeClub = new Club("Hajduk", "HAJ", squad1, manager1);
            Club awayClub = new Club("Rijeka", "RIJ", squad2, manager2);
            Simulator.IMatchSimulator matchSimulator = new Simulator.MyMatchSimulator();
            matchSimulator.Simulate(homeClub, awayClub);
        }
    }
}
