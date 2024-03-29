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

    public partial class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Code Field is Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name Field is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price Field is Required")]
        public Nullable<decimal> Price { get; set; }
        [Required(ErrorMessage = "Available Count Field is Required")]
        public Nullable<int> Available { get; set; }
    }
}
