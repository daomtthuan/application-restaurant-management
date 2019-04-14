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
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password});
            return (result.Rows.Count == 1)? result.Rows[0][0] : null;
        }

        public static AccountDao Instance { get => instance ?? new AccountDao(); private set => instance = value; }
    }
}
