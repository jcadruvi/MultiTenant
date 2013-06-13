using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Controllers
{
    public class SurveyApiController : BaseApiController
    {
        private ISurveyService _surveyService;
        public SurveyApiController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public IEnumerable<KeyValuePair<int, string>> GetSurveyItems()
        {
            return _surveyService.GetSurveyItems();
        } 
    }
}
