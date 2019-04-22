using Restaurant_Management.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management.dao
{
    public class BillDao
    {
        private static BillDao instance;

        private BillDao() { }

        public List<Bill> GetBill(int tableID, int statusID)
        {
            List<Bill> bills = new List<Bill>();
            foreach (DataRow row in DataProvider.Instance.ExecuteQuery("[procGetBill] @tableID , @statusID", new object[] { tableID, statusID }).Rows)
            {
                bills.Add(new Bill(row));
            }
            return bills;
        }

        public Bill GetUncheckedOutBill(int tableID)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("[procGetBill] @tableID , 0", new object[] { tableID });
            return (data.Rows.Count == 1)? new Bill(data.Rows[0]) : null;     
        }

        public void PayBill(int billID, int sale)
        {
            DataProvider.Instance.ExecuteNonQuery("[procPayBill] @billID , @sale", new object[] { billID, sale});
        }

        public static BillDao Instance { get => instance ?? new BillDao(); private set => instance = value; }
    }
}
