using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Restaurant_Management.bul.usc;

namespace Restaurant_Management.bul.frm
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private List<UserControl> usc;

        public frmMain()
        {
            InitializeComponent();
            usc = new List<UserControl>()
            {
                new uscTableManager() { Dock = DockStyle.Fill }
            };
           
            foreach (UserControl item in usc)
            {
                fluContainer.Controls.Add(item);
                item.Hide();
            }
        }

        private void AccordionControlElement3_Click(object sender, EventArgs e)
        {
            usc[0].Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            AccordionControlElement3_Click(sender, e);
        }
    }
}