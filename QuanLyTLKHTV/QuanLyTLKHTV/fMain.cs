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
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fTacGia fTG = new fTacGia();
            fTG.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhachHang fKH = new fKhachHang();
            fKH.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhanVien fNV = new fNhanVien();
            fNV.ShowDialog();
        }

        private void tạoHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fTaoHoaDon fTHD = new fTaoHoaDon();
            fTHD.ShowDialog();
        }

        private void danhSáchHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDanhSachHoaDon fDSHD = new fDanhSachHoaDon();
            fDSHD.ShowDialog();
        }

        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNXB fNXB = new fNXB();
            fNXB.ShowDialog();
        }

        private void chuyênNgànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fChuyenNganh fCN = new fChuyenNganh();
            fCN.ShowDialog();
        }

        private void tàiLiệuKhoaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fTLKH fTL = new fTLKH();
            fTL.ShowDialog();
        }
        public int role;
        private void fMain_Load(object sender, EventArgs e)
        {
            if (role == 0)
            {
                nhânViênToolStripMenuItem.Enabled = false;
                tàiLiệuKhoaHọcToolStripMenuItem.Enabled = false;
                tácGiảToolStripMenuItem.Enabled = false;
                chuyênNgànhToolStripMenuItem.Enabled = false;
                nhàXuấtBảnToolStripMenuItem.Enabled = false;
            }
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongKe fTK = new fThongKe();
            fTK.ShowDialog();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PHẦN MỀM QUẢN LÝ TÀI LIỆU KHOA HỌC - ĐỒ ÁN THỰC TẬP" + Environment.NewLine + "NGƯỜI THỰC HIỆN" + Environment.NewLine + " TẠ ĐẶNG NIÊN KỸ" + Environment.NewLine + "PHẦN MỀM ĐƯỢC CHIA SẺ DƯỚI HÌNH THỨC HỌC TẬP" + Environment.NewLine + "XIN CẢM ƠN", "THÔNG TIN PHẦN MỀM", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
