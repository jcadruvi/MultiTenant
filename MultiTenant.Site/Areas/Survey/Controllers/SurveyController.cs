using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Controllers;
using MultiTenant.Models;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Areas.Survey.Controllers
{
    public class SurveyController : BaseController
    {
        public SurveyController(ITenantService tenantService) : base(tenantService)
        {
        }
        //
        // GET: /Survey/Survey/

        public ActionResult Survey()
        {
            BaseViewModel model = new BaseViewModel();
            model.CurrentTenant = CurrentTenant;
            return View("Survey", model);
        }

    }
}
