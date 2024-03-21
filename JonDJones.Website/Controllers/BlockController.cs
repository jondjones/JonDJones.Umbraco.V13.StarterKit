using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace JonDJones.Website.Controllers;

public class BlocksExampleController : RenderController
{
    private readonly IPublishedValueFallback _publishedValueFallback;

    public BlocksExampleController(
            ILogger<MyControllerController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IPublishedValueFallback publishedValueFallback)
        : base(logger, compositeViewEngine, umbracoContextAccessor)
    {
        _publishedValueFallback = publishedValueFallback;
    }

    public override IActionResult Index()
    {
        var blocksExample = new BlocksExample(CurrentPage, _publishedValueFallback);
        return View("~/Views/BlocksExample.cshtml", blocksExample);
    }
}
