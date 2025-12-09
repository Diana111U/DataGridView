using DataGridView.AppConstants;
using System.ComponentModel.DataAnnotations;

namespace DataGridView.Entities.Models
{
    /// <summary>
    /// Модель абитуриента
    /// </summary>
    public class ApplicantModel
    {
        /// <summary>
        /// Id абитуриента
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// ФИО
        /// </summary>
        [Display(Name = "ФИО абитуриента")]
        [Required(ErrorMessage = "{0} обязательно для заполнения")]
        [StringLength(Constants.FullNameMaxLength, ErrorMessage = "{0} должно быть меньше {1} символов")]
        public string FullName { get; set; } = string.Empty;

        /// <inheritdoc cref = "Models.Gender"/>
        public Gender Gender { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        [Required(ErrorMessage = "Дата рождения обязательна")]
        public DateTime BirthDay { get; set; } = DateTime.Now;

        /// <inheritdoc cref = "Models.FormOfEducation"/>
        public FormOfEducation FormOfEducation { get; set; }

        /// <summary>
        /// Кол-во баллов ЕГЭ по математике
        /// </summary>
        [Display(Name = "Баллы ЕГЭ по математике")]
        [Required(ErrorMessage = "{0} обязательно для заполнения")]
        [Range(Constants.MinScore, Constants.MaxScore, ErrorMessage = "{0} должно быть между {1} и {2}")]
        public int MathExamScore { get; set; }

        /// <summary>
        /// Кол-во баллов ЕГЭ по русскому языку
        /// </summary>
        [Display(Name = "Баллы ЕГЭ по русскому языку")]
        [Required(ErrorMessage = "{0} обязательно для заполнения")]
        [Range(Constants.MinScore, Constants.MaxScore, ErrorMessage = "{0} должно быть между {1} и {2}")]
        public int RussianLanguageExamScore { get; set; }

        /// <summary>
        /// Кол-во баллов ЕГЭ по информатике
        /// </summary>
        [Display(Name = "Баллы ЕГЭ по информатике")]
        [Required(ErrorMessage = "{0} обязательно для заполнения")]
        [Range(Constants.MinScore, Constants.MaxScore, ErrorMessage = "{0} должно быть между {1} и {2}")]
        public int InformaticExamScore { get; set; }
    }
}
