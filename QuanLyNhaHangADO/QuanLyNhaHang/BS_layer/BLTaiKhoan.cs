using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.BS_layer
{
    class BLTaiKhoan
    {
        DAL db = null;
        BLNhanVien dbNV = new BLNhanVien();
        public BLTaiKhoan()
        {
            db = new DAL();
        }
        public DataTable LayTaiKhoan()
        {
            DataSet TK = db.ExecuteQueryDataSet("select * from TaiKhoan", CommandType.Text);
            DataTable dt = new DataTable();
            dt.Columns.Add("TenTaiKhoan");
            dt.Columns.Add("MatKhau");
            dt.Columns.Add("MaNV");
            dt.Columns.Add("CapDoQuyen");
            foreach (DataRow row in TK.Tables[0].Rows)
            {
                string tenTaiKhoan = row["TenTaiKhoan"].ToString();
                string matKhau = row["MatKhau"].ToString();
                string maNV = row["MaNV"].ToString();
                string capDoQuyen = row["CapDoQuyen"].ToString();
                string tenNV = dbNV.MaNV_TenNV(maNV); // Gọi phương thức chuyển đổi từ MaNV sang Tên NV
                dt.Rows.Add(tenTaiKhoan, matKhau, tenNV, capDoQuyen);
            }
            return dt;
        }
        public bool ThemTaiKhoan(string TenTaiKhoan, string MatKhau, string MaNV, int CapDoQuyen, ref string err)
        {
            string sqlString = "INSERT INTO TaiKhoan (TenTaiKhoan, MatKhau, MaNV, CapDoQuyen) VALUES (" +
                                "'" + TenTaiKhoan + "', " +
                                "N'" + MatKhau + "', " +
                                "'" + MaNV + "', " +
                                CapDoQuyen + ")";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool XoaTaiKhoan(string TenTaiKhoan, ref string err)
        {
            string sqlString = "Delete From TaiKhoan Where TenTaiKhoan='" + TenTaiKhoan + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaTaiKhoanTheoNV(string Manv, ref string err)
        {
            string sqlString = "DELETE FROM TaiKhoan WHERE Manv = '" + Manv + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool DangNhap(string TenTaiKhoan, string MatKhau)
        {
            string sqlString = "select * from TaiKhoan where TenTaiKhoan = '" + TenTaiKhoan + "' and MatKhau = '" + MatKhau + "' ";
            DataTable dtTaiKhoan = new DataTable();
            DataSet ds = db.ExecuteQueryDataSet(sqlString, CommandType.Text);
            dtTaiKhoan = ds.Tables[0];
            if (dtTaiKhoan.Rows.Count > 0) return true;
            else return false;
        }
        public DataTable TimKiemTaiKhoan(string str)
        {
            DataSet TK = db.ExecuteQueryDataSet("SELECT * FROM TAIKHOAN WHERE TenTaiKhoan LIKE '%" + str + "%'", CommandType.Text);
            DataTable dt = new DataTable();
            dt.Columns.Add("TenTaiKhoan");
            dt.Columns.Add("MatKhau");
            dt.Columns.Add("MaNV");
            dt.Columns.Add("CapDoQuyen");
            foreach (DataRow row in TK.Tables[0].Rows)
            {
                string tenTaiKhoan = row["TenTaiKhoan"].ToString();
                string matKhau = row["MatKhau"].ToString();
                string maNV = row["MaNV"].ToString();
                string capDoQuyen = row["CapDoQuyen"].ToString();
                string tenNV = dbNV.MaNV_TenNV(maNV); // Gọi phương thức chuyển đổi từ MaNV sang Tên NV
                dt.Rows.Add(tenTaiKhoan, matKhau, tenNV, capDoQuyen);
            }
            return dt;

        }
        public bool CapNhatTaiKhoan(string TenTaiKhoan, string MatKhau, string MaNV, int CapDoQuyen, ref string err)
        {

            string sqlString = "UPDATE TAIKHOAN SET MatKhau = N'" + MatKhau + "', MaNV = N'"
        + MaNV + "', CapDoQuyen = " + CapDoQuyen + " WHERE TenTaiKhoan = '" + TenTaiKhoan + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool KT(string TenTaiKhoan)
        {
            string sqlString = "select * from TaiKhoan where TenTaiKhoan = '" + TenTaiKhoan + "' and CapDoQuyen = 1";
            DataTable dtTaiKhoan = new DataTable();
            DataSet ds = db.ExecuteQueryDataSet(sqlString, CommandType.Text);
            dtTaiKhoan = ds.Tables[0];
            if (dtTaiKhoan.Rows.Count > 0) return true;
            else return false;
        }
        public string LayQuyen(string str)
        {
            DataSet TK = db.ExecuteQueryDataSet("SELECT * FROM TAIKHOAN WHERE TenTaiKhoan LIKE '%" + str + "%'", CommandType.Text);
            string CapDoQuyen = "";
            foreach (DataRow row in TK.Tables[0].Rows)
            {
                CapDoQuyen = row["CapDoQuyen"].ToString();

            }
            if (CapDoQuyen == "1") CapDoQuyen = "ADMIN";
            else CapDoQuyen = "Nhân viên quản lý";
            return CapDoQuyen;
        }
        public string TimKiemTen(string str)
        {
            DataSet TK = db.ExecuteQueryDataSet("SELECT * FROM TAIKHOAN WHERE TenTaiKhoan LIKE '%" + str + "%'", CommandType.Text);
            string tenNV = "";
            foreach (DataRow row in TK.Tables[0].Rows)
            {
                string maNV = row["MaNV"].ToString();
                tenNV = dbNV.MaNV_TenNV(maNV).Split('-')[1].Trim();
            }
            return tenNV;
        }
    }
}
