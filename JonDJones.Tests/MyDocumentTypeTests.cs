using FluentAssertions;
using JonDJones.Website.Code;
using Moq;
using NUnit.Framework;
using System.Reflection;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace JonDJones.Tests;

[TestFixture]
public class MyDocumentTypeTests
{
    private MyDocumentType? _myDocumentType;
    private Mock<IPublishedContent>? _mockedPublishedContent;

    [SetUp]
    public void Init()
    {
        _mockedPublishedContent = new Mock<IPublishedContent>();

        _myDocumentType = new MyDocumentType(
            _mockedPublishedContent.Object,
            Mock.Of<IPublishedValueFallback>());

        var property = new Mock<IPublishedProperty>();
        property.Setup(x => x.Alias).Returns("Prop");
        property.Setup(x => x.GetValue(It.IsAny<string?>(), It.IsAny<string?>())).Returns("ValueOne");

        var pInfo = typeof(MyDocumentType).GetProperty(nameof(MyDocumentType.Props)).GetCustomAttribute<ImplementPropertyTypeAttribute>();
        _mockedPublishedContent.Setup(x => x.GetProperty(pInfo.Alias)).Returns(property.Object);
    }

    [Test]
    public void BasicTest()
    {
        var myViewModel = new ExampleViewModel(_myDocumentType);
        myViewModel.Prop.Should().Be("ValueOne");
    }
}
