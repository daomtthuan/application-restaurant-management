using Restaurant_Management.dto;
using System.Collections.Generic;
using System.Data;

namespace Restaurant_Management.dao
{
    public class dao_Bill
    {
        private static dao_Bill instance;

        private dao_Bill() { }

        public List<Bill> GetBill(int tableID, int statusID)
        {
            List<Bill> bills = new List<Bill>();
            foreach (DataRow row in DataProvider.Instance.ExecuteQuery("[proc_GetBill] @tableID , @statusID", new object[] { tableID, statusID }).Rows)
            {
                bills.Add(new Bill(row));
            }
            return bills;
        }

        public Bill GetUncheckedOutBill(int tableID)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("[proc_GetBill] @tableID , 0", new object[] { tableID });
            return (data.Rows.Count == 1)? new Bill(data.Rows[0]) : null;     
        }

        public void PayBill(int billID, int discount)
        {
            DataProvider.Instance.ExecuteNonQuery("[proc_PayBill] @billID , @discount", new object[] { billID, discount });
        }

        public static dao_Bill Instance { get => instance ?? new dao_Bill(); private set => instance = value; }
    }
}