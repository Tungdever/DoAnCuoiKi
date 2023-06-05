using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.BS_layer
{
     class BLTblMain
    {

        public List<tblMain> GetOrders()
        {
            using (QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities())
            {
                var query = from order in qlnhEntity.tblMains
                            where order.status == "Pending"
                            select order;

                return query.ToList();
            }
        }
        public int AddTblMain(DateTime date, string time, string TableName, string WaiterName, string Status, string orderType, double Total, double received, double change, string driverID, string cusName, string cusPhone, ref string err)
        {
            try
            {
                QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();

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

                qlnhEntity.tblMains.Add(newOrder);
                qlnhEntity.SaveChanges();

                return newOrder.MaBill; // Trả về Id của bản ghi mới thêm vào
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return -1; // Trả về -1 nếu có lỗi xảy ra
            }
        }
        /*public List<tblMain> GetBills()
        {
            using (QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities())
            {
                var bills = qlnhEntity.tblMains
                    .Where(m => m.status != "Pending")
                    .Select(m => new tblMain
                    {
                        MaBill = m.MaBill,
                        TableName = m.TableName,
                        WaiterName = m.WaiterName,
                        aTime = m.aTime,
                        orderType = m.orderType,
                        status = m.status,
                        total = m.total
                    })
                    .ToList();

                return bills;
            }
        }*/
        public DataTable GetBills()
        {
            using (QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities())
            {
                var result = from m in qlnhEntity.tblMains
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
        }


        public bool UpdateTblMain(int MainID, DateTime date, string time, string TableName, string WaiterName, string Status, string orderType, double Total, double received, double change, ref string err)
        {
            try
            {
                QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();

                var existingOrder = qlnhEntity.tblMains.SingleOrDefault(o => o.MaBill == MainID);

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

                    qlnhEntity.SaveChanges();

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
                QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();

                var order = qlnhEntity.tblMains.SingleOrDefault(o => o.MaBill == MaBill);

                if (order != null)
                {
                    order.status = "Complete";
                    qlnhEntity.SaveChanges();

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
                QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();

                var order = qlnhEntity.tblMains.SingleOrDefault(o => o.MaBill == MaBill);

                if (order != null)
                {
                    order.total = total;
                    order.received = received;
                    order.change = change;
                    order.status = status;

                    qlnhEntity.SaveChanges();

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
            QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities();

            var result = from m in qlnhEntity.tblMains
                         join d in qlnhEntity.tblDetails on m.MaBill equals d.MaBill
                         where m.MaBill == MaBill
                         select new
                         {
                             m.MaBill,
                             m.aDate,
                             m.aTime,
                             m.TableName,
                             m.WaiterName,
                             m.status,
                             m.orderType,
                             m.total,
                             m.received,
                             m.change,
                             m.driverID,
                             m.cusName,
                             m.cusPhone,
                             d.DetailID,
                             d.proID,
                             d.proName,
                             d.qty,
                             d.price,
                             d.amount
                         };

            DataTable dt = new DataTable();
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
        public DataTable GetJoinTABLE(int maBill)
        {
            using (QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities())
            {
                var joinTableData = from m in qlnhEntity.tblMains
                                    join d in qlnhEntity.tblDetails on m.MaBill equals d.MaBill
                                    join t in qlnhEntity.BANs on m.TableName equals t.Tname
                                    where m.MaBill == maBill
                                    select new
                                    {
                                        m.TableName,
                                        m.MaBill,
                                        m.WaiterName,
                                        m.orderType,
                                        d.DetailID,
                                        d.proName,
                                        d.proID,
                                        d.qty,
                                        d.price,
                                        d.amount,
                                        t.Tid,
                                        t.Tstate
                                    };

                DataTable dt = new DataTable();

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
        }



    }
}
