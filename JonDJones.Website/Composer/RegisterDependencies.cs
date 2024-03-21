using Scrutor;
using Umbraco.Cms.Core.Composing;

namespace JonDJones.Core.Composers;

public class RegisterDependencies : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.Scan(scan => scan
            .FromAssemblies(
                typeof(IMyInterface).Assembly
            )
            .AddClasses()
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithTransientLifetime());
    }
}