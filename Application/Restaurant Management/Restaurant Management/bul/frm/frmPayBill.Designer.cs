namespace Restaurant_Management.bul.frm
{
    partial class frmPayBill
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
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.lblTableName = new DevExpress.XtraEditors.LabelControl();
            this.lblCheckIn = new DevExpress.XtraEditors.LabelControl();
            this.btnPay = new DevExpress.XtraEditors.SimpleButton();
            this.tbxSalePrice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tbxSumPrice = new DevExpress.XtraEditors.TextEdit();
            this.tbxTotalPrice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ctrlBillDetail = new DevExpress.XtraGrid.GridControl();
            this.viewBillDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.FoodName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Total = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxSalePrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxSumPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBillDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBillDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.lblTableName);
            this.layoutControl.Controls.Add(this.lblCheckIn);
            this.layoutControl.Controls.Add(this.btnPay);
            this.layoutControl.Controls.Add(this.tbxSalePrice);
            this.layoutControl.Controls.Add(this.labelControl3);
            this.layoutControl.Controls.Add(this.labelControl2);
            this.layoutControl.Controls.Add(this.tbxSumPrice);
            this.layoutControl.Controls.Add(this.tbxTotalPrice);
            this.layoutControl.Controls.Add(this.labelControl1);
            this.layoutControl.Controls.Add(this.ctrlBillDetail);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(312, 196, 650, 400);
            this.layoutControl.Root = this.Root;
            this.layoutControl.Size = new System.Drawing.Size(601, 564);
            this.layoutControl.TabIndex = 9;
            this.layoutControl.Text = "layoutControl1";
            // 
            // lblTableName
            // 
            this.lblTableName.Location = new System.Drawing.Point(12, 12);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(56, 20);
            this.lblTableName.StyleController = this.layoutControl;
            this.lblTableName.TabIndex = 0;
            this.lblTableName.Text = "Tên bàn:";
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.Location = new System.Drawing.Point(12, 36);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(93, 20);
            this.lblCheckIn.StyleController = this.layoutControl;
            this.lblCheckIn.TabIndex = 0;
            this.lblCheckIn.Text = "Thời gian vào:";
            // 
            // btnPay
            // 
            this.btnPay.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnPay.Appearance.Options.UseBackColor = true;
            this.btnPay.Location = new System.Drawing.Point(443, 472);
            this.btnPay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(146, 80);
            this.btnPay.StyleController = this.layoutControl;
            this.btnPay.TabIndex = 12;
            this.btnPay.Text = "Thanh toán";
            this.btnPay.Click += new System.EventHandler(this.BtnPay_Click);
            // 
            // tbxSalePrice
            // 
            this.tbxSalePrice.EditValue = "0";
            this.tbxSalePrice.Location = new System.Drawing.Point(121, 500);
            this.tbxSalePrice.Name = "tbxSalePrice";
            this.tbxSalePrice.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxSalePrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxSalePrice.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tbxSalePrice.Properties.ReadOnly = true;
            this.tbxSalePrice.Size = new System.Drawing.Size(318, 24);
            this.tbxSalePrice.StyleController = this.layoutControl;
            this.tbxSalePrice.TabIndex = 10;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 528);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(105, 24);
            this.labelControl3.StyleController = this.layoutControl;
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Thành tiền";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 500);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(105, 24);
            this.labelControl2.StyleController = this.layoutControl;
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Giảm giá";
            // 
            // tbxSumPrice
            // 
            this.tbxSumPrice.EditValue = "0";
            this.tbxSumPrice.Location = new System.Drawing.Point(121, 472);
            this.tbxSumPrice.Name = "tbxSumPrice";
            this.tbxSumPrice.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxSumPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxSumPrice.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tbxSumPrice.Properties.ReadOnly = true;
            this.tbxSumPrice.Size = new System.Drawing.Size(318, 24);
            this.tbxSumPrice.StyleController = this.layoutControl;
            this.tbxSumPrice.TabIndex = 8;
            // 
            // tbxTotalPrice
            // 
            this.tbxTotalPrice.EditValue = "0";
            this.tbxTotalPrice.Location = new System.Drawing.Point(121, 528);
            this.tbxTotalPrice.Name = "tbxTotalPrice";
            this.tbxTotalPrice.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.tbxTotalPrice.Properties.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.tbxTotalPrice.Properties.Appearance.Options.UseFont = true;
            this.tbxTotalPrice.Properties.Appearance.Options.UseForeColor = true;
            this.tbxTotalPrice.Properties.Appearance.Options.UseTextOptions = true;
            this.tbxTotalPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbxTotalPrice.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tbxTotalPrice.Properties.ReadOnly = true;
            this.tbxTotalPrice.Size = new System.Drawing.Size(318, 24);
            this.tbxTotalPrice.StyleController = this.layoutControl;
            this.tbxTotalPrice.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 472);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(105, 24);
            this.labelControl1.StyleController = this.layoutControl;
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Tổng cộng";
            // 
            // ctrlBillDetail
            // 
            this.ctrlBillDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlBillDetail.Location = new System.Drawing.Point(12, 60);
            this.ctrlBillDetail.MainView = this.viewBillDetail;
            this.ctrlBillDetail.Name = "ctrlBillDetail";
            this.ctrlBillDetail.Size = new System.Drawing.Size(577, 408);
            this.ctrlBillDetail.TabIndex = 6;
            this.ctrlBillDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewBillDetail});
            // 
            // viewBillDetail
            // 
            this.viewBillDetail.ActiveFilterEnabled = false;
            this.viewBillDetail.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.viewBillDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.viewBillDetail.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.viewBillDetail.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.viewBillDetail.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.viewBillDetail.DetailHeight = 368;
            this.viewBillDetail.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.viewBillDetail.GridControl = this.ctrlBillDetail;
            this.viewBillDetail.Name = "viewBillDetail";
            this.viewBillDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.viewBillDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.viewBillDetail.OptionsBehavior.Editable = false;
            this.viewBillDetail.OptionsCustomization.AllowColumnMoving = false;
            this.viewBillDetail.OptionsCustomization.AllowFilter = false;
            this.viewBillDetail.OptionsCustomization.AllowGroup = false;
            this.viewBillDetail.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
            this.viewBillDetail.OptionsCustomization.AllowQuickHideColumns = false;
            this.viewBillDetail.OptionsCustomization.AllowSort = false;
            this.viewBillDetail.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.viewBillDetail.OptionsFilter.AllowColumnMRUFilterList = false;
            this.viewBillDetail.OptionsFilter.AllowFilterEditor = false;
            this.viewBillDetail.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.viewBillDetail.OptionsFilter.AllowMRUFilterList = false;
            this.viewBillDetail.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
            this.viewBillDetail.OptionsLayout.Columns.AddNewColumns = false;
            this.viewBillDetail.OptionsLayout.Columns.RemoveOldColumns = false;
            this.viewBillDetail.OptionsLayout.Columns.StoreLayout = false;
            this.viewBillDetail.OptionsMenu.EnableColumnMenu = false;
            this.viewBillDetail.OptionsMenu.EnableFooterMenu = false;
            this.viewBillDetail.OptionsMenu.EnableGroupPanelMenu = false;
            this.viewBillDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewBillDetail.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.viewBillDetail.OptionsView.AllowGlyphSkinning = true;
            this.viewBillDetail.OptionsView.ShowGroupPanel = false;
            this.viewBillDetail.OptionsView.ShowIndicator = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem11,
            this.layoutControlItem18,
            this.layoutControlItem12,
            this.layoutControlItem14,
            this.layoutControlItem13,
            this.layoutControlItem17,
            this.layoutControlItem19,
            this.layoutControlItem20,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(601, 564);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ctrlBillDetail;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(581, 412);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.labelControl1;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 460);
            this.layoutControlItem11.MinSize = new System.Drawing.Size(75, 24);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(109, 28);
            this.layoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.labelControl2;
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 488);
            this.layoutControlItem18.MinSize = new System.Drawing.Size(64, 24);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(109, 28);
            this.layoutControlItem18.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.tbxSumPrice;
            this.layoutControlItem12.Location = new System.Drawing.Point(109, 460);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(322, 28);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.tbxSalePrice;
            this.layoutControlItem14.Location = new System.Drawing.Point(109, 488);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(322, 28);
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.labelControl3;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 516);
            this.layoutControlItem13.MinSize = new System.Drawing.Size(77, 24);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(109, 28);
            this.layoutControlItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.tbxTotalPrice;
            this.layoutControlItem17.Location = new System.Drawing.Point(109, 516);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(322, 28);
            this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem17.TextVisible = false;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.btnPay;
            this.layoutControlItem19.Location = new System.Drawing.Point(431, 460);
            this.layoutControlItem19.MinSize = new System.Drawing.Size(85, 29);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(150, 84);
            this.layoutControlItem19.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextVisible = false;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.lblTableName;
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(581, 24);
            this.layoutControlItem20.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem20.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lblCheckIn;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(581, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // FoodName
            // 
            this.FoodName.Caption = "Tên món";
            this.FoodName.Name = "FoodName";
            this.FoodName.Visible = true;
            this.FoodName.VisibleIndex = 0;
            this.FoodName.Width = 300;
            // 
            // Quantity
            // 
            this.Quantity.Caption = "Số lượng";
            this.Quantity.Name = "Quantity";
            this.Quantity.Visible = true;
            this.Quantity.VisibleIndex = 1;
            this.Quantity.Width = 79;
            // 
            // Price
            // 
            this.Price.Caption = "Đơn giá";
            this.Price.Name = "Price";
            this.Price.Visible = true;
            this.Price.VisibleIndex = 2;
            this.Price.Width = 79;
            // 
            // Total
            // 
            this.Total.Caption = "Giá tiền";
            this.Total.Name = "Total";
            this.Total.Visible = true;
            this.Total.VisibleIndex = 3;
            this.Total.Width = 85;
            // 
            // frmPayBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 564);
            this.Controls.Add(this.layoutControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayBill";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán hoá đơn";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxSalePrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxSumPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTotalPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlBillDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBillDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.LabelControl lblTableName;
        private DevExpress.XtraEditors.LabelControl lblCheckIn;
        private DevExpress.XtraEditors.SimpleButton btnPay;
        private DevExpress.XtraEditors.TextEdit tbxSalePrice;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit tbxSumPrice;
        private DevExpress.XtraEditors.TextEdit tbxTotalPrice;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl ctrlBillDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView viewBillDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn FoodName;
        private DevExpress.XtraGrid.Columns.GridColumn Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private DevExpress.XtraGrid.Columns.GridColumn Total;
    }
}