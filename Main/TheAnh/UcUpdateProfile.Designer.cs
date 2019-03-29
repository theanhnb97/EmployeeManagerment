namespace Main
{
    partial class UcUpdateProfile
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
            this.txtFullName = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtIdentity = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtAddress = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtPhone = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtEmail = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnAdd = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFullName
            // 
            this.txtFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFullName.HintForeColor = System.Drawing.Color.Empty;
            this.txtFullName.HintText = "Họ và tên";
            this.txtFullName.isPassword = false;
            this.txtFullName.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtFullName.LineIdleColor = System.Drawing.Color.Gray;
            this.txtFullName.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtFullName.LineThickness = 3;
            this.txtFullName.Location = new System.Drawing.Point(171, 68);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(282, 44);
            this.txtFullName.TabIndex = 0;
            this.txtFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFullName.Click += new System.EventHandler(this.txtEdit_Click);
            this.txtFullName.Leave += new System.EventHandler(this.txtEditLeave_Click);
            // 
            // txtIdentity
            // 
            this.txtIdentity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIdentity.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtIdentity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtIdentity.HintForeColor = System.Drawing.Color.Empty;
            this.txtIdentity.HintText = "Số CMND";
            this.txtIdentity.isPassword = false;
            this.txtIdentity.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtIdentity.LineIdleColor = System.Drawing.Color.Gray;
            this.txtIdentity.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtIdentity.LineThickness = 3;
            this.txtIdentity.Location = new System.Drawing.Point(171, 157);
            this.txtIdentity.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdentity.Name = "txtIdentity";
            this.txtIdentity.Size = new System.Drawing.Size(282, 44);
            this.txtIdentity.TabIndex = 1;
            this.txtIdentity.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtIdentity.Click += new System.EventHandler(this.txtEdit_Click);
            this.txtIdentity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Key_KeyPress);
            this.txtIdentity.Leave += new System.EventHandler(this.txtEditLeave_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAddress.HintForeColor = System.Drawing.Color.Empty;
            this.txtAddress.HintText = "Địa chỉ";
            this.txtAddress.isPassword = false;
            this.txtAddress.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtAddress.LineIdleColor = System.Drawing.Color.Gray;
            this.txtAddress.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtAddress.LineThickness = 3;
            this.txtAddress.Location = new System.Drawing.Point(171, 249);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(282, 44);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAddress.Click += new System.EventHandler(this.txtEdit_Click);
            this.txtAddress.Leave += new System.EventHandler(this.txtEditLeave_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPhone.HintForeColor = System.Drawing.Color.Empty;
            this.txtPhone.HintText = "Điện thoại";
            this.txtPhone.isPassword = false;
            this.txtPhone.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtPhone.LineIdleColor = System.Drawing.Color.Gray;
            this.txtPhone.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtPhone.LineThickness = 3;
            this.txtPhone.Location = new System.Drawing.Point(171, 342);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(282, 44);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPhone.Click += new System.EventHandler(this.txtEdit_Click);
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Key_KeyPress);
            this.txtPhone.Leave += new System.EventHandler(this.txtEditLeave_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmail.HintForeColor = System.Drawing.Color.Empty;
            this.txtEmail.HintText = "Email";
            this.txtEmail.isPassword = false;
            this.txtEmail.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtEmail.LineIdleColor = System.Drawing.Color.Gray;
            this.txtEmail.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtEmail.LineThickness = 3;
            this.txtEmail.Location = new System.Drawing.Point(171, 437);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(282, 44);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.Click += new System.EventHandler(this.txtEdit_Click);
            this.txtEmail.Leave += new System.EventHandler(this.txtEditLeave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Activecolor = System.Drawing.Color.SteelBlue;
            this.btnAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.BorderRadius = 0;
            this.btnAdd.ButtonText = "Cập nhật";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DisabledColor = System.Drawing.Color.Gray;
            this.btnAdd.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAdd.Iconimage = null;
            this.btnAdd.Iconimage_right = null;
            this.btnAdd.Iconimage_right_Selected = null;
            this.btnAdd.Iconimage_Selected = null;
            this.btnAdd.IconMarginLeft = 0;
            this.btnAdd.IconMarginRight = 0;
            this.btnAdd.IconRightVisible = true;
            this.btnAdd.IconRightZoom = 0D;
            this.btnAdd.IconVisible = true;
            this.btnAdd.IconZoom = 90D;
            this.btnAdd.IsTab = false;
            this.btnAdd.Location = new System.Drawing.Point(377, 521);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Normalcolor = System.Drawing.Color.SteelBlue;
            this.btnAdd.OnHovercolor = System.Drawing.Color.SteelBlue;
            this.btnAdd.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAdd.selected = false;
            this.btnAdd.Size = new System.Drawing.Size(76, 36);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Cập nhật";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Textcolor = System.Drawing.Color.White;
            this.btnAdd.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Cập nhật tài khoản:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Họ tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Số CMND";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(89, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(70, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Điện thoại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(95, 460);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Email";
            // 
            // UcUpdateProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtIdentity);
            this.Controls.Add(this.txtFullName);
            this.Name = "UcUpdateProfile";
            this.Size = new System.Drawing.Size(809, 588);
            this.Load += new System.EventHandler(this.UcUpdateProfile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuMaterialTextbox txtFullName;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtIdentity;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtAddress;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPhone;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtEmail;
        private Bunifu.Framework.UI.BunifuFlatButton btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}