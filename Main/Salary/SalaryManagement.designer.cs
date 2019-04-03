namespace Main
{
    partial class SalaryManagement
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAllPageSalary = new System.Windows.Forms.Label();
            this.lblPagingSalaryIndex = new System.Windows.Forms.Label();
            this.btnNextSalary = new System.Windows.Forms.Button();
            this.btnPreSalary = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSalary = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelDate = new System.Windows.Forms.Panel();
            this.dateTDateFilter = new System.Windows.Forms.DateTimePicker();
            this.dateFDateFilter = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDeptFilter = new System.Windows.Forms.TextBox();
            this.txtNameFilter = new System.Windows.Forms.TextBox();
            this.cbbRecordNum = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panelDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 57);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Salary Management";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbbRecordNum);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lblAllPageSalary);
            this.panel2.Controls.Add(this.lblPagingSalaryIndex);
            this.panel2.Controls.Add(this.btnNextSalary);
            this.panel2.Controls.Add(this.btnPreSalary);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnLoadData);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 537);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(809, 77);
            this.panel2.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(724, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "/";
            // 
            // lblAllPageSalary
            // 
            this.lblAllPageSalary.AutoSize = true;
            this.lblAllPageSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllPageSalary.Location = new System.Drawing.Point(736, 9);
            this.lblAllPageSalary.Name = "lblAllPageSalary";
            this.lblAllPageSalary.Size = new System.Drawing.Size(21, 15);
            this.lblAllPageSalary.TabIndex = 18;
            this.lblAllPageSalary.Text = "10";
            // 
            // lblPagingSalaryIndex
            // 
            this.lblPagingSalaryIndex.AutoSize = true;
            this.lblPagingSalaryIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagingSalaryIndex.Location = new System.Drawing.Point(704, 10);
            this.lblPagingSalaryIndex.Name = "lblPagingSalaryIndex";
            this.lblPagingSalaryIndex.Size = new System.Drawing.Size(17, 15);
            this.lblPagingSalaryIndex.TabIndex = 15;
            this.lblPagingSalaryIndex.Text = "1 ";
            // 
            // btnNextSalary
            // 
            this.btnNextSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextSalary.Location = new System.Drawing.Point(767, 6);
            this.btnNextSalary.Name = "btnNextSalary";
            this.btnNextSalary.Size = new System.Drawing.Size(27, 23);
            this.btnNextSalary.TabIndex = 17;
            this.btnNextSalary.Text = ">";
            this.btnNextSalary.UseVisualStyleBackColor = true;
            this.btnNextSalary.Click += new System.EventHandler(this.btnNextSalary_Click);
            // 
            // btnPreSalary
            // 
            this.btnPreSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreSalary.Location = new System.Drawing.Point(666, 6);
            this.btnPreSalary.Name = "btnPreSalary";
            this.btnPreSalary.Size = new System.Drawing.Size(27, 23);
            this.btnPreSalary.TabIndex = 16;
            this.btnPreSalary.Text = "<";
            this.btnPreSalary.UseVisualStyleBackColor = true;
            this.btnPreSalary.Click += new System.EventHandler(this.btnPreSalary_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(115, 30);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(22, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(206, 30);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadData.Location = new System.Drawing.Point(295, 30);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 10;
            this.btnLoadData.Text = "Search";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(388, 30);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Refresh";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSalary);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(809, 338);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Salary Information";
            // 
            // dgvSalary
            // 
            this.dgvSalary.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalary.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSalary.Location = new System.Drawing.Point(3, 16);
            this.dgvSalary.Name = "dgvSalary";
            this.dgvSalary.Size = new System.Drawing.Size(803, 318);
            this.dgvSalary.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelDate);
            this.groupBox2.Controls.Add(this.chkDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDeptFilter);
            this.groupBox2.Controls.Add(this.txtNameFilter);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(809, 142);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter area";
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.dateTDateFilter);
            this.panelDate.Controls.Add(this.dateFDateFilter);
            this.panelDate.Controls.Add(this.label5);
            this.panelDate.Controls.Add(this.label2);
            this.panelDate.Location = new System.Drawing.Point(6, 74);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(797, 62);
            this.panelDate.TabIndex = 18;
            // 
            // dateTDateFilter
            // 
            this.dateTDateFilter.Location = new System.Drawing.Point(471, 21);
            this.dateTDateFilter.Name = "dateTDateFilter";
            this.dateTDateFilter.Size = new System.Drawing.Size(201, 20);
            this.dateTDateFilter.TabIndex = 18;
            // 
            // dateFDateFilter
            // 
            this.dateFDateFilter.Location = new System.Drawing.Point(165, 21);
            this.dateFDateFilter.Name = "dateFDateFilter";
            this.dateFDateFilter.Size = new System.Drawing.Size(201, 20);
            this.dateFDateFilter.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(407, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "To date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "From date";
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(111, 53);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(135, 17);
            this.chkDate.TabIndex = 17;
            this.chkDate.Text = "Search By Create Date";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Department";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(109, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Name";
            // 
            // txtDeptFilter
            // 
            this.txtDeptFilter.Location = new System.Drawing.Point(477, 21);
            this.txtDeptFilter.Name = "txtDeptFilter";
            this.txtDeptFilter.Size = new System.Drawing.Size(201, 20);
            this.txtDeptFilter.TabIndex = 12;
            // 
            // txtNameFilter
            // 
            this.txtNameFilter.Location = new System.Drawing.Point(171, 22);
            this.txtNameFilter.Name = "txtNameFilter";
            this.txtNameFilter.Size = new System.Drawing.Size(201, 20);
            this.txtNameFilter.TabIndex = 12;
            // 
            // cbbRecordNum
            // 
            this.cbbRecordNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRecordNum.FormattingEnabled = true;
            this.cbbRecordNum.Location = new System.Drawing.Point(611, 6);
            this.cbbRecordNum.Name = "cbbRecordNum";
            this.cbbRecordNum.Size = new System.Drawing.Size(49, 21);
            this.cbbRecordNum.TabIndex = 20;
            this.cbbRecordNum.SelectedIndexChanged += new System.EventHandler(this.cbbRecordNum_SelectedIndexChanged);
            // 
            // SalaryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SalaryManagement";
            this.Size = new System.Drawing.Size(809, 614);
            this.Load += new System.EventHandler(this.Salary_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSalary;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDeptFilter;
        private System.Windows.Forms.TextBox txtNameFilter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAllPageSalary;
        private System.Windows.Forms.Label lblPagingSalaryIndex;
        private System.Windows.Forms.Button btnNextSalary;
        private System.Windows.Forms.Button btnPreSalary;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.Panel panelDate;
        private System.Windows.Forms.DateTimePicker dateTDateFilter;
        private System.Windows.Forms.DateTimePicker dateFDateFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbRecordNum;
    }
}
