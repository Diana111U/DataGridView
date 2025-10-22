using DataGridView.Models;

namespace DataGridView
{
    public partial class MainForm : Form
    {
        private readonly List<StudentModel> items;
        public MainForm()
        {
            items = new List<StudentModel>();
            items.Add(new StudentModel
            { 
                FullName ="Иванов Иван Иванович",
                Gender = Gender.Male,
                BirthDay = DateOnly.Parse("10.10.2005"),
                FormOfEducation = FormOfEducation.FullTime,
                MathExamScore = 62,
                RussianLanguageExamScore = 87,
                InformaticExamScore = 99
            });
            items.Add(new StudentModel
            {
                FullName = "Петрова Анна Михайловна",
                Gender = Gender.Female,
                BirthDay = DateOnly.Parse("10.10.2004"),
                FormOfEducation = FormOfEducation.PartTime,
                MathExamScore = 90,
                RussianLanguageExamScore = 93,
                InformaticExamScore = 100
            });
            InitializeComponent();

        }
    }
}
