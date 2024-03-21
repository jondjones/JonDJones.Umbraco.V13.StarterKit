using FluentAssertions;
using JonDJones.Website.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;

namespace JonDJones.Tests;

[TestFixture]
public class MySurfaceControllerTests
{
    private MySurfaceController? _myController;

    [SetUp]
    public void Init()
    {
        _myController = new(
            Mock.Of<IUmbracoContextAccessor>(),
            Mock.Of<IUmbracoDatabaseFactory>(),
            ServiceContext.CreatePartial(),
            AppCaches.NoCache,
            Mock.Of<IProfilingLogger>(),
            Mock.Of<IPublishedUrlProvider>());
    }

    [Test]
    public void PassesBackCorrectModel()
    {
        var result = (ContentResult)_myController.Submit();
        result.Should().NotBeNull();
        result.Content.Should().Be("Hello!");
    }
}
