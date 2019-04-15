using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Restaurant_Management.dao;
using Restaurant_Management.dto;

namespace Restaurant_Management.bul.usc
{
    public partial class uscTableManager : DevExpress.XtraEditors.XtraUserControl
    {
        public uscTableManager()
        {
            InitializeComponent();

            loadFoodTables();
        }

        #region Method
        private void loadFoodTables()
        {
            List<FoodTable> foodTablesList = FoodTableDao.Instance.loadFoodTables();
            foreach (FoodTable item in foodTablesList)
            {
                SimpleButton btn = new SimpleButton()
                {
                    Name = "btnFoodTable" + item.ID,
                    Text = item.Name + Environment.NewLine + item.Status,
                    Width = 100,
                    Height = 100
                };

                if (item.Status == "Có người")
                    btn.Appearance.BackColor = Color.FromArgb(16, 110, 190);

                btn.Tag = item;
                btn.Click += Btn_Click;

                flpFoodTable.Controls.Add(btn);
            }
        }

        private void showBill(int TableID)
        {
            lsvBillDetail.Items.Clear();
            List<BillDetail> billDetail = BillDetailDao.Instance.GetBillDetail(BillDao.Instance.getUncheckedOut_BillID_by_TableID(TableID));
            foreach (BillDetail item in billDetail)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodID.ToString());
                lsvItem.SubItems.Add(item.Quantity.ToString());
                lsvBillDetail.Items.Add(lsvItem);
            }
        }

        #endregion

        #region Events
        private void Btn_Click(object sender, EventArgs e)
        {
            int TableID = ((sender as SimpleButton).Tag as FoodTable).ID;
            showBill(TableID);
        }
        #endregion
    }
}
