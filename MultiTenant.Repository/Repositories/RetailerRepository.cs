using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Repository.Repositories
{
    public class RetailerRepository
    {
        private static RetailerRepository _instance = new RetailerRepository();
        static RetailerRepository(){}
        private RetailerRepository(){}
        public static RetailerRepository Instance { get { return _instance; } }
    }
}
