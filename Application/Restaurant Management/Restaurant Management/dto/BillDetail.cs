using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management.dto
{
    public class BillDetail
    {
        private int iD;
        private string foodName;
        private int quantity;
        private int price;
        private int total;

        public BillDetail(int id, string foodName, int quantity, int price, int total)
        {
            ID = id;
            FoodName = foodName;
            Quantity = quantity;
            Price = price;
            Total = total;
        }

        public BillDetail(DataRow row)
        {
            ID = (int)row["ID"];
            FoodName = row["FoodName"].ToString();
            Quantity = (int)row["Quantity"];
            Price = (int)row["Price"];
            Total = (int)row["Total"];
        }

        public int ID { get => iD; set => iD = value; }
        public string FoodName { get => foodName; set => foodName = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int Price { get => price; set => price = value; }
        public int Total { get => total; set => total = value; }
    }
}
