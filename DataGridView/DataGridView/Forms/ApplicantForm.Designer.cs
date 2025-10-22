namespace DataGridView.Forms
{
    partial class ApplicantForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label8 = new Label();
            textBoxFullName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBoxRussianLanguageExamScore = new TextBox();
            textBoxInformaticExamScore = new TextBox();
            textBoxMathExamScore = new TextBox();
            comboBoxGender = new ComboBox();
            comboBoxFormOfEducation = new ComboBox();
            dateTimePickerBirthDay = new DateTimePicker();
            buttonAddApplicant = new Button();
            buttonCancel = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 255, 255);
            panel1.Controls.Add(label8);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(640, 100);
            panel1.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(279, 49);
            label8.Name = "label8";
            label8.Size = new Size(72, 15);
            label8.TabIndex = 0;
            label8.Text = "Абитуриент";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(302, 135);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(100, 23);
            textBoxFullName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(217, 143);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 2;
            label1.Text = "ФИО";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(217, 190);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 3;
            label2.Text = "Пол";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(182, 233);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 4;
            label3.Text = "День рождения";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(173, 272);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 5;
            label4.Text = "Форма обучения";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(100, 316);
            label5.Name = "label5";
            label5.Size = new Size(196, 15);
            label5.TabIndex = 6;
            label5.Text = "Кол-во баллов ЕГЭ по математике";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(100, 364);
            label6.Name = "label6";
            label6.Size = new Size(184, 15);
            label6.TabIndex = 7;
            label6.Text = "Кол-во баллов ЕГЭ по русскому";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(77, 399);
            label7.Name = "label7";
            label7.Size = new Size(207, 15);
            label7.TabIndex = 8;
            label7.Text = "Кол-во баллов ЕГЭ по информатике";
            // 
            // textBoxRussianLanguageExamScore
            // 
            textBoxRussianLanguageExamScore.Location = new Point(302, 356);
            textBoxRussianLanguageExamScore.Name = "textBoxRussianLanguageExamScore";
            textBoxRussianLanguageExamScore.Size = new Size(100, 23);
            textBoxRussianLanguageExamScore.TabIndex = 9;
            // 
            // textBoxInformaticExamScore
            // 
            textBoxInformaticExamScore.Location = new Point(302, 396);
            textBoxInformaticExamScore.Name = "textBoxInformaticExamScore";
            textBoxInformaticExamScore.Size = new Size(100, 23);
            textBoxInformaticExamScore.TabIndex = 10;
            // 
            // textBoxMathExamScore
            // 
            textBoxMathExamScore.Location = new Point(302, 308);
            textBoxMathExamScore.Name = "textBoxMathExamScore";
            textBoxMathExamScore.Size = new Size(100, 23);
            textBoxMathExamScore.TabIndex = 12;
            // 
            // comboBoxGender
            // 
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.FormattingEnabled = true;
            comboBoxGender.Location = new Point(302, 182);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(121, 23);
            comboBoxGender.TabIndex = 13;
            // 
            // comboBoxFormOfEducation
            // 
            comboBoxFormOfEducation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFormOfEducation.FormattingEnabled = true;
            comboBoxFormOfEducation.Location = new Point(302, 269);
            comboBoxFormOfEducation.Name = "comboBoxFormOfEducation";
            comboBoxFormOfEducation.Size = new Size(121, 23);
            comboBoxFormOfEducation.TabIndex = 14;
            // 
            // dateTimePickerBirthDay
            // 
            dateTimePickerBirthDay.Location = new Point(302, 227);
            dateTimePickerBirthDay.Name = "dateTimePickerBirthDay";
            dateTimePickerBirthDay.Size = new Size(200, 23);
            dateTimePickerBirthDay.TabIndex = 15;
            dateTimePickerBirthDay.UseWaitCursor = true;
            // 
            // buttonAddApplicant
            // 
            buttonAddApplicant.Location = new Point(221, 453);
            buttonAddApplicant.Name = "buttonAddApplicant";
            buttonAddApplicant.Size = new Size(75, 23);
            buttonAddApplicant.TabIndex = 16;
            buttonAddApplicant.Text = "Добавить";
            buttonAddApplicant.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(357, 453);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 17;
            buttonCancel.Text = "Отменить";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // ApplicantForm
            // 
            AcceptButton = buttonAddApplicant;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(640, 516);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAddApplicant);
            Controls.Add(dateTimePickerBirthDay);
            Controls.Add(comboBoxFormOfEducation);
            Controls.Add(comboBoxGender);
            Controls.Add(textBoxMathExamScore);
            Controls.Add(textBoxInformaticExamScore);
            Controls.Add(textBoxRussianLanguageExamScore);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxFullName);
            Controls.Add(panel1);
            Name = "ApplicantForm";
            Text = "ApplicantForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox textBoxFullName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBoxRussianLanguageExamScore;
        private TextBox textBoxInformaticExamScore;
        private TextBox textBoxMathExamScore;
        private ComboBox comboBoxGender;
        private ComboBox comboBoxFormOfEducation;
        private DateTimePicker dateTimePickerBirthDay;
        private Label label8;
        private Button buttonAddApplicant;
        private Button buttonCancel;
    }
}