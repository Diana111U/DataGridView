using DataGridView.App.Forms;
using DataGridView.Manager;
using DataGridView.MemoryStorage;
using Microsoft.Extensions.Logging;
using Serilog;

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
            using var log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File("logs/log-.txt",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.Seq("http://localhost:5341",
                    apiKey: "br0jBx1kqPztmNwXmsJB")
                .CreateLogger();

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog(log);
            });

            var applicantsStorage = new InMemoryStorage();
            var applicantManager = new ApplicantManager(applicantsStorage, loggerFactory);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(applicantManager));
        }
    }
}