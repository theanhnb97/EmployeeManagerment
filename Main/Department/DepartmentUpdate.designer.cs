namespace Main.Department
{
    partial class DepartmentUpdate
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCannel = new System.Windows.Forms.Button();
            this.cmbActive = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(88, 304);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCannel
            // 
            this.btnCannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCannel.Location = new System.Drawing.Point(224, 304);
            this.btnCannel.Name = "btnCannel";
            this.btnCannel.Size = new System.Drawing.Size(75, 23);
            this.btnCannel.TabIndex = 7;
            this.btnCannel.Text = "Cannel";
            this.btnCannel.UseVisualStyleBackColor = true;
            this.btnCannel.Click += new System.EventHandler(this.btnCannel_Click);
            // 
            // cmbActive
            // 
            this.cmbActive.DisplayMember = "1,2,3";
            this.cmbActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActive.FormattingEnabled = true;
            this.cmbActive.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.cmbActive.Location = new System.Drawing.Point(88, 240);
            this.cmbActive.Name = "cmbActive";
            this.cmbActive.Size = new System.Drawing.Size(215, 21);
            this.cmbActive.TabIndex = 80;
            this.cmbActive.ValueMember = "1,2,3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 81;
            this.label6.Text = "Active :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(128, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(82, 15);
            this.lblTitle.TabIndex = 79;
            this.lblTitle.Text = "Department";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 75;
            this.label7.Text = "Decription";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 76;
            this.label8.Text = "Họ tên";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(88, 80);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(215, 129);
            this.txtDescription.TabIndex = 74;
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(88, 48);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(215, 20);
            this.txtDepartmentName.TabIndex = 73;
            // 
            // DepartmentUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 356);
            this.Controls.Add(this.cmbActive);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtDepartmentName);
            this.Controls.Add(this.btnCannel);
            this.Controls.Add(this.btnUpdate);
            this.Name = "DepartmentUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DepartmentUpdate";
            this.Load += new System.EventHandler(this.DepartmentUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCannel;
        private System.Windows.Forms.ComboBox cmbActive;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtDepartmentName;
    }
}