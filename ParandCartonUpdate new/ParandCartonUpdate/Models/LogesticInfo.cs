//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParandCartonUpdate.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LogesticInfo
    {
        public int Id { get; set; }
        public int OrderInfoId { get; set; }
        public int PrintInfoId { get; set; }
        public Nullable<bool> LayoutType { get; set; }
        public Nullable<int> LayoutCount { get; set; }
        public Nullable<bool> TypeOfUse { get; set; }
        public Nullable<int> ProductDistance { get; set; }
        public Nullable<bool> DeliveryMethod { get; set; }
        public Nullable<int> AnbareshTime { get; set; }
        public string SendMethod { get; set; }
        public string LogesticTypeSelection { get; set; }
        public string Humidity { get; set; }
        public Nullable<bool> UseAddress { get; set; }
        public string OtherAddress { get; set; }
        public Nullable<int> WhoSave { get; set; }
    
        public virtual OrderInfo OrderInfo { get; set; }
    }
}
