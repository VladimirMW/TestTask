
namespace SetParams
{
    public partial class FormServiceParams
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelServiceType = new System.Windows.Forms.Label();
            this.comboBoxServiceType = new System.Windows.Forms.ComboBox();
            this.labelServicePath = new System.Windows.Forms.Label();
            this.textBoxServicePath = new System.Windows.Forms.TextBox();
            this.labelAttemptsQuantity = new System.Windows.Forms.Label();
            this.textBoxAttemptsQuantity = new System.Windows.Forms.TextBox();
            this.labelCheckInterval = new System.Windows.Forms.Label();
            this.textBoxCheckInterval = new System.Windows.Forms.TextBox();
            this.labeldCorrectState = new System.Windows.Forms.Label();
            this.textBoxCorrectState = new System.Windows.Forms.TextBox();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelServiceName = new System.Windows.Forms.Label();
            this.textBoxServiceName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelServiceType
            // 
            this.labelServiceType.AutoSize = true;
            this.labelServiceType.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelServiceType.Location = new System.Drawing.Point(12, 29);
            this.labelServiceType.Name = "labelServiceType";
            this.labelServiceType.Size = new System.Drawing.Size(71, 13);
            this.labelServiceType.TabIndex = 3;
            this.labelServiceType.Text = "Тип сервиса";
            // 
            // comboBoxServiceType
            // 
            this.comboBoxServiceType.FormattingEnabled = true;
            this.comboBoxServiceType.Items.AddRange(new object[] {
            "WEB",
            "Console"});
            this.comboBoxServiceType.Location = new System.Drawing.Point(142, 29);
            this.comboBoxServiceType.Name = "comboBoxServiceType";
            this.comboBoxServiceType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxServiceType.TabIndex = 4;
            this.comboBoxServiceType.SelectedIndexChanged += new System.EventHandler(this.comboBoxServiceType_SelectedIndexChanged);
            // 
            // labelServicePath
            // 
            this.labelServicePath.AutoSize = true;
            this.labelServicePath.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelServicePath.Location = new System.Drawing.Point(12, 53);
            this.labelServicePath.Name = "labelServicePath";
            this.labelServicePath.Size = new System.Drawing.Size(89, 13);
            this.labelServicePath.TabIndex = 5;
            this.labelServicePath.Text = "Адресс сервиса";
            // 
            // textBoxServicePath
            // 
            this.textBoxServicePath.Location = new System.Drawing.Point(142, 53);
            this.textBoxServicePath.Name = "textBoxServicePath";
            this.textBoxServicePath.Size = new System.Drawing.Size(442, 20);
            this.textBoxServicePath.TabIndex = 0;
            // 
            // labelAttemptsQuantity
            // 
            this.labelAttemptsQuantity.AutoSize = true;
            this.labelAttemptsQuantity.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelAttemptsQuantity.Location = new System.Drawing.Point(12, 107);
            this.labelAttemptsQuantity.Name = "labelAttemptsQuantity";
            this.labelAttemptsQuantity.Size = new System.Drawing.Size(112, 13);
            this.labelAttemptsQuantity.TabIndex = 5;
            this.labelAttemptsQuantity.Text = "Количество попыток";
            // 
            // textBoxAttemptsQuantity
            // 
            this.textBoxAttemptsQuantity.Location = new System.Drawing.Point(142, 107);
            this.textBoxAttemptsQuantity.Name = "textBoxAttemptsQuantity";
            this.textBoxAttemptsQuantity.Size = new System.Drawing.Size(121, 20);
            this.textBoxAttemptsQuantity.TabIndex = 6;
            this.textBoxAttemptsQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAttemptsQuantity_KeyPress);
            // 
            // labelCheckInterval
            // 
            this.labelCheckInterval.AutoSize = true;
            this.labelCheckInterval.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelCheckInterval.Location = new System.Drawing.Point(12, 133);
            this.labelCheckInterval.Name = "labelCheckInterval";
            this.labelCheckInterval.Size = new System.Drawing.Size(107, 13);
            this.labelCheckInterval.TabIndex = 7;
            this.labelCheckInterval.Text = "Интервал проверки";
            // 
            // textBoxCheckInterval
            // 
            this.textBoxCheckInterval.Location = new System.Drawing.Point(142, 133);
            this.textBoxCheckInterval.Name = "textBoxCheckInterval";
            this.textBoxCheckInterval.Size = new System.Drawing.Size(121, 20);
            this.textBoxCheckInterval.TabIndex = 6;
            this.textBoxCheckInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCheckInterval_KeyPress);
            // 
            // labeldCorrectState
            // 
            this.labeldCorrectState.AutoSize = true;
            this.labeldCorrectState.Cursor = System.Windows.Forms.Cursors.Default;
            this.labeldCorrectState.Location = new System.Drawing.Point(12, 162);
            this.labeldCorrectState.Name = "labeldCorrectState";
            this.labeldCorrectState.Size = new System.Drawing.Size(329, 13);
            this.labeldCorrectState.TabIndex = 7;
            this.labeldCorrectState.Text = "Условия корректности: код WEB ответа/возраста файла (мин)";
            // 
            // textBoxCorrectState
            // 
            this.textBoxCorrectState.Location = new System.Drawing.Point(347, 162);
            this.textBoxCorrectState.Name = "textBoxCorrectState";
            this.textBoxCorrectState.Size = new System.Drawing.Size(100, 20);
            this.textBoxCorrectState.TabIndex = 8;
            this.textBoxCorrectState.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCorrectState_KeyPress);
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(188, 204);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 9;
            this.ButtonOk.Text = "Ok";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(350, 204);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(269, 204);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelServiceName
            // 
            this.labelServiceName.AutoSize = true;
            this.labelServiceName.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelServiceName.Location = new System.Drawing.Point(12, 83);
            this.labelServiceName.Name = "labelServiceName";
            this.labelServiceName.Size = new System.Drawing.Size(74, 13);
            this.labelServiceName.TabIndex = 5;
            this.labelServiceName.Text = "Имя сервиса";
            // 
            // textBoxServiceName
            // 
            this.textBoxServiceName.Location = new System.Drawing.Point(142, 80);
            this.textBoxServiceName.Name = "textBoxServiceName";
            this.textBoxServiceName.Size = new System.Drawing.Size(121, 20);
            this.textBoxServiceName.TabIndex = 6;
            this.textBoxServiceName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAttemptsQuantity_KeyPress);
            // 
            // FormServiceParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 239);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.textBoxCorrectState);
            this.Controls.Add(this.labeldCorrectState);
            this.Controls.Add(this.labelCheckInterval);
            this.Controls.Add(this.textBoxCheckInterval);
            this.Controls.Add(this.textBoxServiceName);
            this.Controls.Add(this.textBoxAttemptsQuantity);
            this.Controls.Add(this.labelServiceName);
            this.Controls.Add(this.labelAttemptsQuantity);
            this.Controls.Add(this.labelServicePath);
            this.Controls.Add(this.comboBoxServiceType);
            this.Controls.Add(this.labelServiceType);
            this.Controls.Add(this.textBoxServicePath);
            this.Name = "FormServiceParams";
            this.Text = "Параметры сервиса проверки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormServiceParams_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelServiceType;
        private System.Windows.Forms.ComboBox comboBoxServiceType;
        private System.Windows.Forms.Label labelServicePath;
        private System.Windows.Forms.TextBox textBoxServicePath;
        private System.Windows.Forms.Label labelAttemptsQuantity;
        private System.Windows.Forms.TextBox textBoxAttemptsQuantity;
        private System.Windows.Forms.Label labelCheckInterval;
        private System.Windows.Forms.TextBox textBoxCheckInterval;
        private System.Windows.Forms.Label labeldCorrectState;
        private System.Windows.Forms.TextBox textBoxCorrectState;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelServiceName;
        private System.Windows.Forms.TextBox textBoxServiceName;
    }
}

