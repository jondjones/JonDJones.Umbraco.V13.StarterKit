using System.Web.Mvc;
using Umbraco.Cms.Web.Common.ApplicationBuilder;

namespace JonDJones.Website.Composer;

public static partial class UmbracoApplicationBuilderExtensions
{

    public static IUmbracoEndpointBuilderContext UseCustomRoutingRules(this IUmbracoEndpointBuilderContext app)
    {
        app.EndpointRouteBuilder.MapControllerRoute(
            "PartialController",
            "Partial/{action}/{item}/{alias}",
            new
            {
                controller = "Partial",
                action = "Index",
                item = UrlParameter.Optional,
                alias = UrlParameter.Optional,
            });

        return app;
    }
}
