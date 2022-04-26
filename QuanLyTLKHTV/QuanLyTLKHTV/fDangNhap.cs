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
    public partial class fDangNhap : Form
    {
        QLTLKHDataClassesDataContext db = new QLTLKHDataClassesDataContext();
        public fDangNhap()
        {
            InitializeComponent();
        }
        public bool KiemTra()
        {
            if (txtTDN.Text == "")
            {
                MessageBox.Show("Tên đăng nhập không được để trống", "Có lỗi");
                return false;
            }
            if (txtMK.Text == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Có lỗi");
                return false;
            }
            return true;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                string tdn = txtTDN.Text.Trim();
                string mk = txtMK.Text.Trim();
                var data = from q in db.NhanViens
                           where q.TDN == tdn
                           select q;
                if (data.Count() > 0)
                {
                    var tk = data.Single();
                    if (tk.MK==mk)
                    {
                        fMain fM = new fMain();
                        fM.role = Int32.Parse(tk.Role.ToString());
                        this.Hide();
                        if (fM.ShowDialog() == DialogResult.Cancel)
                        {
                            this.Show();
                            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.NhanViens);
                            txtMK.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Có lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Có lỗi");
                }
            }
        }

      
    }
}
