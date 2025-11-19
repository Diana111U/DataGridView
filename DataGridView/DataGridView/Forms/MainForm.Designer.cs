namespace DataGridView.App.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            dataGridView1 = new System.Windows.Forms.DataGridView();
            FullName = new DataGridViewTextBoxColumn();
            Gender = new DataGridViewTextBoxColumn();
            BirthDay = new DataGridViewTextBoxColumn();
            FormOfEducation = new DataGridViewTextBoxColumn();
            MathExamScore = new DataGridViewTextBoxColumn();
            RussianLanguageExamScore = new DataGridViewTextBoxColumn();
            InformaticExamScore = new DataGridViewTextBoxColumn();
            TotalAmount = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            AddButton = new ToolStripButton();
            ChangeButton = new ToolStripButton();
            DeleteButton = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { FullName, Gender, BirthDay, FormOfEducation, MathExamScore, RussianLanguageExamScore, InformaticExamScore, TotalAmount });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 25);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1020, 403);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            // 
            // FullName
            // 
            FullName.DataPropertyName = "FullName";
            FullName.HeaderText = "ФИО";
            FullName.Name = "FullName";
            FullName.ReadOnly = true;
            // 
            // Gender
            // 
            Gender.DataPropertyName = "Gender";
            Gender.HeaderText = "Пол";
            Gender.Name = "Gender";
            Gender.ReadOnly = true;
            // 
            // BirthDay
            // 
            BirthDay.DataPropertyName = "BirthDay";
            BirthDay.HeaderText = "Дата рождения";
            BirthDay.Name = "BirthDay";
            BirthDay.ReadOnly = true;
            // 
            // FormOfEducation
            // 
            FormOfEducation.DataPropertyName = "FormOfEducation";
            FormOfEducation.HeaderText = "Форма обучения";
            FormOfEducation.Name = "FormOfEducation";
            FormOfEducation.ReadOnly = true;
            // 
            // MathExamScore
            // 
            MathExamScore.DataPropertyName = "MathExamScore";
            MathExamScore.HeaderText = "Баллы ЕГЭ по математике";
            MathExamScore.Name = "MathExamScore";
            MathExamScore.ReadOnly = true;
            // 
            // RussianLanguageExamScore
            // 
            RussianLanguageExamScore.DataPropertyName = "RussianLanguageExamScore";
            RussianLanguageExamScore.HeaderText = "Баллы ЕГЭ по русскому";
            RussianLanguageExamScore.Name = "RussianLanguageExamScore";
            RussianLanguageExamScore.ReadOnly = true;
            // 
            // InformaticExamScore
            // 
            InformaticExamScore.DataPropertyName = "InformaticExamScore";
            InformaticExamScore.HeaderText = "Баллы ЕГЭ по информатике";
            InformaticExamScore.Name = "InformaticExamScore";
            InformaticExamScore.ReadOnly = true;
            // 
            // TotalAmount
            // 
            TotalAmount.HeaderText = "Общая сумма баллов";
            TotalAmount.Name = "TotalAmount";
            TotalAmount.ReadOnly = true;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { AddButton, ChangeButton, DeleteButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1020, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // AddButton
            // 
            AddButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            AddButton.Image = (Image)resources.GetObject("AddButton.Image");
            AddButton.ImageTransparentColor = Color.Magenta;
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(135, 22);
            AddButton.Text = "Добавить абитуриента";
            AddButton.Click += AddButton_Click;
            // 
            // ChangeButton
            // 
            ChangeButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ChangeButton.Image = (Image)resources.GetObject("ChangeButton.Image");
            ChangeButton.ImageTransparentColor = Color.Magenta;
            ChangeButton.Name = "ChangeButton";
            ChangeButton.Size = new Size(137, 22);
            ChangeButton.Text = "Изменить абитуриента";
            ChangeButton.Click += ChangeButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            DeleteButton.Image = (Image)resources.GetObject("DeleteButton.Image");
            DeleteButton.ImageTransparentColor = Color.Magenta;
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(127, 22);
            DeleteButton.Text = "Удалить абитуриента";
            DeleteButton.Click += DeleteButton_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel3 });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1020, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(108, 17);
            toolStripStatusLabel1.Text = "Кол-во абитур-ов:";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(201, 17);
            toolStripStatusLabel2.Text = "Кол-во абитур-ов с баллами > 150:";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(63, 17);
            toolStripStatusLabel3.Text = "Проходят:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 450);
            Controls.Add(dataGridView1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Name = "MainForm";
            Text = "Приёмная комиссия";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private ToolStripButton AddButton;
        private ToolStripButton ChangeButton;
        private ToolStripButton DeleteButton;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn Gender;
        private DataGridViewTextBoxColumn BirthDay;
        private DataGridViewTextBoxColumn FormOfEducation;
        private DataGridViewTextBoxColumn MathExamScore;
        private DataGridViewTextBoxColumn RussianLanguageExamScore;
        private DataGridViewTextBoxColumn InformaticExamScore;
        private DataGridViewTextBoxColumn TotalAmount;
    }
}
