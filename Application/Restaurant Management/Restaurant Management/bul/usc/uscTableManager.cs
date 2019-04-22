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
            List<FoodCategory> categories = FoodCategoryDao.Instance.GetFoodCategory();
            lkuCategory.Properties.DataSource = categories;
            lkuCategory.Properties.DisplayMember = "Name";
            lkuCategory.Properties.ValueMember = "ID";
            lkuCategory.Properties.DropDownRows = (categories.Count <= 20) ? categories.Count : 20;
            lkuCategory.EditValue = 0;
            Cursor = Cursors.Default;
        }


        private void LoadFoodName(int CategoryID)
        {
            Cursor = Cursors.WaitCursor;
            List<Food> foods = FoodDao.Instance.GetFood(CategoryID);
            lkuFood.Properties.DataSource = foods;
            lkuFood.Properties.DisplayMember = "Name";
            lkuFood.Properties.ValueMember = "ID";
            lkuFood.Properties.DropDownRows = (foods.Count <= 20) ? foods.Count : 20;
            lkuFood.EditValue = foods[0].ID;
            spinQuantity.Value = 0;
            Cursor = Cursors.Default;
        }

        private void LoadTable()
        {
            Cursor = Cursors.WaitCursor;
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
            Cursor = Cursors.Default;
        }

        private void ShowBill(int TableID)
        {
            Cursor = Cursors.WaitCursor;
            int sumPrice = 0;
            Bill bill = BillDao.Instance.GetUncheckedOutBill(TableID);
            DataTable data = BillDetailDao.Instance.GetBillDetail((bill != null) ? bill.ID : -1);           

            data.Columns.RemoveAt(0);
            data.Columns[0].ColumnName = "Tên món";
            data.Columns[1].ColumnName = "Số lượng";
            data.Columns[2].ColumnName = "Đơn giá";
            data.Columns[3].ColumnName = "Giá tiền";
            ctrlBillDetail.DataSource = data;
            viewBillDetail.Columns[0].Width = 300;

            lblCheckIn.Text = (bill != null) ? "Thời gian vào: " + bill.CheckIn.ToString() : "";            

            foreach (DataRow row in data.Rows) sumPrice += (int)row[3];
            tbxSumPrice.EditValue = sumPrice;
            tbxTotalPrice.EditValue = sumPrice;
            spinSale.Value = 0;
            btnPay.Tag = (bill != null) ? bill.ID : -1;
            Cursor = Cursors.Default;
        }

        private void Btn_Click(object sender, EventArgs e)
        {          
            viewBillDetail.Tag = (sender as SimpleButton).Tag;
            ShowBill((viewBillDetail.Tag as Table).ID);
            lblTableName.Text = "Tền bàn: " + (viewBillDetail.Tag as Table).Name; 
        }

        private void TbxSumPrice_EditValueChanged(object sender, EventArgs e)
        {
            spinSale.ReadOnly = (int)tbxSumPrice.EditValue == 0;
            btnPay.Enabled = (int)tbxSumPrice.EditValue != 0;
        }

        private void BtnAddFood_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
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
            Cursor = Cursors.Default;
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
            using (frmPayBill frmPayBill = new frmPayBill((int)btnPay.Tag, lblTableName.Text, lblCheckIn.Text, ctrlBillDetail.DataSource as DataTable, Int32.Parse(tbxSumPrice.Text), Int32.Parse(tbxSalePrice.Text), Int32.Parse(tbxTotalPrice.Text)))
            {
                frmPayBill.ShowDialog();
                if (frmPayBill.isPay)
                {
                    int tableID = (viewBillDetail.Tag as Table).ID;
                    SimpleButton btn = (SimpleButton)layoutTable.Controls[tableID];           
                    btn.Text = btn.Text.Replace("Có người", "Trống");
                    btn.Appearance.BackColor = btnAddFood.Appearance.BackColor;
                    ctrlBillDetail.DataSource = null;
                    layoutTable.Controls[tableID].Focus();
                }
            }
        }
    }
}
