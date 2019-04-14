namespace Restaurant_Management.bul.frm
{
    partial class frmLogin
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbxUsername = new DevExpress.XtraEditors.TextEdit();
            this.tbxPassword = new DevExpress.XtraEditors.TextEdit();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbxUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(12, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(296, 37);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Đăng nhập hệ thống";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 70);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(114, 23);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tên đăng nhập";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 135);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 23);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Mật khẩu";
            // 
            // tbxUsername
            // 
            this.tbxUsername.EditValue = "admin";
            this.tbxUsername.Location = new System.Drawing.Point(12, 99);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Properties.MaxLength = 100;
            this.tbxUsername.Size = new System.Drawing.Size(296, 30);
            this.tbxUsername.TabIndex = 1;
            // 
            // tbxPassword
            // 
            this.tbxPassword.EditValue = "admin";
            this.tbxPassword.Location = new System.Drawing.Point(12, 164);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Properties.MaxLength = 100;
            this.tbxPassword.Properties.UseSystemPasswordChar = true;
            this.tbxPassword.Size = new System.Drawing.Size(296, 30);
            this.tbxPassword.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(195, 200);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(113, 38);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 258);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.tbxUsername);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán ăn";
            ((System.ComponentModel.ISupportInitialize)(this.tbxUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit tbxUsername;
        private DevExpress.XtraEditors.TextEdit tbxPassword;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
    }
}