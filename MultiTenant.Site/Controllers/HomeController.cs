﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Models;
using MultiTenant.Service.Interfaces;

namespace MultiTenant.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ITenantService tenantService) : base(tenantService)
        {
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            BaseViewModel model = new BaseViewModel();
            model.CurrentTenant = CurrentTenant;
            return View("Index", model);
        }

    }
}
