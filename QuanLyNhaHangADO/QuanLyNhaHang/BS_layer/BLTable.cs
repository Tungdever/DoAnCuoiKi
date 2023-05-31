using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.BS_layer
{
    class BLTable
    {
        DAL db = null;
        public BLTable()
        {
           db = new DAL();
        }
        public DataSet LayTable()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM BAN", CommandType.Text);
        }
        public DataSet TimKiemTable(string str)
        {
            return db.ExecuteQueryDataSet("SELECT * FROM BAN WHERE Tname LIKE '%" + str + "%'", CommandType.Text);
        }
        public bool ThemTable(string Tid, string Tname, string Tstate, ref string err)
        {
            string sqlString = "INSERT INTO BAN VALUES('" + Tid + "', N'" + Tname + "', N'" + Tstate +"')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaTable(string Tid, ref string err)
        {
            string sqlString = "DELETE FROM BAN WHERE Tid = '" + Tid + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatTable(string Tid, string Tname, string Tstate, ref string err)
        {
            string sqlString = "UPDATE BAN SET Tname = N'" + Tname + "', Tstate = N'" + Tstate + "' WHERE Tid = '" + Tid + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool UpdateStateTable(string Tid, string Tname, string Tstate, ref string err)
        {
            string sqlString = "UPDATE BAN SET Tname = N'" + Tname + "', Tstate = N'" + Tstate + "' WHERE Tid = '" + Tid + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

    }
}
