// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Microsoft.AspNetCore.Mvc;
using GaCloudServer.STS.Identity.Configuration.Interfaces;

namespace GaCloudServer.STS.Identity.ViewComponents
{
    public class SessionServerAdminLinkViewComponent : ViewComponent
    {
        private readonly IRootConfiguration _configuration;

        public SessionServerAdminLinkViewComponent(IRootConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IViewComponentResult Invoke()
        {
            var sessionAdminUrl = _configuration.AdminConfiguration.SessionAdminBaseUrl;

            return View(model: sessionAdminUrl);
        }
    }
}







