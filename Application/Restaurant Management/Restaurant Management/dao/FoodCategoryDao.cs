using DevExpress.XtraLayout.Customization;
using Restaurant_Management.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management.dao
{
    public class FoodCategoryDao
    {
        private static FoodCategoryDao instance;

        private FoodCategoryDao() { }

        public List<FoodCategory> GetFoodCategory()
        {
            List<FoodCategory> categories = new List<FoodCategory>();
            foreach (DataRow row in DataProvider.Instance.ExecuteQuery("[procGetFoodCategory]").Rows)
            {   
                categories.Add(new FoodCategory(row));
            }
            return categories;
        }

        public static FoodCategoryDao Instance { get => instance ?? new FoodCategoryDao(); private set => instance = value; }
    }
}
