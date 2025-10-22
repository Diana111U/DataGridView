using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.Models
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
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; } = Gender.Unknown;

        /// <summary>
        /// День рождения
        /// </summary>
        public DateOnly BirthDay { get; set; } = DateOnly.MinValue;

        /// <summary>
        /// Форма обучения
        /// </summary>
        public FormOfEducation FormOfEducation { get; set; } = FormOfEducation.Unknown;

        /// <summary>
        /// Кол-во баллов ЕГЭ по математике
        /// </summary>
        public int MathExamScore { get; set; } = 0;

        /// <summary>
        /// Кол-во баллов ЕГЭ по русскому
        /// </summary>
        public int RussianLanguageExamScore { get; set; } = 0;

        /// <summary>
        /// Кол-во баллов ЕГЭ по информатике
        /// </summary>
        public int InformaticExamScore { get; set; } = 0;

        /// <summary>
        /// Кол-во баллов за все предметы
        /// </summary>
        public int TotalAmount 
        {
            get { return MathExamScore + RussianLanguageExamScore + InformaticExamScore; }
        }

        public ApplicantModel Clone()
        {
            return (ApplicantModel)MemberwiseClone();
        }
    }
}
