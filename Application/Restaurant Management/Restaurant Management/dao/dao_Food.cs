using Restaurant_Management.dto;
using System.Collections.Generic;
using System.Data;

namespace Restaurant_Management.dao
{
    public class dao_Food
    {
        private static dao_Food instance;

        private dao_Food() { }

        public List<Food> GetFood(int categoryID)
        {
            List<Food> foods = new List<Food>();
            foreach (DataRow row in DataProvider.Instance.ExecuteQuery("[proc_GetFood] @categoryID", new object[] { categoryID }).Rows)
            {
                foods.Add(new Food(row));
            }
            return foods;
        }

        public static dao_Food Instance { get => instance ?? new dao_Food(); private set => instance = value; }
    }
}
