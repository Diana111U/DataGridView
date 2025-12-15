using DataGridView.Entities.Models;
using DataGridView.Manager.Contracts;

namespace DataGridView.Web.Models
{
    /// <summary>
    /// Модель представления для главной страницы абитуриентов
    /// </summary>
    public class ApplicantIndexViewModel
    {
        /// <summary>
        /// Список всех абитуриентов, отображаемых в таблице
        /// </summary>
        public List<ApplicantModel> Applicants { get; set; } = [];

        /// <summary>
        /// Общая статистика по абитуриентам
        /// </summary>
        public ApplicantStatistics Statistics { get; set; } = new();
    }
}
