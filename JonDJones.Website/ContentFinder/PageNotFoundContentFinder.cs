using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Web;

namespace JonDJones.Website.ContentFinder;

public class PageNotFoundContentFinder : IContentLastChanceFinder
{
    private readonly IUmbracoContextAccessor _umbracoContextAccessor;

    public PageNotFoundContentFinder(
            IUmbracoContextAccessor umbracoContextAccessor)
    {
        _umbracoContextAccessor = umbracoContextAccessor;
    }

    public Task<bool> TryFindContent(IPublishedRequestBuilder request)
    {
        var notFoundPage = _umbracoContextAccessor.GetRequiredUmbracoContext().Content.GetById(1068);
        request.SetIs404();
        request.SetPublishedContent(notFoundPage);

        return Task.FromResult(true);
    }
}
