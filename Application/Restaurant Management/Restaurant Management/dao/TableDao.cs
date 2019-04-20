using Restaurant_Management.dto;
using System.Collections.Generic;
using System.Data;

namespace Restaurant_Management.dao
{
    class TableDao
    {
        private static TableDao instance;
        
        private TableDao() { }       

        public List<Table> LoadTable()
        {
            List<Table> foodTablesList = new List<Table>();
            foreach (DataRow item in DataProvider.Instance.ExecuteQuery("[procGetTable]").Rows)
            {
                foodTablesList.Add(new Table(item));
            }
            return foodTablesList;
        }

        public static TableDao Instance { get => instance ?? new TableDao(); private set => instance = value; }
    }
}
