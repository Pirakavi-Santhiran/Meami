//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Meami.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Field is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Code Field is Required")]
        public string Code { get; set; }
        public string Mobile { get; set; }
        public string ProductCode { get; set; }
    }

 

}