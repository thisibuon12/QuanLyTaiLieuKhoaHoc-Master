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
    public partial class fDanhSachHoaDon : Form
    {
        QLTLKHDataClassesDataContext db = new QLTLKHDataClassesDataContext();
        public fDanhSachHoaDon()
        {
            InitializeComponent();
        }

        private void fDanhSachHoaDon_Load(object sender, EventArgs e)
        {
            HoaDon();
        }
        public void HoaDon()
        {
            var data = from q in db.HoaDons
                       where q.TongTien != null && q.MaKH != null
                       orderby q.NgayLap descending
                       select new { q.MaHD, q.NgayLap, q.MaKH, q.TongTien };
            dgvHD.DataSource = data;
            if (dgvHD.Rows.Count > 0)
            {
                dgvHD.CurrentRow.Selected = true;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            if (tukhoa == "")
            {
                HoaDon();
            }
            else
            {
                var data = from q in db.HoaDons
                           where q.TongTien != null && q.MaKH != null && (q.MaHD.Contains(tukhoa) || q.NgayLap.ToString().Contains(tukhoa) || q.MaKH.Contains(tukhoa) || q.TongTien.ToString().Contains(tukhoa))
                           orderby q.NgayLap descending
                           select new { q.MaHD, q.NgayLap, q.MaKH, q.TongTien };
                dgvHD.DataSource = data;
                if (dgvHD.Rows.Count > 0)
                {
                    dgvHD.CurrentRow.Selected = true;
                }
            }
        }

        private void dgvHD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHD.Rows.Count > 0)
            {
                dgvHD.CurrentRow.Selected = true;
                string mahd = dgvHD.CurrentRow.Cells["MaHD"].Value.ToString().Trim();
                fXemCTHD fXCT = new fXemCTHD();
                fXCT.mahd = mahd;
                fXCT.ShowDialog();
            }
        }
    }
}
