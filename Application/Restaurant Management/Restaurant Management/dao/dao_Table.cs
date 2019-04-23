using Restaurant_Management.dto;
using System.Collections.Generic;
using System.Data;

namespace Restaurant_Management.dao
{
    class dao_Table
    {
        private static dao_Table instance;
        
        private dao_Table() { }       

        public List<Table> LoadTable()
        {
            List<Table> foodTablesList = new List<Table>();
            foreach (DataRow item in DataProvider.Instance.ExecuteQuery("[proc_GetTable]").Rows)
            {
                foodTablesList.Add(new Table(item));
            }
            return foodTablesList;
        }

        public static dao_Table Instance { get => instance ?? new dao_Table(); private set => instance = value; }
    }
}
