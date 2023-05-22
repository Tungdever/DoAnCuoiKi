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
        public DataTable LayDanhMuc()
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var dms =
            from p in qlnhEntity.DANHMUCs
            select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("MaDM");
            dt.Columns.Add("TenDM");
            foreach (var p in dms)
            {
                dt.Rows.Add(p.MaDM, p.TenDM);
            }
            return dt;
        }
        public List<DANHMUC> TimKiemDanhMuc(string str)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var danhMucList = from dm in qlnhEntity.DANHMUCs
                              where dm.TenDM.Contains(str)
                              select dm;

            return danhMucList.ToList();
        }
        public bool ThemDanhMuc(string MaDM, string TenDM, ref string err)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            DANHMUC dm = new DANHMUC();
            dm.MaDM= MaDM;
            dm.TenDM= TenDM;
            qlnhEntity.DANHMUCs.Add(dm);
            qlnhEntity.SaveChanges();
            return true;

        }
        public bool XoaDanhMuc(string MaDM, ref string err)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            DANHMUC dm = new DANHMUC();
            dm.MaDM = MaDM;
            qlnhEntity.DANHMUCs.Attach(dm);
            qlnhEntity.DANHMUCs.Remove(dm);
            qlnhEntity.SaveChanges();
            return true;
        }
        public bool CapNhatDanhMuc(string MaDM, string TenDM, ref string err)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var dmQuery = (from dm in qlnhEntity.DANHMUCs
                           where dm.MaDM == MaDM
                           select dm).SingleOrDefault();
            if (dmQuery != null)
            {
                dmQuery.TenDM = TenDM;
                qlnhEntity.SaveChanges();
            }
            return true;
        }
        public List<string> LayDanhSachMaDanhMuc()
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var danhMucList = qlnhEntity.DANHMUCs.Select(dm => dm.MaDM).ToList();
            return danhMucList;
        }
        public string LayTenDanhMuc(string MaDM)
        {
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();
            var danhMuc = (from dm in qlnhEntity.DANHMUCs
                           where dm.MaDM == MaDM
                           select dm.TenDM).FirstOrDefault();
            return danhMuc;
        }
    }
}
