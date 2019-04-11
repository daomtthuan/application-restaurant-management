using DevExpress.XtraEditors;
using Restaurant_Management.dao;
using System;
using System.Windows.Forms;

namespace Restaurant_Management
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private bool Login(string username, string password)
        {
            return AccountDao.Instance.Login(username, password);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text, password = tbxPassword.Text;
            tbxPassword.Text = "";
            tbxPassword.Focus();
            if (Login(username, password))
            {
                Hide();                
                using (frmMain frmMain = new frmMain())
                {
                    frmMain.ShowDialog();
                }
                Show();
            }
            else
            {
                XtraMessageBox.Show("Đăng nhập không thành công!\nTên đăng nhập hoặc mật khẩu không đúng.","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}