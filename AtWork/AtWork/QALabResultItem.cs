//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AtWork
{
    using System;
    using System.Collections.Generic;
    
    public partial class QALabResultItem
    {
        public int Record_Number { get; set; }
        public int QALabSessionNumber { get; set; }
        public int QALabRequirement_Number { get; set; }
        public Nullable<decimal> NumericValue { get; set; }
        public Nullable<bool> PassFailValue { get; set; }
        public string StringValue { get; set; }
        public int TestBy { get; set; }
        public System.DateTime TestOn { get; set; }
    
        public virtual QALabRequirement QALabRequirement { get; set; }
    }
}
