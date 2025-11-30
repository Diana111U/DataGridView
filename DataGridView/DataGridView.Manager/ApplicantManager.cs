using DataGridView.AppConstants;
using DataGridView.Entities.Models;
using DataGridView.Manager.Contracts;
using DataGridView.MemoryStorage.Contracts;
using Serilog;
using System.Diagnostics;

namespace DataGridView.Manager
{
    public class ApplicantManager : IApplicantManager
    {
        private IApplicantStorage storage;

        public ApplicantManager(IApplicantStorage storage)
        {
            this.storage = storage;
        }

        async Task<IEnumerable<ApplicantModel>> IApplicantManager.GetAllApplicants()
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await storage.GetAllApplicants();
                return result;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("GetAllApplicants() выполнен за {ms:F6} мс", ms);
            }
        }

        async Task IApplicantManager.AddApplicant(ApplicantModel applicant)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.AddApplicant(applicant);
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("AddApplicant() выполнен за {ms:F6} мс", ms);
            }
        }

        async Task IApplicantManager.ChangeApplicant(ApplicantModel applicant)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.ChangeApplicant(applicant);
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("ChangeApplicant() выполнен за {ms:F6} мс", ms);
            }
        }

        async Task IApplicantManager.DeleteApplicant(Guid Id)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.DeleteApplicant(Id);
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("DeleteApplicant() выполнен за {ms:F6} мс", ms);
            }
        }

        async Task<int> IApplicantManager.GetTotalAmount(Guid Id)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await storage.GetTotalAmount(Id);
                return result;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("GetTotalAmount() выполнен за {ms:F6} мс", ms);
            }
        }

        async Task<ApplicantStatistics> IApplicantManager.GetStatistics()
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var items = await (storage).GetAllApplicants();
                var statistics = new ApplicantStatistics
                {
                    ApplicantCount = items.Count(),
                    CountScoreMoreThan150 = items.Count(x => x.MathExamScore + x.RussianLanguageExamScore + x.InformaticExamScore > 150),
                    CountPassing = items.Count(x => x.MathExamScore + x.RussianLanguageExamScore + x.InformaticExamScore > Constants.ScoreNeedToAdmission)
                };
                return statistics;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("GetStatistics() выполнен за {ms:F6} мс", ms);
            }
            
        }
    }
}
