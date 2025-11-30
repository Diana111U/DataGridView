using DataGridView.AppConstants;
using DataGridView.Entities.Models;
using DataGridView.Manager.Contracts;
using DataGridView.MemoryStorage.Contracts;

namespace DataGridView.Manager
{
    public class ApplicantManager(IApplicantStorage storage) : IApplicantManager
    {
        private IApplicantStorage Storage { get; } = storage;

        Task<IEnumerable<ApplicantModel>> IApplicantManager.GetAllApplicants() => Storage.GetAllApplicants();

        Task IApplicantManager.AddApplicant(ApplicantModel applicant) => Storage.AddApplicant(applicant);

        Task IApplicantManager.ChangeApplicant(ApplicantModel applicant) => Storage.ChangeApplicant(applicant);

        Task IApplicantManager.DeleteApplicant(Guid Id) => Storage.DeleteApplicant(Id);

        Task<int> IApplicantManager.GetTotalAmount(Guid Id) => Storage.GetTotalAmount(Id);

        async Task<ApplicantStatistics> IApplicantManager.GetStatistics()
        {
            var items = await(Storage).GetAllApplicants();
            var statistics = new ApplicantStatistics
            {
                ApplicantCount = items.Count(),
                CountScoreMoreThan150 = items.Count(x => x.MathExamScore + x.RussianLanguageExamScore + x.InformaticExamScore > 150),
                CountPassing = items.Count(x => x.MathExamScore + x.RussianLanguageExamScore + x.InformaticExamScore > Constants.ScoreNeedToAdmission)
            };
            return statistics;
        }
    }
}
