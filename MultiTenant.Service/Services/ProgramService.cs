using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Repository.Interfaces;
using MultiTenant.Repository.Repositories;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Service.Services
{
    public class ProgramService : IProgramService
    {
        private IProgramRepository _programRepository;
        public ProgramService()
        {
            _programRepository = ProgramRepository.Instance;
        }
        public IEnumerable<KeyValuePair<int, string>> GetProgramItems()
        {
            return _programRepository.GetProgramItems();
        }
    }
}
