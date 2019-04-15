using System.Data;

namespace Restaurant_Management.dao
{
    public class AccountDao
    {
        private static AccountDao instance;

        private AccountDao() { }

        public object getAccountID(string username, string password)
        {
            string query = "EXEC [getAccountID] @username , @password";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });
            return (data.Rows.Count == 1) ? data.Rows[0][0] : null;
        }

        public static AccountDao Instance { get => instance ?? new AccountDao(); private set => instance = value; }
    }
}
