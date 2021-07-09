using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donnatello
{    
    /// <summary>
    /// Main entry point of program.
    /// By Samuel Lightowler 2021.
    /// </summary>
    static class Program
    {
      
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Donnatello());
        }
    }
}
