using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenant.Repository.Interfaces;

namespace MultiTenant.Repository.Repositories
{
    public class SurveyRepository : ISurveyRepository 
    {
        private static SurveyRepository _instance = new SurveyRepository();
        public static SurveyRepository Instance { get { return _instance; } }
        private readonly ICollection<KeyValuePair<int, string>> _surveyItems; 
        static SurveyRepository() {}
        private SurveyRepository()
        {
            _surveyItems = new Collection<KeyValuePair<int, string>>();

            _surveyItems.Add(new KeyValuePair<int, string>(1, "Survey 1"));
            _surveyItems.Add(new KeyValuePair<int, string>(2, "Survey 2"));
            _surveyItems.Add(new KeyValuePair<int, string>(3, "Survey 3"));
        }
        public IEnumerable<KeyValuePair<int, string>> GetSurveyItems()
        {
            return _surveyItems;
        }
    }
}
