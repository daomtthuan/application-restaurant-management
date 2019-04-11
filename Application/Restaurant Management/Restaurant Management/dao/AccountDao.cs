using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management.dao
{
    public class AccountDao
    {
        private static AccountDao instance;

        public static AccountDao Instance
        {
            get { if (instance == null) instance = new AccountDao(); return instance; }
            private set { instance = value; }
        }

        private AccountDao() { }

        public bool Login(string username, string password)
        {
            string query = "EXEC [Login] @username , @password";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password});
            return result.Rows.Count > 0;
        }
    }
}
