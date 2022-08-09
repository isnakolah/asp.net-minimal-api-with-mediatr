namespace MinimalApiWithMediatr.Common.Models;

public abstract record BaseEntity
{
    public Guid Id { get; set; }
};