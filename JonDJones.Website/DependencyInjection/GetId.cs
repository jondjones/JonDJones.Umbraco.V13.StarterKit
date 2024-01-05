namespace JonDJones.Website.DependencyInjection;

public class GetId : ISingleton, ITransient, IScoped
{
    public GetId()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Id { get; }
}