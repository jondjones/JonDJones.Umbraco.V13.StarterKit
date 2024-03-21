using JonDJones.Website.Controllers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace JonDJones.Website.ViewComponents;

public class blockViewComponent : ViewComponent
{
	private IUmbracoContextAccessor _context;
	private IPublishedValueFallback _publishedValueFallback;

	public blockViewComponent(IPublishedValueFallback publishedValueFallback, IUmbracoContextAccessor context)
	{
		_context = context;
		_publishedValueFallback = publishedValueFallback;

	}

	public async Task<IViewComponentResult> InvokeAsync(IPublishedElement model)
	{
		var content = new Block(model, _publishedValueFallback);

		var viewModel = new MyViewModel();
		return View(viewModel);
	}
}