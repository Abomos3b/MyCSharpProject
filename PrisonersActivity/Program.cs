using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using PrisonersActivity.BE;
using PrisonersActivity.Forms;
using ZGTools;
using ZGTools.Funs;

namespace PrisonersActivity
{
    internal static class Program
    {
        private static int GetNumberOfProcesses()
        {
            var current = Process.GetCurrentProcess();
            const string prcName = "PrisonersActivity";

            return Process.GetProcessesByName(current.ProcessName).Count(proc => string.Equals(proc.ProcessName, prcName, StringComparison.CurrentCultureIgnoreCase));


        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ZLicense.SetLicense("");
            var process = GetNumberOfProcesses();
            if (process > 1)
            {
                ZEntry.ShowErrorMessage("البرنامج مفتوح من قبل", "خطأ", true);

            }
            else
            {
                ClsVarslocal.LoadSettings();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var culture = CultureInfo.CreateSpecificCulture("ar-SA");
                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;

                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
                

                Application.Run(FrmHomePage.GetInstance());

                
            }

        }
    }
}
