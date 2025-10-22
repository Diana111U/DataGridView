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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridView1.Columns[e.ColumnIndex];
            var applicant = (ApplicantModel)dataGridView1.Rows[e.RowIndex].DataBoundItem;

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

        public void OnUpdate()
        {
            bindingSource.ResetBindings(false);
            SetStatistic();
        }

        public void SetStatistic()
        {
            toolStripStatusLabel1.Text = $"Кол-во абитур-ов: {items.Count}";
            toolStripStatusLabel2.Text = $"Кол-во абитур-ов с баллами > 150: {items.Where(x=>x.TotalAmount>150).Count()}";
            toolStripStatusLabel3.Text = $"Проходят: {items.Where(x=>x.TotalAmount>ScoreNeedToAdmission).Count()}";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new ApplicantForm();
            if(addForm.ShowDialog() == DialogResult.OK)
            {
                items.Add(addForm.CurrentApplicant);
                OnUpdate();
            }
        }

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
    }
}