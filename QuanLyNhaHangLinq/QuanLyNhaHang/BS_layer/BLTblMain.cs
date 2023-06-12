using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Markup;

namespace QuanLyNhaHang.BS_layer
{
    class BLTblMain
    {
        public List<tblMain> GetOrders()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var query = from order in qlNH.tblMains
                        where order.status == "Pending"
                        select order;

            return query.ToList();
        }
        public DataTable GetBills()
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();

            var result = from m in qlNH.tblMains
                         where m.status != "Pending"
                         select new
                         {
                             m.MaBill,
                             m.TableName,
                             m.WaiterName,
                             m.aTime,
                             m.orderType,
                             m.status,
                             m.total
                         };

            DataTable dt = new DataTable();
            dt.Columns.Add("MaBill");
            dt.Columns.Add("TableName");
            dt.Columns.Add("WaiterName");
            dt.Columns.Add("aTime");
            dt.Columns.Add("orderType");
            dt.Columns.Add("status");
            dt.Columns.Add("total");

            foreach (var item in result)
            {
                DataRow row = dt.NewRow();
                row["MaBill"] = item.MaBill;
                row["TableName"] = item.TableName;
                row["WaiterName"] = item.WaiterName;
                row["aTime"] = item.aTime;
                row["orderType"] = item.orderType;
                row["status"] = item.status;
                row["total"] = item.total;

                dt.Rows.Add(row);
            }

