using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Restaurant_Management.dao;
using Restaurant_Management.dto;

namespace Restaurant_Management.bul.usc
{
    public partial class uscTableManager : DevExpress.XtraEditors.XtraUserControl
    {
        public uscTableManager()
        {
            InitializeComponent();

            loadFoodTables();
        }

        #region Method
        private void loadFoodTables()
        {
            List<FoodTable> foodTablesList = FoodTableDao.Instance.loadFoodTables();
            foreach (FoodTable item in foodTablesList)
            {
                SimpleButton btn = new SimpleButton()
                {
                    Name = "btnFoodTable" + item.ID,
                    Text = item.Name + Environment.NewLine + item.Status,
                    Width = 100,
                    Height = 100
                };

                if (item.Status == "Có người")
                    btn.Appearance.BackColor = Color.FromArgb(16, 110, 190);

                flpFoodTable.Controls.Add(btn);
            }
        }
        #endregion

        #region Events
        #endregion
    }
}
