namespace DataGridView.App.Forms
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
            components = new System.ComponentModel.Container();
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
            comboBoxGender = new ComboBox();
            comboBoxFormOfEducation = new ComboBox();
            dateTimePickerBirthDay = new DateTimePicker();
            buttonAddApplicant = new Button();
            buttonCancel = new Button();
            errorProvider1 = new ErrorProvider(components);
            MathExamScorenumericUpDown = new NumericUpDown();
            RussianLanguageExamScorenumericUpDown = new NumericUpDown();
            InformaticExamScorenumericUpDown = new NumericUpDown();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MathExamScorenumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RussianLanguageExamScorenumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InformaticExamScorenumericUpDown).BeginInit();
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
            textBoxFullName.Location = new Point(302, 155);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(236, 23);
            textBoxFullName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(238, 158);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 2;
            label1.Text = "ФИО";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(238, 197);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 3;
            label2.Text = "Пол";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(182, 241);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 4;
            label3.Text = "День рождения";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(173, 285);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 5;
            label4.Text = "Форма обучения";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(78, 317);
            label5.Name = "label5";
            label5.Size = new Size(196, 15);
            label5.TabIndex = 6;
            label5.Text = "Кол-во баллов ЕГЭ по математике";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(90, 355);
            label6.Name = "label6";
            label6.Size = new Size(184, 15);
            label6.TabIndex = 7;
            label6.Text = "Кол-во баллов ЕГЭ по русскому";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(67, 386);
            label7.Name = "label7";
            label7.Size = new Size(207, 15);
            label7.TabIndex = 8;
            label7.Text = "Кол-во баллов ЕГЭ по информатике";
            // 
            // comboBoxGender
            // 
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.FormattingEnabled = true;
            comboBoxGender.Location = new Point(302, 194);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(121, 23);
            comboBoxGender.TabIndex = 13;
            // 
            // comboBoxFormOfEducation
            // 
            comboBoxFormOfEducation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFormOfEducation.FormattingEnabled = true;
            comboBoxFormOfEducation.Location = new Point(303, 277);
            comboBoxFormOfEducation.Name = "comboBoxFormOfEducation";
            comboBoxFormOfEducation.Size = new Size(159, 23);
            comboBoxFormOfEducation.TabIndex = 14;
            // 
            // dateTimePickerBirthDay
            // 
            dateTimePickerBirthDay.Location = new Point(302, 235);
            dateTimePickerBirthDay.MaxDate = new DateTime(2100, 1, 1, 0, 0, 0, 0);
            dateTimePickerBirthDay.MinDate = new DateTime(2003, 1, 1, 0, 0, 0, 0);
            dateTimePickerBirthDay.Name = "dateTimePickerBirthDay";
            dateTimePickerBirthDay.Size = new Size(200, 23);
            dateTimePickerBirthDay.TabIndex = 15;
            dateTimePickerBirthDay.UseWaitCursor = true;
            // 
            // buttonAddApplicant
            // 
            buttonAddApplicant.Location = new Point(212, 454);
            buttonAddApplicant.Name = "buttonAddApplicant";
            buttonAddApplicant.Size = new Size(75, 30);
            buttonAddApplicant.TabIndex = 16;
            buttonAddApplicant.Text = "Добавить";
            buttonAddApplicant.UseVisualStyleBackColor = true;
            buttonAddApplicant.Click += buttonAddApplicant_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(348, 454);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 30);
            buttonCancel.TabIndex = 17;
            buttonCancel.Text = "Отменить";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // MathExamScorenumericUpDown
            // 
            MathExamScorenumericUpDown.Location = new Point(303, 317);
            MathExamScorenumericUpDown.Name = "MathExamScorenumericUpDown";
            MathExamScorenumericUpDown.Size = new Size(120, 23);
            MathExamScorenumericUpDown.TabIndex = 18;
            // 
            // RussianLanguageExamScorenumericUpDown
            // 
            RussianLanguageExamScorenumericUpDown.Location = new Point(303, 349);
            RussianLanguageExamScorenumericUpDown.Name = "RussianLanguageExamScorenumericUpDown";
            RussianLanguageExamScorenumericUpDown.Size = new Size(120, 23);
            RussianLanguageExamScorenumericUpDown.TabIndex = 19;
            // 
            // InformaticExamScorenumericUpDown
            // 
            InformaticExamScorenumericUpDown.Location = new Point(303, 384);
            InformaticExamScorenumericUpDown.Name = "InformaticExamScorenumericUpDown";
            InformaticExamScorenumericUpDown.Size = new Size(120, 23);
            InformaticExamScorenumericUpDown.TabIndex = 20;
            // 
            // ApplicantForm
            // 
            AcceptButton = buttonAddApplicant;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(640, 516);
            Controls.Add(InformaticExamScorenumericUpDown);
            Controls.Add(RussianLanguageExamScorenumericUpDown);
            Controls.Add(MathExamScorenumericUpDown);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAddApplicant);
            Controls.Add(dateTimePickerBirthDay);
            Controls.Add(comboBoxFormOfEducation);
            Controls.Add(comboBoxGender);
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
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)MathExamScorenumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)RussianLanguageExamScorenumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)InformaticExamScorenumericUpDown).EndInit();
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
        private ComboBox comboBoxGender;
        private ComboBox comboBoxFormOfEducation;
        private DateTimePicker dateTimePickerBirthDay;
        private Label label8;
        private Button buttonAddApplicant;
        private Button buttonCancel;
        private ErrorProvider errorProvider1;
        private NumericUpDown InformaticExamScorenumericUpDown;
        private NumericUpDown RussianLanguageExamScorenumericUpDown;
        private NumericUpDown MathExamScorenumericUpDown;
    }
}