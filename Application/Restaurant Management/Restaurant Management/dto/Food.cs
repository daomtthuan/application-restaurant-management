using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management.dto
{
    public class Food
    {
        private int iD;
        private string name;
        private int categoryID;
        private int price;

        public Food(int id, string name, int categoryID, int price)
        {
            ID = id;
            Name = name;
            CategoryID = categoryID;
            Price = price;
        }

        public Food(DataRow row)
        {
            ID = (int)row["ID"];
            Name = row["Name"].ToString();
            CategoryID = (int)row["CategoryID"];
            Price = (int)row["Price"];
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public int Price { get => price; set => price = value; }
    }
}
