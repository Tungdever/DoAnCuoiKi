using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.BS_layer
{
    class BLNhanVien
    {
        public DataTable LayNhanVien()
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var nv = from p in qlnhEntity.NHANVIENs
                     select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Manv");
            dt.Columns.Add("Ten");
            dt.Columns.Add("SDT");
            dt.Columns.Add("ChucVu");
            foreach (var p in nv)
            {
                dt.Rows.Add(p.Manv,p.Ten,p.SDT,p.ChucVu, p.Luo);
            }
            return dt;
        }
        public List <NHANVIEN> TimKiemNhanVien(string str)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var NhanVienList = from nv in qlnhEntity.NHANVIENs
                               where nv.Ten.Contains(str)
                               select nv;
            return NhanVienList.ToList();
        }
        public bool ThemNhanVien(string Manv, string Ten, string SDT, string ChucVu, ref string err)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            NHANVIEN nv = new NHANVIEN();
            nv.Manv = Manv;
            nv.Ten = Ten;
            nv.SDT = SDT;
            nv.ChucVu = ChucVu;
            qlnhEntity.NHANVIENs.Add(nv);
            qlnhEntity.SaveChanges();
            return true;
        }
        public bool XoaNhanVien(string Manv, ref string err)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            NHANVIEN nv = new NHANVIEN();
            nv.Manv = Manv;
            qlnhEntity.NHANVIENs.Attach(nv);
            qlnhEntity.NHANVIENs.Remove(nv);
            qlnhEntity.SaveChanges();
            return true;
        }
        public bool CapnhatNhanVien(string Manv, string Ten, string SDT, string ChucVu, ref string err)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var nvQuerry = (from nv in qlnhEntity.NHANVIENs
                            where nv.Manv == Manv
                            select nv).SingleOrDefault();
            if (nvQuerry != null)
            {
                nvQuerry.Ten = Ten;
                nvQuerry.SDT = SDT;
                nvQuerry.ChucVu = ChucVu;
                qlnhEntity.SaveChanges();
            }
            return true;
        }
    }
}
