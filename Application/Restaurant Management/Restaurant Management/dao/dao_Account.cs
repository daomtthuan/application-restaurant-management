using System.Data;

namespace Restaurant_Management.dao
{
    public class dao_Account
    {
        private static dao_Account instance;

        private dao_Account() { }

        public int GetAccountID(string username, string password)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("[proc_GetAccountID] @username , @password", new object[] { username, password });
            return (data.Rows.Count == 1) ? (int)data.Rows[0][0] : -1;
        }

        public static dao_Account Instance { get => instance ?? new dao_Account(); private set => instance = value; }
    }
}
