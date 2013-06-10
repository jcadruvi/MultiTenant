using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MultiTenant.Model;

namespace MultiTenant.Models
{
    public class BaseViewModel
    {
        public Tenant CurrentTenant { get; set; }
    }
}