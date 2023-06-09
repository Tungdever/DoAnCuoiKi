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
