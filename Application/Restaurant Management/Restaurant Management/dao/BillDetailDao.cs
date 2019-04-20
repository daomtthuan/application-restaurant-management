using System.Data;

namespace Restaurant_Management.dao
{
    public class BillDetailDao
    {
        private static BillDetailDao instance;

        private BillDetailDao() { }

        public DataTable GetBillDetail(int billID)
        {
            return DataProvider.Instance.ExecuteQuery("[procGetBillDetailByBillID] @billID", new object[] { billID });
        }

        public void EditBill(int tableID, int foodID, int quantity)
        {
            DataProvider.Instance.ExecuteNonQuery("[procEditBill] @tableID , @foodID , @quantity", new object[] { tableID, foodID, quantity });
        }

        public static BillDetailDao Instance { get => instance ?? new BillDetailDao(); private set => instance = value; }
    }
}
