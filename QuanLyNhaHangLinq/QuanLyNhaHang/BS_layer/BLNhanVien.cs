using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Data.Linq;
using System.Data;
using System.Net.NetworkInformation;

namespace QuanLyNhaHang.BS_layer
{
    class BLNhanVien
    {
        public System.Data.Linq.Table <NHANVIEN> LayNhanVien()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            return qlNH.NHANVIENs;
        }

        public DataTable Staff()
        {

            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var NVL = from nv in qlNH.NHANVIENs
                      select nv;
            DataTable dt = new DataTable();
            dt.Columns.Add("Manv");
            dt.Columns.Add("Ten");
            dt.Columns.Add("SDT");
            dt.Columns.Add("ChucVu");
            dt.Columns.Add("Luong");
            foreach (var nv in NVL )
            {
                dt.Rows.Add(nv.Manv, nv.Ten, nv.SDT, nv.ChucVu, nv.Luong);
            }   
            return dt;
        }
        public List<NHANVIEN> TimKiemNhanVien(string str)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var NhanVienList = from nv in qlNH.NHANVIENs
                               where nv.Ten.Contains(str)
                               select nv;
            return NhanVienList.ToList();
        }
        public DataTable LayDSNV()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var employees = from nv in qlNH.NHANVIENs
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

        public List<NHANVIEN> LayGiaoHang()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var nhanViens = from nv in qlNH.NHANVIENs
                            where nv.ChucVu == "Giao Hàng"
                            select nv;

            return nhanViens.ToList();
        }
        public List<NHANVIEN> LayPhucVu()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var nhanViens = from nv in qlNH.NHANVIENs
                            where nv.ChucVu == "Phục Vụ"
                            select nv;

            return nhanViens.ToList();
        }

        public bool ThemNhanVien(string Manv, string Ten, string SDT, string ChucVu , float Luong, ref string err)
        {
            bool f = false;
            try
            {
                QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
                NHANVIEN nv = new NHANVIEN();
                nv.Manv = Manv;
                nv.Ten = Ten;
                nv.SDT = SDT;
                nv.ChucVu = ChucVu;
                nv.Luong = Luong;
                qlNH.NHANVIENs.InsertOnSubmit(nv);
                qlNH.NHANVIENs.Context.SubmitChanges();
                f = true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return f;
        }
        public bool XoaNHanVien(string Manv, ref string err)
        {
            bool f = false;
            try
            {
                QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
                var nvQuerry = from nv in qlNH.NHANVIENs
                               where nv.Manv == Manv
                               select nv;
                qlNH.NHANVIENs.DeleteAllOnSubmit(nvQuerry);
                qlNH.SubmitChanges();
                f = true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return f;
        }
        public bool CapNhatNhanVien(string Manv, string Ten, string SDT, string ChucVu, float Luong, ref string err)
        {
            bool f = false;
            try
            {
                QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
                var nvQuerry = (from nv in qlNH.NHANVIENs
                                where nv.Manv == Manv
                                select nv).SingleOrDefault();
                if (nvQuerry != null)
                {
                    nvQuerry.Ten = Ten;
                    nvQuerry.SDT = SDT;
                    nvQuerry.ChucVu = ChucVu;
                    nvQuerry.Luong = Luong;
                    qlNH.SubmitChanges();
                }
                f = true;
            }
            catch ( Exception ex ) 
            { 
                err = ex.Message;
            }
            return f;
        }
        public string MaNV_TenNV(string MaNV)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var employee = (from nv in qlNH.NHANVIENs
                            where nv.Manv == MaNV
                            select nv.Manv + " - " + nv.Ten).FirstOrDefault();

            return employee;
        }
    }
}
