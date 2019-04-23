using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
                new uscTableManager() { Dock = DockStyle.Fill },
                new uscRevenueManager() { Dock = DockStyle.Fill }
            };

            foreach (UserControl item in usc)
            {
                fluContainer.Controls.Add(item);
                item.Hide();
            }

            fluContainer.Tag = usc[0];
            usc[0].Show();
        }

        private void ShowUsercontrol(UserControl usc)
        {
            Cursor = Cursors.WaitCursor;
            (fluContainer.Tag as UserControl).Hide();
            fluContainer.Tag = usc;
            usc.Show();
            Cursor = Cursors.Default;
        }


        private void AceExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void AceLogout_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void AceTableManager_Click(object sender, EventArgs e)
        {
            ShowUsercontrol(usc[0]);
        }

        private void AceRevenueManager_Click(object sender, EventArgs e)
        {
            ShowUsercontrol(usc[1]);
        }
    }
}