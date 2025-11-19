using DataGridView.Entities.Models;
using DataGridView.Infrastructure;
using DataGridView.Models;
using System.ComponentModel.DataAnnotations;


namespace DataGridView.App.Forms
{
    public partial class ApplicantForm : Form
    {
        private readonly ApplicantModel targetApplicant;

        public ApplicantForm(ApplicantModel? sourceApplicant = null)
        {
            InitializeComponent();

            if (sourceApplicant != null)
            {
                targetApplicant = new ApplicantModel
                {
                    Id = sourceApplicant.Id,
                    FullName = sourceApplicant.FullName,
                    Gender = sourceApplicant.Gender,
                    BirthDay = sourceApplicant.BirthDay,
                    FormOfEducation = sourceApplicant.FormOfEducation,
                    MathExamScore = sourceApplicant.MathExamScore,
                    RussianLanguageExamScore = sourceApplicant.RussianLanguageExamScore,
                    InformaticExamScore = sourceApplicant.InformaticExamScore,
                };

                buttonAddApplicant.Text = "Сохранить";
            }
            else
            {
                targetApplicant = new ApplicantModel();
            }

            comboBoxFormOfEducation.DataSource = Enum.GetValues(typeof(FormOfEducation));
            comboBoxGender.DataSource = Enum.GetValues(typeof(Gender));

            textBoxFullName.AddBinding(x => x.Text, targetApplicant, x => x.FullName, errorProvider1);
            comboBoxGender.AddBinding(x => x.SelectedItem!, targetApplicant, x => x.Gender);
            comboBoxFormOfEducation.AddBinding(x => x.SelectedItem!, targetApplicant, x => x.FormOfEducation);
            MathExamScorenumericUpDown.AddBinding(x => x.Value, targetApplicant, x => x.MathExamScore, errorProvider1);
            RussianLanguageExamScorenumericUpDown.AddBinding(x => x.Value, targetApplicant, x => x.RussianLanguageExamScore, errorProvider1);
            InformaticExamScorenumericUpDown.AddBinding(x => x.Value, targetApplicant, x => x.InformaticExamScore, errorProvider1);
            dateTimePickerBirthDay.AddBinding(x => x.Value, targetApplicant, x => x.BirthDay);
        }

        public ApplicantModel CurrentApplicant => targetApplicant;

        /// <summary>
        /// Метод обработки события клика по кнопке добавить
        /// </summary>
        private void buttonAddApplicant_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            var context = new ValidationContext(targetApplicant);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(targetApplicant, context, results, true);

            if (isValid)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                foreach (var validationResult in results)
                {
                    foreach (var memberName in validationResult.MemberNames)
                    {
                        Control? control = memberName switch
                        {
                            nameof(ApplicantModel.FullName) => textBoxFullName,
                            nameof(ApplicantModel.BirthDay) => dateTimePickerBirthDay,
                            nameof(ApplicantModel.Gender) => comboBoxGender,
                            nameof(ApplicantModel.FormOfEducation) => comboBoxFormOfEducation,
                            nameof(ApplicantModel.MathExamScore) => MathExamScorenumericUpDown,
                            nameof(ApplicantModel.RussianLanguageExamScore) => RussianLanguageExamScorenumericUpDown,
                            nameof(ApplicantModel.InformaticExamScore) => InformaticExamScorenumericUpDown,
                            _=> null
                        };

                        if (control != null)
                        {
                            errorProvider1.SetError(control, validationResult.ErrorMessage);
                        }
                    }
                }
            }
        }
    }
}
