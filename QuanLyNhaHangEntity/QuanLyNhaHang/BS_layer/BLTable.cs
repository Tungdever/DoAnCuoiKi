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
        public DataTable LayTable()
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var t = from p in qlnhEntity.BANs
                    select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Tid");
            dt.Columns.Add("Tname");
            dt.Columns.Add("Tstate");
            foreach (var p in t) 
            {
                dt.Rows.Add(p.Tid, p.Tname, p.Tstate);
            }
            return dt;
        }
        public List <BAN> TimKiemTable(string str)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var TableList = from t in qlnhEntity.BANs
                            where t.Tname.Contains(str)
                            select t;
            return TableList.ToList();
        }
        public bool ThemTable(string Tid, string Tname, string Tstate,ref string err) 
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            BAN t =  new BAN();
            t.Tid = Tid;
            t.Tname = Tname;
            t.Tstate = Tstate;
            try
            {
                qlnhEntity.BANs.Add(t);
                qlnhEntity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }
        public bool XoaTable(string Tid, ref string err) 
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            BAN t = new BAN();
            t.Tid = Tid;
            try
            {
                qlnhEntity.BANs.Attach(t);
                qlnhEntity.BANs.Remove(t);
                qlnhEntity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }
        public bool CapnhatTable(string Tid,string Tname, string Tstate, ref string err)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var tQuerry = (from t in qlnhEntity.BANs
                           where t.Tid == Tid
                           select t).SingleOrDefault();
            try
            {
                if (tQuerry != null)
                {
                    tQuerry.Tname = Tname;
                    tQuerry.Tstate = Tstate;
                    qlnhEntity.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }
    }
}
