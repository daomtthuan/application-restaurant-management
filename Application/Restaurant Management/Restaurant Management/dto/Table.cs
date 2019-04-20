using System.Data;

namespace Restaurant_Management.dto
{
    public class Table
    {
        private int iD;
        private string name;
        private int statusID;

        public Table(int id, string name, int statusID)
        {
            ID = id;
            Name = name;
            StatusID = statusID;
        }

        public Table(DataRow row)
        {
            ID = (int)row["ID"];
            Name = row["Name"].ToString();
            StatusID = (int)row["statusID"];
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int StatusID { get => statusID; set => statusID = value; }
    }
}
