using AutoMapper;

namespace MinimalApiWithMediatr.Common.Mappings;

public static class Mapper
{
    public static IMapper? Instance { get; private set; }

    public static void UseMapper(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        Instance = scope.ServiceProvider.GetRequiredService<IMapper>();
    }
}