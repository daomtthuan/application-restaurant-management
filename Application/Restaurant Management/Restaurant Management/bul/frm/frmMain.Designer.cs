namespace Restaurant_Management.bul.frm
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.fluContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.aceAdmin = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceEmployeeManager = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceFoodTableManager = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceSetting = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceInformation = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceLogout = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceExit = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluContainer
            // 
            this.fluContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluContainer.Location = new System.Drawing.Point(48, 30);
            this.fluContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fluContainer.Name = "fluContainer";
            this.fluContainer.Size = new System.Drawing.Size(1230, 726);
            this.fluContainer.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.AccessibleName = "";
            this.accordionControl1.ContextButtonsOptions.AllowGlyphSkinning = true;
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceAdmin,
            this.aceSetting});
            this.accordionControl1.Location = new System.Drawing.Point(0, 30);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.accordionControl1.Size = new System.Drawing.Size(48, 726);
            this.accordionControl1.TabIndex = 1;
            // 
            // aceAdmin
            // 
            this.aceAdmin.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceEmployeeManager,
            this.aceFoodTableManager});
            this.aceAdmin.Expanded = true;
            this.aceAdmin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceAdmin.ImageOptions.Image")));
            this.aceAdmin.Name = "aceAdmin";
            this.aceAdmin.Text = "Quản lý";
            // 
            // aceEmployeeManager
            // 
            this.aceEmployeeManager.Name = "aceEmployeeManager";
            this.aceEmployeeManager.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceEmployeeManager.Text = "Nhân viên";
            // 
            // aceFoodTableManager
            // 
            this.aceFoodTableManager.Name = "aceFoodTableManager";
            this.aceFoodTableManager.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceFoodTableManager.Text = "Bàn ăn";
            this.aceFoodTableManager.Click += new System.EventHandler(this.aceFoodTableManager_Click);
            // 
            // aceSetting
            // 
            this.aceSetting.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceInformation,
            this.aceLogout,
            this.aceExit});
            this.aceSetting.Expanded = true;
            this.aceSetting.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl)});
            this.aceSetting.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceSetting.ImageOptions.Image")));
            this.aceSetting.Name = "aceSetting";
            this.aceSetting.Text = "Cài đặt";
            // 
            // aceInformation
            // 
            this.aceInformation.Name = "aceInformation";
            this.aceInformation.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceInformation.Text = "Thông tin tài khoản";
            // 
            // aceLogout
            // 
            this.aceLogout.Name = "aceLogout";
            this.aceLogout.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceLogout.Text = "Đăng xuất";
            this.aceLogout.Click += new System.EventHandler(this.AceLogout_Click);
            // 
            // aceExit
            // 
            this.aceExit.Name = "aceExit";
            this.aceExit.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceExit.Text = "Thoát";
            this.aceExit.Click += new System.EventHandler(this.AceExit_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1278, 30);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 756);
            this.ControlContainer = this.fluContainer;
            this.Controls.Add(this.fluContainer);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.NavigationControl = this.accordionControl1;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán ăn";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceAdmin;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceSetting;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceInformation;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceLogout;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceExit;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceEmployeeManager;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceFoodTableManager;
    }
}