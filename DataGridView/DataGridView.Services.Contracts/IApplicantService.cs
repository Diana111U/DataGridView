using DataGridView.Entities.Models;

namespace DataGridView.Services.Contracts
{
    /// <summary>
    /// Интерфейс сервиса для управления данными об абитуриентах
    /// </summary>
    public interface IApplicantService
    {
        /// <summary>
        /// Получить всех абитуриентов
        /// </summary>
        public Task<IEnumerable<ApplicantModel>> GetAllApplicants();

        /// <summary>
        /// Добавить нового абитуриента
        /// </summary>
        public Task AddApplicant(ApplicantModel applicant);

        /// <summary>
        /// Изменение абитуриента
        /// </summary>
        public Task ChangeApplicant(ApplicantModel applicant);
    }
}