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

        public int GetUncheckedOutBillID(int tableID)
        {
            var data = DataProvider.Instance.ExecuteScalar("[procGetUncheckedOutBillID] @tableID", new object[] { tableID });
            return (data == null) ? -1 : (int)data;
        }

        public static BillDao Instance { get => instance ?? new BillDao(); private set => instance = value; }
    }
}
