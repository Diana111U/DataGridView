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
        public async Task<List<ApplicantModel>> GetAllApplicants()
        {
            using var database = new DataGridViewContext();
            return await database.Applicants.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Добавить нового абитуриента.
        /// </summary>
        public async Task AddApplicant(ApplicantModel applicant)
        {
            using var database = new DataGridViewContext();
            database.Applicants.Add(applicant);
            await database.SaveChangesAsync();
        }

        /// <summary>
        /// Изменить данные абитуриента.
        /// </summary>
        public async Task ChangeApplicant(ApplicantModel applicant)
        {
            using var database = new DataGridViewContext();
            database.Applicants.Update(applicant);
            await database.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить абитуриента по Id.
        /// </summary>
        public async Task DeleteApplicant(Guid id)
        {
            using var database = new DataGridViewContext();
            var applicant = await database.Applicants.FindAsync(id);
            if (applicant != null)
            {
                database.Applicants.Remove(applicant);
                await database.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получить сумму всех экзаменов абитуриента.
        /// </summary>
        public async Task<int> GetTotalAmount(Guid id)
        {
            using var database = new DataGridViewContext();
            var applicant = await database.Applicants
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (applicant is null)
                return 0;

            return applicant.MathExamScore + applicant.RussianLanguageExamScore + applicant.InformaticExamScore;
        }
    }
}
