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
        public System.Data.Linq.Table<TAIKHOAN> LayTaiKhoan()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            return qlNH.TAIKHOANs;
        }
        public bool ThemTaiKhoan(string TenTaiKhoan, string MatKhau, ref string err)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            TAIKHOAN tk = new TAIKHOAN();
            tk.TenTaiKhoan = TenTaiKhoan;
            tk.MatKhau = MatKhau;
            qlNH.TAIKHOANs.InsertOnSubmit(tk);
            qlNH.TAIKHOANs.Context.SubmitChanges();
            return true;

        }
        public bool XoaTaiKhoan(string TenTaiKhoan, ref string err)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var tkQuery = from tk in qlNH.TAIKHOANs
                          where tk.TenTaiKhoan == TenTaiKhoan
                          select tk;
            qlNH.TAIKHOANs.DeleteAllOnSubmit(tkQuery);
            qlNH.SubmitChanges();
            return true;
        }
        //public bool CapNhatThanhPho(string MaThanhPho, string TenThanhPho, ref string err)
        //{
        //    QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
        //    var tpQuery = (from tp in qlBH.ThanhPhos
        //                   where tp.ThanhPho1 == MaThanhPho
        //                   select tp).SingleOrDefault();
        //    if (tpQuery != null)
        //    {
        //        tpQuery.TenThanhPho = TenThanhPho;
        //        qlBH.SubmitChanges();
        //    }
        //    return true;
        //}
        public bool DangNhap(string TenTaiKhoan, string MatKhau)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            List<TAIKHOAN> tkQuery = (from tk in qlNH.TAIKHOANs
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
