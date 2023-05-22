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
        public DataTable LayTaiKhoan()
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var dms =
            from p in qlnhEntity.TAIKHOANs
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("TenTaiKhoan");
            dt.Columns.Add("MatKhau");
            foreach (var p in dms)
            {
                dt.Rows.Add(p.TenTaiKhoan, p.MatKhau);
            }
            return dt;
        }
        public List<TAIKHOAN> TimKiemTaiKhoan(string str)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var taikhoanList = from tk in qlnhEntity.TAIKHOANs
                              where tk.TenTaiKhoan.Contains(str)
                              select tk;

            return taikhoanList.ToList();
        }
        public bool ThemTaiKhoan(string TenTaiKhoan, string MatKhau, ref string err)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            TAIKHOAN tk = new TAIKHOAN();
            tk.TenTaiKhoan = TenTaiKhoan;
            tk.MatKhau= MatKhau;
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
        public bool CapNhatTaiKhoan(string TenTaiKhoan, string MatKhau, ref string err)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var tkQuery = (from tk in qlnhEntity.TAIKHOANs
                           where tk.TenTaiKhoan == TenTaiKhoan
                           select tk).SingleOrDefault();
            if (tkQuery != null)
            {
                tkQuery.TenTaiKhoan = TenTaiKhoan;
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
    }
}
