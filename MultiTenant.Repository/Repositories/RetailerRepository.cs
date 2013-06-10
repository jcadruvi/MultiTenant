using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Model;
using MultiTenant.Repository.Interfaces;

namespace MultiTenant.Repository.Repositories
{
    public class RetailerRepository : IRetailerRepository
    {
        private static RetailerRepository _instance = new RetailerRepository();
        private ICollection<Retailer> _retailers;
        static RetailerRepository(){}
        private RetailerRepository()
        {
            _retailers = new Collection<Retailer>();

            _retailers.Add(new Retailer
            {
                Id = 1,
                Name = "Best Buy",
                Number = "1"
            });
            _retailers.Add(new Retailer
            {
                Id = 2,
                Name = "Frys",
                Number = "2"
            });
            _retailers.Add(new Retailer
            {
                Id = 3,
                Name = "Wal Mart",
                Number = "3"
            });
        }
        public static RetailerRepository Instance { get { return _instance; } }

        public IEnumerable<Retailer> GetAll()
        {
            return _retailers;
        }
    }
}
