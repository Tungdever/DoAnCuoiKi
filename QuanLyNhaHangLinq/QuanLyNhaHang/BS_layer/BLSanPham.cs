using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.BS_layer
{
    class BLSanPham
    {
        public DataTable LaySanPham()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var sps =
                        from p in qlNH.SANPHAMs
                        select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSP");
            dt.Columns.Add("TenSP");
            dt.Columns.Add("MaLoaiSP");
            dt.Columns.Add("TenLoaiSP");
            dt.Columns.Add("GiaSP");
            foreach (var p in sps)
            {
                dt.Rows.Add(p.MaSP, p.TenSP, p.MaLoaiSP, p.TenLoaiSP, p.GiaSP);
            }
            return dt;
        }
        public DataTable TimKiemSanPham(string str)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var sps = from sp in qlNH.SANPHAMs
                              where sp.TenSP.Contains(str)
                              select sp;
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSP");
            dt.Columns.Add("TenSP");
            dt.Columns.Add("MaLoaiSP");
            dt.Columns.Add("TenLoaiSP");
            dt.Columns.Add("GiaSP");
            foreach (var p in sps)
            {
                dt.Rows.Add(p.MaSP, p.TenSP, p.MaLoaiSP, p.TenLoaiSP, p.GiaSP);
            }
            return dt;
        }
        public bool ThemSanPham(string MaSP, string TenSP, string MaLoaiSP, string TenLoaiSP, float GiaSP, System.Drawing.Image AnhSP, ref string err)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            SANPHAM sp = new SANPHAM();
            MemoryStream ms = new MemoryStream();
            System.Drawing.Image tmp = AnhSP;
            tmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageByteArray = ms.ToArray();
            sp.MaSP = MaSP;
            sp.TenSP = TenSP;
            sp.MaLoaiSP = MaLoaiSP;
            sp.TenLoaiSP = TenLoaiSP;
            sp.GiaSP = GiaSP;
            sp.AnhSP = imageByteArray;
            qlNH.SANPHAMs.InsertOnSubmit(sp);
            qlNH.SANPHAMs.Context.SubmitChanges();
            return true;

        }
        public bool XoaSanPham(string Masp, ref string err)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var spQuery = from sp in qlNH.SANPHAMs
                          where sp.MaSP == Masp
                          select sp;
            qlNH.SANPHAMs.DeleteAllOnSubmit(spQuery);
            qlNH.SubmitChanges();
            return true;
        }
        public bool CapNhatSanPham(string MaSP, string TenSP, string MaLoaiSP, string TenLoaiSP, float GiaSP, System.Drawing.Image AnhSP, ref string err)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var spQuery = (from sp in qlNH.SANPHAMs
                           where sp.MaSP == MaSP
                           select sp).SingleOrDefault();
            MemoryStream ms = new MemoryStream();
            System.Drawing.Image tmp = AnhSP;
            tmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageByteArray = ms.ToArray();
            if (spQuery != null)
            {
                spQuery.TenSP = TenSP;
                spQuery.MaLoaiSP = MaLoaiSP;
                spQuery.TenLoaiSP = TenLoaiSP;
                spQuery.GiaSP = GiaSP;
                spQuery.AnhSP = imageByteArray;
                qlNH.SubmitChanges();
            }
            return true;
        }
        public List<byte[]> LayHinh(string MaSP)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var sanphamList = (from sp in qlNH.SANPHAMs
                               where sp.MaSP == MaSP
                               select sp.AnhSP).ToList();

            List<byte[]> imageList = new List<byte[]>();
            foreach (var sanpham in sanphamList)
            {
                byte[] imageData = sanpham.ToArray();
                imageList.Add(imageData);
            }

            return imageList;
        }
    }
}
