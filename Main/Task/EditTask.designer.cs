namespace Main.Bang
{
    partial class frmEditTask
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
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.cmbAssign = new System.Windows.Forms.ComboBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.btnCacncel = new System.Windows.Forms.Button();
            this.lbLevel = new System.Windows.Forms.Label();
            this.lbDepartment = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbAssign = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbTaskName = new System.Windows.Forms.Label();
            this.linkFile = new System.Windows.Forms.LinkLabel();
            this.btnSelectfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.cmbLevel.Location = new System.Drawing.Point(120, 293);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(206, 21);
            this.cmbLevel.TabIndex = 35;
            this.cmbLevel.ValueMember = "1,2,3";
            // 
            // cmbAssign
            // 
            this.cmbAssign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssign.FormattingEnabled = true;
            this.cmbAssign.Location = new System.Drawing.Point(123, 120);
            this.cmbAssign.Name = "cmbAssign";
            this.cmbAssign.Size = new System.Drawing.Size(203, 21);
            this.cmbAssign.TabIndex = 34;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(123, 158);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(203, 20);
            this.dtpDueDate.TabIndex = 33;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(123, 77);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(203, 21);
            this.cmbDepartment.TabIndex = 32;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(108, 395);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 30;
            this.btnUpdate.Text = "UpDate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnUpdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnUpdate_KeyDown);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(123, 206);
            this.txtDescription.MaxLength = 2000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(203, 68);
            this.txtDescription.TabIndex = 29;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            this.txtDescription.Leave += new System.EventHandler(this.txtDescription_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 343);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Tệp Đính Kèm : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Mức Độ : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Mô Tả : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Hạn Chót : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Người Nhận : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Phòng/Ban : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Tên Công Việc :";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(123, 29);
            this.txtTaskName.MaxLength = 200;
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(203, 20);
            this.txtTaskName.TabIndex = 21;
            this.txtTaskName.TextChanged += new System.EventHandler(this.txtTaskName_TextChanged);
            this.txtTaskName.Leave += new System.EventHandler(this.txtTaskName_Leave);
            // 
            // btnCacncel
            // 
            this.btnCacncel.Location = new System.Drawing.Point(227, 395);
            this.btnCacncel.Name = "btnCacncel";
            this.btnCacncel.Size = new System.Drawing.Size(75, 23);
            this.btnCacncel.TabIndex = 36;
            this.btnCacncel.Text = "Cancel";
            this.btnCacncel.UseVisualStyleBackColor = true;
            this.btnCacncel.Click += new System.EventHandler(this.btnCacncel_Click);
            // 
            // lbLevel
            // 
            this.lbLevel.AutoSize = true;
            this.lbLevel.ForeColor = System.Drawing.Color.Red;
            this.lbLevel.Location = new System.Drawing.Point(345, 296);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Size = new System.Drawing.Size(17, 13);
            this.lbLevel.TabIndex = 42;
            this.lbLevel.Text = "(*)";
            // 
            // lbDepartment
            // 
            this.lbDepartment.AutoSize = true;
            this.lbDepartment.ForeColor = System.Drawing.Color.Red;
            this.lbDepartment.Location = new System.Drawing.Point(345, 80);
            this.lbDepartment.Name = "lbDepartment";
            this.lbDepartment.Size = new System.Drawing.Size(17, 13);
            this.lbDepartment.TabIndex = 41;
            this.lbDepartment.Text = "(*)";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.ForeColor = System.Drawing.Color.Red;
            this.lbDate.Location = new System.Drawing.Point(345, 163);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(17, 13);
            this.lbDate.TabIndex = 40;
            this.lbDate.Text = "(*)";
            // 
            // lbAssign
            // 
            this.lbAssign.AutoSize = true;
            this.lbAssign.ForeColor = System.Drawing.Color.Red;
            this.lbAssign.Location = new System.Drawing.Point(345, 124);
            this.lbAssign.Name = "lbAssign";
            this.lbAssign.Size = new System.Drawing.Size(17, 13);
            this.lbAssign.TabIndex = 39;
            this.lbAssign.Text = "(*)";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.ForeColor = System.Drawing.Color.Red;
            this.lbDescription.Location = new System.Drawing.Point(345, 234);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(17, 13);
            this.lbDescription.TabIndex = 38;
            this.lbDescription.Text = "(*)";
            // 
            // lbTaskName
            // 
            this.lbTaskName.AutoSize = true;
            this.lbTaskName.ForeColor = System.Drawing.Color.Red;
            this.lbTaskName.Location = new System.Drawing.Point(345, 32);
            this.lbTaskName.Name = "lbTaskName";
            this.lbTaskName.Size = new System.Drawing.Size(17, 13);
            this.lbTaskName.TabIndex = 37;
            this.lbTaskName.Text = "(*)";
            // 
            // linkFile
            // 
            this.linkFile.AutoSize = true;
            this.linkFile.Location = new System.Drawing.Point(123, 373);
            this.linkFile.Name = "linkFile";
            this.linkFile.Size = new System.Drawing.Size(0, 13);
            this.linkFile.TabIndex = 44;
            // 
            // btnSelectfile
            // 
            this.btnSelectfile.Location = new System.Drawing.Point(123, 343);
            this.btnSelectfile.Name = "btnSelectfile";
            this.btnSelectfile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectfile.TabIndex = 43;
            this.btnSelectfile.Text = "Chọn file";
            this.btnSelectfile.UseVisualStyleBackColor = true;
            this.btnSelectfile.Click += new System.EventHandler(this.btnSelectfile_Click);
            // 
            // frmEditTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(408, 450);
            this.Controls.Add(this.linkFile);
            this.Controls.Add(this.btnSelectfile);
            this.Controls.Add(this.lbLevel);
            this.Controls.Add(this.lbDepartment);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbAssign);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbTaskName);
            this.Controls.Add(this.btnCacncel);
            this.Controls.Add(this.cmbLevel);
            this.Controls.Add(this.cmbAssign);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTaskName);
            this.Name = "frmEditTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditTask";
            this.Load += new System.EventHandler(this.EditTask_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLevel;
        private System.Windows.Forms.ComboBox cmbAssign;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Button btnCacncel;
        private System.Windows.Forms.Label lbLevel;
        private System.Windows.Forms.Label lbDepartment;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbAssign;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbTaskName;
        private System.Windows.Forms.LinkLabel linkFile;
        private System.Windows.Forms.Button btnSelectfile;
    }
}