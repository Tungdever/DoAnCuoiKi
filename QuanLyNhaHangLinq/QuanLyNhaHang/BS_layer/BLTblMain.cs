using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                         select new { m, d };

            DataTable dt = new DataTable();
            foreach (var item in result.FirstOrDefault().GetType().GetProperties())
            {
                dt.Columns.Add(item.Name, item.PropertyType);
            }

            // Thêm các cột khác tương ứng với các trường trong bảng tblMain và tblDetails

            /*   foreach (var item in result)
               {
                   DataRow row = dt.NewRow();
                   row["MaBill"] = item.m.MaBill;
                   // Gán giá trị các trường khác tương ứng với các trường trong bảng tblMain và tblDetails

                   dt.Rows.Add(row);
               }*/
            // Thêm dữ liệu vào DataTable
            foreach (var item in result.GetType().GetProperties())
            {
                DataRow row = dt.NewRow();
                foreach (var prop in item.GetType().GetProperties())
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                dt.Rows.Add(row);
            }


            /* DataSet ds = new DataSet();
             ds.Tables.Add(dt);

             return ds;*/
            return dt;
        }
        public DataTable GetJoinTABLE(int maBill)
        {
            QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext();
            var joinTableData = from m in qlNH.tblMains
                                join d in qlNH.tblDetails on m.MaBill equals d.MaBill
                                join t in qlNH.BANs on m.TableName equals t.Tname
                                where m.MaBill == maBill
                                select new
                                {
                                    MainTable = m,
                                    DetailsTable = d,
                                    BANTable = t
                                };

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

            return dataTable;
        }
    }
    
}
