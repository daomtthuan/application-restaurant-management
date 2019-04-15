using Restaurant_Management.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management.dao
{
    public class BillDetailDao
    {
        private static BillDetailDao instance;

        private BillDetailDao() { }

        public List<BillDetail> GetBillDetail(int billID)
        {
            List<BillDetail> billDetail = new List<BillDetail>();
            string query = "EXEC [getBillDetail] @billID";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { billID });

            foreach (DataRow item in data.Rows)
            {
                billDetail.Add(new BillDetail(item));
            }
            return billDetail;
        }

        public static BillDetailDao Instance { get => instance ?? new BillDetailDao(); private set => instance = value; }
    }
}
