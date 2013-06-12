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
    public class TraitRepository : ITraitRepository 
    {
        private static TraitRepository _instance = new TraitRepository();
        public static TraitRepository Instance { get { return _instance; }}
        private ICollection<Trait> _addTraits; 
        private ICollection<Trait> _viewTraits;
        
        static TraitRepository() {}
        private TraitRepository()
        {
            _addTraits = new Collection<Trait>();
            _viewTraits = new Collection<Trait>();

            _addTraits.Add(new Trait
            {
                Id = 1,
                Name = "Trait 1"
            });
            _addTraits.Add(new Trait
            {
                Id = 2,
                Name = "Trait 2"
            });
            _addTraits.Add(new Trait
            {
                Id = 3,
                Name = "Trait 3"
            });

            _viewTraits.Add(new Trait
            {
                Id = 4,
                Name = "Trait 4"
            });
            _viewTraits.Add(new Trait
            {
                Id = 5,
                Name = "Trait 5"
            });
            _viewTraits.Add(new Trait
            {
                Id = 6,
                Name = "Trait 6"
            });
        }

        public IEnumerable<Trait> GetAddTraits()
        {
            return _addTraits;
        } 

        public IEnumerable<Trait> GetViewTraits()
        {
            return _viewTraits;
        } 
    }
}
