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
    public partial class fTacGia : Form
    {
        QLTLKHDataClassesDataContext db = new QLTLKHDataClassesDataContext();
        public fTacGia()
        {
            InitializeComponent();
        }

        private void fTacGia_Load(object sender, EventArgs e)
        {
            TacGia();
        }
        public void TacGia()
        {
            var data = from q in db.TacGias
                       select q;
            dgvTG.DataSource = data;
            if (dgvTG.Rows.Count > 0)
            {
                dgvTG.CurrentRow.Selected = true;
            }
        }
        public bool KiemTra()
        {
            if (txtMaTG.Text == "")
            {
                MessageBox.Show("Mã tác giả không được để trống", "Có lỗi");
                return false;
            }
            if (txtTenTG.Text == "")
            {
                MessageBox.Show("Mã tác giả không được để trống", "Có lỗi");
                return false;
            }
            if (cbNam.Checked == false && cbNu.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Có lỗi");
                return false;
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Số điện thoại không được để trống", "Có lỗi");
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Địa chỉ không được để trống", "Có lỗi");
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Email không được để trống", "Có lỗi");
                return false;
            }
            return true;
        }
        public bool KiemTraTG(string matg)
        {
            var data = from q in db.TacGias
                       where q.MaTG == matg
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
                if (KiemTraTG(txtMaTG.Text.Trim()))
                {
                    TacGia tg = new TacGia();
                    tg.MaTG = txtMaTG.Text.Trim();
                    tg.TenTG = txtTenTG.Text.Trim();
                    if (cbNam.Checked == true)
                    {
                        tg.GioiTinh = 0;
                    }
                    else
                    {
                        tg.GioiTinh = 1;
                    }
                    tg.SDT = txtSDT.Text.Trim();
                    tg.DiaChi = txtDiaChi.Text.Trim();
                    tg.Email = txtEmail.Text.Trim();
                    db.TacGias.InsertOnSubmit(tg);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    TacGia();
                    BoQua();
                }
                else
                {
                    MessageBox.Show("Mã tác giả này đã tồn tại", "Có lỗi");
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                if (KiemTraTG(txtMaTG.Text.Trim()) == false)
                {
                    var data = from q in db.TacGias
                               where q.MaTG == txtMaTG.Text.Trim()
                               select q;
                    TacGia tg = data.Single();
                    tg.TenTG = txtTenTG.Text.Trim();
                    if (cbNam.Checked == true)
                    {
                        tg.GioiTinh = 0;
                    }
                    else
                    {
                        tg.GioiTinh = 1;
                    }
                    tg.SDT = txtSDT.Text.Trim();
                    tg.DiaChi = txtDiaChi.Text.Trim();
                    tg.Email = txtEmail.Text.Trim();
                    db.SubmitChanges();
                    MessageBox.Show("Cập nhật thành công", "Thông báo");
                    TacGia();
                    BoQua();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã tác giả", "Có lỗi");
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            BoQua();
        }
        public void BoQua()
        {
            txtMaTG.Text = "";
            txtTenTG.Text = "";
            txtSDT.Text = "";
            cbNam.Checked = false;
            cbNu.Checked = false;
            txtDiaChi.Text = "";
            txtEmail.Text = "";
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (KiemTraTG(txtMaTG.Text.Trim()) == false)
            {
                if (MessageBox.Show("Xóa tác giả sẽ xóa các tài liệu liên quan đến tác giả này, bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var data = from q in db.TacGias
                               where q.MaTG == txtMaTG.Text.Trim()
                               select q;
                    TacGia tg = data.Single();
                    db.TacGias.DeleteOnSubmit(tg);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    TacGia();
                    BoQua();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã tác giả", "Có lỗi");
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            if (tukhoa == "")
            {
                TacGia();
            }
            else
            {
                var data = from q in db.TacGias
                           where q.MaTG.Contains(tukhoa) || q.TenTG.Contains(tukhoa) || q.SDT.Contains(tukhoa) || q.GioiTinh.ToString().Contains(tukhoa) || q.DiaChi.Contains(tukhoa) || q.Email.Contains(tukhoa)
                           select q;
                dgvTG.DataSource = data;
                if (dgvTG.Rows.Count > 0)
                {
                    dgvTG.CurrentRow.Selected = true;
                }
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtMaTG_TextChanged(object sender, EventArgs e)
        {
            if (txtMaTG.Text == "")
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

        private void dgvTG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTG.Rows.Count > 0)
            {
                dgvTG.CurrentRow.Selected = true;
                txtMaTG.Text = dgvTG.CurrentRow.Cells["MaTG"].Value.ToString().Trim();
                txtTenTG.Text = dgvTG.CurrentRow.Cells["TenTG"].Value.ToString().Trim();
                if (dgvTG.CurrentRow.Cells["GioiTinh"].Value.ToString() == "0")
                {
                    cbNam.Checked = true;
                }
                else
                {
                    cbNu.Checked = true;
                }
                txtSDT.Text = dgvTG.CurrentRow.Cells["SDT"].Value.ToString().Trim();
                txtDiaChi.Text = dgvTG.CurrentRow.Cells["DiaChi"].Value.ToString().Trim();
                txtEmail.Text = dgvTG.CurrentRow.Cells["Email"].Value.ToString().Trim();
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

        private void dgvTG_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTG.Columns[e.ColumnIndex].Name.Equals("GioiTinh"))
            {
                string vl = e.Value.ToString();
                if (vl == null)
                {
                    return;
                }
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
    }
}
