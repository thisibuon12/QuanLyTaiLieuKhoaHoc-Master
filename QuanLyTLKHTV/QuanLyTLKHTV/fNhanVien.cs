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
    public partial class fNhanVien : Form
    {
        QLTLKHDataClassesDataContext db = new QLTLKHDataClassesDataContext();
        public fNhanVien()
        {
            InitializeComponent();
        }

        private void fNhanVien_Load(object sender, EventArgs e)
        {
            NhanVien();
        }
        public void NhanVien()
        {
            var data = from q in db.NhanViens
                       select new { q.MaNV, q.TenNV, q.TDN, q.GioiTinh, q.NgaySinh, q.SDT, q.DiaChi };
            dgvNhanVien.DataSource = data;
            if (dgvNhanVien.Rows.Count > 0)
            {
                dgvNhanVien.CurrentRow.Selected = true;
            }
        }
        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                btnThem.Enabled = false;
                btnCapNhat.Enabled = false;
                btnBoQua.Enabled = false;
                btnXoa.Enabled = false;
                btnDMK.Enabled = false;
            }
            else
            {
                btnThem.Enabled = true;
                btnCapNhat.Enabled = true;
                btnBoQua.Enabled = true;
                btnXoa.Enabled = true;
                btnDMK.Enabled = true;
            }
        }
        public bool KiemTra()
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống", "Có lỗi");
                return false;
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Tên nhân viên không được để trống", "Có lỗi");
                return false;
            }
            if (txtTDN.Text == "")
            {
                MessageBox.Show("Tên đăng nhập không được để trống", "Có lỗi");
                return false;
            }
            if (cbNam.Checked == false && cbNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Có lỗi");
                return false;
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Số điện thoại nhân viên không được để trống", "Có lỗi");
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Địa chỉ nhân viên không được để trống", "Có lỗi");
                return false;
            }
            return true;
        }
        public bool KiemTraNV(string manv)
        {
            var data = from q in db.NhanViens
                       where q.MaNV == manv
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
                if(KiemTraNV(txtMaNV.Text.Trim()))
                {
                    NhanVien nv = new NhanVien();
                    nv.MaNV = txtMaNV.Text.Trim();
                    nv.TenNV = txtTenNV.Text.Trim();
                    nv.TDN = txtTDN.Text.Trim();
                    nv.MK = "1";
                    if (cbNam.Checked == true)
                    {
                        nv.GioiTinh = 0;
                    }
                    else
                    {
                        nv.GioiTinh = 1;
                    }
                    nv.NgaySinh = DateTime.Parse(dateNgaySinh.Value.ToShortDateString());
                    nv.SDT = txtSDT.Text.Trim();
                    nv.DiaChi = txtDiaChi.Text.Trim();
                    nv.Role = 0;
                    db.NhanViens.InsertOnSubmit(nv);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    NhanVien();
                    BoQua();
                }
                else
                {
                    MessageBox.Show("Mã nhân viên này đã tồn tại", "Có lỗi");
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                if (KiemTraNV(txtMaNV.Text.Trim()) == false)
                {
                    if (txtMaNV.Text.Trim() == "ADMIN")
                    {
                        if (txtTDN.Text.Trim() == "admin")
                        {
                            var data = from q in db.NhanViens
                                       where q.MaNV == "ADMIN"
                                       select q;
                            NhanVien nv = data.Single();
                            nv.TenNV = txtTenNV.Text.Trim();
                            if (cbNam.Checked == true)
                            {
                                nv.GioiTinh = 0;
                            }
                            else
                            {
                                nv.GioiTinh = 1;
                            }
                            nv.NgaySinh = DateTime.Parse(dateNgaySinh.Value.ToShortDateString());
                            nv.SDT = txtSDT.Text.Trim();
                            nv.DiaChi = txtDiaChi.Text.Trim();
                            db.SubmitChanges();
                            MessageBox.Show("Cập nhật thành công", "Thông báo");
                            NhanVien();
                            BoQua();
                        }
                        else
                        {
                            MessageBox.Show("Không thể đổi tên đăng nhập của tài khoản admin", "Có lỗi");
                        }
                    }
                    else
                    {
                        var data = from q in db.NhanViens
                                   where q.MaNV == txtMaNV.Text.Trim()
                                   select q;
                        NhanVien nv = data.Single();
                        nv.TenNV = txtTenNV.Text.Trim();
                        nv.TDN = txtTDN.Text.Trim();
                        if (cbNam.Checked == true)
                        {
                            nv.GioiTinh = 0;
                        }
                        else
                        {
                            nv.GioiTinh = 1;
                        }
                        nv.NgaySinh = DateTime.Parse(dateNgaySinh.Value.ToShortDateString());
                        nv.SDT = txtSDT.Text.Trim();
                        nv.DiaChi = txtDiaChi.Text.Trim();
                        db.SubmitChanges();
                        MessageBox.Show("Cập nhật thành công", "Thông báo");
                        NhanVien();
                        BoQua();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên", "Có lỗi");
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            BoQua();
        }
        public void BoQua()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtTDN.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (KiemTraNV(txtMaNV.Text.Trim()) == false)
            {
                if (txtMaNV.Text.Trim() == "ADMIN")
                {
                    MessageBox.Show("Không thể xóa thông tin admin", "Có lỗi");
                }
                else
                {
                    if (MessageBox.Show("Xóa thông tin nhân viên sẽ xóa mọi thông tin liên quan đến nhân viên này, bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var data = from q in db.NhanViens
                                   where q.MaNV == txtMaNV.Text.Trim()
                                   select q;
                        NhanVien nv = data.Single();
                        db.NhanViens.DeleteOnSubmit(nv);
                        db.SubmitChanges();
                        MessageBox.Show("Xóa thành công", "Thông báo");
                        NhanVien();
                        BoQua();
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã nhân viên", "Có lỗi");
            }
        }

        private void btnDMK_Click(object sender, EventArgs e)
        {
            if (KiemTraNV(txtMaNV.Text.Trim()) == false)
            {
                fDoiMK fDMK = new fDoiMK();
                fDMK.tdn = txtTDN.Text.Trim();
                fDMK.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã nhân viên", "Có lỗi");
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhanVien.Rows.Count > 0)
            {
                dgvNhanVien.CurrentRow.Selected = true;
                txtMaNV.Text = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString().Trim();
                txtTenNV.Text = dgvNhanVien.CurrentRow.Cells["TenNV"].Value.ToString().Trim();
                txtTDN.Text = dgvNhanVien.CurrentRow.Cells["TDN"].Value.ToString().Trim();
                if (dgvNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString() == "0")
                {
                    cbNam.Checked = true;
                }
                else
                {
                    cbNu.Checked = true;
                }
                dateNgaySinh.Value = DateTime.Parse(dgvNhanVien.CurrentRow.Cells["NgaySinh"].Value.ToString());
                txtSDT.Text = dgvNhanVien.CurrentRow.Cells["SDT"].Value.ToString().Trim();
                txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells["DiaChi"].Value.ToString().Trim();
            }
        }

        private void cbNam_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNam.Checked == true)
            {
                cbNu.Checked = false;
            }
        }

        private void cbNu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNu.Checked == true)
            {
                cbNam.Checked = false;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            if (tukhoa == "")
            {
                NhanVien();
            }
            else
            {
                var data=from q in db.NhanViens
                         where q.MaNV.Contains(tukhoa) || q.TenNV.Contains(tukhoa) || q.SDT.Contains(tukhoa) || q.DiaChi.Contains(tukhoa) || q.NgaySinh.ToString().Contains(tukhoa)
                         select new { q.MaNV, q.TenNV, q.TDN, q.GioiTinh, q.NgaySinh, q.SDT, q.DiaChi };
                dgvNhanVien.DataSource = data;
                if (dgvNhanVien.Rows.Count > 0)
                {
                    dgvNhanVien.CurrentRow.Selected = true;
                }
            }
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien.Columns[e.ColumnIndex].Name.Equals("GioiTinh"))
            {
                string vl = e.Value.ToString();
                if (vl == null)
                    return;
                switch (vl)
                {
                    case "0":
                        e.Value = "Nam";
                        break;
                    case "1":
                        e.Value = "Nữ";
                        break;
                }
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
