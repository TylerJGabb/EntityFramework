//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseFirst2
{
    using System;
    using System.Collections.Generic;
    
    public partial class QALabTestMap
    {
        public int QALabTest_Number { get; set; }
        public int QALabRequirement_Number { get; set; }
        public int Record_Number { get; set; }
    
        public virtual QALabRequirement QALabRequirement { get; set; }
        public virtual QALabTest QALabTest { get; set; }
    }
}
