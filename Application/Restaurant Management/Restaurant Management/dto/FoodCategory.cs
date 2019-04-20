using System.Data;

namespace Restaurant_Management.dto
{
    public class FoodCategory
    {
        private int iD;
        private string name;

        public FoodCategory(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public FoodCategory(DataRow row)
        {
            ID = (int)row["ID"];
            Name = row["Name"].ToString();
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
    }
}
