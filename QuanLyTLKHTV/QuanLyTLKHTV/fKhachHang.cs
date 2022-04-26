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
    public partial class fKhachHang : Form
    {
        public int chon = 0;
        public string mahd = "";
        QLTLKHDataClassesDataContext db = new QLTLKHDataClassesDataContext();
        public fKhachHang()
        {
            InitializeComponent();
        }

        private void fKhachHang_Load(object sender, EventArgs e)
        {
            KhachHang();
            CheckButtonChon();
        }
        public void CheckButtonChon()
        {
            if (chon == 1)
            {
                btnChon.Visible = true;
            }
        }
        public void KhachHang()
        {
            var data = from q in db.KhachHangs
                       select q;
            dgvKH.DataSource = data;
            if (dgvKH.Rows.Count > 0)
            {
                dgvKH.CurrentRow.Selected = true;
            }
        }
        public bool KiemTra()
        {
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Mã khách hàng không được để trống", "Có lỗi");
                return false;
            }
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Tên khách hàng không được để trống", "Có lỗi");
                return false;
            }
            return true;
        }
        public bool KiemTraKH(string makh)
        {
            var data = from q in db.KhachHangs
                       where q.MaKH == makh
                       select q;
            if (data.Count() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                if (KiemTraKH(txtMaKH.Text.Trim()))
                {
                    KhachHang kh = new KhachHang();
                    kh.MaKH = txtMaKH.Text.Trim();
                    kh.TenKH = txtTenKH.Text.Trim();
                    db.KhachHangs.InsertOnSubmit(kh);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    KhachHang();
                    BoQua();
                }
                else
                {
                    MessageBox.Show("Mã khách hàng này đã tồn tại", "Có lỗi");
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                if (KiemTraKH(txtMaKH.Text.Trim()) == false)
                {
                    var data = from q in db.KhachHangs
                               where q.MaKH == txtMaKH.Text.Trim()
                               select q;
                    KhachHang kh = data.Single();
                    kh.TenKH = txtTenKH.Text.Trim();
                    db.SubmitChanges();
                    MessageBox.Show("Cập nhật thành công", "Thông báo");
                    KhachHang();
                    BoQua();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã khách hàng", "Có lỗi");
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            BoQua();
        }
        public void BoQua()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (KiemTraKH(txtMaKH.Text.Trim()) == false)
            {
                if (MessageBox.Show("Xóa khách hàng sẽ xóa mọi thông tin liên quan đến khách hàng này, bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var data = from q in db.KhachHangs
                               where q.MaKH == txtMaKH.Text.Trim()
                               select q;
                    KhachHang kh = data.Single();
                    db.KhachHangs.DeleteOnSubmit(kh);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    KhachHang();
                    BoQua();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã khách hàng", "Có lỗi");
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            if (tukhoa == "")
            {
                KhachHang();
            }
            else
            {
                var data = from q in db.KhachHangs
                           where q.MaKH.Contains(tukhoa) || q.TenKH.Contains(tukhoa)
                           select q;
                dgvKH.DataSource = data;
                if (dgvKH.Rows.Count > 0)
                {
                    dgvKH.CurrentRow.Selected = true;
                }
            }
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKH.Rows.Count > 0)
            {
                dgvKH.CurrentRow.Selected = true;
                txtMaKH.Text = dgvKH.CurrentRow.Cells["MaKH"].Value.ToString().Trim();
                txtTenKH.Text = dgvKH.CurrentRow.Cells["TenKH"].Value.ToString().Trim();
            }
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "")
            {
                btnThem.Enabled = false;
                btnCapNhat.Enabled = false;
                btnBoQua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                btnThem.Enabled = true;
                btnCapNhat.Enabled = true;
                btnBoQua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (KiemTraKH(txtMaKH.Text.Trim()) == false)
            {
                var data = from q in db.HoaDons
                           where q.MaHD == mahd
                           select q;
                HoaDon hd = data.Single();
                hd.MaKH = txtMaKH.Text.Trim();
                db.SubmitChanges();
                fXuatHoaDon fXHD = new fXuatHoaDon();
                fXHD.mahd = mahd;
                if (fXHD.ShowDialog() == DialogResult.Cancel)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã khách hàng", "Có lỗi");
            }
        }
    }
}
