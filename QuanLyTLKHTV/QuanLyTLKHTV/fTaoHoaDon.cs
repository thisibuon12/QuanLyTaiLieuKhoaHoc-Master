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
    public partial class fTaoHoaDon : Form
    {
        public string tdn = "admin";
        QLTLKHDataClassesDataContext db = new QLTLKHDataClassesDataContext();
        public fTaoHoaDon()
        {
            InitializeComponent();
        }
        Int64 thanhtien = 0;
        public void LayThongTinTL()
        {
            try
            {
                var data = from q in db.TLKHs
                           where q.MaVach == txtMaVach.Text.Trim()
                           select q;
                if (data.Count() > 0)
                {
                    TLKH tl = data.First();
                    txtMaLT.Text = tl.MaTL;
                    txtTenTL.Text = tl.TenTL;
                    txtGiaSach.Text = tl.GiaBan.ToString();
                    if (cbMua.Checked == true)
                    {
                        thanhtien = Int64.Parse(tl.GiaBan.ToString());
                        txtThanhTien.Text = String.Format("{0:C0}", thanhtien);
                    }
                    else
                    {
                        thanhtien = Int64.Parse(tl.GiaBan.ToString()) + Int64.Parse(tl.GiaThue.ToString());
                        txtThanhTien.Text = String.Format("{0:C0}", thanhtien);
                    }
                }
                else
                {
                    txtMaLT.Text = "";
                    txtTenTL.Text = "";
                    txtGiaSach.Text = "";
                    txtThanhTien.Text = "";
                }
            }
            catch { }
        }
        private void txtMaVach_TextChanged(object sender, EventArgs e)
        {
            LayThongTinTL();
        }

        private void fTaoHoaDon_Load(object sender, EventArgs e)
        {
            cbMua.Checked = true;
            this.ActiveControl = txtMaVach;
        }

        private void cbMua_CheckedChanged(object sender, EventArgs e)
        {
            txtMaVach.Text = "";
            if (cbMua.Checked == true)
            {
                cbThue.Checked = false;
            }
            else
            {
                cbThue.Checked = true;
            }
        }

        private void cbThue_CheckedChanged(object sender, EventArgs e)
        {
            txtMaVach.Text = "";
            if (cbThue.Checked == true)
            {
                cbMua.Checked = false;
            }
            else
            {
                cbMua.Checked = true;
            }
        }

        private void txtMaVach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
            }
        }
        int check = 0;
        string mahd = "";
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLT.Text != "")
            {
                if (check == 0)
                {
                    TaoHD();
                    string matl = txtMaLT.Text.Trim();
                    int loai = cbThue.Checked == true ? 1 : 0;
                    ThemCTHD(mahd, matl, loai, thanhtien);
                    CapNhatTongTienHD(mahd, thanhtien);
                    LoadCTHD();
                    check = 1;
                }
                else
                {
                    string matl = txtMaLT.Text.Trim();
                    int loai = cbThue.Checked == true ? 1 : 0;
                    ThemCTHD(mahd, matl, loai, thanhtien);
                    CapNhatTongTienHD(mahd, thanhtien);
                    LoadCTHD();
                }
                TinhTongTien();
                thanhtien = 0;
                txtMaVach.Text = "";
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài liệu", "Có lỗi");
            }
        }
        public void TaoHD()
        {
            HoaDon hd = new HoaDon();
            hd.MaHD = DateTime.Now.ToString("ddMMyyyyHHmmss");
            hd.NgayLap = DateTime.Now;
            hd.MaNV = tdn;
            hd.TongTien = 0;
            db.HoaDons.InsertOnSubmit(hd);
            db.SubmitChanges();
            mahd = hd.MaHD;
        }
        public string LayMaHD()
        {
            var data = from q in db.HoaDons
                       orderby q.MaHD descending
                       select q;
            HoaDon hd = data.First();
            return hd.MaHD;
        }
        public void ThemCTHD(string mahd, string matl, int loai, Int64 tt)
        {
            CTHD ct = new CTHD();
            ct.MaHD = mahd;
            ct.MaTL = matl;
            ct.Loai = loai;
            ct.SL = 1;
            ct.ThanhTien = tt;
            db.CTHDs.InsertOnSubmit(ct);
            db.SubmitChanges();
        }
        public void CapNhatTongTienHD(string mahd, Int64 sotien)
        {
            var data = from q in db.HoaDons
                       where q.MaHD == mahd
                       select q;
            HoaDon hd = data.Single();
            hd.TongTien += sotien;
            db.SubmitChanges();
        }
        public void TinhTongTien()
        {
            var data = from q in db.CTHDs
                       where q.MaHD==mahd
                       select q;
            Int64 tongtien = 0;
            foreach (var item in data)
            {
                tongtien += Int64.Parse(item.ThanhTien.ToString());
                txtTongThanhToan.Text = String.Format("{0:C0}", tongtien);
            }
        }
        public void LoadCTHD()
        {
            var data = from q in db.CTHDs
                       join p in db.TLKHs on q.MaTL equals p.MaTL
                       where q.MaHD == mahd
                       group new { q, p } by new { q.MaTL, p.TenTL, q.Loai } into g
                       select new { MaTL = g.Key.MaTL, TenTL = g.Key.TenTL, Loai = g.Key.Loai, SL = g.Sum(x => x.q.SL), ThanhTien = g.Sum(y => y.q.ThanhTien) };
            dgvGH.DataSource = data;
        }

        private void dgvGH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvGH.Columns[e.ColumnIndex].Name.Equals("Loai"))
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

        private void btnXHD_Click(object sender, EventArgs e)
        {
            if (dgvGH.Rows.Count > 0)
            {
                fKhachHang fKH = new fKhachHang();
                fKH.chon = 1;
                fKH.mahd = mahd;
                if (fKH.ShowDialog() == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Chưa có tài liệu nào, không thể xuất hóa đơn", "Có lỗi");
            }
        }
    }
}
