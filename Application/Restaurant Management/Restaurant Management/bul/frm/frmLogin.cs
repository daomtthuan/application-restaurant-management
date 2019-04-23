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

        private int getAccountID(string username, string password)
        {
            return dao_Account.Instance.GetAccountID(username, password);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (tbxUsername.Text == "" || tbxPassword.Text == "")
            {
                XtraMessageBox.Show("Đăng nhập không thành công!\nĐiền tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (tbxUsername.Text == "") tbxUsername.Focus(); else tbxPassword.Focus();
            }
            else
            {           
                if (getAccountID(tbxUsername.Text, tbxPassword.Text) != -1)
                {
                    Hide();
                    tbxPassword.Text = "";
                    tbxPassword.Focus();
                    
                    new frmMain().ShowDialog();
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
            Cursor = Cursors.Default;
        }
    }
}