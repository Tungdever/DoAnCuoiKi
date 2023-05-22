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
        public System.Data.Linq.Table<DANHMUC> LayDanhMuc()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            return qlNH.DANHMUCs;
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
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            DANHMUC dm = new DANHMUC();
            dm.MaDM = MaDM;
            dm.TenDM = TenDM;
            qlNH.DANHMUCs.InsertOnSubmit(dm);
            qlNH.DANHMUCs.Context.SubmitChanges();
            return true;

        }
        public bool XoaDanhMuc(string MaDM, ref string err)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var dmQuery = from dm in qlNH.DANHMUCs
                          where dm.MaDM == MaDM
                          select dm;
            qlNH.DANHMUCs.DeleteAllOnSubmit(dmQuery);
            qlNH.SubmitChanges();
            return true;
        }
        public bool CapNhatDanhMuc(string MaDM, string TenDM, ref string err)
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
            return true;
        }
        public List<string> LayDanhSachMaDanhMuc()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var danhMucList = qlNH.DANHMUCs.Select(dm => dm.MaDM).ToList();
            return danhMucList;
        }
        public string LayTenDanhMuc(string MaDM)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var danhMuc = (from dm in qlNH.DANHMUCs
                           where dm.MaDM == MaDM
                           select dm.TenDM).FirstOrDefault();
            return danhMuc;
        }
    }
}
