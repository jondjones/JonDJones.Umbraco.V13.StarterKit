using FluentAssertions;
using Moq;
using NUnit.Framework;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Dictionary;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Templates;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;

namespace JonDJones.Tests;

[TestFixture]
public class MockExamples
{
    private Mock<IUmbracoContext>? _umbracoContext;
    private Mock<IPublishedContent>? _publishedContent;
    private UmbracoHelper? _umbracoHelper;

    [SetUp]
    public void Init()
    {
        _umbracoHelper = new UmbracoHelper(
            Mock.Of<ICultureDictionaryFactory>(),
            Mock.Of<IUmbracoComponentRenderer>(),
            Mock.Of<IPublishedContentQuery>());
    }

    [Test]
    public void Data()
    {
        _publishedContent = new Mock<IPublishedContent>();

        _umbracoContext = new Mock<IUmbracoContext>();
        _umbracoContext
            .Setup(x => x.Content.GetById(1))
            .Returns(_publishedContent.Object);

        var data = _umbracoContext.Object.Content.GetById(1);
        data.Should().NotBeNull();
    }

}
