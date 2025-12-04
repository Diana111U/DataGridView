using Ahatornn.TestGenerator;
using DataGridView.AppConstants;
using DataGridView.Entities.Models;
using DataGridView.Manager.Contracts;
using DataGridView.MemoryStorage.Contracts;
using FluentAssertions;
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;


namespace DataGridView.Manager.Tests
{
    /// <summary>
    /// Набор модульных тестов для проверки работы класса <see cref="ApplicantManager"/>
    /// </summary>
    public class ApplicantManagerTests
    {
        private readonly IApplicantManager applicantManager;
        private readonly Mock<IApplicantStorage> storageMock;

        /// <summary>
        /// Инициализирует экземпляр <see cref="<ApplicantManagerTests>"/>
        /// </summary>
        public ApplicantManagerTests()
        {
            storageMock = new Mock<IApplicantStorage>();

            var mockLogger = new Mock<ILogger>();
            var mockLoggerFactory = new Mock<ILoggerFactory>();
            mockLoggerFactory
                .Setup(f => f.CreateLogger(It.IsAny<string>()))
                .Returns(mockLogger.Object);

            applicantManager = new ApplicantManager(storageMock.Object, mockLoggerFactory.Object);
        }

        /// <summary>
        /// Проверяет, что метод получения всех абитуриентов возвращает корректную коллекцию и вызывает хранилище один раз
        /// </summary>
        [Fact]
        public async Task GetAllApplicantsShouldReturnValue()
        {
            var applicant1 = TestEntityProvider.Shared.Create<ApplicantModel>();
            var applicant2 = TestEntityProvider.Shared.Create<ApplicantModel>();
            storageMock.Setup(x => x.GetAllApplicants())
                .ReturnsAsync(
                [
                    applicant1,
                    applicant2,
                ]);

            var result = await applicantManager.GetAllApplicants();

            result.Should().BeEquivalentTo([applicant1, applicant2]);
            storageMock.Verify(x => x.GetAllApplicants(), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод добавления абитуриента вызывает соответствующий метод хранилища
        /// </summary>
        [Fact]
        public async Task AddApplicantShouldWork()
        {
            var applicant = TestEntityProvider.Shared.Create<ApplicantModel>();

            var act = () => applicantManager.AddApplicant(applicant);

            await act.Should().NotThrowAsync();
            storageMock.Verify(x => x.AddApplicant(applicant), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод изменения данных абитуриента вызывает обновление в хранилище
        /// </summary>
        [Fact]
        public async Task ChangeApplicantShouldWork()
        {
            var applicant = TestEntityProvider.Shared.Create<ApplicantModel>();

            var act = () => applicantManager.ChangeApplicant(applicant);

            await act.Should().NotThrowAsync();
            storageMock.Verify(x => x.ChangeApplicant(applicant), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод удаления абитуриента вызывает удаление по идентификатору в хранилище
        /// </summary>
        [Fact]
        public async Task DeleteApplicantShouldWork()
        {
            var applicant = TestEntityProvider.Shared.Create<ApplicantModel>();

            var act = () => applicantManager.DeleteApplicant(applicant.Id);

            await act.Should().NotThrowAsync();
            storageMock.Verify(x => x.DeleteApplicant(applicant.Id), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод получения итоговой суммы по абитуриенту корректно обращается к хранилищу и возвращает значение
        /// </summary>
        [Fact]
        public async Task GetTotalAmountShouldReturnValue()
        {
            var applicant = TestEntityProvider.Shared.Create<ApplicantModel>();
            var expected = 75;

            storageMock.Setup(x => x.GetTotalAmount(applicant.Id))
                .ReturnsAsync(expected);

            var result = await applicantManager.GetTotalAmount(applicant.Id);

            result.Should().Be(expected);
            storageMock.Verify(x => x.GetTotalAmount(applicant.Id), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверяет, что метод получения статистики корректно считает количество абитуриентов и проходные баллы
        /// </summary>
        [Fact]
        public async Task GetStatisticsShouldReturnValue()
        {
            var applicant1 = TestEntityProvider.Shared.Create<ApplicantModel>();
            applicant1.MathExamScore = 40;
            applicant1.RussianLanguageExamScore = 50;
            applicant1.InformaticExamScore = 30;
            var applicant2 = TestEntityProvider.Shared.Create<ApplicantModel>();
            applicant2.MathExamScore = 70;
            applicant2.RussianLanguageExamScore = 80;
            applicant2.InformaticExamScore = 100;
            storageMock.Setup(x => x.GetAllApplicants())
                .ReturnsAsync([applicant1, applicant2]);

            var result = await applicantManager.GetStatistics();

            var score1 = applicant1.MathExamScore + applicant1.RussianLanguageExamScore + applicant1.InformaticExamScore;
            var score2 = applicant2.MathExamScore + applicant2.RussianLanguageExamScore + applicant2.InformaticExamScore;

            result.ApplicantCount.Should().Be(2);
            result.CountScoreMoreThan150.Should().Be(1);
            result.CountPassing.Should().Be(
                (score1 > Constants.ScoreNeedToAdmission ? 1 : 0) +
                (score2 > Constants.ScoreNeedToAdmission ? 1 : 0));
            storageMock.Verify(x => x.GetAllApplicants(), Times.Once);
            storageMock.VerifyNoOtherCalls();
        }
    }
}
