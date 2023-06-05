using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.BS_layer
{
     class BLTblDetail
    {
        public bool AddTblDetail(int MainID, string ProID, string ProName, int qty, float price, float amount, ref string err)
        {
            using (QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities())
            {
                try
                {
                    tblDetail detail = new tblDetail();
                    detail.MaBill = MainID;
                    detail.proID = ProID;
                    detail.proName = ProName;
                    detail.qty = qty;
                    detail.price = price;
                    detail.amount = amount;

                    qlnhEntity.tblDetails.Add(detail);
                    qlnhEntity.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                    return false;
                }
            }
        }

        public bool UpdateTblDetail(int DetailID, int MainID, string ProID, string ProName, int qty, float price, float amount, ref string err)
        {
            using (QuanLyNhaHangEntities qlnhEntity = new QuanLyNhaHangEntities())
            {
                try
                {
                    var detail = qlnhEntity.tblDetails.SingleOrDefault(d => d.DetailID == DetailID);
                    if (detail != null)
                    {
                        detail.MaBill = MainID;
                        detail.proID = ProID;
                        detail.proName = ProName;
                        detail.qty = qty;
                        detail.price = price;
                        detail.amount = amount;

                        qlnhEntity.SaveChanges();

                        return true;
                    }
                    else
                    {
                        err = "DetailID not found";
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                    return false;
                }
            }
        }


    }
}
