//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyNhaHang
{
    using System;
    using System.Collections.Generic;
    
    public partial class SANPHAM
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string MaLoaiSP { get; set; }
        public string TenLoaiSP { get; set; }
        public Nullable<double> GiaSP { get; set; }
        public byte[] AnhSP { get; set; }
    
        public virtual DANHMUC DANHMUC { get; set; }
    }
}
