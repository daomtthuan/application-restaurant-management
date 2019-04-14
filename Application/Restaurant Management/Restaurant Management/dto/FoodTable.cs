using System.Data;

namespace Restaurant_Management.dto
{
    public class FoodTable
    {
        private int iD;
        private string name;
        private string status;

        public FoodTable(int id, string name, string status)
        {
            ID = id;
            Name = name;
            Status = status;
        }

        public FoodTable(DataRow row)
        {
            ID = (int)row["ID"];
            Name = row["Name"].ToString();
            Status = row["Status"].ToString();
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
    }
}
