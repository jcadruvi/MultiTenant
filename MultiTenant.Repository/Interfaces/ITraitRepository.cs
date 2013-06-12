using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Model;

namespace MultiTenant.Repository.Interfaces
{
    public interface ITraitRepository
    {
        IEnumerable<Trait> GetAddTraits();
        IEnumerable<Trait> GetViewTraits();
    }
}
