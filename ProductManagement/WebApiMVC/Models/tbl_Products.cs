//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Products
    {
        public int Prod_ID { get; set; }
        public string Prod_Name { get; set; }
        public string Prod_Category { get; set; }
        public Nullable<double> Prod_Price { get; set; }
        public Nullable<int> Prod_Quantity { get; set; }
        public string Prod_Short_Des { get; set; }
        public string Prod_Long_Des { get; set; }
        public string Prod_Small_Image { get; set; }
        public string Prod_Large_Image { get; set; }
    }
}