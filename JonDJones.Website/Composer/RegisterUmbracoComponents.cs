using JonDJones.Website.ContentFinder;
using Umbraco.Cms.Core.Composing;

namespace JonDJones.Website.Composer;

public class RegisterUmbracoComponents : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        // Example of to register last chance finder
        builder.SetContentLastChanceFinder<PageNotFoundContentFinder>();
    }
}