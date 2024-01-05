using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace JonDJones.Website.Code;

public class MySurfaceController : SurfaceController
{
    public MySurfaceController(
        IUmbracoContextAccessor umbracoContextAccessor,
        IUmbracoDatabaseFactory databaseFactory,
        ServiceContext services,
        AppCaches appCaches,
        IProfilingLogger profilingLogger,
        IPublishedUrlProvider publishedUrlProvider)
        : base(
              umbracoContextAccessor,
              databaseFactory,
              services,
              appCaches,
              profilingLogger,
              publishedUrlProvider)
    {
    }

    [HttpPost]
    public IActionResult Submit()
    {
        return Content("Hello!");
    }
}
