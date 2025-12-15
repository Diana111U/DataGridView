using DataGridView.Manager.Contracts;
using DataGridView.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataGridView.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicantManager applicantManager;

        public HomeController(IApplicantManager applicantManager)
        {
            this.applicantManager = applicantManager;
        }

        public async Task<IActionResult> Index()
        {
            var applicants = await applicantManager.GetAllApplicants();
            var statistics = await applicantManager.GetStatistics();

            var model = new ApplicantIndexViewModel
            {
                Applicants = applicants.ToList(),
                Statistics = statistics
            };

            return View(model);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
