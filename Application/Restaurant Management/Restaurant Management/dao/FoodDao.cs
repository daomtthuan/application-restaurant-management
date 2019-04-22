using Restaurant_Management.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management.dao
{
    public class FoodDao
    {
        private static FoodDao instance;

        private FoodDao() { }

        public List<Food> GetFood(int categoryID)
        {
            List<Food> foods = new List<Food>();
            foreach (DataRow row in DataProvider.Instance.ExecuteQuery("[procGetFood] @categoryID", new object[] { categoryID }).Rows)
            {
                foods.Add(new Food(row));
            }
            return foods;
        }

        public static FoodDao Instance { get => instance ?? new FoodDao(); private set => instance = value; }
    }
}
