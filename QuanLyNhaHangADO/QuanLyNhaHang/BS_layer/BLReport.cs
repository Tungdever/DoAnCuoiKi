using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

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

            //  string qry = "Select * from tblMain m inner join tblDetails d on m.MaBill = d.MaBill  inner join SANPHAM  p on p.MaSP= d.proID  inner join DANHMUC c on c.MaDM = p.MaLoaiSP where m.aDate between '" + bDate.ToString() + "' and '" + eDate.ToString() + "' ";
            /* string qry = "SELECT m.aDate, m.aTime, m.TableName, m.WaiterName, m.status, m.orderType, m.total, m.received, m.change, m.driverID, m.cusName, m.cusPhone, d.MaBill, d.proID, d.qty, d.price, d.amount , p.TenSP, c.TenDM " +
              "FROM tblMain m " +
              "INNER JOIN tblDetails d ON m.MaBill = d.MaBill " +
              "INNER JOIN SANPHAM p ON p.MaSP = d.proID " +
              "INNER JOIN DANHMUC c ON c.MaDM = p.MaLoaiSP " +
              "WHERE m.aDate BETWEEN '" + bDate.ToString("yyyy-MM-dd") + "' AND '" + eDate.ToString("yyyy-MM-dd") + "' "
             ;
             return db.ExecuteQueryDataSet(qry, CommandType.Text);*/
            /*string qry = "SELECT * FROM tblMain m " +
                "INNER JOIN tblDetails d ON m.MaBill = d.MaBill " +
                "INNER JOIN SANPHAM p ON p.MaSP = d.proID " +
                "INNER JOIN DANHMUC c ON c.MaDM = p.MaLoaiSP " +
                "WHERE m.aDate BETWEEN @BeginDate AND @EndDate";
            SqlCommand command = new SqlCommand(qry);
            command.Parameters.AddWithValue("@BeginDate", bDate);
            command.Parameters.AddWithValue("@EndDate", eDate);
            db.comm = command;*/
            string qry = "SELECT m.*, d.*, p.TenSP , c.TenDM " +
             "FROM tblMain m " +
             "INNER JOIN tblDetails d ON m.MaBill = d.MaBill " +
             "INNER JOIN SANPHAM p ON p.MaSP = d.proID " +
             "INNER JOIN DANHMUC c ON c.MaDM = p.MaLoaiSP " +
             "WHERE m.aDate BETWEEN '" + bDate.ToString("yyyy-MM-dd") + "' AND '" + eDate.ToString("yyyy-MM-dd") + "' ";

            
            return db.ExecuteQueryDataSet(qry, CommandType.Text);
        }

    }
}
