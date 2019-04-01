namespace Main
{
    partial class AddTask
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
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.cmbAssign = new System.Windows.Forms.ComboBox();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.lbTaskName = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbAssign = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbDepartment = new System.Windows.Forms.Label();
            this.lbLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(118, 81);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(203, 20);
            this.txtTaskName.TabIndex = 0;
            this.txtTaskName.TextChanged += new System.EventHandler(this.txtTaskName_TextChanged);
            this.txtTaskName.Leave += new System.EventHandler(this.txtTaskName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên Công Việc :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phòng/Ban : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Người Nhận : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hạn Chót : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mô Tả : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 348);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mức Độ : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tệp Đính Kèm : ";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(118, 258);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(203, 68);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            this.txtDescription.Leave += new System.EventHandler(this.txtDescription_Leave);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(118, 450);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(246, 450);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(118, 129);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(203, 21);
            this.cmbDepartment.TabIndex = 1;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(118, 210);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDueDate.TabIndex = 3;
            this.dtpDueDate.ValueChanged += new System.EventHandler(this.dtpDueDate_ValueChanged);
            this.dtpDueDate.Leave += new System.EventHandler(this.dtpDueDate_Leave);
            // 
            // cmbAssign
            // 
            this.cmbAssign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssign.FormattingEnabled = true;
            this.cmbAssign.Location = new System.Drawing.Point(118, 172);
            this.cmbAssign.Name = "cmbAssign";
            this.cmbAssign.Size = new System.Drawing.Size(203, 21);
            this.cmbAssign.TabIndex = 2;
            // 
            // cmbLevel
            // 
            this.cmbLevel.DisplayMember = "1,2,3";
            this.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.cmbLevel.Location = new System.Drawing.Point(115, 345);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(203, 21);
            this.cmbLevel.TabIndex = 5;
            this.cmbLevel.ValueMember = "1,2,3";
            // 
            // lbTaskName
            // 
            this.lbTaskName.AutoSize = true;
            this.lbTaskName.ForeColor = System.Drawing.Color.Red;
            this.lbTaskName.Location = new System.Drawing.Point(340, 84);
            this.lbTaskName.Name = "lbTaskName";
            this.lbTaskName.Size = new System.Drawing.Size(17, 13);
            this.lbTaskName.TabIndex = 9;
            this.lbTaskName.Text = "(*)";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.ForeColor = System.Drawing.Color.Red;
            this.lbDescription.Location = new System.Drawing.Point(340, 283);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(17, 13);
            this.lbDescription.TabIndex = 10;
            this.lbDescription.Text = "(*)";
            // 
            // lbAssign
            // 
            this.lbAssign.AutoSize = true;
            this.lbAssign.ForeColor = System.Drawing.Color.Red;
            this.lbAssign.Location = new System.Drawing.Point(340, 177);
            this.lbAssign.Name = "lbAssign";
            this.lbAssign.Size = new System.Drawing.Size(17, 13);
            this.lbAssign.TabIndex = 11;
            this.lbAssign.Text = "(*)";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.ForeColor = System.Drawing.Color.Red;
            this.lbDate.Location = new System.Drawing.Point(340, 215);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(17, 13);
            this.lbDate.TabIndex = 12;
            this.lbDate.Text = "(*)";
            // 
            // lbDepartment
            // 
            this.lbDepartment.AutoSize = true;
            this.lbDepartment.ForeColor = System.Drawing.Color.Red;
            this.lbDepartment.Location = new System.Drawing.Point(340, 134);
            this.lbDepartment.Name = "lbDepartment";
            this.lbDepartment.Size = new System.Drawing.Size(17, 13);
            this.lbDepartment.TabIndex = 13;
            this.lbDepartment.Text = "(*)";
            // 
            // lbLevel
            // 
            this.lbLevel.AutoSize = true;
            this.lbLevel.ForeColor = System.Drawing.Color.Red;
            this.lbLevel.Location = new System.Drawing.Point(340, 345);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Size = new System.Drawing.Size(17, 13);
            this.lbLevel.TabIndex = 14;
            this.lbLevel.Text = "(*)";
            // 
            // AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(398, 497);
            this.Controls.Add(this.lbLevel);
            this.Controls.Add(this.lbDepartment);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbAssign);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbTaskName);
            this.Controls.Add(this.cmbLevel);
            this.Controls.Add(this.cmbAssign);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTaskName);
            this.Name = "AddTask";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddTask";
            this.Load += new System.EventHandler(this.AddTask_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddTask_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.ComboBox cmbAssign;
        private System.Windows.Forms.ComboBox cmbLevel;
        private System.Windows.Forms.Label lbTaskName;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbAssign;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbDepartment;
        private System.Windows.Forms.Label lbLevel;
    }
}