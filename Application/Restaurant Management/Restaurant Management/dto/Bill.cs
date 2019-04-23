using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management.dto
{
    public class Bill
    {
        private int iD;
        private DateTime? checkIn;
        private DateTime? checkOut;
        private int tableID;
        private int statusID;
        private int discount;

        public Bill(int id, DateTime? checkin, DateTime? checkout, int tableID, int statusID, int discount)
        {
            ID = id;
            checkIn = checkin;
            checkOut = checkout;
            TableID = tableID;
            StatusID = statusID;
            Discount = discount;
        }

        public Bill(DataRow row)
        {            
            ID = (int)row["ID"];
            checkIn = (DateTime?)row["CheckIn"];
            checkOut = (row["CheckOut"].ToString() != "") ? (DateTime?)row["CheckOut"] : null;
            TableID = (int)row["TableID"];
            StatusID = (int)row["StatusID"];
            Discount = (int)row["Discount"];
        }

        public int ID { get => iD; set => iD = value; }
        public DateTime? CheckIn { get => checkIn; set => checkIn = value; }
        public DateTime? CheckOut { get => checkOut; set => checkOut = value; }
        public int TableID { get => tableID; set => tableID = value; }
        public int StatusID { get => statusID; set => statusID = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}
