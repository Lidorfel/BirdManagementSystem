//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BirdManagementSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bird
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Species { get; set; }
        public string SubSpecies { get; set; }
        public Nullable<System.DateTime> HatchDate { get; set; }
        public string Gender { get; set; }
        public string Cage { get; set; }
        public string Mother { get; set; }
        public string Father { get; set; }
    }
}
