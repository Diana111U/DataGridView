using DataGridView.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridView.Forms
{
    public partial class ApplicantForm : Form
    {
        private readonly ApplicantModel targetApplicant;
        public ApplicantForm(ApplicantModel? sourceApplicant = null)
        {
            InitializeComponent();

            if (sourceApplicant != null)
            {
                targetApplicant = sourceApplicant.Clone();
                buttonAddApplicant.Text = "Сохранить";
            }
            else
            {
                targetApplicant = new ApplicantModel();
            }

            comboBoxFormOfEducation.DataSource = Enum.GetValues(typeof(FormOfEducation));
            comboBoxGender.DataSource = Enum.GetValues(typeof(Gender));
        }

        public ApplicantModel CurrentApplicant => targetApplicant;
    }
}
