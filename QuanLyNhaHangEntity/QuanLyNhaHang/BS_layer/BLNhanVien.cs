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
            dt.Columns.Add("Luong");
            foreach (var p in nv)
            {
<<<<<<< HEAD
                dt.Rows.Add(p.Manv,p.Ten,p.SDT,p.ChucVu, p.Luo);
=======
                dt.Rows.Add(p.Manv,p.Ten,p.SDT,p.ChucVu, p.Luong);
>>>>>>> 96c861ca2bb83c0df1e7222f4e382566d27aaff5
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
        public bool ThemNhanVien(string Manv, string Ten, string SDT, string ChucVu, float Luong, ref string err)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            NHANVIEN nv = new NHANVIEN();
            nv.Manv = Manv;
            nv.Ten = Ten;
            nv.SDT = SDT;
            nv.ChucVu = ChucVu;
            nv.Luong = Luong;
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
        public bool CapnhatNhanVien(string Manv, string Ten, string SDT, string ChucVu, float Luong, ref string err)
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
                nvQuerry.Luong = Luong;
                qlnhEntity.SaveChanges();
            }
            return true;
        }
        public List<string> LayDSTenNhanVien()
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var NV = from nv in qlnhEntity.NHANVIENs
                     select nv.Manv + "-" + nv.Ten;
            return NV.ToList();
        }
        public DataTable LayDSNV()
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var employees = from nv in qlnhEntity.NHANVIENs
                            select new
                            {
                                ID = nv.Manv,
                                Display = nv.Manv + "-" + nv.Ten
                            };
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Display");

            foreach (var employee in employees)
            {
                dataTable.Rows.Add(employee.ID, employee.Display);
            }
            return dataTable;
        }
        public string MaNV_TenNV(string MaNV)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var employee = (from nv in qlnhEntity.NHANVIENs
                            where nv.Manv == MaNV
                            select nv.Manv + " - " + nv.Ten).FirstOrDefault();

            return employee; 
        }
    }
}
