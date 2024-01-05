using FluentAssertions;
using JonDJones.Website.Code;
using Newtonsoft.Json;
using NUnit.Framework;

namespace JonDJones.Tests;

[TestFixture]
public class MyApiControllerTests
{
    private MyApiController? _myController;

    [SetUp]
    public void Init()
    {
        _myController = new MyApiController();
    }

    [Test]
    public void ExampleOne_Has_Value()
    {
        var result = _myController.ExampleOne();
        result.Should().Be("Hello");
    }

    [Test]
    public void ExampleTwo_Has_Value()
    {
        var json = JsonConvert.SerializeObject(_myController.ExampleTwo().Value);
        json.Should().Be("[\"1\",\"3\"]");
    }
}
