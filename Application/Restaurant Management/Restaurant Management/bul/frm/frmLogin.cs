using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Restaurant_Management.dao;

namespace Restaurant_Management.bul.frm
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private object getAccountID(string username, string password)
        {
            return AccountDao.Instance.getAccountID(username, password);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (tbxUsername.Text == "" || tbxPassword.Text == "")
            {
                XtraMessageBox.Show("Đăng nhập không thành công!\nĐiền tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (tbxUsername.Text == "") tbxUsername.Focus(); else tbxPassword.Focus();
            }
            else
            {
                if (getAccountID(tbxUsername.Text, tbxPassword.Text) != null)
                {
                    Hide();
                    tbxPassword.Text = "";
                    tbxPassword.Focus();
                    using (frmMain frmMain = new frmMain())
                    {
                        frmMain.ShowDialog();
                    }
                    Show();
                }
                else
                {
                    tbxPassword.Text = "";
                    XtraMessageBox.Show("Đăng nhập không thành công!\nTên đăng nhập hoặc mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbxUsername.Focus();
                    tbxUsername.SelectAll();
                }
            }
        }
    }
}