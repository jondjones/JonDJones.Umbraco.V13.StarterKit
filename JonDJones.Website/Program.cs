using JonDJones.Website.Composer;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.CreateUmbracoBuilder()
	.AddBackOffice()
	.AddWebsite()
	.AddDeliveryApi()
	.AddComposers()
	.Build();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseExceptionHandler("/500.html");

app.UseUmbraco()
	.WithMiddleware(u =>
	{
		u.UseBackOffice();
		u.UseWebsite();
	})
	.WithEndpoints(u =>
	{
		u.UseCustomRoutingRules();
		u.UseInstallerEndpoints();
		u.UseBackOfficeEndpoints();
		u.UseWebsiteEndpoints();
	});

await app.RunAsync();
