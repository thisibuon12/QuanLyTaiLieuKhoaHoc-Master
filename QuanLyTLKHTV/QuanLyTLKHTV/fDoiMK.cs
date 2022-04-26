using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTLKHTV
{
    public partial class fDoiMK : Form
    {
        public string tdn;
        QLTLKHDataClassesDataContext db = new QLTLKHDataClassesDataContext();
        public fDoiMK()
        {
            InitializeComponent();
        }

        private void fDoiMK_Load(object sender, EventArgs e)
        {
            txtTDN.Text = tdn;
            this.ActiveControl = txtMKM;
        }

        private void btnDMK_Click(object sender, EventArgs e)
        {
            if (txtMKM.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới");
            }
            else
            {
                var data = from q in db.NhanViens
                           where q.TDN == tdn
                           select q;
                NhanVien nv = data.Single();
                nv.MK = txtMKM.Text.Trim();
                db.SubmitChanges();
                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                this.Close();
            }
        }
    }
}
