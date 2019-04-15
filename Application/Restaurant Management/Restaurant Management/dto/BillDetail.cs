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
        private int billID;
        private int foodID;
        private int quantity;

        public BillDetail(int id, int billID, int foodID, int quantity)
        {
            ID = id;
            BillID = billID;
            FoodID = foodID;
            Quantity = quantity;
        }

        public BillDetail(DataRow row)
        {
            ID = (int)row["ID"];
            BillID = (int)row["BillID"];
            FoodID = (int)row["FoodID"];
            Quantity = (int)row["Quantity"];
        }

        public int ID { get => iD; set => iD = value; }
        public int BillID { get => billID; set => billID = value; }
        public int FoodID { get => foodID; set => foodID = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
