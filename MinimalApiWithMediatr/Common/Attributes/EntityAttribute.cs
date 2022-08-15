namespace MinimalApiWithMediatr.Common.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class EntityAttribute : Attribute
{
    public bool IsTemporal { get; set; }
}