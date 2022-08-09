namespace MinimalApiWithMediatr.Common.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CommandAttribute : Attribute
{
    public CommandAttribute(string route, CommandType type = CommandType.POST)
    {
        (Route, Type) = (route, type);
    }

    public string Route { get; }
    public CommandType Type { get; }
}

public enum CommandType
{
    POST,
    PUT,
    DELETE
}