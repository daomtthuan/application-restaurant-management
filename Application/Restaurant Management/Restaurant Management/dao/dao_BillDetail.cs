using System.Data;

namespace Restaurant_Management.dao
{
    public class dao_BillDetail
    {
        private static dao_BillDetail instance;

        private dao_BillDetail() { }

        public DataTable GetBillDetail(int billID)
        {
            return DataProvider.Instance.ExecuteQuery("[proc_GetBillDetailByBillID] @billID", new object[] { billID });
        }

        public void EditBill(int tableID, int foodID, int quantity)
        {
            DataProvider.Instance.ExecuteNonQuery("[proc_EditBill] @tableID , @foodID , @quantity", new object[] { tableID, foodID, quantity });
        }

        public static dao_BillDetail Instance { get => instance ?? new dao_BillDetail(); private set => instance = value; }
    }
}
