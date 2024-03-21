using Umbraco.Cms.Web.Common.PublishedModels;

namespace JonDJones.Website.Controllers.ViewModels;

public class ExampleViewModel(Homepage documentType)
{
    public string Prop { get; set; } = documentType.TextEditor.ToString();
}
