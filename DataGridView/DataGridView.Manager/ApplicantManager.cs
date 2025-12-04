using DataGridView.AppConstants;
using DataGridView.Entities.Models;
using DataGridView.Manager.Contracts;
using DataGridView.MemoryStorage.Contracts;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DataGridView.Manager
{
    /// <summary>
    /// Класс управления хранилищем
    /// </summary>
    public class ApplicantManager : IApplicantManager
    {
        private IApplicantStorage storage;
        private ILogger logger;

        /// <summary>
        /// Инициализирует экземпляр <see cref="<ApplicantManager>"/>
        /// </summary>
        public ApplicantManager(IApplicantStorage storage, ILoggerFactory loggerFactory)
        {
            this.storage = storage;
            logger = loggerFactory.CreateLogger<ApplicantManager>();
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
                logger.LogInformation("GetAllApplicants() выполнен за {ms:F6} мс", ms);
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
                logger.LogInformation("AddApplicant() выполнен за {ms:F6} мс", ms);
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
                logger.LogInformation("ChangeApplicant() выполнен за {ms:F6} мс", ms);
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
                logger.LogInformation("DeleteApplicant() выполнен за {ms:F6} мс", ms);
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
                logger.LogInformation("GetTotalAmount() выполнен за {ms:F6} мс", ms);
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
                logger.LogInformation("GetStatistics() выполнен за {ms:F6} мс", ms);
            }
        }
    }
}
