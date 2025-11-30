using DataGridView.App.Forms;
using DataGridView.MemoryStorage;
using DataGridView.MemoryStorage.Contracts;

namespace DataGridView.App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            IApplicantStorage applicantService = new InMemoryStorage();
            Application.Run(new MainForm(applicantService));
        }
    }
}