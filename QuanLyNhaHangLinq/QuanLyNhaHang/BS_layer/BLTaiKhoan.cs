using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.BS_layer
{
    class BLTaiKhoan
    {
        BLNhanVien dbNV = new BLNhanVien();
        public DataTable LayTaiKhoan()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var taikhoanList = from tk in qlNH.TAIKHOANs
                               select new
                               {
                                   TenTaiKhan = tk.TenTaiKhoan,
                                   MatKhau = tk.MatKhau,
                                   MaNV = tk.MaNV,
                                   CapDoQuyen = tk.CapDoQuyen
                               };
            DataTable dt = new DataTable();
            dt.Columns.Add("TenTaiKhoan");
            dt.Columns.Add("MatKhau");
            dt.Columns.Add("MaNV");
            dt.Columns.Add("CapDoQuyen");
            foreach (var item in taikhoanList)
            {
                dt.Rows.Add(item.TenTaiKhan, item.MatKhau, dbNV.MaNV_TenNV(item.MaNV), item.CapDoQuyen);
            }
            return dt;
        }
        public bool ThemTaiKhoan(string TenTaiKhoan, string MatKhau, string MaNV, int CapDoQuyen, ref string err)
        {
            bool f = false;
            try
            {
                QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
                TAIKHOAN tk = new TAIKHOAN();
                tk.TenTaiKhoan = TenTaiKhoan;
                tk.MatKhau = MatKhau;
                tk.MaNV = MaNV;
                tk.CapDoQuyen = CapDoQuyen;
                qlNH.TAIKHOANs.InsertOnSubmit(tk);
                qlNH.TAIKHOANs.Context.SubmitChanges();
                f = true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return f;
        }
        public bool XoaTaiKhoan(string TenTaiKhoan, ref string err)
        {
            bool f = false;
            try
            {
                QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
                var tkQuerry = from tk in qlNH.TAIKHOANs
                               where tk.TenTaiKhoan == TenTaiKhoan
                               select tk;
                qlNH.TAIKHOANs.DeleteAllOnSubmit(tkQuerry);
                qlNH.SubmitChanges();
                f = true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return f;
        }
        public bool XoaTaiKhoanTheoNV(string MaNV, ref string err)
        {
            bool f = false;
            try
            {
                QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
                var tkQuerry = from tk in qlNH.TAIKHOANs
                               where tk.MaNV == MaNV
                               select tk;
                qlNH.TAIKHOANs.DeleteAllOnSubmit(tkQuerry);
                qlNH.SubmitChanges();
                f = true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return f;
        }
        public bool CapNhatTaiKhoan(string TenTaiKhoan, string MatKhau, string MaNV, int CapDoQuyen, ref string err)
        {
            bool f = false;
            try
            {
                QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
                var tkQuery = (from tk in qlNH.TAIKHOANs
                               where tk.TenTaiKhoan == TenTaiKhoan
                               select tk).SingleOrDefault();
                if (tkQuery != null)
                {
                    tkQuery.MatKhau = MatKhau;
                    tkQuery.MaNV = MaNV;
                    tkQuery.CapDoQuyen = CapDoQuyen;
                    qlNH.SubmitChanges();
                }
                f = true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return f;
        }
        public bool DangNhap(string TenTaiKhoan, string MatKhau)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            List<TAIKHOAN> tkQuery = (from tk in qlNH.TAIKHOANs
                                      where tk.TenTaiKhoan == TenTaiKhoan && tk.MatKhau == MatKhau
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
        public DataTable TimKiemTaiKhoan(string str)
        {

            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var taikhoanList = from tk in qlNH.TAIKHOANs
                               where tk.TenTaiKhoan.Contains(str)
                               select new
                               {
                                   TenTaiKhan = tk.TenTaiKhoan,
                                   MatKhau = tk.MatKhau,
                                   MaNV = tk.MaNV,
                                   CapDoQuyen = tk.CapDoQuyen
                               };
            DataTable dt = new DataTable();
            dt.Columns.Add("TenTaiKhoan");
            dt.Columns.Add("MatKhau");
            dt.Columns.Add("MaNV");
            dt.Columns.Add("CapDoQuyen");
            foreach (var item in taikhoanList)
            {
                dt.Rows.Add(item.TenTaiKhan, item.MatKhau, dbNV.MaNV_TenNV(item.MaNV), item.CapDoQuyen);
            }
            return dt;

        }
        public bool KT(string TenTaiKhoan)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            List<TAIKHOAN> tkQuery = (from tk in qlNH.TAIKHOANs
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
        public string LayQuyen(string str)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var taikhoanList = from tk in qlNH.TAIKHOANs
                               where tk.TenTaiKhoan.Contains(str)
                               select new
                               {
                                   CapDoQuyen = tk.CapDoQuyen
                               };
            string CapDoQuyen = "";
            foreach (var item in taikhoanList)
            {
                CapDoQuyen = item.CapDoQuyen.ToString();
            }
            if (CapDoQuyen == "1") CapDoQuyen = "ADMIN";
            else CapDoQuyen = "Nhân viên quản lý";
            return CapDoQuyen;
        }
        public string TimKiemTen(string str)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var taikhoanList = from tk in qlNH.TAIKHOANs
                               where tk.TenTaiKhoan.Contains(str)
                               select new
                               {
                                   MaNV = tk.MaNV,
                                   CapDoQuyen = tk.CapDoQuyen
                               };
            string tenNV = "";
            foreach (var item in taikhoanList)
            {
                string maNV = item.MaNV.ToString();
                tenNV = dbNV.MaNV_TenNV(maNV).Split('-')[1].Trim();
            }
            return tenNV;
        }
    }
}
