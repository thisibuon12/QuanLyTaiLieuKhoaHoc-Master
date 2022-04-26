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
    public partial class fChuyenNganh : Form
    {
        QLTLKHDataClassesDataContext db = new QLTLKHDataClassesDataContext();
        public fChuyenNganh()
        {
            InitializeComponent();
        }

        private void fChuyenNganh_Load(object sender, EventArgs e)
        {
            ChuyenNganh();
        }
        public void ChuyenNganh()
        {
            var data = from q in db.ChuyenNganhs
                       select q;
            dgvCN.DataSource = data;
            if (dgvCN.Rows.Count > 0)
            {
                dgvCN.CurrentRow.Selected = true;
            }
        }
        public bool KiemTra()
        {
            if (txtMaCN.Text == "")
            {
                MessageBox.Show("Mã chuyên ngành không được để trống", "Có lỗi");
                return false;
            }
            if (txtTenCN.Text == "")
            {
                MessageBox.Show("Tên chuyên ngành không được để trống", "Có lỗi");
                return false;
            }
            if (txtMoTa.Text == "")
            {
                MessageBox.Show("Mô tả không được để trống", "Có lỗi");
                return false;
            }
            return true;
        }
        public bool KiemTraCN(string macn)
        {
            var data = from q in db.ChuyenNganhs
                       where q.MaCN == macn
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
                if (KiemTraCN(txtMaCN.Text.Trim()))
                {
                    ChuyenNganh cn = new ChuyenNganh();
                    cn.MaCN = txtMaCN.Text.Trim();
                    cn.TenCN = txtTenCN.Text.Trim();
                    cn.MoTa = txtMoTa.Text.Trim();
                    db.ChuyenNganhs.InsertOnSubmit(cn);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    ChuyenNganh();
                    BoQua();
                }
                else
                {
                    MessageBox.Show("Mã chuyên ngành đã tồn tại", "Có lỗi");
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                if (KiemTraCN(txtMaCN.Text.Trim()) == false)
                {
                    var data = from q in db.ChuyenNganhs
                               where q.MaCN == txtMaCN.Text.Trim()
                               select q;
                    ChuyenNganh cn = data.Single();
                    cn.TenCN = txtTenCN.Text.Trim();
                    cn.MoTa = txtMoTa.Text.Trim();
                    db.SubmitChanges();
                    MessageBox.Show("Cập nhật thành công", "Thông báo");
                    ChuyenNganh();
                    BoQua();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã chuyên ngành", "Có lỗi");
                }
            }
        }
        public void BoQua()
        {
            txtMaCN.Text = "";
            txtTenCN.Text = "";
            txtMoTa.Text = "";
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            BoQua();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (KiemTraCN(txtMaCN.Text.Trim()) == false)
            {
                if (MessageBox.Show("Xóa chuyên ngành sẽ tài liệu khoa học liên quan, bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var data = from q in db.ChuyenNganhs
                               where q.MaCN == txtMaCN.Text.Trim()
                               select q;
                    ChuyenNganh cn = data.Single();
                    db.ChuyenNganhs.DeleteOnSubmit(cn);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    ChuyenNganh();
                    BoQua();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã chuyên ngành", "Có lỗi");
            }
        }

        private void dgvCN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCN.Rows.Count > 0)
            {
                dgvCN.CurrentRow.Selected = true;
                txtMaCN.Text = dgvCN.CurrentRow.Cells["MaCN"].Value.ToString().Trim();
                txtTenCN.Text = dgvCN.CurrentRow.Cells["TenCN"].Value.ToString().Trim();
                txtMoTa.Text = dgvCN.CurrentRow.Cells["MoTa"].Value.ToString().Trim();
            }
        }

        private void txtMaCN_TextChanged(object sender, EventArgs e)
        {
            if (txtMaCN.Text == "")
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
                ChuyenNganh();
            }
            else
            {
                var data = from q in db.ChuyenNganhs
                           where q.MaCN.Contains(tukhoa) || q.TenCN.Contains(tukhoa) || q.MoTa.Contains(tukhoa)
                           select q;
                dgvCN.DataSource = data;
                if (dgvCN.Rows.Count > 0)
                {
                    dgvCN.CurrentRow.Selected = true;
                }
            }
        }
    }
}
