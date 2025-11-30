using DataGridView.App.Forms;
using DataGridView.Manager;
using DataGridView.MemoryStorage;

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
            var applicants = new InMemoryStorage();
            var applicantManager = new ApplicantManager(applicants);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(applicantManager));
        }
    }
}