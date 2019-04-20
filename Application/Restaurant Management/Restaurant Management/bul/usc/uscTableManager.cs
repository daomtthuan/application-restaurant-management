using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using Restaurant_Management.dao;
using Restaurant_Management.dto;
using DevExpress.LookAndFeel;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using DevExpress.Utils.Extensions;
using DevExpress.XtraPrinting.Native;

namespace Restaurant_Management.bul.usc
{
    public partial class uscTableManager : XtraUserControl
    {
        public uscTableManager()
        {
            InitializeComponent();

            LoadTable();
            LoadCategory();
            LoadFoodName(0);
        }

        private void LoadCategory()
        {
            List<FoodCategory> categories = FoodCategoryDao.Instance.GetFoodCategory();
            lkuCategory.Properties.DataSource = categories;
            lkuCategory.Properties.DisplayMember = "Name";
            lkuCategory.Properties.ValueMember = "ID";
            lkuCategory.Properties.DropDownRows = (categories.Count <= 20) ? categories.Count : 20;
            lkuCategory.EditValue = 0;
        }


        private void LoadFoodName(int CategoryID)
        {
            List<Food> foods = FoodDao.Instance.GetFood(CategoryID);
            lkuFood.Properties.DataSource = foods;
            lkuFood.Properties.DisplayMember = "Name";
            lkuFood.Properties.ValueMember = "ID";
            lkuFood.Properties.DropDownRows = (foods.Count <= 20) ? foods.Count : 20;
            lkuFood.EditValue = foods[0].ID;
            spinQuantity.Value = 0;
        }

        private void LoadTable()
        {
            List<Table> tables = TableDao.Instance.LoadTable();
            foreach (Table item in tables)
            {
                SimpleButton btn = new SimpleButton()
                {
                    Name = "btnFoodTable" + item.ID.ToString(),
                    Text = item.Name + Environment.NewLine + (item.StatusID == 1 ? "Có người" : "Trống")                 
                };

                btn.Appearance.BackColor = (item.StatusID == 1) ? DXSkinColors.FillColors.Primary : btnAddFood.Appearance.BackColor;
                btn.Tag = item;
                btn.Click += Btn_Click;
                layoutTable.Controls.Add(btn);
            }
        }

        private void ShowBill(int TableID)
        {
            DataTable data = BillDetailDao.Instance.GetBillDetail(BillDao.Instance.GetUncheckedOutBillID(TableID));

            data.Columns.RemoveAt(0);
            data.Columns[0].ColumnName = "Tên món";
            data.Columns[1].ColumnName = "Số lượng";
            data.Columns[2].ColumnName = "Đơn giá";
            data.Columns[3].ColumnName = "Thành tiền";
            ctrlBillDetail.DataSource = data;
            viewBillDetail.Columns[0].Width = 300;

            int sumPrice = 0;
            foreach (DataRow row in data.Rows)
            {
                sumPrice += (int)row[3];
            }

            tbxSumPrice.EditValue = sumPrice;
            tbxTotalPrice.EditValue = sumPrice;
            spinSale.Value = 0;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            viewBillDetail.Tag = (sender as SimpleButton).Tag;
            ShowBill((viewBillDetail.Tag as Table).ID);
        }

        private void ViewBillDetail_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.VisibleIndex == 2 || e.Column.VisibleIndex == 3)
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        }

        private void TbxSumPrice_EditValueChanged(object sender, EventArgs e)
        {
            spinSale.ReadOnly = (int)tbxSumPrice.EditValue == 0;
            btnPay.Enabled = (int)tbxSumPrice.EditValue != 0;
        }

        private void BtnAddFood_Click(object sender, EventArgs e)
        {
            if (spinQuantity.Value != 0)
            {
                int tableID = (viewBillDetail.Tag as Table).ID;
                BillDetailDao.Instance.EditBill(tableID, (int)lkuFood.EditValue, (int)spinQuantity.Value);
                ShowBill(tableID);

                SimpleButton btn = (SimpleButton)layoutTable.Controls[tableID];
                if (((DataView)viewBillDetail.DataSource).Count == 0)
                {
                    btn.Text = btn.Text.Replace("Có người", "Trống");
                    btn.Appearance.BackColor = btnAddFood.Appearance.BackColor;
                }
                else
                {
                    btn.Text = btn.Text.Replace("Trống", "Có người");
                    btn.Appearance.BackColor = DXSkinColors.FillColors.Primary;
                }
                spinQuantity.Value = 0;
            }
        }

        private void LkuCategory_EditValueChanged(object sender, EventArgs e)
        {
            LoadFoodName((int)lkuCategory.EditValue);
        }

        private void LkuFood_EditValueChanged(object sender, EventArgs e)
        {
            spinQuantity.Value = 0;
        }

        private void SpinSale_EditValueChanged(object sender, EventArgs e)
        {
            tbxSalePrice.EditValue = (int)tbxSumPrice.EditValue * spinSale.Value / 100;
            tbxTotalPrice.EditValue = (int)tbxSumPrice.EditValue - (int)tbxSumPrice.EditValue * spinSale.Value / 100;
        }

        private void SpinQuantity_EditValueChanged(object sender, EventArgs e)
        {
            if (((DataView)viewBillDetail.DataSource).Count == 0 && spinQuantity.Value < 0)
                spinQuantity.Value = 0;
            btnAddFood.Enabled = spinQuantity.Value != 0;
        }

        private void LayoutTable_Resize(object sender, EventArgs e)
        {
            int i = 0;
            do { i++; } while (layoutTable.Width - SystemInformation.VerticalScrollBarWidth - i * 6 > i * 110);
            for (int j = layoutTable.Controls.Count - 1; j >= 0; j--)
            {
                layoutTable.Controls[j].Width = (layoutTable.Width - SystemInformation.VerticalScrollBarWidth - i * 6) / i;
                layoutTable.Controls[j].Height = layoutTable.Controls[j].Width;
            }
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {

        }
    }
}
