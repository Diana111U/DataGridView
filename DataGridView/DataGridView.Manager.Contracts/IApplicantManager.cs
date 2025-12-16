using DataGridView.Entities.Models;

namespace DataGridView.Manager.Contracts
{
    /// <summary>
    /// Интерфейс менеджера для управления данными об абитуриентах
    /// </summary>
    public interface IApplicantManager
    {
        /// <summary>
        /// Получить всех абитуриентов
        /// </summary>
        public Task<IEnumerable<ApplicantModel>> GetAllApplicants(CancellationToken cancellationToken);

        /// <summary>
        /// Добавить нового абитуриента
        /// </summary>
        public Task AddApplicant(ApplicantModel applicant, CancellationToken cancellationToken);

        /// <summary>
        /// Изменение абитуриента
        /// </summary>
        public Task ChangeApplicant(ApplicantModel applicant, CancellationToken cancellationToken);

        /// <summary>
        /// Нахождение абитуриента по ID
        /// </summary>
        public Task<ApplicantModel?> GetApplicantById(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Удаление абитуриента
        /// </summary>
        public Task DeleteApplicant(Guid Id, CancellationToken cancellationToken);

        /// <summary>
        /// Получаем сумму баллов за все экзамены
        /// </summary>
        public Task<int> GetTotalAmount(Guid Id, CancellationToken cancellationToken);

        /// <summary>
        /// Статистика абитуриента
        /// </summary>
        public Task<ApplicantStatistics> GetStatistics(CancellationToken cancellationToken);
    }
}
