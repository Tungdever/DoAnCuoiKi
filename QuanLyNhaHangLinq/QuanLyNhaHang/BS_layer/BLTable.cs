using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.BS_layer
{
    class BLTable
    {
        public System.Data.Linq.Table <BAN> LayTable()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            return qlNH.BANs;
        }
        public List<BAN> TimKiemTable(string str) 
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var TableList = from t in qlNH.BANs
                            where t.Tid.Contains(str)
                            select t;
            return TableList.ToList();
        }
        public bool ThemTable(string Tid, string Tname, string Tstate, ref string err)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            BAN t = new BAN();
            t.Tid = Tid;
            t.Tname = Tname;
            t.Tstate = Tstate;
            qlNH.BANs.InsertOnSubmit(t);
            qlNH.BANs.Context.SubmitChanges();
            return true;
        }
        public bool XoaTable(string Tid, ref string err)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var tQuerry = from t in qlNH.BANs
                          where t.Tid == Tid
                          select t;
            qlNH.BANs.DeleteAllOnSubmit(tQuerry);
            qlNH.SubmitChanges();
            return true;
        }
        public bool CapNhatTable(string Tid, string Tname, string Tstate, ref string err)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var tQuerry = (from t in qlNH.BANs
                           where t.Tid == Tid
                           select t).SingleOrDefault();
            if(tQuerry != null) 
            {
                tQuerry.Tname = Tname;
                tQuerry.Tstate = Tstate;
                qlNH.SubmitChanges();
            }
            return true;
        }
    }
}
