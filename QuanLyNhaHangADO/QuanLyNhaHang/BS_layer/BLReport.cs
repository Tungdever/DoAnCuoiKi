using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.BS_layer
{
     class BLReport
    {
        DAL db = null;
        public BLReport() {
            db = new DAL();
        }

        public DataSet GetSaleByCatBetweenDate(DateTime bDate, DateTime eDate)
        {

            string qry = "Select * from tblMain m inner join tblDetails d on m.MaBill = d.MaBill  inner join SANPHAM  p on p.MaSP= d.proID  inner join DANHMUC c on c.MaDM = p.MaLoaiSP where m.aDate between '" + bDate.ToString() + "' and '" + eDate.ToString() + "' ";
            
           
               
            return db.ExecuteQueryDataSet(qry, CommandType.Text);
        }

    }
}
