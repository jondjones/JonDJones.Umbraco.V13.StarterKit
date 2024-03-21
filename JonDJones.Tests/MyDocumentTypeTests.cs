using FluentAssertions;
using JonDJones.Website.Controllers.ViewModels;
using Moq;
using NUnit.Framework;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace JonDJones.Tests;

[TestFixture]
public class MyDocumentTypeTests
{
    private Homepage _myDocumentType;
    private Mock<IPublishedContent> _mockedPublishedContent;


    [SetUp]
    public void Init()
    {
        var property = new Mock<IPublishedProperty>();
        property.Setup(x => x.Alias).Returns("Prop");
        property.Setup(x => x.GetValue(It.IsAny<string>(), It.IsAny<string>())).Returns("ValueOne");

        _mockedPublishedContent = new Mock<IPublishedContent>();
        _mockedPublishedContent.Setup(x => x.GetProperty("prop")).Returns(property.Object);

        _myDocumentType = new Homepage(
            _mockedPublishedContent.Object,
            Mock.Of<IPublishedValueFallback>());
    }

    [Test]
    public void BasicTest()
    {
        var myViewModel = new ExampleViewModel(_myDocumentType);
        myViewModel.Prop.Should().Be("ValueOne");
    }
}