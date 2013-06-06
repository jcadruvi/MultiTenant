using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Model
{
    public class RequestPath
    {
        public int TenantId { get; set; }
        public string OriginalPath { get; set; }
        public string NewPath { get; set; }
    }
}