            return dt;
        }
        public int AddTblMain(DateTime date, string time, string TableName, string WaiterName, string Status, string orderType, double Total, double received, double change, string driverID, string cusName, string cusPhone, ref string err)
        {
            try
            {
                QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();

                tblMain newOrder = new tblMain()
                {
                    aDate = date,
                    aTime = time,
                    TableName = TableName,
                    WaiterName = WaiterName,
                    status = Status,
                    orderType = orderType,
                    total = Total,
                    received = received,
                    change = change,
                    driverID = driverID,
                    cusName = cusName,
                    cusPhone = cusPhone
                };

                qlNH.tblMains.InsertOnSubmit(newOrder);
                qlNH.SubmitChanges();

                return newOrder.MaBill; // Trả về Id của bản ghi mới thêm vào

            }
            catch (Exception ex)
            {
                err = ex.Message;
                return -1; // Trả về -1 nếu có lỗi xảy ra
            }
        }
        public bool UpdateTblMain(int MainID, DateTime date, string time, string TableName, string WaiterName, string Status, string orderType, double Total, double received, double change, ref string err)
        {
            try
            {
                QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();

               // tblMain existingOrder = qlNH.tblMains.FirstOrDefault(o => o.MaBill == MainID);
                var existingOrder = (from o in qlNH.tblMains
                                     where o.MaBill == MainID
                                     select o).SingleOrDefault();

                if (existingOrder != null)
                {
                    existingOrder.aDate = date;
                    existingOrder.aTime = time;
                    existingOrder.TableName = TableName;
                    existingOrder.WaiterName = WaiterName;
                    existingOrder.status = Status;
                    existingOrder.orderType = orderType;
                    existingOrder.total = Total;
                    existingOrder.received = received;
                    existingOrder.change = change;

                    qlNH.SubmitChanges();

                    return true; // Trả về true nếu cập nhật thành công
                }
                else
                {
                    err = "Order not found";
                    return false; // Trả về false nếu không tìm thấy bản ghi
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false; // Trả về false nếu có lỗi xảy ra
            }
        }
        public bool UpdateStatus(int MaBill, ref string err)
        {
            try
            {
                QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();

                var order = (from o in qlNH.tblMains
                             where o.MaBill == MaBill
                             select o).SingleOrDefault();

                if (order != null)
                {
                    order.status = "Complete";
                    qlNH.SubmitChanges();

                    return true; // Trả về true nếu cập nhật thành công
                }
                else
                {
                    err = "Order not found";
                    return false; // Trả về false nếu không tìm thấy bản ghi
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false; // Trả về false nếu có lỗi xảy ra
            }
        }
        public bool UpdateCheckOut(int MaBill, double total, double received, double change, string status, ref string err)
        {
            try
            {
                QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();

                var order = (from o in qlNH.tblMains
                             where o.MaBill == MaBill
                             select o).SingleOrDefault();

                if (order != null)
                {
                    order.total = total;
                    order.received = received;
                    order.change = change;
                    order.status = status;

                    qlNH.SubmitChanges();

                    return true; // Trả về true nếu cập nhật thành công
                }
                else
                {
                    err = "Order not found";
                    return false; // Trả về false nếu không tìm thấy bản ghi
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false; // Trả về false nếu có lỗi xảy ra
            }
        }
        public DataTable GetJoin(int MaBill)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();

            var result = from m in qlNH.tblMains
                         join d in qlNH.tblDetails on m.MaBill equals d.MaBill
                         where m.MaBill == MaBill
                          select new { m.MaBill, m.aDate, m.aTime, m.TableName, m.WaiterName, m.status, m.orderType, 
                              m.total,m.received,m.change,m.driverID,m.cusName,m.cusPhone,
                             d.DetailID, d.proID, d.proName, d.qty, d.price, d.amount
                                };
                        // select new { m, d };

            DataTable dt = new DataTable();
            /*foreach (var prop in result.FirstOrDefault().GetType().GetProperties())
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                Console.WriteLine(prop.Name);
            }*/
            var properties = result.FirstOrDefault()?.GetType().GetProperties();
            if (properties != null)
            {
                foreach (var prop in properties)
                {
                    dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    Console.WriteLine(prop.Name);
                }
            }
            foreach (var item in result)
            {
                DataRow row = dt.NewRow();
                foreach (var prop in item.GetType().GetProperties())
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                dt.Rows.Add(row);
            }

            return dt;

        }
        public DataTable GetJoinRP(int MaBill)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();

            var result = from m in qlNH.tblMains
                         join d in qlNH.tblDetails on m.MaBill equals d.MaBill into details
                         where m.MaBill == MaBill
                         select new
                         {
                             Main = m,
                             Details = details
                         };

            DataTable dt = new DataTable();

            // Add columns to DataTable
            dt.Columns.Add("MaBill", typeof(int));
            dt.Columns.Add("aDate", typeof(string));
            dt.Columns.Add("aTime", typeof(string));
            dt.Columns.Add("TableName", typeof(string));
            dt.Columns.Add("WaiterName", typeof(string));
            dt.Columns.Add("status", typeof(string));
            dt.Columns.Add("orderType", typeof(string));
            dt.Columns.Add("total", typeof(float));
            dt.Columns.Add("received", typeof(float));
            dt.Columns.Add("change", typeof(float));
            dt.Columns.Add("driverID", typeof(string));
            dt.Columns.Add("cusName", typeof(string));
            dt.Columns.Add("cusPhone", typeof(string));
            dt.Columns.Add("DetailID", typeof(string));
            dt.Columns.Add("qty", typeof(int));
            dt.Columns.Add("price", typeof(float));
            dt.Columns.Add("amount", typeof(float));
            

            foreach (var item in result)
            {
                var main = item.Main;
                //By including the details as a concatenated string within the main record, you avoid duplicating the main record for each detail record.
                //This should resolve the issue of duplicated rows in the report.
                // The duplication issue in the report occurs because you are using a DataTable to store the joined data from both tblMain and tblDetails tables.
                // Since there can be multiple detail records for each main record, the join operation will create multiple rows for the same main record.
                // need to adjust the way populating the DataTable when using LINQ. Instead of creating a new DataRow for each detail record,  concatenate the details into a single string and include it in the respective main record row
                var details = string.Join(", ", item.Details.Select(d => d.proName + " (" + d.qty + ")"));
                DataRow row = dt.NewRow();
                row["MaBill"] = main.MaBill;
                row["aDate"] = main.aDate.GetValueOrDefault().ToShortDateString(); //GetValueOrDefault() sẽ trả về giá trị ngày mặc định (một giá trị không null) nếu "aDate" là null.
                row["aTime"] = main.aTime;
                row["TableName"] = main.TableName;
                row["WaiterName"] = main.WaiterName;
                row["status"] = main.status;
                row["orderType"] = main.orderType;
                row["total"] = main.total;
                row["received"] = main.received;
                row["change"] = main.change;
                row["driverID"] = main.driverID;
                row["cusName"] = main.cusName;
                row["cusPhone"] = main.cusPhone;
                //    row["DetailID"] = details;
                row["DetailID"] = DBNull.Value ;
                row["qty"] = DBNull.Value; // Set DBNull for subtotal rows
                row["price"] = DBNull.Value; // Set DBNull for subtotal rows
                row["amount"] = DBNull.Value; // Set DBNull for subtotal rows
                dt.Rows.Add(row);

                foreach (var detail in item.Details)
                {
                    DataRow detailRow = dt.NewRow();
                    detailRow["MaBill"] = DBNull.Value; // Set DBNull for detail rows
                    detailRow["aDate"] = DBNull.Value;
                    detailRow["aTime"] = DBNull.Value; // Set DBNull for detail rows
                    detailRow["TableName"] = DBNull.Value; // Set DBNull for detail rows
                    detailRow["WaiterName"] = DBNull.Value; // Set DBNull for detail rows
                    detailRow["status"] = DBNull.Value; // Set DBNull for detail rows
                    detailRow["orderType"] = DBNull.Value; // Set DBNull for detail rows
                    detailRow["total"] = DBNull.Value; // Set DBNull for detail rows
                    detailRow["received"] = DBNull.Value; // Set DBNull for detail rows
                    detailRow["change"] = DBNull.Value; // Set DBNull for detail rows
                    detailRow["driverID"] = DBNull.Value; // Set DBNull for detail rows
                    detailRow["cusName"] = DBNull.Value; // Set DBNull for detail rows
                    detailRow["cusPhone"] = DBNull.Value; // Set DBNull for detail rows
                                                          //  detailRow["DetailID"] = DBNull.Value; // Set DBNull for detail rows
                    detailRow["DetailID"] = detail.DetailID;
                    detailRow["qty"] = detail.qty;
                    detailRow["price"] = detail.price;
                    detailRow["amount"] = detail.amount;
                    dt.Rows.Add(detailRow);
                }
            }

            return dt;
        }

        public DataTable GetSaleByCatBetweenDate(DateTime bDate, DateTime eDate)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();

            var result = (from m in qlNH.tblMains
                          join d in qlNH.tblDetails on m.MaBill equals d.MaBill into details
                          from d in details.Distinct()
                          join p in qlNH.SANPHAMs on d.proID equals p.MaSP
                          where m.aDate >= bDate && m.aDate <= eDate
                          select new
                          {
                              Main = m,
                              Details = details,
                              Product = p
                          }).GroupBy(x => x.Main.MaBill);

            DataTable dt = new DataTable();

            // Add columns to DataTable
            dt.Columns.Add("MaBill", typeof(int));
            dt.Columns.Add("aDate", typeof(string));
            dt.Columns.Add("orderType", typeof(string));
            dt.Columns.Add("DetailID", typeof(string));
            dt.Columns.Add("proName", typeof(string));
            dt.Columns.Add("qty", typeof(int));
            dt.Columns.Add("price", typeof(float));
            dt.Columns.Add("amount", typeof(float));
            dt.Columns.Add("TenLoaiSP", typeof(string));

            foreach (var group in result)
            {
                var main = group.First().Main;
                DataRow row = dt.NewRow();
                row["MaBill"] = main.MaBill;
                row["aDate"] = main.aDate.GetValueOrDefault().ToShortDateString();
                row["orderType"] = main.orderType;
                row["DetailID"] = DBNull.Value;
                row["proName"] = DBNull.Value;
                row["price"] = DBNull.Value;
                row["amount"] = DBNull.Value;
                dt.Rows.Add(row);

                foreach (var item in group)
                {
                    var detail = item.Details.First();
                    var product = item.Product;

                    DataRow detailRow = dt.NewRow();
                    detailRow["MaBill"] = DBNull.Value;
                    detailRow["aDate"] = DBNull.Value;
                    detailRow["orderType"] = DBNull.Value;
                    detailRow["TenLoaiSP"] = product.TenLoaiSP;
                    detailRow["DetailID"] = detail.DetailID;
                    detailRow["proName"] = detail.proName;
                    detailRow["price"] = detail.price;
                    detailRow["amount"] = detail.amount;
                    dt.Rows.Add(detailRow);
                }
            }

            return dt;
        }
        /* public DataTable GetSaleByCatBetweenDate(DateTime bDate, DateTime eDate)
         {
             QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();

             var result = from m in qlNH.tblMains
                          join d in qlNH.tblDetails on m.MaBill equals d.MaBill
                          join p in qlNH.SANPHAMs on d.proID equals p.MaSP
                          where m.aDate >= bDate && m.aDate <= eDate
                          select new
                          {
                              Main = m,
                              Detail = d,
                              Product = p
                          };

             DataTable dt = new DataTable();

             // Add columns to DataTable
             dt.Columns.Add("MaBill", typeof(int));
             dt.Columns.Add("aDate", typeof(string));
             dt.Columns.Add("orderType", typeof(string));
             dt.Columns.Add("DetailID", typeof(string));
             dt.Columns.Add("proName", typeof(string));
             dt.Columns.Add("qty", typeof(int));
             dt.Columns.Add("price", typeof(float));
             dt.Columns.Add("amount", typeof(float));
             dt.Columns.Add("TenLoaiSP", typeof(string));

             foreach (var item in result)
             {
                 var main = item.Main;
                 var detail = item.Detail;
                 var product = item.Product;

                 DataRow row = dt.NewRow();
                 row["MaBill"] = main.MaBill;
                 row["aDate"] = main.aDate.GetValueOrDefault().ToShortDateString();
                 row["orderType"] = main.orderType;
                 row["DetailID"] = DBNull.Value;
                 row["proName"] = detail.proName;
                 row["qty"] = detail.qty;
                 row["price"] = detail.price;
                 row["amount"] = detail.amount;
                 row["TenLoaiSP"] = product.TenLoaiSP;

                 dt.Rows.Add(row);
             }

             return dt;
         }*/


        /*public List<> GetJoin1(int MaBill)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();

            var result = from m in qlNH.tblMains
                         join d in qlNH.tblDetails on m.MaBill equals d.MaBill
                         where m.MaBill == MaBill
                         select new { m, d };



            return result.ToList();
        }*/
        public DataTable GetJoinTABLE(int maBill)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var joinTableData = from m in qlNH.tblMains
                                join d in qlNH.tblDetails on m.MaBill equals d.MaBill
                                join t in qlNH.BANs on m.TableName equals t.Tname
                                where m.MaBill == maBill
                                select new
                                {
                                    m.TableName
                                    , m.MaBill, m.WaiterName, m.orderType,
                                    d.DetailID, d.proName, d.proID, d.qty, d.price, d.amount,
                                    t.Tid, t.Tstate
                                };
            /*
                        DataTable dataTable = new DataTable();

                        // Tạo các cột trong DataTable dựa trên các thuộc tính của các bảng
                        foreach (var item in joinTableData.FirstOrDefault().GetType().GetProperties())
                        {
                            dataTable.Columns.Add(item.Name, item.PropertyType);
                        }

                        // Thêm dữ liệu vào DataTable
                        foreach (var item in joinTableData)
                        {
                            DataRow row = dataTable.NewRow();
                            foreach (var prop in item.GetType().GetProperties())
                            {
                                row[prop.Name] = prop.GetValue(item);
                            }
                            dataTable.Rows.Add(row);
                        }

                        return dataTable;*/
            DataTable dt = new DataTable();
            /*foreach (var prop in result.FirstOrDefault().GetType().GetProperties())
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                Console.WriteLine(prop.Name);
            }*/
            var properties = joinTableData.FirstOrDefault()?.GetType().GetProperties();
            if (properties != null)
            {
                foreach (var prop in properties)
                {
                    dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    Console.WriteLine(prop.Name);
                }
            }
            foreach (var item in joinTableData)
            {
                DataRow row = dt.NewRow();
                foreach (var prop in item.GetType().GetProperties())
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                dt.Rows.Add(row);
            }

            return dt;
        }
        public string doanhthu(string ordertype, string month, string year)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            DateTime startDate;
            DateTime endDate;
            if (month != "2")
            {
                startDate = DateTime.Parse(month + "-01-" + year);
                endDate = DateTime.Parse(month + "-30-" + year);
            }
            else
            {
                startDate = DateTime.Parse(month + "-01-" + year);
                endDate = DateTime.Parse(month + "-28-" + year);
            }
            double totalSum = (from m in qlNH.tblMains
                               where m.orderType == ordertype && m.aDate >= startDate && m.aDate <= endDate
                               select m.total).Sum() ?? 0;
            string dtquery = totalSum.ToString();
            return dtquery;
        }
    }
   

}
