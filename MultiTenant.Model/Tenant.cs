using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Model
{
    public class Tenant
    {
        public string Host { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
