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
            this.listView1 = new System.Windows.Forms.ListView();
            this.flpFoodTable = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Location = new System.Drawing.Point(630, 10);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(867, 938);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
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
            // uscTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpFoodTable);
            this.Controls.Add(this.listView1);
            this.Name = "uscTableManager";
            this.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Size = new System.Drawing.Size(1506, 958);
            this.ResumeLayout(false);

        }

        #endregion
        private ListView listView1;
        private FlowLayoutPanel flpFoodTable;
    }
}
