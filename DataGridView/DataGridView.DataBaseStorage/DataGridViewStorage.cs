using DataGridView.Entities.Models;
using DataGridView.MemoryStorage.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataGridView.DataBaseStorage
{
    public class DataGridViewStorage : IApplicantStorage
    {
        /// <summary>
        /// Получить всех абитуриентов.
        /// </summary>
        public async Task<IEnumerable<ApplicantModel>> GetAllApplicants(CancellationToken cancellationToken)
        {
            using var database = new DataGridViewContext();
            return await database.Applicants.AsNoTracking().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Добавить нового абитуриента.
        /// </summary>
        public async Task AddApplicant(ApplicantModel applicant, CancellationToken cancellationToken)
        {
            using var database = new DataGridViewContext();
            database.Applicants.Add(applicant);
            await database.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Изменить данные абитуриента.
        /// </summary>
        public async Task ChangeApplicant(ApplicantModel applicant, CancellationToken cancellationToken)
        {
            using var database = new DataGridViewContext();
            database.Applicants.Update(applicant);
            await database.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удалить абитуриента по Id.
        /// </summary>
        public async Task DeleteApplicant(Guid id, CancellationToken cancellationToken)
        {
            using var database = new DataGridViewContext();
            var applicant = await database.Applicants.FindAsync(id, cancellationToken);
            if (applicant != null)
            {
                database.Applicants.Remove(applicant);
                await database.SaveChangesAsync(cancellationToken);
            }
        }

        /// <summary>
        /// Получить одного абитуриента по Id.
        /// </summary>
        public async Task<ApplicantModel?> GetApplicantById(Guid id, CancellationToken cancellationToken)
        {
            using var database = new DataGridViewContext();
            // Чтение без трекинга, так как в MVC мы просто отображаем данные
            return await database.Applicants.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        /// <summary>
        /// Получить сумму всех экзаменов абитуриента.
        /// </summary>
        public async Task<int> GetTotalAmount(Guid id, CancellationToken cancellationToken)
        {
            using var database = new DataGridViewContext();
            var applicant = await database.Applicants
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            if (applicant is null)
                return 0;

            return applicant.MathExamScore + applicant.RussianLanguageExamScore + applicant.InformaticExamScore;
        }
    }
}
