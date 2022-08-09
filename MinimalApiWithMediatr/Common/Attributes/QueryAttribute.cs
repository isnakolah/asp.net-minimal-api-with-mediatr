namespace MinimalApiWithMediatr.Common.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class QueryAttribute : Attribute
{
    public QueryAttribute(string route)
    {
        Route = route;
    }

    public string Route { get; }
}