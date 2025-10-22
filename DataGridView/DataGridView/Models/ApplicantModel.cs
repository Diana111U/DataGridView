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
        /// ФИО
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        public DateOnly BirthDay { get; set; }

        /// <summary>
        /// Форма обучения
        /// </summary>
        public FormOfEducation FormOfEducation { get; set; }

        /// <summary>
        /// Кол-во баллов ЕГЭ по математике
        /// </summary>
        public int MathExamScore { get; set; }

        /// <summary>
        /// Кол-во баллов ЕГЭ по русскому
        /// </summary>
        public int RussianLanguageExamScore { get; set; }

        /// <summary>
        /// Кол-во баллов ЕГЭ по информатике
        /// </summary>
        public int InformaticExamScore { get; set; }

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
