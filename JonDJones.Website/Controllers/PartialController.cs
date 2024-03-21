using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace JonDJones.Website.Controllers
{
    public class PartialController : Controller
    {
        [HttpGet]
        public ActionResult Index(IPublishedElement item = null, string alias = "")
        {
            if (alias == "block")
            {
            }

            return null;
        }
    }
}