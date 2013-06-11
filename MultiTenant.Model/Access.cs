using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Model
{
    public class Access
    {
        public int TenantId { get; set; }
        public string Type { get; set; }
        public bool HasAccess { get; set; }
    }
}
