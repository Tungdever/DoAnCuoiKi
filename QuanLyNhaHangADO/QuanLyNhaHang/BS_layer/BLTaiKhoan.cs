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
        DAL db = null;
        public BLTaiKhoan()
        {
            db = new DAL();
        }
        public DataSet LayTaiKhoan()
        {
            return db.ExecuteQueryDataSet("select * from TaiKhoan", CommandType.Text);
        }
        public bool ThemTaiKhoan(string TenTaiKhoan, string MatKhau, ref string err)
        {
            string sqlString = "Insert Into TaiKhoan Values(" + "'" +
            TenTaiKhoan + "',N'" +
            MatKhau + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool XoaTaiKhoan(ref string err, string TenTaiKhoan)
        {
            string sqlString = "Delete From TaiKhoan Where TenTaiKhoan='" + TenTaiKhoan + "'";
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

        //public bool CapNhatTaiKhoan(string TenTaiKhoan, string MatKhau, string MaNV, int CapDoQuyen, ref string err)
        //{
        //    string sqlString = "Update ThanhPho Set TenThanhPho=N'" +
        //    TenThanhPho + "' Where ThanhPho='" + MaThanhPho + "'";
        //    return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        //}
    }
}
