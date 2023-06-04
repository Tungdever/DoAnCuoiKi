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
            using (QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext())
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

                    qlNH.tblDetails.InsertOnSubmit(detail);
                    qlNH.SubmitChanges();

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
            using (QuanLyNhaHangDataContext qlNH = new QuanLyNhaHangDataContext())
            {
                try
                {
                    var detail = qlNH.tblDetails.SingleOrDefault(d => d.DetailID == DetailID);
                    if (detail != null)
                    {
                        detail.proID = ProID;
                        detail.proName = ProName;
                        detail.qty = qty;
                        detail.price = price;
                        detail.amount = amount;

                        qlNH.SubmitChanges();

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
