using DataGridView.Entities.Models;
using DataGridView.Manager;
using DataGridView.Manager.Contracts;
using DataGridView.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataGridView.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicantManager applicantManager;

        /// <summary>
        /// Инициализирует контроллер
        /// </summary>
        public HomeController(IApplicantManager applicantManager)
        {
            this.applicantManager = applicantManager;
        }

        /// <summary>
        /// Отображает главную страницу со списком абитуриентов и статистикой
        /// </summary>
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

        /// <summary>
        /// Отображает форму для добавления нового товара
        /// </summary>
        [HttpGet]
        public IActionResult Create() => View(new ApplicantModel());

        /// <summary>
        /// Принимает данные нового абитуриента из формы и добавляет его в хранилище
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicantModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await applicantManager.AddApplicant(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Change(Guid id)
        {
            var applicant = await applicantManager.GetApplicantById(id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        [HttpPost]
        public async Task<IActionResult> Change(ApplicantModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await applicantManager.ChangeApplicant(model);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу с политикой конфиденциальности
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Отображает страницу ошибки с информацией о текущем запросе
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
