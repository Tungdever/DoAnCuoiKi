using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.BS_layer
{
    class BLTaiKhoan
    {   
        BLNhanVien dbNV = new BLNhanVien();
        public DataTable LayTaiKhoan()
        {

            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var dms =
            from p in qlnhEntity.TAIKHOANs
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("TenTaiKhoan");
            dt.Columns.Add("MatKhau");
            dt.Columns.Add("MaNV");
            dt.Columns.Add("CapDoQuyen");
            foreach (var p in dms)
            {
                dt.Rows.Add(p.TenTaiKhoan, p.MatKhau, dbNV.MaNV_TenNV(p.MaNV),p.CapDoQuyen);
            }
            return dt;
        }
        public DataTable TimKiemTaiKhoan(string str)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var dms =
            from p in qlnhEntity.TAIKHOANs
            where p.TenTaiKhoan.Contains(str)
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("TenTaiKhoan");
            dt.Columns.Add("MatKhau");
            dt.Columns.Add("MaNV");
            dt.Columns.Add("CapDoQuyen");
            foreach (var p in dms)
            {
                dt.Rows.Add(p.TenTaiKhoan, p.MatKhau, dbNV.MaNV_TenNV(p.MaNV), p.CapDoQuyen);
            }
            return dt;
        }
        public bool ThemTaiKhoan(string TenTaiKhoan, string MatKhau, string MaNV, int CapDoQuyen, ref string err)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            TAIKHOAN tk = new TAIKHOAN();
            tk.TenTaiKhoan = TenTaiKhoan;
            tk.MatKhau= MatKhau;
            tk.MaNV = MaNV;
            tk.CapDoQuyen = CapDoQuyen;
            qlnhEntity.TAIKHOANs.Add(tk);
            qlnhEntity.SaveChanges();
            return true;

        }
        public bool XoaTaiKhoan(string TenTaiKhoan, ref string err)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            TAIKHOAN tk = new TAIKHOAN();
            tk.TenTaiKhoan = TenTaiKhoan;
            qlnhEntity.TAIKHOANs.Attach(tk);
            qlnhEntity.TAIKHOANs.Remove(tk);
            qlnhEntity.SaveChanges();
            return true;
        }
        public bool CapNhatTaiKhoan(string TenTaiKhoan, string MatKhau, string MaNV, int CapDoQuyen, ref string err)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var tkQuery = (from tk in qlnhEntity.TAIKHOANs
                           where tk.TenTaiKhoan == TenTaiKhoan
                           select tk).SingleOrDefault();
            if (tkQuery != null)
            {
                tkQuery.MatKhau = MatKhau;
                tkQuery.MaNV = MaNV;
                tkQuery.CapDoQuyen = CapDoQuyen;
                qlnhEntity.SaveChanges();
            }
            return true;
        }
        
        
        public bool DangNhap(string TenTaiKhoan, string MatKhau)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            List<TAIKHOAN> tkQuery = (from tk in qlnhEntity.TAIKHOANs
                          where tk.TenTaiKhoan == TenTaiKhoan && tk.MatKhau == MatKhau
                          select tk).ToList();
            if (tkQuery.Count > 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool KT(string TenTaiKhoan)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            List<TAIKHOAN> tkQuery = (from tk in qlnhEntity.TAIKHOANs
                                      where tk.TenTaiKhoan == TenTaiKhoan && tk.CapDoQuyen == 1
                                      select tk).ToList();
            if (tkQuery.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
