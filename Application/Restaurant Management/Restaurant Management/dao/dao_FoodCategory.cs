using Restaurant_Management.dto;
using System.Collections.Generic;
using System.Data;

namespace Restaurant_Management.dao
{
    public class dao_FoodCategory
    {
        private static dao_FoodCategory instance;

        private dao_FoodCategory() { }

        public List<FoodCategory> GetFoodCategory()
        {
            List<FoodCategory> categories = new List<FoodCategory>();
            foreach (DataRow row in DataProvider.Instance.ExecuteQuery("[proc_GetFoodCategory]").Rows)
            {   
                categories.Add(new FoodCategory(row));
            }
            return categories;
        }

        public static dao_FoodCategory Instance { get => instance ?? new dao_FoodCategory(); private set => instance = value; }
    }
}
