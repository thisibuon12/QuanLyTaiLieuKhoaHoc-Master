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
    public partial class fXemCTHD : Form
    {
        public string mahd;
        QLTLKHDataClassesDataContext db = new QLTLKHDataClassesDataContext();
        public fXemCTHD()
        {
            InitializeComponent();
        }

        private void fXemCTHD_Load(object sender, EventArgs e)
        {
            ThongTin();
            CTHD();
        }
        public void ThongTin()
        {
            var data = from q in db.HoaDons
                       join q1 in db.KhachHangs on q.MaKH equals q1.MaKH
                       join q2 in db.NhanViens on q.MaNV equals q2.MaNV
                       where q.MaHD == mahd
                       select new { q.MaHD, q.NgayLap, q.MaKH, q1.TenKH, q2.TenNV, q.TongTien };
            var item = data.Single();
            txtMaHD.Text = item.MaHD.Trim();
            txtNgayLap.Text = DateTime.Parse(item.NgayLap.ToString()).ToString("dd/MM/yyyy HH:mm:ss");
            txtMaKH.Text = item.MaKH.Trim();
            txtTenKH.Text = item.TenKH;
            txtNhanVienLap.Text = item.TenNV;
            txtThanhToan.Text = String.Format("{0:C0}", Int64.Parse(item.TongTien.ToString()));
        }
        public void CTHD()
        {
            var data = from q in db.CTHDs
                       join q1 in db.TLKHs on q.MaTL equals q1.MaTL
                       where q.MaHD == mahd
                       select new { q.MaTL, q1.TenTL, q.Loai, q.ThanhTien };
            dgvCTHD.DataSource = data;
            if (dgvCTHD.Rows.Count > 0)
            {
                dgvCTHD.CurrentRow.Selected = true;
            }
        }

        private void dgvCTHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCTHD.Columns[e.ColumnIndex].Name.Equals("Loai"))
            {
                string vl = e.Value.ToString();
                if (vl == null)
                    return;
                switch (vl)
                {
                    case "0":
                        e.Value = "Mua";
                        break;
                    case "1":
                        e.Value = "Thuê";
                        break;
                }
            }
        }
    }
}
