using Microsoft.Reporting.WinForms;
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
    public partial class fXuatHoaDon : Form
    {
        public string mahd;
        QLTLKHDataClassesDataContext db = new QLTLKHDataClassesDataContext();
        public fXuatHoaDon()
        {
            InitializeComponent();
        }

        private void fXuatHoaDon_Load(object sender, EventArgs e)
        {
            var data = from q in db.HoaDons
                       join q1 in db.CTHDs on q.MaHD equals q1.MaHD
                       join q2 in db.TLKHs on q1.MaTL equals q2.MaTL
                       join q3 in db.KhachHangs on q.MaKH equals q3.MaKH
                       join q4 in db.NhanViens on q.MaNV equals q4.MaNV
                       where q.MaHD == mahd
                       group new { q, q1, q2, q3, q4 } by new { q.MaHD, q.NgayLap, q.TongTien, q.MaKH, q3.TenKH, q4.TenNV, q2.MaTL, q2.TenTL, q1.Loai } into g
                       select new { MaHD = g.Key.MaHD, NgayLap = g.Key.NgayLap, TongTien = g.Key.TongTien, MaKH = g.Key.MaKH, TenKH = g.Key.TenKH, TenNV = g.Key.TenNV, MaTL = g.Key.MaTL, TenTL = g.Key.TenTL, Loai = g.Key.Loai, SL = g.Sum(x => x.q1.SL), ThanhTien = g.Sum(y => y.q1.ThanhTien) };
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 150;
            reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyTLKHTV.rpXuatHoaDon.rdlc";
            if (data.Count() > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "XuatHoaDon";
                rds.Value = data;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
