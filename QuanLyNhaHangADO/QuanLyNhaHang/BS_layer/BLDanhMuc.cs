using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.BS_layer
{
    class BLDanhMuc
    {
        DAL db = null;
        public BLDanhMuc()
        {
            db = new DAL();
        }
        public DataSet LayDanhMuc()
        {
            return db.ExecuteQueryDataSet("select * from DanhMuc", CommandType.Text);
        }
        public List<string> LayDanhSachMaDanhMuc()
        {

            List<string> danhSachMaDM = new List<string>();

            DataSet ds = db.ExecuteQueryDataSet("SELECT MaDM FROM DanhMuc", CommandType.Text);
            DataTable dtDM = ds.Tables[0];

            foreach (DataRow row in dtDM.Rows)
            {
                string maDM = row["MaDM"].ToString();
                danhSachMaDM.Add(maDM);
            }

            return danhSachMaDM;

        }
        public string LayTenDanhMuc(string MaDM)
        {
            DataSet ds = db.ExecuteQueryDataSet("select TenDM from DanhMuc where MaDM='" + MaDM + "'", CommandType.Text);
            DataTable dtDM = ds.Tables[0];
            if (dtDM.Rows.Count > 0)
            {
                DataRow row = dtDM.Rows[0];
                string tenDanhMuc = row["TenDM"].ToString();
                return tenDanhMuc;
            }
            return string.Empty;
        }
        public DataSet TimKiemDanhMuc(string str)
        {
            return db.ExecuteQueryDataSet("select * from DanhMuc where TenDM like '%" + str + "%' ", CommandType.Text);
        }
        public bool ThemDanhMuc(string MaDM, string TenDM, ref string err)
        {
            string sqlString = "Insert Into DanhMuc Values(" + "'" +
            MaDM + "',N'" +
            TenDM + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool XoaDanhMuc(string MaDM, ref string err)
        {
            string sqlString = "Delete From DanhMuc Where MaDM='" + MaDM + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatDanhMuc(string MaDM, string TenDM, ref string err)
        {
            string sqlString = "Update DanhMuc Set TenDM=N'" +
            TenDM + "' Where MaDM='" + MaDM + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
