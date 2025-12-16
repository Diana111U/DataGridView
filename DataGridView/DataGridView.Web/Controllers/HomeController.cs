using DataGridView.Entities.Models;
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
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var applicants = await applicantManager.GetAllApplicants(cancellationToken);
            var statistics = await applicantManager.GetStatistics(cancellationToken);

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
        public async Task<IActionResult> Create(ApplicantModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await applicantManager.AddApplicant(model, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает форму редактирования выбранного абитуриента
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Change(Guid id, CancellationToken cancellationToken)
        {
            var applicant = await applicantManager.GetApplicantById(id, cancellationToken);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        /// <summary>
        /// Принимает изменения абитуриента из формы и сохраняет их
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Change(ApplicantModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await applicantManager.ChangeApplicant(model, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу подтверждения удаления выбранного абитуриента
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var applicant = await applicantManager.GetApplicantById(id, cancellationToken);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        /// <summary>
        /// Выполняет удаление абитуриента после подтверждения пользователем
        /// </summary>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
        {
            await applicantManager.DeleteApplicant(id, cancellationToken);
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
