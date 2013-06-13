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
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository; 

        public SurveyService()
        {
            _surveyRepository = SurveyRepository.Instance;
        }

        public IEnumerable<KeyValuePair<int, string>> GetSurveyItems()
        {
            return _surveyRepository.GetSurveyItems();
        }
    }
}
