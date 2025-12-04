using DataGridView.Entities.Models;

namespace DataGridView.MemoryStorage.Contracts
{
    /// <summary>
    /// Интерфейс управления хранилища данных об абитуриентах
    /// </summary>
    public interface IApplicantStorage
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

        /// <summary>
        /// Удаление абитуриента
        /// </summary>
        public Task DeleteApplicant(Guid Id);

        /// <summary>
        /// Получаем сумму баллов за все экзамены
        /// </summary>
        public Task<int> GetTotalAmount(Guid Id);
    }
}