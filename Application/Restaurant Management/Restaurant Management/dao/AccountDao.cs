using System.Data;

namespace Restaurant_Management.dao
{
    public class AccountDao
    {
        private static AccountDao instance;

        private AccountDao() { }

        public int GetAccountID(string username, string password)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("[procGetAccountID] @username , @password", new object[] { username, password });
            return (data.Rows.Count == 1) ? (int)data.Rows[0][0] : -1;
        }

        public static AccountDao Instance { get => instance ?? new AccountDao(); private set => instance = value; }
    }
}
