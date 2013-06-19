using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiTenant.Models
{
    public class RetailerViewModel: BaseViewModel
    {
        public string CalendarSales { get; set; }
        public string FiscalSales { get; set; }
        public int? Id { get; set; }
        public int? Ipads { get; set; }
        public int? Iphones { get; set; }
        public int? Ipods { get; set; }
        public string OrgLevel { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int? Rank { get; set; }
        public string SubOrgLevel { get; set; }
        public string Type { get; set; }
    }
}