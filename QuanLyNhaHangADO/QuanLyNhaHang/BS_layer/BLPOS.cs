﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.BS_layer
{
     class BLPOS
    {
        DAL db = null;

        //Cons
        public BLPOS()
        {
            db = new DAL();
        }
        public DataSet GetProducts()
        {
            return db.ExecuteQueryDataSet("Select * from SANPHAM inner join DanhMuc on MaLoaiSP  = MaDM", CommandType.Text);
        }
    }
}
