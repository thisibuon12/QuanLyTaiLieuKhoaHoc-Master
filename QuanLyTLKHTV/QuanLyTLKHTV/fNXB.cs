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
    public partial class fNXB : Form
    {
        QLTLKHDataClassesDataContext db = new QLTLKHDataClassesDataContext();
        public fNXB()
        {
            InitializeComponent();
        }

        private void fNXB_Load(object sender, EventArgs e)
        {
            NXB();
        }
        public void NXB()
        {
            var data = from q in db.NXBs
                       select q;
            dgvNXB.DataSource = data;
            if (dgvNXB.Rows.Count > 0)
            {
                dgvNXB.CurrentRow.Selected = true;
            }
        }
        public bool KiemTra()
        {
            if (txtMaNXB.Text == "")
            {
                MessageBox.Show("Mã nhà xuất bản không được để trống", "Có lỗi");
                return false;
            }
            if (txtTenNXB.Text == "")
            {
                MessageBox.Show("Tên nhà xuất bản không được để trống", "Có lỗi");
                return false;
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Số điện thoại nhà xuất bản không được để trống", "Có lỗi");
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Địa chỉ nhà xuất bản không được để trống", "Có lỗi");
                return false;
            }
            return true;
        }
        public bool KiemTraNXB(string manxb)
        {
            var data = from q in db.NXBs
                       where q.MaNXB == manxb
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
                if (KiemTraNXB(txtMaNXB.Text.Trim()))
                {
                    NXB nxb = new NXB();
                    nxb.MaNXB = txtMaNXB.Text.Trim();
                    nxb.TenNXB = txtTenNXB.Text.Trim();
                    nxb.SDT = txtSDT.Text.Trim();
                    nxb.DiaChi = txtDiaChi.Text.Trim();
                    db.NXBs.InsertOnSubmit(nxb);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    NXB();
                    BoQua();
                }
                else
                {
                    MessageBox.Show("Mã nhà xuất bản này đã tồn tại", "Có lỗi");
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                if (KiemTraNXB(txtMaNXB.Text.Trim()) == false)
                {
                    var data = from q in db.NXBs
                               where q.MaNXB == txtMaNXB.Text.Trim()
                               select q;
                    NXB nxb = data.Single();
                    nxb.TenNXB = txtTenNXB.Text.Trim();
                    nxb.SDT = txtSDT.Text.Trim();
                    nxb.DiaChi = txtDiaChi.Text.Trim();
                    db.SubmitChanges();
                    MessageBox.Show("Cập nhật thành công", "Thông báo");
                    NXB();
                    BoQua();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã nhà xuất bản", "Có lỗi");
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            BoQua();
        }
        public void BoQua()
        {
            txtMaNXB.Text = "";
            txtTenNXB.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (KiemTraNXB(txtMaNXB.Text.Trim()) == false)
            {
                if (MessageBox.Show("Xóa nhà xuất bản sẽ xóa tài liệu liên quan đến nhà xuất bản này, bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var data = from q in db.NXBs
                               where q.MaNXB == txtMaNXB.Text.Trim()
                               select q;
                    NXB nxb = data.Single();
                    db.NXBs.DeleteOnSubmit(nxb);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    NXB();
                    BoQua();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã nhà xuất bản", "Có lỗi");
            }
        }

        private void dgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNXB.Rows.Count > 0)
            {
                dgvNXB.CurrentRow.Selected = true;
                txtMaNXB.Text = dgvNXB.CurrentRow.Cells["MaNXB"].Value.ToString().Trim();
                txtTenNXB.Text = dgvNXB.CurrentRow.Cells["TenNXB"].Value.ToString().Trim();
                txtSDT.Text = dgvNXB.CurrentRow.Cells["SDT"].Value.ToString().Trim();
                txtDiaChi.Text = dgvNXB.CurrentRow.Cells["DiaChi"].Value.ToString().Trim();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            if (tukhoa == "")
            {
                NXB();
            }
            else
            {
                var data = from q in db.NXBs
                           where q.MaNXB.Contains(tukhoa) || q.TenNXB.Contains(tukhoa) || q.SDT.Contains(tukhoa) || q.DiaChi.Contains(tukhoa)
                           select q;
                dgvNXB.DataSource = data;
                if (dgvNXB.Rows.Count > 0)
                {
                    dgvNXB.CurrentRow.Selected = true;
                }
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtMaNXB_TextChanged(object sender, EventArgs e)
        {
            if (txtMaNXB.Text == "")
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
    }
}
