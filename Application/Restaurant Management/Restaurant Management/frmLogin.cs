using System;

namespace Restaurant_Management
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Hide();
            frmMain frmMain = new frmMain();
            frmMain.ShowDialog();
            Show();
        }
    }
}