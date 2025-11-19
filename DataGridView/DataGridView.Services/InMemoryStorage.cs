using DataGridView.Entities.Models;
using DataGridView.Services.Contracts;

namespace DataGridView.Services
{
    /// <summary>
    /// Сервис для доступа к абитуриентам в памяти
    /// </summary>
    public class InMemoryStorage : IApplicantService
    {
        private readonly List<ApplicantModel> items;

        /// <summary>
        /// Инициализация экземпляра InMemoryStorage
        /// </summary>
        public InMemoryStorage()
        {
            items =
            [
                new ApplicantModel
                {
                    FullName = "Иванов Иван Иванович",
                    Gender = Entities.Models.Gender.Male,
                    BirthDay = DateTime.Parse("10.10.2005"),
                    FormOfEducation = Entities.Models.FormOfEducation.FullTime,
                    MathExamScore = 62,
                    RussianLanguageExamScore = 87,
                    InformaticExamScore = 99
                },
                new ApplicantModel
                {
                    FullName = "Петрова Анна Михайловна",
                    Gender = Entities.Models.Gender.Female,
                    BirthDay = DateTime.Parse("10.10.2004"),
                    FormOfEducation = Entities.Models.FormOfEducation.PartTime,
                    MathExamScore = 90,
                    RussianLanguageExamScore = 93,
                    InformaticExamScore = 100
                },
            ];
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ApplicantModel>> GetAllApplicants() => await Task.FromResult<IEnumerable<ApplicantModel>>(items);

        async Task IApplicantService.AddApplicant(ApplicantModel applicant)
        {
            items.Add(applicant);
            await Task.CompletedTask;
        }

        async Task IApplicantService.ChangeApplicant(ApplicantModel applicant)
        {
            var target = items.FirstOrDefault(x => x.Id == applicant.Id);
            if (target != null)
            {
                target.FullName = applicant.FullName;
                target.Gender = applicant.Gender;
                target.BirthDay = applicant.BirthDay;
                target.FormOfEducation = applicant.FormOfEducation;
                target.MathExamScore = applicant.MathExamScore;
                target.RussianLanguageExamScore = applicant.RussianLanguageExamScore;
                target.InformaticExamScore = applicant.InformaticExamScore;

                await Task.CompletedTask;
            }
        }

        async Task IApplicantService.DeleteApplicant(Guid Id)
        {
            var target = items.FirstOrDefault(x => x.Id == Id);
            if (target != null)
            {
                items.Remove(target);
                await Task.CompletedTask;
            }
        }

        async Task<int> IApplicantService.GetTotalAmount(Guid Id)
        {
            var target = items.FirstOrDefault(y => y.Id == Id);
            if (target != null)
            {
                var totalAmount = target.MathExamScore + target.RussianLanguageExamScore + target.InformaticExamScore;
                return await Task.FromResult(totalAmount);
            }
        }
    }
}
