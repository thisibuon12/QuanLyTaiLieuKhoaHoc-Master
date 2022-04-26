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
    public partial class fTLKH : Form
    {
        QLTLKHDataClassesDataContext db = new QLTLKHDataClassesDataContext();
        public fTLKH()
        {
            InitializeComponent();
        }

        private void fTLKH_Load(object sender, EventArgs e)
        {
            TacGia();
            ChuyenNganh();
            NXB();
            TLKH();
        }
        public void TacGia()
        {
            var data = from q in db.TacGias
                       select q;
            listTG.DataSource = data;
            listTG.DisplayMember = "TenTG";
            listTG.ValueMember = "MaTG";
            listTG.SelectedItem = null;
        }
        public void ChuyenNganh()
        {
            var data = from q in db.ChuyenNganhs
                       select q;
            listCN.DataSource = data;
            listCN.DisplayMember = "TenCN";
            listCN.ValueMember = "MaCN";
            listCN.SelectedItem = null;
        }
        public void NXB()
        {
            var data = from q in db.NXBs
                       select q;
            listNXB.DataSource = data;
            listNXB.DisplayMember = "TenNXB";
            listNXB.ValueMember = "MaNXB";
            listNXB.SelectedItem = null;
        }
        public void TLKH()
        {
            var data = from q in db.TLKHs
                       select new { q.MaTL, q.TenTL, q.MoTa, q.MaTG, q.MaCN, q.MaNXB, q.SoTrang, q.ThoiGianNhap, q.GiaBan, q.GiaThue, q.MaVach };
            dgvTLKH.DataSource = data;
            if (dgvTLKH.Rows.Count > 0)
            {
                dgvTLKH.CurrentRow.Selected = true;
            }
        }
        public bool KiemTra()
        {
            if (txtMaTL.Text == "")
            {
                MessageBox.Show("Mã tài liệu không được để trống", "Có lỗi");
                return false;
            }
            if (txtTenTL.Text == "")
            {
                MessageBox.Show("Tên tài liệu không được để trống", "Có lỗi");
                return false;
            }
            if (txtMoTa.Text == "")
            {
                MessageBox.Show("Mô tả tài liệu không được để trống", "Có lỗi");
                return false;
            }
            if (listTG.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn tác giả", "Có lỗi");
                return false;
            }
            if (listCN.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn chuyên ngành", "Có lỗi");
                return false;
            }
            if (listNXB.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn nhà xuất bản", "Có lỗi");
                return false;
            }
            if (txtSoTrang.Text == "")
            {
                MessageBox.Show("Số trang tài liệu không được để trống", "Có lỗi");
                return false;
            }
            if (txtGiaBan.Text == "")
            {
                MessageBox.Show("Giá bán tài liệu không được để trống", "Có lỗi");
                return false;
            }
            if (txtGiaThue.Text == "")
            {
                MessageBox.Show("Giá thuê tài liệu không được để trống", "Có lỗi");
                return false;
            }
            if (txtMaVach.Text == "")
            {
                MessageBox.Show("Mã vạch tài liệu không được để trống", "Có lỗi");
                return false;
            }
            return true;
        }
        public bool KiemTraTL(string matl)
        {
            var data = from q in db.TLKHs
                       where q.MaTL == matl
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
                if (KiemTraTL(txtMaTL.Text.Trim()))
                {
                    TLKH tl = new TLKH();
                    tl.MaTL = txtMaTL.Text.Trim();
                    tl.TenTL = txtTenTL.Text.Trim();
                    tl.MoTa = txtMoTa.Text.Trim();
                    tl.MaTG = listTG.SelectedValue.ToString();
                    tl.MaCN = listCN.SelectedValue.ToString();
                    tl.MaNXB = listNXB.SelectedValue.ToString();
                    tl.SoTrang = Int32.Parse(txtSoTrang.Text.Trim());
                    tl.ThoiGianNhap = dateThoiGianNhap.Value;
                    tl.GiaBan = Int64.Parse(txtGiaBan.Text.Trim());
                    tl.GiaThue = Int64.Parse(txtGiaThue.Text.Trim());
                    tl.MaVach = txtMaVach.Text.Trim();
                    db.TLKHs.InsertOnSubmit(tl);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    TLKH();
                    BoQua();
                }
                else
                {
                    MessageBox.Show("Mã tài liệu này đã tồn tại", "Có lỗi");
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                if (KiemTraTL(txtMaTL.Text.Trim()) == false)
                {
                    var data = from q in db.TLKHs
                               where q.MaTL == txtMaTL.Text.Trim()
                               select q;
                    TLKH tl = data.Single();
                    tl.TenTL = txtTenTL.Text.Trim();
                    tl.MoTa = txtMoTa.Text.Trim();
                    tl.MaTG = listTG.SelectedValue.ToString();
                    tl.MaCN = listCN.SelectedValue.ToString();
                    tl.MaNXB = listNXB.SelectedValue.ToString();
                    tl.SoTrang = Int32.Parse(txtSoTrang.Text.Trim());
                    tl.ThoiGianNhap = dateThoiGianNhap.Value;
                    tl.GiaBan = Int64.Parse(txtGiaBan.Text.Trim());
                    tl.GiaThue = Int64.Parse(txtGiaThue.Text.Trim());
                    tl.MaVach = txtMaVach.Text.Trim();
                    db.SubmitChanges();
                    MessageBox.Show("Cập nhật thành công", "Thông báo");
                    TLKH();
                    BoQua();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã tài liệu", "Có lỗi");
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            BoQua();
        }
        public void BoQua()
        {
            txtMaTL.Text = "";
            txtTenTL.Text = "";
            txtMoTa.Text = "";
            listTG.SelectedItem = null;
            listNXB.SelectedItem = null;
            listCN.SelectedItem = null;
            txtSoTrang.Text = "";
            dateThoiGianNhap.Text = "";
            txtGiaBan.Text = "";
            txtGiaThue.Text = "";
            txtMaVach.Text = "";
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (KiemTraTL(txtMaTL.Text.Trim()) == false)
            {
                if (MessageBox.Show("Xóa tài liệu khoa học sẽ xóa mọi dữ liệu liên quan đến tài liệu này, bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var data = from q in db.TLKHs
                               where q.MaTL == txtMaTL.Text.Trim()
                               select q;
                    TLKH tl = data.Single();
                    db.TLKHs.DeleteOnSubmit(tl);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    TLKH();
                    BoQua();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã tài liệu", "Có lỗi");
            }
        }

        private void dgvTLKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTLKH.Rows.Count > 0)
            {
                dgvTLKH.CurrentRow.Selected = true;
                txtMaTL.Text = dgvTLKH.CurrentRow.Cells["MaTL"].Value.ToString().Trim();
                txtTenTL.Text = dgvTLKH.CurrentRow.Cells["TenTL"].Value.ToString().Trim();
                txtMoTa.Text = dgvTLKH.CurrentRow.Cells["MoTa"].Value.ToString().Trim();
                listTG.SelectedValue = dgvTLKH.CurrentRow.Cells["MaTG"].Value.ToString();
                listCN.SelectedValue = dgvTLKH.CurrentRow.Cells["MaCN"].Value.ToString();
                listNXB.SelectedValue = dgvTLKH.CurrentRow.Cells["MaNXB"].Value.ToString();
                txtSoTrang.Text = dgvTLKH.CurrentRow.Cells["SoTrang"].Value.ToString().Trim();
                dateThoiGianNhap.Value = DateTime.Parse(dgvTLKH.CurrentRow.Cells["ThoiGianNhap"].Value.ToString().Trim());
                txtGiaBan.Text = dgvTLKH.CurrentRow.Cells["GiaBan"].Value.ToString().Trim();
                txtGiaThue.Text = dgvTLKH.CurrentRow.Cells["GiaThue"].Value.ToString().Trim();
                txtMaVach.Text = dgvTLKH.CurrentRow.Cells["MaVach"].Value.ToString().Trim();
            }
        }

        private void txtMaTL_TextChanged(object sender, EventArgs e)
        {
            if (txtMaTL.Text == "")
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            if (tukhoa == "")
            {
                TLKH();
            }
            else
            {
                var data = from q in db.TLKHs
                           where q.MaTL.Contains(tukhoa) || q.TenTL.Contains(tukhoa) || q.MoTa.Contains(tukhoa) || q.MaTG.Contains(tukhoa) || q.MaCN.Contains(tukhoa) || q.MaNXB.Contains(tukhoa) || q.SoTrang.ToString().Contains(tukhoa) || q.GiaBan.ToString().Contains(tukhoa) || q.GiaThue.ToString().Contains(tukhoa) || q.MaVach.Contains(tukhoa)
                           select new { q.MaTL, q.TenTL, q.MoTa, q.MaTG, q.MaCN, q.MaNXB, q.SoTrang, q.ThoiGianNhap, q.GiaBan, q.GiaThue, q.MaVach };
                dgvTLKH.DataSource = data;
                if (dgvTLKH.Rows.Count > 0)
                {
                    dgvTLKH.CurrentRow.Selected = true;
                }
            }
        }
    }
}
