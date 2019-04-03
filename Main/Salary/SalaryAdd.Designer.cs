namespace Main.Dong
{
    partial class SalaryAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveRefresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbbCoefficient = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbDept = new System.Windows.Forms.ComboBox();
            this.cbbRank = new System.Windows.Forms.ComboBox();
            this.cbbIdentity = new System.Windows.Forms.ComboBox();
            this.cbbName = new System.Windows.Forms.ComboBox();
            this.cbbBasic = new System.Windows.Forms.ComboBox();
            this.cbbBussiness = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Mã nhân viên";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Lương cơ bản";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "Họ tên";
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(111, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 74;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveRefresh
            // 
            this.btnSaveRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRefresh.Location = new System.Drawing.Point(195, 380);
            this.btnSaveRefresh.Name = "btnSaveRefresh";
            this.btnSaveRefresh.Size = new System.Drawing.Size(112, 23);
            this.btnSaveRefresh.TabIndex = 75;
            this.btnSaveRefresh.Text = "Lưu và tạo mới";
            this.btnSaveRefresh.UseVisualStyleBackColor = true;
            this.btnSaveRefresh.Click += new System.EventHandler(this.btnSaveRefresh_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(315, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 76;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbbCoefficient
            // 
            this.cbbCoefficient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCoefficient.FormattingEnabled = true;
            this.cbbCoefficient.Location = new System.Drawing.Point(162, 289);
            this.cbbCoefficient.Name = "cbbCoefficient";
            this.cbbCoefficient.Size = new System.Drawing.Size(215, 21);
            this.cbbCoefficient.TabIndex = 87;
            this.cbbCoefficient.SelectedIndexChanged += new System.EventHandler(this.cbbCoefficient_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 78;
            this.label6.Text = "Lương kinh doanh";
            this.label6.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "Hệ số lương";
            this.label2.Click += new System.EventHandler(this.cbbCoefficient_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(73, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "Phòng";
            this.label8.Click += new System.EventHandler(this.label1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 79;
            this.label7.Text = "Chức vụ";
            this.label7.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbbDept
            // 
            this.cbbDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbDept.FormattingEnabled = true;
            this.cbbDept.Location = new System.Drawing.Point(162, 70);
            this.cbbDept.Name = "cbbDept";
            this.cbbDept.Size = new System.Drawing.Size(215, 21);
            this.cbbDept.TabIndex = 81;
            this.cbbDept.SelectedIndexChanged += new System.EventHandler(this.cbbDept_ItemSetected);
            this.cbbDept.TextChanged += new System.EventHandler(this.cbbDept_TextChanged);
            // 
            // cbbRank
            // 
            this.cbbRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRank.FormattingEnabled = true;
            this.cbbRank.Location = new System.Drawing.Point(162, 107);
            this.cbbRank.Name = "cbbRank";
            this.cbbRank.Size = new System.Drawing.Size(215, 21);
            this.cbbRank.TabIndex = 82;
            this.cbbRank.SelectedIndexChanged += new System.EventHandler(this.cbbRank_SelectedIndexChanged);
            // 
            // cbbIdentity
            // 
            this.cbbIdentity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbIdentity.FormattingEnabled = true;
            this.cbbIdentity.Location = new System.Drawing.Point(162, 139);
            this.cbbIdentity.Name = "cbbIdentity";
            this.cbbIdentity.Size = new System.Drawing.Size(215, 21);
            this.cbbIdentity.TabIndex = 83;
            this.cbbIdentity.SelectedIndexChanged += new System.EventHandler(this.cbbIdentity_SelectedIndexChanged);
            this.cbbIdentity.TextChanged += new System.EventHandler(this.cbbIdentity_TextChanged);
            // 
            // cbbName
            // 
            this.cbbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbName.FormattingEnabled = true;
            this.cbbName.Location = new System.Drawing.Point(162, 177);
            this.cbbName.Name = "cbbName";
            this.cbbName.Size = new System.Drawing.Size(215, 21);
            this.cbbName.TabIndex = 84;
            this.cbbName.SelectedIndexChanged += new System.EventHandler(this.cbbName_SelectedIndexChanged);
            this.cbbName.TextChanged += new System.EventHandler(this.cbbName_TextChanged);
            // 
            // cbbBasic
            // 
            this.cbbBasic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBasic.FormattingEnabled = true;
            this.cbbBasic.Location = new System.Drawing.Point(162, 219);
            this.cbbBasic.Name = "cbbBasic";
            this.cbbBasic.Size = new System.Drawing.Size(215, 21);
            this.cbbBasic.TabIndex = 85;
            this.cbbBasic.SelectedIndexChanged += new System.EventHandler(this.cbbBasic_SelectedIndexChanged);
            // 
            // cbbBussiness
            // 
            this.cbbBussiness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBussiness.FormattingEnabled = true;
            this.cbbBussiness.Location = new System.Drawing.Point(162, 251);
            this.cbbBussiness.Name = "cbbBussiness";
            this.cbbBussiness.Size = new System.Drawing.Size(215, 21);
            this.cbbBussiness.TabIndex = 86;
            this.cbbBussiness.SelectedIndexChanged += new System.EventHandler(this.cbbBussiness_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(180, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 18);
            this.label5.TabIndex = 88;
            this.label5.Text = "Tạo bản lương mới";
            // 
            // SalaryAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 433);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbbCoefficient);
            this.Controls.Add(this.cbbBussiness);
            this.Controls.Add(this.cbbBasic);
            this.Controls.Add(this.cbbName);
            this.Controls.Add(this.cbbIdentity);
            this.Controls.Add(this.cbbRank);
            this.Controls.Add(this.cbbDept);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveRefresh);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "SalaryAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalaryAdd";
            this.Load += new System.EventHandler(this.Add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveRefresh;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbbCoefficient;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbDept;
        private System.Windows.Forms.ComboBox cbbRank;
        private System.Windows.Forms.ComboBox cbbIdentity;
        private System.Windows.Forms.ComboBox cbbName;
        private System.Windows.Forms.ComboBox cbbBasic;
        private System.Windows.Forms.ComboBox cbbBussiness;
        private System.Windows.Forms.Label label5;
    }
}