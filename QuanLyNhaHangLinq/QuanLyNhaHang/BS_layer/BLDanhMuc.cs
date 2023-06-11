using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.BS_layer
{
    class BLDanhMuc
    {
        public System.Data.Linq.Table<DANHMUC> LayDanhMuc()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
             return qlNH.DANHMUCs;
        
            //return qlNH.GetTable<DANHMUC>();
        }
        public List<string> LayTenDanhMuc()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            //chọn trường "TenDM" bằng cách sử dụng biểu thức lambda dm => dm.TenDM
            var tenDanhMucList = qlNH.DANHMUCs.Select(dm => dm.TenDM).ToList();
            return tenDanhMucList;
        }
        public List<DANHMUC> TimKiemDanhMuc(string str)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var danhMucList = from dm in qlNH.DANHMUCs
                              where dm.TenDM.Contains(str)
                              select dm;

            return danhMucList.ToList();
        }
        public bool ThemDanhMuc(string MaDM, string TenDM, ref string err)
        {
            bool f = false;
            try
            {
                QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
                DANHMUC dm = new DANHMUC();
                dm.MaDM = MaDM;
                dm.TenDM = TenDM;
                qlNH.DANHMUCs.InsertOnSubmit(dm);
                qlNH.DANHMUCs.Context.SubmitChanges();
                f = true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return f;

        }
        public bool XoaDanhMuc(string MaDM, ref string err)
        {
            bool f = false;
            try
            {
                QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
                var dmQuery = from dm in qlNH.DANHMUCs
                              where dm.MaDM == MaDM
                              select dm;
                qlNH.DANHMUCs.DeleteAllOnSubmit(dmQuery);
                qlNH.SubmitChanges();
                f = true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return f;
        }
        public bool CapNhatDanhMuc(string MaDM, string TenDM, ref string err)
        {
            bool f = false;
            try
            {
                QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
                var dmQuery = (from dm in qlNH.DANHMUCs
                               where dm.MaDM == MaDM
                               select dm).SingleOrDefault();
                if (dmQuery != null)
                {
                    dmQuery.TenDM = TenDM;
                    qlNH.SubmitChanges();
                }
                f = true;
            }
            catch (Exception ex) 
            { 
                err = ex.Message; 
            }
            return f;
        }
        public DataTable LayDanhSachDanhMuc()
        {

            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var employees = from dm in qlNH.DANHMUCs
                            select new
                            {
                                ID = new { MaDM = dm.MaDM, TenDM = dm.TenDM },
                                Display = dm.MaDM + "-" + dm.TenDM
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
    }
}
