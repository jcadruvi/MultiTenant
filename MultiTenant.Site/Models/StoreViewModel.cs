using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MultiTenant.Models
{
    public class StoreViewModel : BaseViewModel
    {
        public string City { get; set; }
        [Required]
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Number { get; set; }
        public string State { get; set; }
    }
}