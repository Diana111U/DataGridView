using DataGridView.Forms;
using DataGridView.Models;
using System.Windows.Forms;

namespace DataGridView
{
    public partial class MainForm : Form
    {
        private readonly List<ApplicantModel> items;
        private const int ScoreNeedToAdmission = 250;
        private readonly BindingSource bindingSource = [];
        public MainForm()
        {
            items =
            [
                new ApplicantModel
                {
                    FullName = "Иванов Иван Иванович",
                    Gender = Models.Gender.Male,
                    BirthDay = DateOnly.Parse("10.10.2005"),
                    FormOfEducation = Models.FormOfEducation.FullTime,
                    MathExamScore = 62,
                    RussianLanguageExamScore = 87,
                    InformaticExamScore = 99
                },
                new ApplicantModel
                {
                    FullName = "Петрова Анна Михайловна",
                    Gender = Models.Gender.Female,
                    BirthDay = DateOnly.Parse("10.10.2004"),
                    FormOfEducation = Models.FormOfEducation.PartTime,
                    MathExamScore = 90,
                    RussianLanguageExamScore = 93,
                    InformaticExamScore = 100
                },
            ];
            InitializeComponent();
            SetStatistic();
            dataGridView1.AutoGenerateColumns = false;
            bindingSource.DataSource = items;
            dataGridView1.DataSource = bindingSource;
        }

        /// <summary>
        /// Метод обработки форматирования каждой ячейки
        /// </summary>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridView1.Columns[e.ColumnIndex];
            var applicant = (ApplicantModel)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            if(applicant==null)
            {
                return;
            }

            if (col.DataPropertyName == nameof(ApplicantModel.Gender))
            {
                e.Value = applicant.Gender switch
                {
                    Models.Gender.Male => "Мужской",
                    Models.Gender.Female => "Женский",
                    _ => string.Empty,
                };
            }

            if (col.DataPropertyName == nameof(ApplicantModel.FormOfEducation))
            {
                e.Value = applicant.FormOfEducation switch
                {
                    Models.FormOfEducation.FullTime => "Очная",
                    Models.FormOfEducation.PartTime => "Очно-заочная",
                    Models.FormOfEducation.Correspondence => "Заочная",
                    _ => string.Empty,
                };
            }
        }

        /// <summary>
        /// Метод обновления данных
        /// </summary>
        public void OnUpdate()
        {
            bindingSource.ResetBindings(false);
            SetStatistic();
        }

        /// <summary>
        /// Метод вывдода данных в StripStatus
        /// </summary>
        public void SetStatistic()
        {
            toolStripStatusLabel1.Text = $"Кол-во абитур-ов: {items.Count}";
            toolStripStatusLabel2.Text = $"Кол-во абитур-ов с баллами > 150: {items.Where(x=>x.TotalAmount>150).Count()}";
            toolStripStatusLabel3.Text = $"Проходят: {items.Where(x=>x.TotalAmount>ScoreNeedToAdmission).Count()}";
        }

        /// <summary>
        /// Метод обработки клика по кнопке добавить
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new ApplicantForm();
            if(addForm.ShowDialog() == DialogResult.OK)
            {
                items.Add(addForm.CurrentApplicant);
                OnUpdate();
            }
        }

        /// <summary>
        /// Метод обработки клика по кнопке удалить
        /// </summary>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var applicant = (ApplicantModel)dataGridView1.SelectedRows[0].DataBoundItem;
            var target = items.FirstOrDefault(x=>x.Id == applicant.Id);
            if (target != null && 
                MessageBox.Show($"Вы действительно желаете удалить абитуриента '{target.FullName}'?",
                "Удаление абитуриента",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)==DialogResult.Yes)
            {
                items.Remove(target);
                OnUpdate();
            }
        }

        /// <summary>
        /// Метод обработки клика по кнопке изменить
        /// </summary>
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var applicant = (ApplicantModel)dataGridView1.SelectedRows[0].DataBoundItem;
            var editForm = new ApplicantForm(applicant);
            if(editForm.ShowDialog() == DialogResult.OK)
            {
                var target = items.FirstOrDefault(x=>x.Id==editForm.CurrentApplicant.Id);
                if(target != null)
                {
                    target.FullName = editForm.CurrentApplicant.FullName;
                    target.Gender = editForm.CurrentApplicant.Gender;
                    target.BirthDay=editForm.CurrentApplicant.BirthDay;
                    target.FormOfEducation = editForm.CurrentApplicant.FormOfEducation;
                    target.MathExamScore = editForm.CurrentApplicant.MathExamScore;
                    target.RussianLanguageExamScore= editForm.CurrentApplicant.RussianLanguageExamScore;
                    target.InformaticExamScore = editForm.CurrentApplicant.InformaticExamScore;
                    OnUpdate();
                }
            }
        }
    }
}