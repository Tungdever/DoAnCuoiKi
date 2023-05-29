using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.BS_layer
{
    class BLTblDetail
    {
        DAL db = null;

        public BLTblDetail() { 
            db = new DAL();
        }
        public bool AddTblDetail(int MainID, string ProID,string ProName, int qty, float price, float amount, ref string err)
        {
            //Không truyền 

            /* string sqlString = "Insert Into tblDetails (MaBill, ProID, ProName, qty, price, amount) Values  (" + MainID + ", '" +
                 ProID + "',N'" + ProName + "', " + qty + ", " + price + ", " + amount + "); " + "SELECT SCOPE_IDENTITY()";*/
            string sqlString = "Insert Into tblDetails (MaBill, proID, proName, qty, price, amount) Values  (" + MainID + ", '" +
                 ProID + "',N'" + ProName + "', " + qty + ", " + price + ", " + amount + ")"; 

            /* qry2 = @"Insert into tblDetails Values (@MainID,@proID, @qty @price,@amount)";
                */
             return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
      //      return db.MyExecuteScalar(sqlString, CommandType.Text);
        }

        public bool UpdateTblDetail(int DetailID, int MainID, string ProID,string ProName ,int qty, float price, float amount, ref string err)
        {

            /*qry2 = @"Update tblDetails Set proID = @proID, qty = @qty,price = @price, amount =@amount where DetailID = @ID ";*/

            string sqlString = "UPDATE tblDetails SET ProID = '"+ProID +"', ProName = '"+ ProName + "', qty = " + qty+ ", price = "+ price + ", amount = " + amount + " WHERE DetailID = " + DetailID + "";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);

        }

        //Cần kết nội với Table SANPHAM để lấy ra Ten Danh Muc để truyền vào dgvPOS
        public DataSet GetJoin(int MaBill)
        {
            return db.ExecuteQueryDataSet("Select * from tblMain m  inner join tblDetails d on m.MaBill = d.MaBill inner join SANPHAM p  on p.MaSP = d.proID WHERE m.MaBill = " + MaBill, CommandType.Text);

        }
    }
}
