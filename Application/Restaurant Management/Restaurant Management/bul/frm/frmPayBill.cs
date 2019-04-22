using DevExpress.XtraEditors;
using System.Data;
using Restaurant_Management.dao;
using System.Windows.Forms;

namespace Restaurant_Management.bul.frm
{
    public partial class frmPayBill : XtraForm
    {
        public static bool isPay;

        public frmPayBill(int id, string name, string checkin, DataTable bill, int sumprice, int saleprice, int totalprice)
        {
            InitializeComponent();
            lblTableName.Text = name;
            lblCheckIn.Text = checkin;
            ctrlBillDetail.DataSource = bill;
            tbxSumPrice.Text = sumprice.ToString("0,0 VNĐ");
            tbxSalePrice.Text = saleprice.ToString("0,0 VNĐ");
            tbxTotalPrice.Text = totalprice.ToString("0,0 VNĐ");
            viewBillDetail.Columns[0].Width = 300;
            Tag = id;
            tbxSalePrice.Tag = (100 * saleprice) / sumprice;
            isPay = false;
        }

        private void BtnPay_Click(object sender, System.EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            BillDao.Instance.PayBill((int)Tag, (int)tbxSalePrice.Tag);
            isPay = true;
            Cursor = Cursors.Default;
            Close();
        }
    }
}