using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.BS_layer
{
    class BLNhanVien
    {
        public System.Data.Linq.Table <NHANVIEN> LayNhanVien()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            return qlNH.NHANVIENs;
        }
        public List<NHANVIEN> TimKiemNhanVien(string str)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var NhanVienList = from nv in qlNH.NHANVIENs
                            where nv.Manv.Contains(str)
                            select nv;
            return NhanVienList.ToList();
        }
        public bool ThemNhanVien(string Manv, string Ten, string SDT, string ChucVu ,ref string err)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            NHANVIEN nv = new NHANVIEN();
            nv.Manv = Manv;
            nv.Ten = Ten;
            nv.SDT = SDT;
            nv.ChucVu = ChucVu;
            qlNH.NHANVIENs.InsertOnSubmit(nv);
            qlNH.NHANVIENs.Context.SubmitChanges();
            return true;
        }
        public bool XoaNHanVien(string Manv, ref string err)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var nvQuerry = from nv in qlNH.NHANVIENs
                          where nv.Manv == Manv
                          select nv;
            qlNH.NHANVIENs.DeleteAllOnSubmit(nvQuerry);
            qlNH.SubmitChanges();
            return true;
        }
        public bool CapNhatNhanVien(string Manv, string Ten, string SDT, string ChucVu, ref string err)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var nvQuerry = (from nv in qlNH.NHANVIENs
                           where nv.Manv == Manv
                           select nv).SingleOrDefault();
            if (nvQuerry != null)
            {
                nvQuerry.Ten= Ten;
                nvQuerry.SDT= SDT;
                nvQuerry.ChucVu= ChucVu;
                qlNH.SubmitChanges();
            }
            return true;
        }
    }
}
