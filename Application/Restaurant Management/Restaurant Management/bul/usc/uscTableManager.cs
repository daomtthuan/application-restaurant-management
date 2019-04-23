using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using Restaurant_Management.dao;
using Restaurant_Management.dto;
using DevExpress.LookAndFeel;
using System.Data;
using System.Windows.Forms;
using Restaurant_Management.bul.frm;

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
            Cursor = Cursors.WaitCursor;
            List<FoodCategory> categories = dao_FoodCategory.Instance.GetFoodCategory();
            lku_Category.Properties.DataSource = categories;
            lku_Category.Properties.DisplayMember = "Name";
            lku_Category.Properties.ValueMember = "ID";
            lku_Category.Properties.DropDownRows = (categories.Count <= 20) ? categories.Count : 20;
            lku_Category.EditValue = 0;
            Cursor = Cursors.Default;
        }


        private void LoadFoodName(int CategoryID)
        {
            Cursor = Cursors.WaitCursor;
            List<Food> foods = dao_Food.Instance.GetFood(CategoryID);
            lku_Food.Properties.DataSource = foods;
            lku_Food.Properties.DisplayMember = "Name";
            lku_Food.Properties.ValueMember = "ID";
            lku_Food.Properties.DropDownRows = (foods.Count <= 20) ? foods.Count : 20;
            lku_Food.EditValue = foods[0].ID;
            spin_Quantity.Value = 0;
            Cursor = Cursors.Default;
        }

        private void LoadTable()
        {
            Cursor = Cursors.WaitCursor;
            List<Table> tables = dao_Table.Instance.LoadTable();
            foreach (Table item in tables)
            {
                SimpleButton btn = new SimpleButton()
                {
                    Name = "btnFoodTable" + item.ID.ToString(),
                    Text = item.Name + Environment.NewLine + (item.StatusID == 1 ? "Có người" : "Trống")
                };

                btn.Appearance.BackColor = (item.StatusID == 1) ? DXSkinColors.FillColors.Primary : btn_EditBill.Appearance.BackColor;
                btn.Tag = item;
                btn.Click += Btn_Click;
                layoutTable.Controls.Add(btn);
            }
            Cursor = Cursors.Default;
        }

        private void ShowBill(int TableID)
        {
            Cursor = Cursors.WaitCursor;
            int sumPrice = 0;
            Bill bill = dao_Bill.Instance.GetUncheckedOutBill(TableID);
            DataTable data = dao_BillDetail.Instance.GetBillDetail((bill != null) ? bill.ID : -1);

            data.Columns.RemoveAt(0);
            data.Columns[0].ColumnName = "Tên món";
            data.Columns[1].ColumnName = "Số lượng";
            data.Columns[2].ColumnName = "Đơn giá";
            data.Columns[3].ColumnName = "Giá tiền";
            ctrlBillDetail.DataSource = data;
            viewBillDetail.Columns[0].Width = 300;

            lbl_CheckIn.Text = (bill != null) ? "Thời gian vào: " + bill.CheckIn.ToString() : "";

            foreach (DataRow row in data.Rows) sumPrice += (int)row[3];
            tbx_SumPrice.EditValue = sumPrice;
            tbx_TotalPrice.EditValue = sumPrice;
            spin_Discount.Value = 0;
            btn_Pay.Tag = (bill != null) ? bill.ID : -1;
            Cursor = Cursors.Default;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            viewBillDetail.Tag = (sender as SimpleButton).Tag;
            ShowBill((viewBillDetail.Tag as Table).ID);
            lbl_TableName.Text = "Tền bàn: " + (viewBillDetail.Tag as Table).Name;
        }

        private void TbxSumPrice_EditValueChanged(object sender, EventArgs e)
        {
            spin_Discount.ReadOnly = (int)tbx_SumPrice.EditValue == 0;
            btn_Pay.Enabled = (int)tbx_SumPrice.EditValue != 0;
        }

        private void LkuCategory_EditValueChanged(object sender, EventArgs e)
        {
            LoadFoodName((int)lku_Category.EditValue);
        }

        private void LkuFood_EditValueChanged(object sender, EventArgs e)
        {
            spin_Quantity.Value = 0;
        }

        private void SpinDiscount_EditValueChanged(object sender, EventArgs e)
        {
            tbx_DiscountPrice.EditValue = (int)tbx_SumPrice.EditValue * spin_Discount.Value / 100;
            tbx_TotalPrice.EditValue = (int)tbx_SumPrice.EditValue - (int)tbx_SumPrice.EditValue * spin_Discount.Value / 100;
        }

        private void SpinQuantity_EditValueChanged(object sender, EventArgs e)
        {
            if (((DataView)viewBillDetail.DataSource).Count == 0 && spin_Quantity.Value < 0)
                spin_Quantity.Value = 0;
            btn_EditBill.Enabled = spin_Quantity.Value != 0;
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

        private void Btn_EditBill_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (spin_Quantity.Value != 0)
            {
                int tableID = (viewBillDetail.Tag as Table).ID;
                dao_BillDetail.Instance.EditBill(tableID, (int)lku_Food.EditValue, (int)spin_Quantity.Value);
                ShowBill(tableID);

                SimpleButton btn = (SimpleButton)layoutTable.Controls[tableID];
                if (((DataView)viewBillDetail.DataSource).Count == 0)
                {
                    btn.Text = btn.Text.Replace("Có người", "Trống");
                    btn.Appearance.BackColor = btn_EditBill.Appearance.BackColor;
                }
                else
                {
                    btn.Text = btn.Text.Replace("Trống", "Có người");
                    btn.Appearance.BackColor = DXSkinColors.FillColors.Primary;
                }
                spin_Quantity.Value = 0;
            }
            Cursor = Cursors.Default;
        }

        private void Btn_Pay_Click(object sender, EventArgs e)
        {
            using (frmPayBill frmPayBill = new frmPayBill((int)btn_Pay.Tag, lbl_TableName.Text, lbl_CheckIn.Text, ctrlBillDetail.DataSource as DataTable, Int32.Parse(tbx_SumPrice.Text), Int32.Parse(tbx_DiscountPrice.Text), Int32.Parse(tbx_TotalPrice.Text)))
            {
                frmPayBill.ShowDialog();
                if (frmPayBill.isPay)
                {
                    int tableID = (viewBillDetail.Tag as Table).ID;
                    SimpleButton btn = (SimpleButton)layoutTable.Controls[tableID];
                    btn.Text = btn.Text.Replace("Có người", "Trống");
                    btn.Appearance.BackColor = btn_EditBill.Appearance.BackColor;
                    ctrlBillDetail.DataSource = null;
                    layoutTable.Controls[tableID].Focus();
                    tbx_SumPrice.EditValue = 0;
                    tbx_TotalPrice.EditValue = 0;
                    spin_Discount.Value = 0;
                }
            }
        }
    }
}
