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

        /// <summary>
        /// Thành công: BillID
        /// Thất bại: -1
        /// </summary>
        /// <param name="tableID"></param>
        /// <returns></returns>
        public int getUncheckedOut_BillID_by_TableID(int tableID)
        {
            string query = "EXEC [getUncheckedOutBill] @tableID";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tableID });
            return (data.Rows.Count > 0) ?  new Bill(data.Rows[0]).ID : -1;
        }

        public static BillDao Instance { get => instance ?? new BillDao(); private set => instance = value; } 
    }
}
