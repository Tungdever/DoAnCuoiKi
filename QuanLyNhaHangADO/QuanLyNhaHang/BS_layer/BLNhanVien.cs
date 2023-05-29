﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;

namespace QuanLyNhaHang.BS_layer
{
    class BLNhanVien
    {
        DAL db = null;
        public BLNhanVien()
        {
            db = new DAL();
        }

        public DataSet LayNhanVien()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM NHANVIEN", CommandType.Text);
        }
        public DataSet LayPhucVu()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM NHANVIEN WHERE ChucVu = 'Phuc vu'", CommandType.Text);
        }

        public DataSet LayGiaoHang()
        {
            return db.ExecuteQueryDataSet("SELECT Manv , Ten FROM NHANVIEN WHERE ChucVu = 'Giao Hang'", CommandType.Text);
        }
        public DataSet TimKiemNhanVien(string str)
        {
            return db.ExecuteQueryDataSet("SELECT * FROM NHANVIEN WHERE Ten LIKE '%" + str + "%'", CommandType.Text);
        }

        public bool ThemNhanVien(string Manv, string Ten, string SDT, string ChucVu, ref string err)
        {
            string sqlString = "INSERT INTO NHANVIEN VALUES('" + Manv + "', N'" + Ten + "', '" + SDT + "', N'" + ChucVu + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool XoaNhanVien(string Manv, ref string err)
        {
            string sqlString = "DELETE FROM NHANVIEN WHERE Manv = '" + Manv + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatNhanVien(string Manv, string Ten, string SDT, string ChucVu, ref string err)
        {
            string sqlString = "UPDATE NHANVIEN SET Ten = N'" + Ten + "', SDT = '" + SDT + "', ChucVu = N'" + ChucVu + "' WHERE Manv = '" + Manv + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
