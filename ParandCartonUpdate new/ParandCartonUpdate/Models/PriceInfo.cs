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
    
    public partial class PriceInfo
    {
        public int id { get; set; }
        public int whosave { get; set; }
        public Nullable<double> costpervaragh { get; set; }
        public Nullable<double> costofall { get; set; }
        public Nullable<double> malyat { get; set; }
        public Nullable<double> takhfif { get; set; }
        public Nullable<double> sumofall { get; set; }
        public int ProductInfoId { get; set; }
        public string Description { get; set; }
    }
}