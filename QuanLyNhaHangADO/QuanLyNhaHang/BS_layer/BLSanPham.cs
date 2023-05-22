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
    class BLSanPham
    {
        DAL db = null;
        public BLSanPham()
        {
            db = new DAL();
        }
        public DataSet LaySanPham()
        {
            return db.ExecuteQueryDataSet("select MaSP, TenSP, MaLoaiSP, TenLoaiSP, GiaSP from SanPham", CommandType.Text);
        }
        public DataSet TimKiemSanPham(string str)
        {
            return db.ExecuteQueryDataSet("select MaSP, TenSP, MaLoaiSP, TenLoaiSP, GiaSP from SanPham where TenSP like '%" + str + "%' ", CommandType.Text);
        }
        public bool ThemSanPham(string MaSP, string TenSP,string MaLoaiSP, string TenLoaiSP, float GiaSP, Image AnhSP, ref string err)
        {
            MemoryStream ms = new MemoryStream();
            Image tmp = AnhSP;
            tmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageByteArray = ms.ToArray();
            string imageHex = BitConverter.ToString(imageByteArray).Replace("-", string.Empty);

            string sqlString = "Insert Into SanPham (MaSP, TenSP, MaLoaiSP, TenLoaiSP, GiaSP, AnhSP) Values ('" +
    MaSP + "', N'" + TenSP + "', N'" + MaLoaiSP + "', N'" + TenLoaiSP + "', " + GiaSP + ", 0x" + imageHex + ")";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool XoaSanPham(string MaSP, ref string err)
        {
            string sqlString = "Delete From SanPham Where MaSP='" + MaSP + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatSanPham(string MaSP, string TenSP, string MaLoaiSP, string TenLoaiSP, float GiaSP, Image AnhSP, ref string err)
        {
            MemoryStream ms = new MemoryStream();
            Image tmp = AnhSP;
            tmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageByteArray = ms.ToArray();
            string imageHex = BitConverter.ToString(imageByteArray).Replace("-", string.Empty);
            string sqlString = "UPDATE SanPham SET TenSP = N'" + TenSP + "', MaLoaiSP = N'" + MaLoaiSP + "', TenLoaiSP = N'"
        + TenLoaiSP + "', GiaSP = " + GiaSP + ", AnhSP = 0x" + imageHex + " WHERE MaSP = '" + MaSP + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public DataSet LayHinh(string MaSP, ref string err)
        {
            return db.ExecuteQueryDataSet("select AnhSP from SanPham WHERE MaSP = '" + MaSP + "'", CommandType.Text);
        }
    }
}
