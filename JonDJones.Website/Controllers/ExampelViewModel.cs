using Umbraco.Cms.Web.Common.PublishedModels;

namespace JonDJones.Website.Controllers;

public class ExampleViewModel(MyDocumentType documentType)
{
    public string Prop { get; set; } = documentType.Props.ToString();
}
