using System.Windows.Forms;

namespace Restaurant_Management.bul.usc
{
    partial class uscTableManager
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
            this.lsvBillDetail = new System.Windows.Forms.ListView();
            this.flpFoodTable = new System.Windows.Forms.FlowLayoutPanel();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lsvBillDetail
            // 
            this.lsvBillDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvBillDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvBillDetail.GridLines = true;
            this.lsvBillDetail.Location = new System.Drawing.Point(630, 10);
            this.lsvBillDetail.Name = "lsvBillDetail";
            this.lsvBillDetail.Size = new System.Drawing.Size(867, 938);
            this.lsvBillDetail.TabIndex = 1;
            this.lsvBillDetail.UseCompatibleStateImageBehavior = false;
            this.lsvBillDetail.View = System.Windows.Forms.View.Details;
            // 
            // flpFoodTable
            // 
            this.flpFoodTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpFoodTable.AutoScroll = true;
            this.flpFoodTable.Location = new System.Drawing.Point(9, 10);
            this.flpFoodTable.Name = "flpFoodTable";
            this.flpFoodTable.Size = new System.Drawing.Size(615, 938);
            this.flpFoodTable.TabIndex = 2;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "FoodID";
            this.columnHeader1.Width = 135;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Quantity";
            this.columnHeader2.Width = 361;
            // 
            // uscTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpFoodTable);
            this.Controls.Add(this.lsvBillDetail);
            this.Name = "uscTableManager";
            this.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Size = new System.Drawing.Size(1506, 958);
            this.ResumeLayout(false);

        }

        #endregion
        private ListView lsvBillDetail;
        private FlowLayoutPanel flpFoodTable;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}
