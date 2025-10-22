using DataGridView.Models;
using System.Windows.Forms;

namespace DataGridView
{
    public partial class MainForm : Form
    {
        private readonly List<ApplicantModel> items;
        private const int ScoreNeedToAdmission = 180;
        public MainForm()
        {
            items = new List<ApplicantModel>();
            items.Add(new ApplicantModel
            {
                FullName = "Иванов Иван Иванович",
                Gender = Gender.Male,
                BirthDay = DateOnly.Parse("10.10.2005"),
                FormOfEducation = FormOfEducation.FullTime,
                MathExamScore = 62,
                RussianLanguageExamScore = 87,
                InformaticExamScore = 99
            });
            items.Add(new ApplicantModel
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
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = items;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridView1.Columns[e.ColumnIndex];
            var applicant = (ApplicantModel)dataGridView1.Rows[e.RowIndex].DataBoundItem;

            if (col.DataPropertyName == nameof(ApplicantModel.Gender))
            {
                switch (applicant.Gender)
                {
                    case Gender.Male:
                        e.Value = "Мужской";
                        break;

                    case Gender.Female:
                        e.Value = "Женский";
                        break;

                    default:
                        e.Value = string.Empty;
                        break;
                }
            }

            if (col.DataPropertyName == nameof(ApplicantModel.FormOfEducation))
            {
                switch (applicant.FormOfEducation)
                {
                    case FormOfEducation.FullTime:
                        e.Value = "Очная";
                        break;

                    case FormOfEducation.PartTime:
                        e.Value = "Очно-заочная";
                        break;

                    case FormOfEducation.Correspondence:
                        e.Value = "Заочная";
                        break;

                    default:
                        e.Value = string.Empty;
                        break;
                }
            }
        }

        public void SetStatistic()
        {
            toolStripStatusLabel1.Text = $"Кол-во абитур-ов: {items.Count}";
            toolStripButton2.Text = $"Кол-во абитур-ов с баллами > 150: {items.Where(x=>x.TotalAmount>150)}";
            toolStripButton3.Text = $"Проходят: {items.Where(x=>x.TotalAmount>ScoreNeedToAdmission)}";
        }

    }
}