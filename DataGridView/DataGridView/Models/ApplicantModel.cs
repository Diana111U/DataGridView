using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.Models
{
    internal class StudentModel
    {
        public string FullName { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public DateOnly BirthDay { get; set; }

        public FormOfEducation FormOfEducation { get; set; }

        public int MathExamScore { get; set; }

        public int RussianLanguageExamScore { get; set; }

        public int InformaticExamScore { get; set; }

        public int TotalAmount { get; set; }
    }
}
