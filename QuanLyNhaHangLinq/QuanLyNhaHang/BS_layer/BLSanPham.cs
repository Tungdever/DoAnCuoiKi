using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
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

        public DataTable LoadMenu()
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
            dt.Columns.Add("AnhSP", typeof(byte[]));
            foreach (var p in sps)
            {
                byte[] imgdata = p.AnhSP.ToArray();
                //     string imgdata = Convert.ToBase64String(p.AnhSP.ToArray());
                dt.Rows.Add(p.MaSP, p.TenSP, p.MaLoaiSP, p.TenLoaiSP, p.GiaSP, imgdata);
                //   Console.WriteLine(imgdata);
            }
            return dt;
        }

        /*public DataTable LoadMenu()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var sps = from p in qlNH.SANPHAMs
                      select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("MaSP");
            dt.Columns.Add("TenSP");
            dt.Columns.Add("MaLoaiSP");
            dt.Columns.Add("TenLoaiSP");
            dt.Columns.Add("GiaSP");
            dt.Columns.Add("AnhSP", typeof(System.Drawing.Image)); // Chuyển đổi kiểu dữ liệu thành System.Drawing.Image

            foreach (var p in sps)
            {
                byte[] imgData = p.AnhSP.ToArray();
                using (MemoryStream ms = new MemoryStream(imgData))
                {
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                    dt.Rows.Add(p.MaSP, p.TenSP, p.MaLoaiSP, p.TenLoaiSP, p.GiaSP, img);
                }
            }

            return dt;
        }
*/
        public List<SANPHAM> GetProducts()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var query = from sp in qlNH.SANPHAMs
                        join dm in qlNH.DANHMUCs on sp.MaLoaiSP equals dm.MaDM
                        select sp;

            return query.ToList();
        }
        /*  public Table<SANPHAM> LoadMenu()
          {
              *//*using (var qlNH = new QuanLyNhaHangDataContext())
              {

                  return qlNH.SANPHAMs;
              }*//*
              QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
              return qlNH.SANPHAMs;
          }*/
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
            bool f = false;
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
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
            try
            {
                qlNH.SANPHAMs.InsertOnSubmit(sp);
                qlNH.SANPHAMs.Context.SubmitChanges();
                f = true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return f;
        }
        public bool XoaSanPham(string Masp, ref string err)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var spQuery = from sp in qlNH.SANPHAMs
                          where sp.MaSP == Masp
                          select sp;
            try
            {
                qlNH.SANPHAMs.DeleteAllOnSubmit(spQuery);
                qlNH.SubmitChanges();
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
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var spQuery = from sp in qlNH.SANPHAMs
                          where sp.MaLoaiSP == MaDM
                          select sp;
            try
            {
                qlNH.SANPHAMs.DeleteAllOnSubmit(spQuery);
                qlNH.SubmitChanges();
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
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            try
            {
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
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }

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
