using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Repository.Interfaces;

namespace MultiTenant.Repository.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private static ProgramRepository _instance = new ProgramRepository();
        public static ProgramRepository Instance { get { return _instance; } }
        private readonly ICollection<KeyValuePair<int, string>> _programItems; 
        static ProgramRepository() { }
        private ProgramRepository()
        {
            _programItems = new Collection<KeyValuePair<int, string>>();

            _programItems.Add(new KeyValuePair<int, string>(1, "Program 1"));
            _programItems.Add(new KeyValuePair<int, string>(2, "Program 2"));
            _programItems.Add(new KeyValuePair<int, string>(3, "Program 3"));
        }

        public IEnumerable<KeyValuePair<int, string>> GetProgramItems()
        {
            return _programItems;
        }
    }
}
