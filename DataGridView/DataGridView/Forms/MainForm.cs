using DataGridView.Entities.Models;
using DataGridView.Manager.Contracts;


namespace DataGridView.App.Forms
{
    /// <summary>
    /// Главная форма программы
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly IApplicantManager applicantManager;
        private readonly BindingSource bindingSource = [];

        /// <summary>
        /// Инициализирует экземпляр <see cref="<MainForm>"/>
        /// </summary>
        public MainForm(IApplicantManager applicantManager)
        {
            InitializeComponent();
            this.applicantManager = applicantManager;
            dataGridView1.AutoGenerateColumns = false;
        }

        /// <summary>
        /// Метод обработки форматирования каждой ячейки
        /// </summary>
        private async void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridView1.Columns[e.ColumnIndex];
            var applicant = (ApplicantModel)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            if (applicant == null)
            {
                return;
            }

            if (col.DataPropertyName == nameof(ApplicantModel.Gender))
            {
                e.Value = applicant.Gender switch
                {
                    Entities.Models.Gender.Male => "Мужской",
                    Entities.Models.Gender.Female => "Женский",
                    _ => string.Empty,
                };
            }

            if (col.DataPropertyName == nameof(ApplicantModel.FormOfEducation))
            {
                e.Value = applicant.FormOfEducation switch
                {
                    Entities.Models.FormOfEducation.FullTime => "Очная",
                    Entities.Models.FormOfEducation.PartTime => "Очно-заочная",
                    Entities.Models.FormOfEducation.Correspondence => "Заочная",
                    _ => string.Empty,
                };
            }

            if (col.Name == "TotalAmount")
            {
                var totalAmount = await applicantManager.GetTotalAmount(applicant.Id);
                e.Value = totalAmount;
            }
        }

        /// <summary>
        /// Метод обновления данных
        /// </summary>
        public async Task OnUpdate()
        {
            var items = await applicantManager.GetAllApplicants();
            bindingSource.DataSource = items.ToList();
            bindingSource.ResetBindings(false);
            await SetStatistic();
        }

        /// <summary>
        /// Метод вывдода данных в StripStatus
        /// </summary>
        public async Task SetStatistic()
        {
            var statistics = await applicantManager.GetStatistics();

            toolStripStatusLabel1.Text = $"Кол-во абитур-ов: {statistics.ApplicantCount}";
            toolStripStatusLabel2.Text = $"Кол-во абитур-ов с баллами > 150: {statistics.CountScoreMoreThan150}";
            toolStripStatusLabel3.Text = $"Проходят: {statistics.CountPassing}";
        }

        /// <summary>
        /// Метод обработки клика по кнопке добавить
        /// </summary>
        private async void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new ApplicantForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await applicantManager.AddApplicant(addForm.CurrentApplicant);
                await OnUpdate();
            }
        }

        /// <summary>
        /// Метод обработки клика по кнопке удалить
        /// </summary>
        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var applicant = (ApplicantModel)dataGridView1.SelectedRows[0].DataBoundItem;
            if (
                MessageBox.Show($"Вы действительно желаете удалить абитуриента '{applicant.FullName}'?",
                "Удаление абитуриента",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await applicantManager.DeleteApplicant(applicant.Id);
                await OnUpdate();
            }
        }

        /// <summary>
        /// Метод обработки клика по кнопке изменить
        /// </summary>
        private async void ChangeButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var applicant = (ApplicantModel)dataGridView1.SelectedRows[0].DataBoundItem;
            var editForm = new ApplicantForm(applicant);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await applicantManager.ChangeApplicant(editForm.CurrentApplicant);
                await OnUpdate();
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var items = await applicantManager.GetAllApplicants();
            bindingSource.DataSource = items.ToList();
            dataGridView1.DataSource = bindingSource;
            await SetStatistic();
        }
    }
}