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
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var sps =
            from p in qlnhEntity.SANPHAMs
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
        public DataTable LoadMenu()
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var sps =
            from p in qlnhEntity.SANPHAMs
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSP");
            dt.Columns.Add("TenSP");
            dt.Columns.Add("MaLoaiSP");
            dt.Columns.Add("TenLoaiSP");
            dt.Columns.Add("GiaSP");
            dt.Columns.Add("AnhSP", typeof(byte[]));
            foreach (var p in sps)
            {
                byte[] imgdata = p.AnhSP.ToArray();
                dt.Rows.Add(p.MaSP, p.TenSP, p.MaLoaiSP, p.TenLoaiSP, p.GiaSP, imgdata);
            }
            return dt;
        }
        public List<SANPHAM> GetProducts()
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var query = from sp in qlnhEntity.SANPHAMs
                        join dm in qlnhEntity.DANHMUCs on sp.MaLoaiSP equals dm.MaDM
                        select sp;

            return query.ToList();
        }
        public DataTable TimKiemSanPham(string str)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var sanphamList = from sp in qlnhEntity.SANPHAMs
                              where sp.TenSP.Contains(str)
                              select sp;

            DataTable dt = new DataTable();
            dt.Columns.Add("MaSP");
            dt.Columns.Add("TenSP");
            dt.Columns.Add("MaLoaiSP");
            dt.Columns.Add("TenLoaiSP");
            dt.Columns.Add("GiaSP");
            foreach (var p in sanphamList)
            {
                dt.Rows.Add(p.MaSP, p.TenSP, p.MaLoaiSP, p.TenLoaiSP, p.GiaSP);
            }
            return dt;

        }
        public bool ThemSanPham(string MaSP, string TenSP, string MaLoaiSP, string TenLoaiSP, float GiaSP, System.Drawing.Image AnhSP, ref string err)
        {
            try
            {
                QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
                SANPHAM sp = new SANPHAM();
                MemoryStream ms = new MemoryStream();
                System.Drawing.Image tmp = AnhSP;
                tmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageByteArray = ms.ToArray();
                sp.AnhSP = imageByteArray;
                sp.MaSP = MaSP;
                sp.TenSP = TenSP;
                sp.MaLoaiSP = MaLoaiSP;
                sp.TenLoaiSP = TenLoaiSP;
                sp.GiaSP = GiaSP;
                qlnhEntity.SANPHAMs.Add(sp);
                qlnhEntity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }

        }
        public bool XoaSanPham(string MaSP, ref string err)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            SANPHAM sp = new SANPHAM();
            sp.MaSP = MaSP;
            try
            {
                qlnhEntity.SANPHAMs.Attach(sp);
                qlnhEntity.SANPHAMs.Remove(sp);
                qlnhEntity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }
        public bool XoaSanPhamTheoDM(string MaDM, ref string err)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            try
            {
                var sanPhamList = qlnhEntity.SANPHAMs.Where(sp => sp.MaLoaiSP == MaDM).ToList();

                foreach (var p in sanPhamList)
                {
                    qlnhEntity.SANPHAMs.Remove(p);
                }

                qlnhEntity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }
        public bool CapNhatSanPham(string MaSP, string TenSP, string MaLoaiSP, string TenLoaiSP, float GiaSP, System.Drawing.Image AnhSP, ref string err)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                System.Drawing.Image tmp = AnhSP;
                tmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageByteArray = ms.ToArray();
                QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
                var spQuery = (from sp in qlnhEntity.SANPHAMs
                               where sp.MaSP == MaSP
                               select sp).SingleOrDefault();
                if (spQuery != null)
                {
                    spQuery.AnhSP = imageByteArray;
                    spQuery.TenSP = TenSP;
                    spQuery.MaLoaiSP = MaLoaiSP;
                    spQuery.TenLoaiSP = TenLoaiSP;
                    spQuery.GiaSP = GiaSP;
                    qlnhEntity.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }
        public List<byte[]> LayHinh(string MaSP)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var sanphamList = from sp in qlnhEntity.SANPHAMs
                              where sp.MaSP == MaSP
                              select sp.AnhSP;
            List<byte[]> imageList = new List<byte[]>();
            foreach (var sanpham in sanphamList)
            {
                if (sanpham != null)
                {
                    byte[] imageData = sanpham.ToArray();
                    imageList.Add(imageData);
                }
            }
            return imageList;
        }

    }
}
