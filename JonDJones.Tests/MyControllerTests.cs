using FluentAssertions;
using JonDJones.Website.Code;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Umbraco.Cms.Core.Web;

namespace JonDJones.Tests;

[TestFixture]
public class MyControllerTests
{
    private MyController? _myController;
    private Mock<ILogger<MyController>>? _renderController;
    private Mock<ICompositeViewEngine>? _compositeViewEngine;
    private Mock<IUmbracoContextAccessor>? _umbracoContextAccessor;

    [SetUp]
    public void Init()
    {
        _renderController = new Mock<ILogger<MyController>>();
        _compositeViewEngine = new Mock<ICompositeViewEngine>();
        _umbracoContextAccessor = new Mock<IUmbracoContextAccessor>();

        _myController = new MyController(
          _renderController.Object,
          _compositeViewEngine.Object,
          _umbracoContextAccessor.Object);
    }

    [Test]
    public void PassesBackCorrectModel()
    {
        var result = (Microsoft.AspNetCore.Mvc.ViewResult)_myController.Index();
        var myModel = (MyViewModel)result.Model;
        myModel.Should().NotBeNull();
    }
}
