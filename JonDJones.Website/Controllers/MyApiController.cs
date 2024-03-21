using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;

namespace JonDJones.Website.Controllers;

public class MyApiController : UmbracoApiController
{
	public string ExampleOne()
	{
		return "Hello";
	}

	[HttpGet]
	public JsonResult ExampleTwo()
	{
		string[] test = ["1", "3"];
		return new JsonResult(test);
	}
}
