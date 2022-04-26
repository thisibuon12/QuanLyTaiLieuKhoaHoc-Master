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
    public partial class fThongKe : Form
    {
        QLTLKHDataClassesDataContext db = new QLTLKHDataClassesDataContext();
        public fThongKe()
        {
            InitializeComponent();
        }

        private void fThongKe_Load(object sender, EventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            lbDoanhThu.Text = "-";
            lbTongSo.Text = "-";
            lbTLMax.Text = "-";
            lbTLMin.Text = "-";
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tungay = DateTime.Parse(dateTuNgay.Value.ToShortDateString());
                DateTime denngay = dateDenNgay.Value;
                DoanhThuBan(tungay, denngay);
                TongSo(tungay, denngay);
                TLKHMax(tungay, denngay);
                TLKHMin(tungay, denngay);
                DSHD(tungay, denngay);
                TLDuocMua(tungay, denngay);
                TLChuaDuocMua(tungay, denngay);
            }
            catch
            {
                Reset();
            }
        }
        public void TongSo(DateTime tungay, DateTime denngay)
        {
            var data = from q in db.HoaDons
                       where q.TongTien != null && q.MaKH != null && (q.NgayLap >= tungay && q.NgayLap <= denngay)
                       select q;
            lbTongSo.Text = data.Count().ToString();
        }
        public void DoanhThuBan(DateTime tungay, DateTime denngay)
        {
            Int64 tong = 0;
            var data = from q in db.HoaDons
                       join p in db.CTHDs on q.MaHD equals p.MaHD
                       where q.TongTien != null && q.MaKH != null && (q.NgayLap >= tungay && q.NgayLap <= denngay) && p.Loai == 0
                       select new { p.ThanhTien };
            foreach (var item in data)
            {
                tong += Int64.Parse(item.ThanhTien.ToString());
            }
            lbDoanhThu.Text = String.Format("{0:C0}", tong);
        }
        public void TLKHMax(DateTime tungay, DateTime denngay)
        {
            var data = from q in db.HoaDons
                        join p in db.CTHDs on q.MaHD equals p.MaHD
                        where q.TongTien != null && q.MaKH != null && (q.NgayLap >= tungay && q.NgayLap <= denngay)
                        group p by new { p.MaTL } into g
                        orderby g.Count(x => x.MaTL != null) descending
                        select new { MaTL = g.Key.MaTL, SL = g.Count(y => y.MaTL != null) };
            var max = data.First();
            lbTLMax.Text = max.MaTL.Trim() + " - " + LayTenTL(max.MaTL);
        }
        public void TLKHMin(DateTime tungay, DateTime denngay)
        {
            var data = from q in db.HoaDons
                       join p in db.CTHDs on q.MaHD equals p.MaHD
                       where q.TongTien != null && q.MaKH != null && (q.NgayLap >= tungay && q.NgayLap <= denngay)
                       group p by new { p.MaTL } into g
                       orderby g.Count(x => x.MaTL != null) ascending
                       select new { MaTL = g.Key.MaTL, SL = g.Count(y => y.MaTL != null) };
            var min = data.First();
            lbTLMin.Text = min.MaTL.Trim() + " - " + LayTenTL(min.MaTL);
        }
        public string LayTenTL(string matl)
        {
            var data = from q in db.TLKHs
                       where q.MaTL == matl
                       select q;
            TLKH tl = data.Single();
            return tl.TenTL;
        }
        public void DSHD(DateTime tungay, DateTime denngay)
        {
            var data = from q in db.HoaDons
                       where q.TongTien != null && q.MaKH != null && (q.NgayLap >= tungay && q.NgayLap <= denngay)
                       select new { q.MaHD, q.MaKH, q.NgayLap, q.TongTien };
            dgvHD.DataSource = data;
        }
        public void TLDuocMua(DateTime tungay, DateTime denngay)
        {
            var tbltemp = (from q in db.HoaDons
                           join q1 in db.CTHDs on q.MaHD equals q1.MaHD
                           join q2 in db.TLKHs on q1.MaTL equals q2.MaTL
                           where q.TongTien != null && q.MaKH != null && (q.NgayLap >= tungay && q.NgayLap <= denngay)
                           select q1.MaTL).ToList();
            var result = from q in db.TLKHs
                         where tbltemp.Contains(q.MaTL)
                         select new { q.MaTL, q.TenTL };
            dgvTLDuocMua.DataSource = result;
        }
        public void TLChuaDuocMua(DateTime tungay, DateTime denngay)
        {
            var tbltemp = (from q in db.HoaDons
                           join q1 in db.CTHDs on q.MaHD equals q1.MaHD
                           join q2 in db.TLKHs on q1.MaTL equals q2.MaTL
                           where q.TongTien != null && q.MaKH != null && (q.NgayLap >= tungay && q.NgayLap <= denngay)
                           select q1.MaTL).ToList();
            var result = from q in db.TLKHs
                         where !tbltemp.Contains(q.MaTL)
                         select new { q.MaTL, q.TenTL };
            dgvTLChuaDuocMua.DataSource = result;
        }
    }
}
