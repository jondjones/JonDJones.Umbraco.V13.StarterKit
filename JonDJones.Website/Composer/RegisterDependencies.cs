using JonDJones.Website.DependencyInjection;
using Umbraco.Cms.Core.Composing;

namespace JonDJones.Core.Composers;

public class RegisterDependencies : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddTransient<ITransient, GetId>();

        builder.Services.AddScoped<IScoped, GetId>();

        builder.Services.AddSingleton<ISingleton, GetId>();

        //// Use Scrutor to auto discover and auto wire - up configuration
        //builder.Services.Scan(scan => scan
        //        .FromAssemblies(
        //            typeof(IMyInterface).Assembly
        //        )
        //        .AddClasses()
        //        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        //        .AsImplementedInterfaces()
        //        .WithTransientLifetime());
    }
}