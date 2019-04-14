using Restaurant_Management.dto;
using System.Collections.Generic;
using System.Data;

namespace Restaurant_Management.dao
{
    class FoodTableDao
    {
        private static FoodTableDao instance;
        
        private FoodTableDao() { }       

        public List<FoodTable> loadFoodTables()
        {
            List<FoodTable> foodTablesList = new List<FoodTable>();
            DataTable data = DataProvider.Instance.ExecuteQuery("[getFoodTablesList]");
            foreach (DataRow item in data.Rows)
            {
                foodTablesList.Add(new FoodTable(item));
            }
            return foodTablesList;
        }

        public static FoodTableDao Instance { get => instance ?? new FoodTableDao(); private set => instance = value; }
    }
}
